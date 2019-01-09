using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Egkyklopaideia
{
    public partial class FirstCustomControl : UserControl
    {
        TextToSpeech Reader = new TextToSpeech();
        SqlConn conn = new SqlConn();
        List<GroupBox> groupBoxes = new List<GroupBox>();
        List<Label> LabeList = new List<Label>();
        List<Button> ButtonList = new List<Button>();
        private string openMore,openMore2,openMore3;
        public static string somethingOpen;
        public FirstCustomControl()
        {
            InitializeComponent();
            groupBoxes.Add(groupBox1);
            groupBoxes.Add(groupBox2);
            groupBoxes.Add(groupBox3);
            LabeList.Add(label1);
            LabeList.Add(label2);
            LabeList.Add(label3);
            ButtonList.Add(button1);
            ButtonList.Add(button2);
            ButtonList.Add(button3);
            Populate_Main_formAsync();
        }
        
        private async Task Populate_Main_formAsync()
        {
            Summary summary = new Summary();
            int i = 0;
            String[] titArray = new string[3];
            string titl = "";


            foreach (var groupbox in groupBoxes)
            {
                Boolean flag1 = false;
                conn.RandomArticle1();
                titArray[i] = Form1.RTitle;
                if (titArray.Contains(Form1.RTitle))
                {
                    flag1 = true;
                }
                while (flag1)
                {
                    conn.RandomArticle1();
                    if (!titArray.Contains(Form1.RTitle))
                    {
                        titArray[i] = Form1.RTitle;
                        flag1 = false;
                    }
                }
                groupbox.Text = Form1.RTitle;
                var bLabel = LabeList.ElementAt(i);
                await summary.SummaryReturnAsync(Form1.linkForTts);
                String bod = TruncateLongString(Form1.Rbody,50);
                bLabel.Text = bod + "...";

                 

                i++;

                if (i == 1)
                {
                    openMore = Form1.RTitle;


                }
                else if (i == 2)
                {
                    openMore2 = Form1.RTitle;

                }
                else if (i == 3)
                {

                    openMore3 = Form1.RTitle;
                }

            }
            foreach(var Rt in groupBoxes)
            {

                titl = Rt.Text.ToString();
                titl.Replace("_"," ");
                Rt.Text = titl;
            }
        }

        public string TruncateLongString(string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return str.Substring(0, Math.Min(str.Length, maxLength));
        }

 

        private void FirstCustomControl_Load(object sender, EventArgs e)
        {

        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            somethingOpen = openMore;
            Form1.webb2.Visible = true;
            Form1.webb2.BringToFront();
            conn.openArticleMainPage();
            Form1.webb2.DocumentText = Form1.openArticleText;
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            somethingOpen = openMore2;
            Form1.webb2.Visible = true;
            Form1.webb2.BringToFront();
            conn.openArticleMainPage();
            Form1.webb2.DocumentText = Form1.openArticleText;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            somethingOpen = openMore3;
            Form1.webb2.Visible = true;
            Form1.webb2.BringToFront();
            conn.openArticleMainPage();
            Form1.webb2.DocumentText = Form1.openArticleText;

        }
    }
}
