using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Drawing.Printing;





namespace Egkyklopaideia
{
    public partial class Form1 : Form
    {
        TextToSpeech Reader = new TextToSpeech();
        DailyArticleCreator testing = new DailyArticleCreator();

        public static Button UploadButton;
        public static Button LogOutButton;
        public static Button RegisterButton;
        public static Button LoginButton;

        public Form1()
        {
            InitializeComponent();

            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            firstCustomControl1.BringToFront();
            UploadButton = button9;
            LogOutButton = button4;
            RegisterButton = button5;
            LoginButton = login_btn;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            firstCustomControl1.BringToFront();
            articleTextDisplay1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            articleTextDisplay1.BringToFront();
            articleTextDisplay1.Visible = true;
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
            /*string title =”My First Blog”;
            string url =”https://dotnetgeekblog.wordpress.com/&#8221;;
            string summery =”This Is First Geek Blog”;
            string image =”http://s.wordpress.org/about/images/logos/wordpress-logo-stacked-rgb.png&#8221;;

            string facebooklink = “http://www.facebook.com/sharer.php?s=100&amp;p%5Btitle%5D=”+title;
            facebooklink += “&amp; p[summary] =”+summery;
            facebooklink += “&amp; p[url] =” +url;
            facebooklink += “&amp; &p[images][0] =” +image;
            lnkFacebook.HRef = facebooklink;*/
        }

        private void TtsRead_Click(object sender, EventArgs e)
        {
            Reader.TtsRead("https://users.it.teithe.gr/~it154474/American_English.html");
        }

        private void TtsStop_Click(object sender, EventArgs e)
        {
            Reader.TtsStop();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void JsonHandle_Click(object sender, EventArgs e)
        {
            testing.LoadJson();
        }

        private void articleTextDisplay1_Load(object sender, EventArgs e)
        {

        }
        private void button8_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text File|*.txt|Html File|*.html";
            saveFileDialog1.Title = "Save an Image File";
            System.Windows.Forms.WebBrowser article = articleTextDisplay1.get();
            string article2 = article.Document.Body.InnerText;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            System.IO.File.WriteAllText(saveFileDialog1.FileName, article2);
                            break;

                        case 2:
                            System.IO.File.WriteAllText(saveFileDialog1.FileName, article2);
                            break;

                        case 3:

                            System.IO.File.WriteAllText(saveFileDialog1.FileName, article2);
                            break;

                        case 4:
                            System.IO.File.WriteAllText(saveFileDialog1.FileName, article2);
                            break;
                    }
                }

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            PrintDialog printdialog1 = new PrintDialog();
            System.Windows.Forms.WebBrowser article = articleTextDisplay1.get();

            //new PrintingExample(article.Document.Body.InnerText);

            if (printdialog1.ShowDialog() == DialogResult.OK)
            {
                article.Print();
            }
        }

        /*protected void ThePrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ev, System.Windows.Forms.WebBrowser article)
        {
            float linesPerPage = 0;
            float yPosition = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;
            article = articleTextDisplay1.get();
            Font printFont = article.Font;
            StringReader strReader = new StringReader(article.Document.Body.InnerText);
            SolidBrush myBrush = new SolidBrush(Color.Black);
            // Work out the number of lines per page, using the MarginBounds.  
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
            // Iterate over the string using the StringReader, printing each line.  
            while (count < linesPerPage && ((line = strReader.ReadLine()) != null))
            {
                // calculate the next line position based on the height of the font according to the printing device  
                yPosition = topMargin + (count * printFont.GetHeight(ev.Graphics));
                // draw the next line in the rich edit control  
                ev.Graphics.DrawString(line, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                count++;
            }
            // If there are more lines, print another page.  
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
            myBrush.Dispose();
        }*/

        private void button9_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            form.Show(this);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var form = new loginform();
            form.Show(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = new registerform();
            form.Show(this);
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            button9.Enabled = false; // me to log out ta ksanakruvw
            button4.Enabled = false;
            button5.Enabled = true; //profanes
            login_btn.Enabled = true;
            MessageBox.Show("Succesfully Logged-Out!");
        }
    }
}
