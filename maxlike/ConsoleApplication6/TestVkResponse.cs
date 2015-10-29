using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication6
{



    class TestVkResponse : IVkResponse
    {
        public string Send(string request, string param)
        {
           
            int[] usersId = new int[5] {38010036,40349766,40511435,42208446,43153393};
 

            if (request == "https://api.vk.com/method/users.get?user_ids={0}" && param == "seliverstov_roman")
            {
                return @"{""response"":[{""uid"":30326937,""first_name"":""Рома"",""last_name"":""Селивёрстов"",""hidden"":1}]}";
            }
            if (request == "https://api.vk.com/method/friends.get?user_id={0}" && param == "30326937")
            {
                return @"{""response"":[5356439,8191948,8784559,11773257,12027935,13197420]}";
            }

            for (int i = 0; i < usersId.Length; i++)
                {
                    if (request == "https://api.vk.com/method/wall.get?owner_id={0}" && param == Convert.ToString(usersId[i]))
                    {
                        int n = i + 1;
                        FileStream fstream = File.OpenRead(@"C:\Users\Roman\Documents\Visual Studio 2013\Projects\maxlike\ConsoleApplication6\jsontest\" + n + ".txt");
                        byte[] array = new byte[fstream.Length];
                        fstream.Read(array, 0, array.Length);
                        string textFromFile = System.Text.Encoding.Default.GetString(array);
                        return textFromFile;
                    }
                
            }
            return "";
        }

    }
}
