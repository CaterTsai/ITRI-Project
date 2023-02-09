using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ITRI_Project.Data;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;
using System.Security.Claims;
using System.Text.Unicode;
using ITRI_Project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

using System.Text;

namespace ITRI_Project.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [Authorize(Roles = "User")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly JwtHelper _jwt;
        private readonly ITRIContext _context;
        public MapController(ITRIContext context, JwtHelper jwt)
        {
            _jwt = jwt;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetNodeList()
        {
            RepObject<List<Map>> rep = new RepObject<List<Map>>();
            try
            {
                var NodeList = _context.Map.AsNoTracking().ToList();

                foreach(var iter in NodeList)
                {
                    rep.Data.Add(iter);
                }

                rep.Result = true;
            }
            catch (Exception e)
            {
                rep.Msg = e.Message;
            }
            return Ok(rep);
        }

        [HttpGet("{id}")]
        public IActionResult GetNodeScript(int id)
        {
            RepObject<List<Node>> rep = new RepObject<List<Node>>();
            try
            {
                int NodeID = id;
                rep.Data = _context.Nodes.AsNoTracking().Where(b => b.nodeID == NodeID).OrderBy(b => b.orderID).ToList();

                foreach(var iter in rep.Data)
                {
                    if (iter.isGenerate)
                    {
                        iter.questionAudio = String.Format("{0}-{1}.wav", User.Identity.Name, iter.key);
                    }

                    if(iter.type == (int)ConstParameter.ScriptType.eLongVideo)
                    {
                        List<AudioEffectUnit> audioEffect = JsonSerializer.Deserialize<List<AudioEffectUnit>>(iter.scriptParameter);
                        
                        foreach(var effect in audioEffect)
                        {
                            effect.AudioKey = String.Format("{0}-{1}.wav", User.Identity.Name, effect.AudioKey);
                        }
                        iter.scriptParameter = JsonSerializer.Serialize(audioEffect);
                    }
                }

                rep.Result = true;
            }
            catch(Exception e)
            {
                rep.Msg = e.Message;
            }
            return Ok(rep);
        }

        [HttpPost]
        public async Task<IActionResult> UploadResult(IFormCollection form)
        {
            
            RepObject<UploadResponse> rep = new RepObject<UploadResponse>();
            try
            {
                string GUID = User.Identity.Name;
                
                string key = Convert.ToString(form["key"]);
                byte type = Convert.ToByte(form["type"]); 
                

                var UserInfo = _context.UserInfo.AsNoTracking().FirstOrDefault(b => b.Guid == GUID);
                if (UserInfo == null)
                {
                    throw new Exception("Can't Found User Account");
                }

                //Save File
                var recordPath = "";
                if (form.Files.Count > 0)
                {
                    var recode = form.Files["file"];
                    if(recode?.Length <= 0 || recode == null)
                    {
                        throw new Exception("The file is empty");
                    }
                    recordPath = String.Format("./wwwroot/audios/record/{0}-{1}.wav", GUID, key);
                    using var stream = System.IO.File.Create(recordPath);
                    await recode.CopyToAsync(stream);
                    stream.Close();
                }

                var fixedResponse = Convert.ToBoolean(form["hasFixedRep"]);
                if (!fixedResponse)
                {
                    var config = SpeechConfig.FromSubscription(ConstParameter.AZURE_KEY, ConstParameter.AZURE_AREA);
                    if(key == "n6-5")
                    {
                        config.SpeechRecognitionLanguage = "en-US";
                    }
                    else
                    {
                        config.SpeechRecognitionLanguage = "zh-TW";
                    }
                    
                    using var audioConfig = AudioConfig.FromWavFileInput(recordPath);
                    using var recognizer = new SpeechRecognizer(config, audioConfig);

                    var result = await recognizer.RecognizeOnceAsync();

                    string repStr = "" ;
                    string repAudioPath = "";
                    HandleUploadEvent(key, result.Text, UserInfo, ref repStr, ref repAudioPath);
                    rep.Data.Response = repStr;
                    rep.Data.ResponseAudio = repAudioPath;
                }

                Record record = new Record();
                record.Guid = GUID;
                record.Key = key;
                record.Type = type;
                record.Value = Convert.ToString(form["value"]);
                
                _context.Records.Add(record);
                _context.SaveChanges();

                rep.Data.Key = key;
                rep.Result = true;
            }
            catch (Exception e)
            {
                rep.Msg = e.Message;
            }
            return Ok(rep);
        }

        [HttpPut("{id}")]
        public IActionResult NodeFinish(int id)
        {
            RepObject<NodeFinish> rep = new RepObject<NodeFinish>();

            try
            {
                var NodeID = id;
                string GUID = User.Identity.Name;
                var UserInfo = _context.UserInfo.FirstOrDefault(b => b.Guid == GUID);


                if(UserInfo == null)
                {
                    throw new Exception("Can't Found User Account");
                }

                var passNode = JsonSerializer.Deserialize<List<int>>(UserInfo.PassNode);
                
                if(passNode.IndexOf(id) == -1)
                {
                    passNode.Add(id);
                    
                }
                else
                {
                    throw new Exception("This node is pass before");
                }

                byte nowMapType = getUserNowMapType(NodeID, UserInfo.NowMapType, passNode);
                if(nowMapType == 0)
                {
                    throw new Exception("Node Error");
                }
                UserInfo.PassNode = JsonSerializer.Serialize(passNode);
                UserInfo.NowMapType = nowMapType;
                rep.Data.UserMapType = nowMapType;

                if (checkPassNode(passNode))
                {
                    var suggestTime = getFinishTime(_context.Finish.AsNoTracking().ToList().Count + 1);
                    
                    rep.Data.IsFinish = true;
                    rep.Data.Hour = suggestTime.Hour;
                    rep.Data.Minutes = suggestTime.Minute;

                    Finish data = new Finish();
                    data.Guid = GUID;
                    _context.Finish.Add(data);
                }

                _context.SaveChanges();
                rep.Result = true;
            }
            catch(Exception e)
            {
                rep.Msg = e.Message;
            }
            return Ok(rep);
        }


        [HttpPost("script")]
        public async Task<IActionResult> UploadScript(IFormCollection form)
        {
            RepBase rep = new RepBase();

            try
            {
                if (form.Files.Count == 0)
                {
                    throw new Exception("Not Found Script file");
                }

                
                var script = form.Files["script"];
                if (script?.Length <= 0 || script == null)
                {
                    throw new Exception("The script is empty");
                }

                string ScriptJsonSource = "";
                var result = new StringBuilder();
                using (var reader = new StreamReader(script.OpenReadStream()))
                {
                    ScriptJsonSource = reader.ReadToEnd();
                }

                ScriptJsonSource.Replace("\r\n", "");

                var newScriptList = JsonSerializer.Deserialize<List<Node>>(ScriptJsonSource);

                foreach(var newScript in newScriptList)
                {
                    var node = _context.Nodes.Where(b => b.key == newScript.key).SingleOrDefault();
                    if (node == null)
                    {
                        _context.Nodes.Add(newScript);
                    }
                    else
                    {
                        node.orderID = newScript.orderID;
                        node.question = newScript.question;
                        node.questionAudio = newScript.questionAudio;
                        node.response = newScript.response;
                        node.responseAudio = newScript.responseAudio;
                        node.scriptParameter = newScript.scriptParameter;
                        node.hasFixedRep = newScript.hasFixedRep;
                        node.type = newScript.type;
                    }
                    
                }
                await _context.SaveChangesAsync();


                rep.Result = true;

            }
            catch(Exception e)
            {
                rep.Msg = e.Message;
            }

            return Ok(rep);
        }

        private void HandleUploadEvent(string key, string audioMsg, UserInfo user, ref string msg, ref string audio)
        {
            switch (key)
            {
                case "n1-1":
                    {
                        bool isYes = false;
                        bool isNo = false;
                        isYes = (audioMsg.IndexOf("是") != -1) || (audioMsg.IndexOf("對") != -1) || (audioMsg.IndexOf("嗯") != -1);
                        isNo = (audioMsg.IndexOf("不") != -1) || (audioMsg.IndexOf("否") != -1);

                        if (isNo)
                        {
                            msg = string.Format("{0}這是你註冊的Email嗎？", user.Mail);
                            audio = string.Format("{0}-n1-1-mail.wav", user.Guid);
                        }
                        else if(isYes && !isNo)
                        {
                            msg = "終於跟你通上電話了";
                            audio = "n1-1-yes.wav";
                        }
                        else
                        {
                            msg = "收訊可能不夠穩定，不過我有辨識出你的聲音。";
                            audio = "n1-1-other.wav";
                        }

                        break;
                    }
                case "n2-1":
                    {
                        bool isYes = false;
                        bool isNo = false;
                        isYes = (audioMsg.IndexOf("是") != -1) || (audioMsg.IndexOf("對") != -1) || (audioMsg.IndexOf("嗯") != -1);
                        isNo = (audioMsg.IndexOf("不") != -1) || (audioMsg.IndexOf("否") != -1);

                        if (isNo)
                        {
                            msg = string.Format("{0}這是你註冊的Email嗎？", user.Mail);
                            audio = string.Format("{0}-n2-1-mail.wav", user.Guid);
                        }
                        else if (isYes && !isNo)
                        {
                            msg = string.Format("{0}你好", user.Name);
                            audio = string.Format("{0}-n2-1-rep.wav", user.Guid);
                        }
                        else
                        {
                            msg = "好像有點雜音，不過你的聲音我認得。";
                            audio = "n2-1-other.wav";
                        }
                        break;
                    }
                case "n3-1":
                    {
                        bool isYes = false;
                        bool isNo = false;
                        isYes = (audioMsg.IndexOf("是") != -1) || (audioMsg.IndexOf("對") != -1) || (audioMsg.IndexOf("嗯") != -1);
                        isNo = (audioMsg.IndexOf("不") != -1) || (audioMsg.IndexOf("否") != -1);

                        if (isNo)
                        {
                            msg = string.Format("{0}這是你註冊的Email嗎？", user.Mail);
                            audio = string.Format("{0}-n3-1-mail.wav", user.Guid);
                        }
                        else if (isYes && !isNo)
                        {
                            msg = "我差點以為我打錯了";
                            audio = "n3-1-yes.wav";
                        }
                        else
                        {
                            msg = string.Format("{0}，我認得你的聲音", user.Name); ;
                            audio = string.Format("{0}-n3-1-rep.wav", user.Guid);
                        }

                        break;
                    }
                case "n6-5":
                    {
                        bool isOk = false;
                        bool isHey = false;
                        isOk = (audioMsg.ToLower().IndexOf("ok") == -1);
                        isHey = (audioMsg.ToLower().IndexOf("hey") == -1);

                        if (isOk || isHey)
                        {
                            msg = string.Format("{0}密碼正確", user.Name); ;
                            audio = string.Format("{0}-n6-5-rep.wav", user.Guid);
                        }
                        else
                        {
                            msg = "你果然是有機人類";
                            audio = "n6-5-other.wav";
                        }
                        break;
                    }
                
            }
        }

        private bool checkPassNode(List<int> passnode)
        {
            bool result = true;
            for(int i = 3; i <= 7; i++)
            {
                result &= (passnode.IndexOf(i) != -1);
            }
            return result;
        }

        private byte getUserNowMapType(int passNode, byte userMapType, List<int> passnode)
        {
            byte retValue = 0;
            if(userMapType == 1)
            {
                if(passNode == 1)
                {
                    retValue = 2;
                }
            }
            else if(userMapType == 2)
            {
                if(passnode.Count == 6)
                {
                    retValue = 3;
                }
                else
                {
                    retValue = userMapType;
                }
            }
            return retValue;
        }

        private DateTime getFinishTime(int num)
        {
            DateTime now = DateTime.Now;
            int echelon = Math.Max(0, (int)Math.Ceiling((float)num / (float)ConstParameter.ECHELON_NUM) - 1);
            DateTime SuggestTime = new DateTime(now.Year, now.Month, now.Day, 18, 50, 0);
            SuggestTime = SuggestTime.AddMinutes(echelon * ConstParameter.ECHELON_TIME);

            while(SuggestTime <= now)
            {
                SuggestTime = SuggestTime.AddMinutes(ConstParameter.ECHELON_TIME);
            }


            return SuggestTime;

        }
    }
}
