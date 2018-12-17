using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
            responseBody=responseBody.Between("<article>", "</article>");

            p =new Prompt(responseBody);

           
            synth.SetOutputToDefaultAudioDevice();
            synth.SpeakAsync(p);
            
        }
        public async Task TtsStop()
        {
            synth.SpeakAsyncCancel(p);

        }



    }
}
