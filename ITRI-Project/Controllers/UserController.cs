using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ITRI_Project.Data;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;
using System.Security.Claims;
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
    public class UserController : ControllerBase
    {
        private readonly JwtHelper _jwt;
        private readonly ITRIContext _context;
        public UserController(ITRIContext context, JwtHelper jwt)
        {
            _jwt = jwt;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] dynamic value)
        {
            RepData<string> rep = new RepData<string>();
            JsonElement root = value;

            try
            {
                UserInfo newUser = new UserInfo();
                newUser.Guid = GetShortGUID();
                newUser.Name = root.GetProperty("Name").GetString();
                newUser.Mail = root.GetProperty("Mail").GetString();
                newUser.Phone = root.GetProperty("Phone").GetString();
                newUser.Zodiac = root.GetProperty("Zodiac").GetString();
                
                newUser.Birthday = DateTime.Now;

                var UserInfo = _context.UserInfo.AsNoTracking().FirstOrDefault(b=>b.Mail == newUser.Mail);

   

                //if (UserInfo != null)
                //{
                //    rep.Msg = "Mail dubplicate";
                //}
                //else
                //{
                    _context.UserInfo.Add(newUser);
                    await _context.SaveChangesAsync();

                    //Name
                    foreach (var iter in ConstParameter.GENERATE_NAME_QUESTION)
                    {
                        await CreateDefaultAudio(iter.Value, newUser.Guid, newUser.Name);
                        await Task.Delay(100);
                    }

                    //Name REP
                    foreach (var iter in ConstParameter.GENERATE_NAME_RESPONSE)
                    {
                        await CreateDefaultAudio(iter.Value, newUser.Guid, newUser.Name);
                        await Task.Delay(100);
                    }

                    //Zodiac
                    foreach (var iter in ConstParameter.GENERATE_ZODIAC_QUESTION)
                    {
                        await CreateDefaultAudio(iter.Value, newUser.Guid, newUser.Zodiac);
                        await Task.Delay(100);
                    }

                    //Mail REP
                    foreach (var iter in ConstParameter.GENERATE_MAIL_RESPONSE)
                    {
                        await CreateDefaultAudio(iter.Value, newUser.Guid, newUser.Mail);
                        await Task.Delay(100);
                    }

                    rep.Result = true;
                    rep.Data = newUser.Guid;
                //}
            }
            catch(Exception e)
            {
                rep.Msg = e.Message;
            }


            return Ok(rep);

        }

        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult GetToken([FromBody] dynamic value)
        {
            JsonElement root = value;
            RepData<string> rep = new RepData<string>();
            
            try
            {
                string? GUID = root.GetProperty("guid").GetString();
                var UserInfo = _context.UserInfo.AsNoTracking().FirstOrDefault(b => b.Guid == GUID);

                if(GUID == null)
                {
                    throw new Exception("GUID is Null");
                }

                if(UserInfo == null)
                {
                    throw new Exception("Can't Found User Account");
                }
                else
                {
                    rep.Data = _jwt.GenerateToken(GUID, UserInfo.Name, UserInfo.Mail);
                    rep.Result = true;
                }
            }
            catch (Exception e)
            {
                rep.Msg = e.Message;
            }
            if(rep.Result)
            {
                return Ok(rep);
            }
            else
            {
                return Unauthorized();
            }
            
        }

        [AllowAnonymous]
        [HttpPost("test")]
        public async Task<IActionResult> Test([FromBody] dynamic value)
        {
            RepData<string> rep = new RepData<string>();
            JsonElement root = value;

            try
            {
                string guid = root.GetProperty("GUID").GetString();
                var UserInfo = _context.UserInfo.AsNoTracking().FirstOrDefault(b => b.Guid == guid);

                if(UserInfo == null)
                {
                    throw (new Exception("Canot found GUID"));
                }



                //Name
                foreach (var iter in ConstParameter.GENERATE_NAME_QUESTION_FIX)
                {
                    await CreateDefaultAudio(iter.Value, UserInfo.Guid, UserInfo.Name);
                    await Task.Delay(100);
                }

                rep.Result = true;
                rep.Data = UserInfo.Guid;
            }
            catch (Exception e)
            {
                rep.Msg = e.Message;
            }


            return Ok(rep);

        }

        [HttpGet]
        public IActionResult GetUserData()
        {
            RepObject<UserInfoRep> rep = new RepObject<UserInfoRep>();
            try
            {
                string GUID = User.Identity.Name;
                var UserInfo = _context.UserInfo.AsNoTracking().FirstOrDefault(b => b.Guid == GUID);


                if (UserInfo == null)
                {
                    throw new Exception("Can't Found User Account");
                }

                rep.Data.ID = UserInfo.Guid;
                rep.Data.Name = UserInfo.Name;
                rep.Data.Mail = UserInfo.Mail;
                rep.Data.Phone = UserInfo.Phone;
                rep.Data.Zodiac = UserInfo.Zodiac;
                rep.Data.Birthday = UserInfo.Birthday.ToString();
                rep.Data.NowMapType = UserInfo.NowMapType;
                rep.Data.PassNode = JsonSerializer.Deserialize<List<int>>(UserInfo.PassNode);


                rep.Result = true;
            }
            catch (Exception e)
            {
                rep.Msg = e.Message;
            }
            return Ok(rep);
        }

        [HttpGet("reset")]
        public IActionResult ResetUserState()
        {
            RepBase rep = new RepBase();
            try
            {
                string GUID = User.Identity.Name;
                var UserInfo = _context.UserInfo.FirstOrDefault(b => b.Guid == GUID);
                UserInfo.PassNode = "[]";
                UserInfo.NowMapType = 1;
                _context.SaveChanges();

                rep.Result = true;
            }catch(Exception e)
            {
                rep.Msg = e.Message;
            }

            return Ok(rep);

        }

        [HttpGet("record")]
        public IActionResult GetUserNodeRecord()
        {
            RepObject<List<Record>> rep = new RepObject<List<Record>>();

            try
            {
                string GUID = User.Identity.Name;
                var UserInfo = _context.UserInfo.AsNoTracking().FirstOrDefault(b => b.Guid == GUID);


                if (UserInfo == null)
                {
                    throw new Exception("Can't Found User Account");
                }

                rep.Data = _context.Records.AsNoTracking().Where(b => b.Guid == GUID).OrderBy(b=>b.CreateTime).ToList();
                rep.Result = true;
            }
            catch (Exception e)
            {
                rep.Msg = e.Message;
            }
            return Ok(rep);
        }

        public async Task CreateDefaultAudio(GenerateUnit unit, string guid, string value)
        {
            string text = string.Format(unit.format, value);
            string outputPath = string.Format("./wwwroot/audios/audios/{0}-{1}.wav", guid, unit.key);
            string ssmlPath = string.Format("./StaticPublic/ssml/{0}.xml", unit.voiceType);
            string ssml = System.IO.File.ReadAllText(ssmlPath, Encoding.UTF8);
            ssml = String.Format(ssml, text);

            var config = SpeechConfig.FromSubscription(ConstParameter.AZURE_KEY, ConstParameter.AZURE_AREA);
            using var synthesizer = new SpeechSynthesizer(config, null);
            
            var result = await synthesizer.SpeakSsmlAsync(ssml);

            using var stream = AudioDataStream.FromResult(result);
            await stream.SaveToWaveFileAsync(outputPath);
        }

        public static string GetShortGUID()
        {
            string guid = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            guid = guid.Replace("/", "_").Replace("+", "-").Substring(0, 22);
            return guid;
        }
    }



    
}
