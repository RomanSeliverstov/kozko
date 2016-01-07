using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading;

namespace ApiVkServer
{
    class Program
    {
        static void Update(object state)
        {
             MySqlOperations.mysqlCS = MySQLConnectionBuilder.ConnectionBuilder();
            DataTable links = MySqlQuery.ReturnLinks();
            Console.WriteLine(links.Rows[0].Field<string>("link"));
            Console.WriteLine(links.Rows.Count);
            for(int i = 0; i <= links.Rows.Count;i++)
            {
             string id = Parser.GetUserId(ApiVkRequests.GetUserInfo(Parser.ParserLink(links.Rows[i].Field<string>("link"))));
             DataTable checkedUser = MySqlQuery.Checkuser(id);
             DataTable users = MySqlQuery.ReturnUsers();
                try
            {
                    for(int j = 0; j <= users.Rows.Count; j++)
                    {
                        checkedUser.Rows[i].Field<string>("FirstName");
                        UpdaterController.UpdateAllFriends(id);
                    }
            }
                catch 
                {
                    AdderController.AddAllFriends("https://vk.com/id60703958");
                    
                }
            }
        }
    
           


        
        static void Main(string[] args)
        {
           

 TimerCallback timeCB = new TimerCallback(Update);
 Timer t = new Timer(timeCB, "checked", 0, 18000000);  
        }
            
          

    
        }
    }

