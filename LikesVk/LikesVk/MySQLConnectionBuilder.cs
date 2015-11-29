using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;


namespace LikesVk
{
    class MySQLConnectionBuilder
    {
        
            private DataTable dt = new DataTable();
            private MySqlConnectionStringBuilder mysqlCS;
            private MySqlConnection con;
            private MySqlConnectionStringBuilder connectToBase()
            {
                string connectionString = "Server=127.0.0.1;Database=vk_app;Uid=root;CharSet=utf8";
                MySqlConnectionStringBuilder mysqlCSB;
                mysqlCSB = new MySqlConnectionStringBuilder(connectionString);
                return mysqlCSB;

            }
            public string GetLink(string queryString)
            {
                string result = "";
                mysqlCS = connectToBase();
                

                using (con = new MySqlConnection())
                {

                    con.ConnectionString = mysqlCS.ConnectionString;
                    MySqlCommand com = new MySqlCommand(queryString, con);

                    try
                    {
                        con.Open();

                        using (MySqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                result = dr["link"].ToString();
                                
                                
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("Error upload data", ex);
                    }
                }
                return result;
            }


            public void InsertIntoTable(string query)
            {

                mysqlCS = connectToBase();
              


                using (con = new MySqlConnection())
                {

                    con.ConnectionString = mysqlCS.ConnectionString;
                    MySqlCommand com = new MySqlCommand(query, con);
                    MySqlDataReader MyReader2;
                    con.Open();
                    MyReader2 = com.ExecuteReader();
                    con.Close();


                }

            }

        }
    
}
