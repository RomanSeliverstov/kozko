using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using MySql.Data.MySqlClient;

namespace ApiVkServer
{
    public class MySQLConnectionBuilder
    {
        public static  MySqlConnectionStringBuilder ConnectionBuilder()
        {
            string connectionString = "Server=127.0.0.1;Database=vk;Uid=root;CharSet=utf8";
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder(connectionString);
            return mysqlCSB;

        }
    }
}
