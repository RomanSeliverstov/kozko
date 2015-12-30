using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ApiVkServer
{
    public class MySqlOperations
    {
        public static MySqlConnectionStringBuilder mysqlCS { get; set; }
        
        private static MySqlConnection con;
        public static DataTable GetData(string queryString)
        {
            DataTable dt = new DataTable();
            using (con = new MySqlConnection())
            {

                con.ConnectionString = mysqlCS.ConnectionString;
                MySqlCommand com = new MySqlCommand(queryString, con);

                try
                {
                    con.Open();

                    using (MySqlDataReader dr = com.ExecuteReader())
                    {

                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error upload data", ex);
                }
            }
            return dt;
        }



        public static void InsertIntoTable(string query)
        {
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
