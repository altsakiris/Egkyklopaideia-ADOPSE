using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Net.Http;
using System.Net.Http.Headers;
using HtmlAgilityPack;


namespace Egkyklopaideia
{
    class TextToSpeech
    {
        static HttpClient client = new HttpClient();
        Prompt p;
        SpeechSynthesizer synth = new SpeechSynthesizer();
        public async Task TtsRead(String es)
        {
            
            HttpResponseMessage response = await client.GetAsync(es);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(responseBody);
            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"readable\"]");
            string readable = "";
            foreach (var node in htmlNodes)
            {
                readable += node.InnerText;
            }

            p =new Prompt(readable);

           
            synth.SetOutputToDefaultAudioDevice();
            synth.SpeakAsync(p);
            
        }
        public async Task TtsStop()
        {
            synth.SpeakAsyncCancel(p);

        }



    }
}
