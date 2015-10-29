using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace ConsoleApplication6
{
    public class wall
    {
        JObject jsonObj;
        IVkResponse response;

        public wall(bool isTest)
        {
            if (isTest)
            {
                response = new TestVkResponse();
            }
            else
            {
                response = new VkResponse();
            }
        }

        public string getMyId(string user)
        {

            string User = user;
            User = User.Substring("https://vk.com/".Length);
           string UserId = response.Send("https://api.vk.com/method/users.get?user_ids={0}", User);
           jsonObj = JObject.Parse(UserId);
           UserId = Convert.ToString(jsonObj["response"][0]["uid"]);

           return UserId;

        }

       
         public int[] getFriendsId(string Id)
        {
            string friendsIds = response.Send("https://api.vk.com/method/friends.get?user_id={0}", Id);
            jsonObj = JObject.Parse(friendsIds);
            int[] friendsIdsArray;
            friendsIdsArray = new int[jsonObj["response"].Count()];
            
            for (int i = 0; i < friendsIdsArray.Length; i++)
            {
                friendsIdsArray[i] = Convert.ToInt32(jsonObj["response"][i]);
                
            }
            
            return friendsIdsArray;
        }

        public string getMaxLikePost(int[] massiv)
        {
            string wallPosts = "";
            int maxLike = 0;
            int maxPostId = 0;
            int idWithMaxLikes = 0;
            int[] friendsIdsArray = massiv;

            for (int i = 0; i < friendsIdsArray.Length; i++)
            {
                wallPosts = response.Send("https://api.vk.com/method/wall.get?owner_id={0}", friendsIdsArray[i].ToString());
                jsonObj = JObject.Parse(wallPosts);

                if (jsonObj["response"] != null)
                {
                    foreach (var result in jsonObj["response"])
                    {

                        if ((result.Next != null) && (Convert.ToInt32(result.Next["date"]) > (int)(DateTime.Now.AddDays(-7) - new DateTime(1970, 1, 1)).TotalSeconds))
                        {

                            var currentPostId = Convert.ToInt32(result.Next["id"]);
                            var currentLike = Convert.ToInt32(result.Next["likes"]["count"]);
                            
                         

                            if (currentLike > maxLike)
                            {
                                maxLike = currentLike;
                                maxPostId = currentPostId;
                                idWithMaxLikes = friendsIdsArray[i];
                            }
                        }

                    }
                }

             
                    
            }
            string maxlike = idWithMaxLikes.ToString() + "_" + maxPostId.ToString() + " Количество: "+ maxLike.ToString();
            
     
            return maxlike;

        }
    }
}
