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
    public class Wall
    {
        
        IVkResponse response;
       
        public Wall(IVkResponse currentResponse)
        {
            this.response = currentResponse;
        }
      

        public string ParseVkLink(string linkVk)
        {
            JObject jsonObj;
            linkVk = linkVk.Substring("https://vk.com/".Length);
            linkVk = response.Send("https://api.vk.com/method/users.get?user_ids={0}", linkVk);
            jsonObj = JObject.Parse(linkVk);
            string userId = Convert.ToString(jsonObj["response"][0]["uid"]);

            return userId;

        }

       
         public int[] GetIdsFriends(string userId)
        {
            JObject jsonObj;
            string idsFriends = response.Send("https://api.vk.com/method/friends.get?user_id={0}", userId);
            jsonObj = JObject.Parse(idsFriends);
            int[] idsFriendsArray;
            idsFriendsArray = new int[jsonObj["response"].Count()];
            
            for (int i = 0; i < idsFriendsArray.Length; i++)
            {
                idsFriendsArray[i] = Convert.ToInt32(jsonObj["response"][i]);
                
            }
            
            return idsFriendsArray;
        }

        public string GetMaxLike(int[] idsFriendsArray)
        {
            JObject jsonObj;
            string wallPosts = "";
            int maxLike = 0;
            int maxPostId = 0;
            int idWithMaxLikes = 0;
           

            for (int i = 0; i < idsFriendsArray.Length; i++)
            {
                wallPosts = response.Send("https://api.vk.com/method/wall.get?owner_id={0}", idsFriendsArray[i].ToString());
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
                                     idWithMaxLikes = idsFriendsArray[i];
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
