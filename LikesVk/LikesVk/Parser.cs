using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace LikesVk
{
   public class Parser
    {
        VkResponse response = new VkResponse();
        string linq { get; set; }
        string userId;
        string friendId;
        
       
        public Parser(string linq, string friendId)
        {
           this.linq = linq;
           this.userId = GetUserInfo(ParserLink(linq), 0);
           this.friendId = friendId;
        }

       public string ParserLink(string linkVk)
        {
            string info = "";
            info = linkVk.Substring("https://vk.com/".Length);
            return info;
        }

        public string GetUserInfo(string linkVk, int param)
       {
            string info = "";
            JObject jsonObj;
            linkVk = response.Send("https://api.vk.com/method/users.get?user_ids={0}&fields=city&v=5.40", linkVk);
            jsonObj = JObject.Parse(linkVk);
            switch (param)
            {
                case 0:
                    info = Convert.ToString(jsonObj["response"][0]["id"]);
                    userId = info;
                    break;
                case 1:
                    info = Convert.ToString(jsonObj["response"][0]["first_name"]);
                    break;
                case 2:
                    info = Convert.ToString(jsonObj["response"][0]["last_name"]);
                    break;
                case 3:
                    if (jsonObj["response"][0]["city"] != null) info = Convert.ToString(jsonObj["response"][0]["city"]["title"]);
                    else info = "-";
                    break;
            }

            return info;
            

        }

       
        public List<int> ParseFriendsId()
        {
            JObject jsonObj;
            string idsFriends = response.Send("https://api.vk.com/method/friends.get?user_id={0}", userId);
            jsonObj = JObject.Parse(idsFriends);
            List<int> idsFriendsList = new List<int>();
            int countJson = jsonObj["response"].Count();
          
            for (int i = 0; i < countJson; i++)
            {
                idsFriendsList.Add(Convert.ToInt32(jsonObj["response"][i]));

            }
           
            return idsFriendsList;


        }

        public List<int> GetUserPosts ()
        {
            JObject jsonObj;
            string wallPosts = "";
            List<int> userPosts = new List<int>();
            wallPosts = response.Send("https://api.vk.com/method/wall.get?owner_id={0}", friendId);
            jsonObj = JObject.Parse(wallPosts);
               
                if (jsonObj["response"] != null)
                {
                    foreach (var result in jsonObj["response"])
                    {
                        if (result.Next != null)
                        {
                            int countPosts;
                            countPosts = Convert.ToInt32(jsonObj["response"][0]);
                            var currentPostId = Convert.ToInt32(result.Next["id"]);
                            userPosts.Add(currentPostId);
                            
                        }
                    }
                }
            
            return userPosts;
        }

        public DateTime GetDate(int postId)
        {
            JObject jsonObj;
            DateTime pDate = new DateTime();
            string wallPosts = "";
            wallPosts = response.Send("https://api.vk.com/method/wall.get?owner_id={0}", friendId);
            jsonObj = JObject.Parse(wallPosts);

            if (jsonObj["response"] != null)
            {

                foreach (var result in jsonObj["response"])
                {
                    if ((result.Next != null) && (Convert.ToInt32(result.Next["id"]) == postId))
                    {
                        pDate = (new DateTime(1970, 1, 1, 5, 0, 0, 0)).AddSeconds(Convert.ToDouble(result.Next["date"]));
                    }
                }
            }
            return pDate;
        }
        
       

        public int GetLikes(int postId)
        {
            JObject jsonObj;
            int postLikes = 0;
            string wallPosts = "";
            wallPosts = response.Send("https://api.vk.com/method/wall.get?owner_id={0}", friendId);
            jsonObj = JObject.Parse(wallPosts);

            if (jsonObj["response"] != null)
            {

                foreach (var result in jsonObj["response"])
                {
                    if ((result.Next != null) && (Convert.ToInt32(result.Next["id"]) == postId))
                    {
                        postLikes = Convert.ToInt32(result.Next["likes"]["count"]);
                    }
                }
            }
            return postLikes;
        }

        public string GetTextPost(int postId)
        {
            JObject jsonObj;
            string postText = "";
            string wallPosts = "";
            wallPosts = response.Send("https://api.vk.com/method/wall.get?owner_id={0}", friendId);
            jsonObj = JObject.Parse(wallPosts);

            if (jsonObj["response"] != null)
            {

                foreach (var result in jsonObj["response"])
                {
                    if ((result.Next != null) && (Convert.ToInt32(result.Next["id"]) == postId))
                    {
                        postText = result.Next["text"].ToString();
                    }
                }
            }
            return postText;
        }
    }



}
