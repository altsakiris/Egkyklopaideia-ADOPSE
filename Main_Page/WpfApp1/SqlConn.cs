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
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Windows.Documents;

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
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "Allow User Variables = True";

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

        public bool CloseConnection()
        {
            try
            {
                connection.Close();

                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Problem Closing");
                return false;
            }
        }

        public void UploadArticle()
        {

            string selectedCategory = Form2.selectedIndex; // to string tou category pou tha mpei vash, kai h metavlhth mporei na xrhsimopoiithei kai ws hyperlink gia anazhthsh
            string title = Form2.articleTitle;
            string readText = File.ReadAllText(Form2.downloadText);


            string query = "INSERT INTO Articles (Title,Category,Article,Link) values (@inputTitle,@inputCategory,@inputArticle,NULL)";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@inputTitle", title);
                cmd.Parameters.AddWithValue("@inputCategory", selectedCategory);
                cmd.Parameters.AddWithValue("@inputArticle", readText);

                cmd.ExecuteNonQuery();


            }

            //close connection
            this.CloseConnection();

        }

        public void Register()
        {
            string nameVal = registerform.usernameText;
            string passwordVal = registerform.passwordText;
            string emailVal = registerform.emailText;

            string query = "INSERT INTO Users (Name,Password,Email) VALUES(@nameValInput,@passwordValInput,@emailValInput)";

            string NameQuery = "SELECT COUNT(*) FROM Users WHERE Name = '" + nameVal + "'";
            int NameCount = -1;

            string EmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = '" + emailVal + "'";
            int EmailCount = -1;

            //open connection
            if (this.OpenConnection() == true)
            {


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlCommand cmd2 = new MySqlCommand(NameQuery, connection);
                MySqlCommand cmd3 = new MySqlCommand(EmailQuery, connection);
                cmd.Parameters.AddWithValue("@nameValInput", nameVal);
                cmd.Parameters.AddWithValue("@passwordValInput", passwordVal);
                cmd.Parameters.AddWithValue("@emailValInput", emailVal);

                NameCount = int.Parse(cmd2.ExecuteScalar() + "");
                EmailCount = int.Parse(cmd3.ExecuteScalar() + "");


                if (NameCount > 0)
                {
                    MessageBox.Show("Name Already Exists!..");  //profanes

                }
                else if (EmailCount > 0)

                {
                    MessageBox.Show("This Email Is Already Being Used!..");
                }

                else if (!new EmailAddressAttribute().IsValid(emailVal)) //filter gia swsto email
                {
                    MessageBox.Show("Wrong Email Input!..");
                }
                else
                {
                    //Execute command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Created!");
                    registerform.success = true;

                }



                //close connection
                this.CloseConnection();

            }
        }

        public void Login()
        {
            string nameVal = loginform.usernameText;
            string passwordVal = loginform.passwordText;

            string query = "SELECT COUNT(*) FROM Users WHERE Name='" + nameVal + "' AND Password='" + passwordVal + "'";
            int count = -1;

            if (this.OpenConnection() == true)
            {

                MySqlCommand cmd = new MySqlCommand(query, connection);
                count = int.Parse(cmd.ExecuteScalar() + ""); // kai auta profanes

                if (count != 1)
                {
                    MessageBox.Show("Wrong Name Or Password!..");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successful Login!");
                    loginform.successLogin = true;
                    loginform.loginName = nameVal;
                }

                this.CloseConnection();
            }

        }

        public void Search()
        {
            string searchName = Form1.SearchText;
            string query = "SELECT Title From Articles WHERE Title LIKE @searchString";
            if (this.OpenConnection() == true)
            {

                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    string nameString = "%" + searchName + "%";
                    cmd.Parameters.AddWithValue("@searchString", nameString);

                    if (searchName == "")
                    {
                        MessageBox.Show("No Search Query");
                    }
                    else
                    {

                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Form1.resultView.Items.Add(reader["Title"].ToString());
                        }
                    }

 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No results");
                }
            }

            this.CloseConnection();

        }


        public void CategorySearch()
        {

            string categorySearch = Categories.categorySearched;
 
            string query = "SELECT Title From Articles Where Category =@searchCat";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@searchCat", categorySearch);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Categories.catResultView.Items.Add(reader["Title"].ToString());

                }
            }
            this.CloseConnection();
        }

         
        public void OpenArticle()
        {
            string result = Form1.SelectedArticle;

            string query = "SELECT Article,Link From Articles WHERE Title =@inputTitle";

            if (this.OpenConnection() == true)
            {

                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@inputTitle", result);

                    if (result == null)
                    {
                        MessageBox.Show("No Article Selected");
                    }
                    else
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Form1.openArticleText= (reader["Article"].ToString());
                            Form1.linkForTts = reader["Link"].ToString();
                        }
                    }

                }catch(Exception e)
                {
                    MessageBox.Show("??");
                }
            }
            this.CloseConnection();
        }

        public void RandomArticle1()
        {
            string query = "SELECT Title,Link FROM Articles ORDER BY RAND() LIMIT 1";

            if(this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                     Form1.RTitle = reader["Title"].ToString();
                     Form1.linkForTts = reader["Link"].ToString();
                }
            }
            this.CloseConnection();
        }
      
        public void openArticleMainPage()
        {

            string query = "SELECT Article,Link From Articles WHERE Title =@inputTitle";

            if (this.OpenConnection() == true)
            {

                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@inputTitle", FirstCustomControl.somethingOpen);

                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Form1.openArticleText = (reader["Article"].ToString());
                            Form1.linkForTts = reader["Link"].ToString();
                        }


                }
                catch (Exception e)
                {
                    MessageBox.Show("??");
                }
            }
            this.CloseConnection();
        }
    }


}
