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
    public partial class Form2 : Form
    {
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
            using (FileDialog fileDialog = new OpenFileDialog())
            {
                if (DialogResult.OK == fileDialog.ShowDialog())
                {
                    string filename = fileDialog.FileName;

                    textBox1.Text = fileDialog.FileName;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

