using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiVkServer
{
    public class Parser
    {
        public string linq { get; set; }

       static public string ParserLink(string linkVk)
        {
            string info = "";
            info = linkVk.Substring("https://vk.com/".Length);
            return info;
        }

       static public string GetUserId(JObject jObject)
       {
           return Convert.ToString(jObject["response"][0]["id"]);
       }
        
       static public string GetUserFirstName(JObject jObject)
       {
           return Convert.ToString(jObject["response"][0]["first_name"]);
       }

       static  public string GetUserLastName(JObject jObject)
       {
            return Convert.ToString(jObject["response"][0]["last_name"]);
       }
       static public string GetUserCity(JObject jObject)
       {
          if (jObject["response"][0]["city"] != null) return Convert.ToString(jObject["response"][0]["city"]["title"]);
                   else return "-";
       }
       static public List<int> ParseFriendsId(JObject jsonObj)
       {

           List<int> idsFriendsList = new List<int>();
           int countJson = jsonObj["response"].Count();

           for (int i = 0; i < countJson; i++)
           {
               idsFriendsList.Add(Convert.ToInt32(jsonObj["response"][i]));

           }

           return idsFriendsList;
       }

      static public List<int> GetUserPosts(JObject jsonObj)
       {
           List<int> userPosts = new List<int>();
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

      static public DateTime GetDate(JObject jsonObj, int postId)
      {
          DateTime pDate = new DateTime();

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
      public int GetLikes(JObject jsonObj, int postId)
      {
          int postLikes = 0;
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

    }



}


           
   
                   
                   
                   
                   
                   
                  
          
