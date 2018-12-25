using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Egkyklopaideia
{
    class SqlConn
    {

        private MySqlConnection connection;
        private string server;
        private int port;
        private string database;
        private string uid;
        private string password;

        public SqlConn()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "dblabs.it.teithe.gr";
            port = 3306;
            database = "it144322";
            uid = "it144322";
            password = "aiquiE3h@@";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {

            try
            {
                connection.Open();





                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }



        public void UploadArticle()
        {


            string readText = File.ReadAllText(Form2.downloadText); //to readText exei ta periexomena tou file 
            string selectedCategory = Form2.selectedIndex; // to string tou category pou tha mpei vash, kai h metavlhth mporei na xrhsimopoiithei kai ws hyperlink gia anazhthsh

            


            string query = "INSERT INTO Articles (Article,Category) values (@inputArticle,@inputCategory)";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@inputArticle", readText);
                cmd.Parameters.AddWithValue("@inputCategory", selectedCategory);

                cmd.ExecuteNonQuery();
                Console.WriteLine(readText);



            }
        }

    }

    
}
