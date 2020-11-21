using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlank
{
    class DB
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DB()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "eu-cdbr-west-03.cleardb.net";
            database = "heroku_d8408b93d868808";
            uid = "bb1c75f66c74fe";
            password = "f72345db";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

        }
        public void OpenCon()
        {
            try
            {
                connection.Open();


            }
            catch (MySqlException ex)
            {

            }
        }
        public MySqlConnection getCon()
        {
            try
            {
                return connection;


            }
            catch (MySqlException ex)
            {
                return null;
            }
        }
        public void CloseCon()
        {
            try
            {
                connection.Close();


            }
            catch (MySqlException ex)
            {

            }
        }
        public bool isOpen()
        {
            return connection.State == System.Data.ConnectionState.Open;
        }
        public String ReadData(string databaseCommand, string[] param, string[] val, string sel)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(databaseCommand, connection);
                for (int i = 0; i < param.Length; i++)
                    command.Parameters.AddWithValue(param[i], val[i]);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader[sel].ToString();
                    }
                    else return null;
                }

            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();


            }
        }
        public void InsertData(string databaseCommand, string[] param, string[] val)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(databaseCommand, connection);
                for (int i = 0; i < param.Length; i++)
                    command.Parameters.AddWithValue(param[i], val[i]);
                int result = command.ExecuteNonQuery();

            }
			catch(MySqlException ex)
			{

			}
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();


            }
        }
    }
}