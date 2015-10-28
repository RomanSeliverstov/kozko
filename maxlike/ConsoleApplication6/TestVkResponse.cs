using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{



    class TestVkResponse : IVkResponse
    {
        public string Send(string request, string param)
        {
           

            if (request == "https://api.vk.com/method/users.get?user_ids={0}" && param == "seliverstov_roman")
            {
                return @"{""response"":[{""uid"":30326937,""first_name"":""Рома"",""last_name"":""Селивёрстов"",""hidden"":1}]}";
            }
            if (request == "https://api.vk.com/method/friends.get?user_id={0}" && param == "30326937")
            {
                return @"{""response"":[5356439,8191948,8784559,11773257,12027935,13197420]}";
            }
         
            return "";
        }

    }
}
