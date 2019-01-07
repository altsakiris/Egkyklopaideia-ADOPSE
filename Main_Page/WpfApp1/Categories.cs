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
    public partial class Categories : UserControl
    {

        public static string categorySearched;
        public static ListBox catResultView;
        SqlConn conn = new SqlConn();
       

        public Categories()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.realListBox.Items.Clear();
            Form1.webb1.Visible = true;
            Form1.webb1.BringToFront();
            Form1.realListBox.BringToFront();
            Form1.backButton.BringToFront();
            catResultView = Form1.realListBox;
            categorySearched = "Sports";
            conn.CategorySearch();


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.realListBox.Items.Clear();
            Form1.webb1.Visible = true;
            Form1.webb1.BringToFront();
            Form1.realListBox.BringToFront();
            Form1.backButton.BringToFront();
            catResultView = Form1.realListBox;
            categorySearched = "Science";
            conn.CategorySearch();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.realListBox.Items.Clear();
            Form1.webb1.Visible = true;
            Form1.webb1.BringToFront();
            Form1.realListBox.BringToFront();
            Form1.backButton.BringToFront();
            catResultView = Form1.realListBox;
            categorySearched = "Tech";
            conn.CategorySearch();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1.realListBox.Items.Clear();
            Form1.webb1.Visible = true;
            Form1.webb1.BringToFront();
            Form1.realListBox.BringToFront();
            Form1.backButton.BringToFront();
            catResultView = Form1.realListBox;
            categorySearched = "Music";
            conn.CategorySearch();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1.realListBox.Items.Clear();
            Form1.webb1.Visible = true;
            Form1.webb1.BringToFront();
            Form1.realListBox.BringToFront();
            Form1.backButton.BringToFront();
            catResultView = Form1.realListBox;
            categorySearched = "Culture";
            conn.CategorySearch();
        }
    }
}
