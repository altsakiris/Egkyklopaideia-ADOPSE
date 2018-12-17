using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Egkyklopaideia
{
    public partial class Form1 : Form
    {
        TextToSpeech Reader = new TextToSpeech();

        public Form1()
        {
            InitializeComponent();

            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            firstCustomControl1.BringToFront();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            webBrowser1.BringToFront();
            webBrowser1.Visible=true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            firstCustomControl1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button3.Height;
            SidePanel.Top = button3.Top;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void myArticleTextDisplay1_Load(object sender, EventArgs e)
        {

        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            

        }

        private void TtsRead_Click(object sender, EventArgs e)
        {
            Reader.TtsRead("https://users.it.teithe.gr/~it154474/article.html");
        }

        private void TtsStop_Click(object sender, EventArgs e)
        {
            Reader.TtsStop();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
