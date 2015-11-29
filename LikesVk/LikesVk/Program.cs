using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LikesVk
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";
            Query query = new Query();
            result = query.GetUserLink();
            MainUser mainUser = new MainUser(result, true);
            
        }
         
            

            
            


        }
    }

