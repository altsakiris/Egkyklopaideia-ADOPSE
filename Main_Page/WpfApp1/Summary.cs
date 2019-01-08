using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using HtmlAgilityPack;


namespace Egkyklopaideia
{
    class Summary
    {
        static HttpClient client = new HttpClient();
        public async Task SummaryReturnAsync(String es)
        {
            HttpResponseMessage response = await client.GetAsync(es);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(responseBody);
            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"readable\"]").First();
            string readable = htmlNodes.InnerText;
            Form1.Rbody = readable;
        }
    }
}
