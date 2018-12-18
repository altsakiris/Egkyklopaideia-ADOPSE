using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace Egkyklopaideia
{
    class DailyArticleCreator
    {
        public  void LoadJson()
        {
            StreamWriter sWrite = new StreamWriter("C:\\Users\\PAOK-\\Source\\Repos\\atsakiris\\Egkyklopaideia-ADOPSE\\Main_Page\\WpfApp1\\Daily.html");
            DateTime today = DateTime.Today;
            String premade = "";
            sWrite.WriteLine(" <!DOCTYPE html>");
            sWrite.WriteLine("<html>");
            sWrite.WriteLine("<head>");
            sWrite.WriteLine("<meta name='viewport' content='width'='device-width, initial-scale = 1.0'>");
            sWrite.WriteLine("</head>");
            sWrite.WriteLine("<bocy>");
            sWrite.WriteLine("<ul>");
            using (StreamReader r = new StreamReader("C:\\Users\\PAOK-\\Source\\Repos\\atsakiris\\Egkyklopaideia-ADOPSE\\Main_Page\\WpfApp1\\examples.json"))
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<JsonDeserializer>>(json);
                foreach (var item in items)
                {
                       if(item.day==today.Day && item.month == today.Month)
                    {
                        premade ="<li>"+ item.year + " <a href='"+item.link+"'>"+item.title+"</a></li>";
                        sWrite.WriteLine(premade);
                    }
                }
            }
            sWrite.WriteLine("</ul>");
            sWrite.WriteLine("</body>");
            sWrite.WriteLine("</html>");
            sWrite.Close();

        }
    }
}

