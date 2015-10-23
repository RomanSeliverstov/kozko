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
    class wall
    {
        JObject jsonObj;
        vkResponse response = new vkResponse();
        private string getMyId()
        {
          


           string User = "https://vk.com/seliverstov_roman";
           User = User.Substring("https://vk.com/".Length);
           string UserId = response.send("https://api.vk.com/method/users.get?user_ids={0}", User);
           jsonObj = JObject.Parse(UserId);
           UserId = Convert.ToString(jsonObj["response"][0]["uid"]);

           return UserId;

        }
        private int[] getFriendsId()
        {
            string friendsIds = response.send("https://api.vk.com/method/friends.get?user_id={0}", getMyId());
            jsonObj = JObject.Parse(friendsIds);
            int[] friendsIdsArray; ;
            friendsIdsArray = new int[jsonObj["response"].Count()];
            
            for (int i = 0; i < friendsIdsArray.Length; i++)
            {
                friendsIdsArray[i] = Convert.ToInt32(jsonObj["response"][i]);
            }

            return friendsIdsArray;
        }

        public string getMaxLikePost()
        {
            string wallPosts = "";
            int maxLike = 0;
            int maxPostId = 0;
            int idWithMaxLikes = 0;
            int[] friendsIdsArray = getFriendsId();

            for (int i = 0; i < friendsIdsArray.Length; i++)
            {
                wallPosts = response.send("https://api.vk.com/method/wall.get?owner_id={0}", friendsIdsArray[i].ToString());
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
            string maxlike = idWithMaxLikes.ToString() + "_" + maxPostId.ToString();
            
     
            return maxlike;

        }
    }
}
