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

namespace Egkyklopaideia
{
    public partial class Form2 : Form
    {

        SqlConn conn = new SqlConn();
        public static string downloadText;
        public static string selectedIndex;
        public static string articleTitle;

        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* OpenFileDialog openFileDialog1 = new OpenFileDialog();
             if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
             {
                 System.IO.StreamReader sr = new
                    System.IO.StreamReader(openFileDialog1.FileName);
                 MessageBox.Show(sr.ReadToEnd());
                 sr.Close();*/
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "html files (*.html)|*.html"; // filter gia arxeia pou dexetai
                if (DialogResult.OK == fileDialog.ShowDialog())
                {
                    string filename = fileDialog.FileName;
                    articleTitle = Path.GetFileNameWithoutExtension(filename);
                    textBox1.Text = fileDialog.FileName;
                }
                downloadText = textBox1.Text;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {  // analoga me to selection to category. Otan apofasisoume ta categories allazoume ta onomata giati etsi mpainoun vash
            int selectedIndexCat = comboBox1.SelectedIndex;
            if (selectedIndexCat == 0)
            {
                selectedIndex = "Sports";
                
            }else if(selectedIndexCat == 1)
            {
                selectedIndex = "Science";

            }
            else if (selectedIndexCat == 2)
            {
                selectedIndex = "Music";

            }
            else if (selectedIndexCat == 3)
            {
                selectedIndex = "Tech";

            }
            else if (selectedIndexCat == 4)
            {
                selectedIndex = "Culture";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            conn.UploadArticle(); //methodo gia upload
            MessageBox.Show("Το λήμμα ανέβηκε επιτυχώς!");
             

        }

        private void articleTextDisplay1_Load(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
    }

