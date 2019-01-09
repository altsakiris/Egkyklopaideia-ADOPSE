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
using MySql.Data.MySqlClient;
using System.Windows.Documents;

namespace Egkyklopaideia
{
    public partial class Form1 : Form
    {
        TextToSpeech Reader = new TextToSpeech();
       
        SqlConn conn = new SqlConn();

        public static Button UploadButton;
        public static Button LogOutButton;
        public static Button RegisterButton;
        public static Button LoginButton;
        public static Button SearchButton;
        public static string SearchText;
        public static string SelectedIndex;
        public static ListBox resultView;
        public static ListBox realListBox;
        public static string SelectedArticle;
        public static string linkForTts;
        public static string openArticleText;
        public static string openArticleTitle;
        public static WebBrowser webb1,webb2;
        public static Button backButton;
        public static Label helloWorld;
        public static String RTitle;
        public static String Rbody;

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
            SearchButton = button6;
            label1.Text = DateTime.Now.ToShortDateString();
            realListBox = listBox1;
            webb1 = webBrowser1;
            webb2 = webBrowser2;
            backButton = button7;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            helloWorld = label2;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.OemOpenBrackets)
            {
                TtsRead.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.OemCloseBrackets)
            {
                TtsStop.PerformClick();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            TtsRead.Visible = false;
            TtsStop.Visible = false;
            firstCustomControl1.BringToFront();
            articleTextDisplay1.Visible = false;
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            button8.Visible = true;
            button8.BringToFront();
            webBrowser2.BringToFront();
            webBrowser2.Visible = true;
            TtsRead.Visible=true;
            TtsStop.Visible=true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button3.Height;
            SidePanel.Top = button3.Top;
            webBrowser2.Visible = false;
            categories1.Visible = true;
            categories1.BringToFront();
            TtsRead.Visible = false;
            TtsStop.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            listBox1.Items.Clear();
            webBrowser1.Visible = true;
            webBrowser1.BringToFront();
            articleTextDisplay1.Visible = false;
            listBox1.BringToFront();
            button7.BringToFront();
            SearchText = textBox1.Text;
            resultView = listBox1;
            conn.Search();
 

        }



        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("No Articles Selected");
            }
            else
            {
                string item = listBox1.SelectedItem.ToString();
                SelectedArticle = item;
                webBrowser2.Visible = true;
                webBrowser2.BringToFront();
                TtsRead.Visible = true;
                TtsStop.Visible = true;
                conn.OpenArticle();
                SidePanel.Height = button2.Height;
                SidePanel.Top = button2.Top;
                webBrowser2.DocumentText = openArticleText;
                button15.BringToFront();
            }
           
             
        }

        


        private void button15_Click(object sender, EventArgs e)
        {
            listBox1.BringToFront();
            button15.SendToBack();
            SidePanel.Height = button3.Height;
            SidePanel.Top = button3.Top;
            webBrowser2.Visible = false;
            TtsRead.Visible = false;
            TtsStop.Visible = false;
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
            System.Windows.Forms.WebBrowser article = webBrowser2;
            if (article.Document != null) {
                string article2 = article.Document.Title.ToString();
                Clipboard.SetText("Take a look at this article I found \n" + article2 + " : " + linkForTts);
                var form = new Form3();
                form.Show(this);
            }
        }

        private void TtsRead_Click(object sender, EventArgs e)
        {
            Reader.TtsRead(linkForTts);
        }

        private void TtsStop_Click(object sender, EventArgs e)
        {
            Reader.TtsStop();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }


        private void articleTextDisplay1_Load(object sender, EventArgs e)
        {

        }
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                string article2;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Text File|*.txt|Html File|*.html";
                saveFileDialog1.Title = "Save an Image File";
                System.Windows.Forms.WebBrowser article = webBrowser2;

                article2 = article.Document.Body.InnerText;

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
            }catch (Exception)
            {
                MessageBox.Show("No Article Selected!..");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            PrintDialog printdialog1 = new PrintDialog();
            System.Windows.Forms.WebBrowser article = webBrowser2;

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
            label2.Text = "";
            button9.Enabled = false; // me to log out ta ksanakruvw
            button4.Enabled = false;
            button5.Enabled = true; //profanes
            login_btn.Enabled = true;
            MessageBox.Show("Succesfully Logged-Out!");
        }


        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void categories1_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            var form = new Help();
            form.Show(this);
        }
    }
}
