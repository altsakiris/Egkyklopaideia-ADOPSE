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
    public partial class registerform : Form
    {

        SqlConn conn = new SqlConn();
        public static string usernameText;
        public static string passwordText;
        public static string emailText;
        public static bool success = false;

        public registerform()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usernameText = textBox1.Text;
            passwordText = textBox2.Text;
            emailText = textBox3.Text;
            conn.Register();

            if (success == true) //to ekana ama einai epituxeis na kleinei
            {
                this.Close();
            }
        }
    }
}
