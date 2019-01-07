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

    
    public partial class loginform : Form
    {

        SqlConn conn = new SqlConn();
        public static string usernameText;
        public static string passwordText;
        public static bool successLogin = false;
        public static string loginName;
        public loginform()
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
            conn.Login();

            if (successLogin == true)  //to ekana ama einai epituxeis na kleinei
            {
                this.Close();
                Form1.UploadButton.Enabled = true; //enable ta buttonia
                Form1.LogOutButton.Enabled = true;
                Form1.RegisterButton.Enabled = false; //auto disable
                Form1.LoginButton.Enabled = false;
                Form1.helloWorld.Text = "Welcome, "+loginName+"!";

            }
            
          
        }
    }
}
