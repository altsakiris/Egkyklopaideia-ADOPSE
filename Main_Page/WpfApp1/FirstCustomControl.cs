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
        SqlConn conn = new SqlConn();
        List<GroupBox> groupBoxes = new List<GroupBox>();
        List<Label> LabeList = new List<Label>();
        List<Button> ButtonList = new List<Button>();
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
            foreach (var groupbox in groupBoxes)
            {
                conn.RandomArticle1();
                groupbox.Text = Form1.RTitle;
                var bLabel = LabeList.ElementAt(i);
                await summary.SummaryReturnAsync(Form1.linkForTts);
                String bod = TruncateLongString(Form1.Rbody,50);
                bLabel.Text = bod + "...";
                i++;
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
    }
}
