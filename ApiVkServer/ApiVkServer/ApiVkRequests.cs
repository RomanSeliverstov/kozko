using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiVkServer
{
   public class ApiVkRequests
    {
     
     static public JObject GetUserInfo(string linkVk)
        {
            JObject jsonObj;
            linkVk = VkResponse.Send("https://api.vk.com/method/users.get?user_ids={0}&fields=city&v=5.40", linkVk);
            jsonObj = JObject.Parse(linkVk);
            return jsonObj;
        }
     static public JObject GetUserFriends(string userId)
     {
         JObject jsonObj;
         string idsFriends = VkResponse.Send("https://api.vk.com/method/friends.get?user_id={0}", userId);
         jsonObj = JObject.Parse(idsFriends);
         return jsonObj;
     }
    
     static public JObject GetUserPosts(int userId)
     {
         JObject jsonObj;
         string wallPosts = "";
         wallPosts = VkResponse.Send("https://api.vk.com/method/wall.get?owner_id={0}", userId.ToString());
         jsonObj = JObject.Parse(wallPosts);
         return jsonObj;
     }

    
    }
}
