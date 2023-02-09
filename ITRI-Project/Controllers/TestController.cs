using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ITRI_Project.Data;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;
using System.Security.Claims;
using System.Text.Unicode;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Text;

namespace ITRI_Project.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/<TestController>
        [HttpGet("t2s")]
        public async Task<IActionResult> TextToSound()
        {
            RepBase rep = new RepBase();
            var config = SpeechConfig.FromSubscription(ConstParameter.AZURE_KEY, ConstParameter.AZURE_AREA);
            //config.SpeechSynthesisVoiceName = "zh-CN-XiaoxiaoNeural";
            
            using var audioConfig = AudioConfig.FromWavFileOutput("./StaticPublic/output.wav");
            using var synthesizer = new SpeechSynthesizer(config, null);
            
            string ssml = System.IO.File.ReadAllText("./StaticPublic/ssml/n5.xml", Encoding.UTF8);
            ssml = String.Format(ssml, "大家好我是張大頭");
            var result = await synthesizer.StartSpeakingSsmlAsync(ssml);

            using var stream = AudioDataStream.FromResult(result);
            await stream.SaveToWaveFileAsync("./StaticPublic/output.wav");

            rep.Result = true;
            return Ok(rep);
        }

        [HttpPost("s2t")]
        public async Task<IActionResult> SoundToText(IFormCollection post)
        {
            RepData<string> rep = new RepData<string>();

            try
            {
                var recode = post.Files["recode"];
                if (recode?.Length <= 0 || recode == null)
                {
                    throw new Exception("The recode is empty");
                }

                var path = "./upload.wav";
                using var stream = System.IO.File.Create(path);
                recode.CopyTo(stream);
                stream.Close();

                var config = SpeechConfig.FromSubscription(ConstParameter.AZURE_KEY, ConstParameter.AZURE_AREA);
                config.SpeechSynthesisVoiceName = "en-US";
                using var audioConfig = AudioConfig.FromWavFileInput("./upload.wav");
                using var recognizer = new SpeechRecognizer(config, audioConfig);

                var result = await recognizer.RecognizeOnceAsync();
                rep.Data = result.Text;
                rep.Result = true;


            }
            catch(Exception e)
            {
                rep.Msg = e.Message;
            }
            return Ok(rep);
        }
    }
}
