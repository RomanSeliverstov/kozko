using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;

namespace LikesVk
{
    class Program
    {
        static void Main(string[] args)
        {
            TimerCallback timeCB = new TimerCallback(StartProgram);
            Timer t = new Timer(timeCB, "Updating information is starting", 0, 30000);
            Console.ReadLine();
            
        }

        private static void StartProgram(object state)
        {
            Query query = new Query();
            query.DeleteAllData();
            string result = "";
            int isChecked;
            result = query.GetUserLink("link");
            isChecked = Convert.ToInt32(query.GetChecked("param"));
            MainUser mainUser = new MainUser(result, isChecked);
            Console.WriteLine("База данных обновлена!");

        }
            

            
            


        }
    }

