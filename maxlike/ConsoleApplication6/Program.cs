using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using System.Runtime.Serialization;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;



namespace ConsoleApplication6

{
    class Program
    {
        static void Main(string[] args)
        {
            string UserId = "19701897";
            



            

         //   string token = "e16651b5485bbf73d0e19dbfa8cb4385b417041641f0a0543eec0f107e8dbf99e207ec37300d84558d0bf";
            HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(String.Format("https://api.vk.com/method/friends.get?user_id={0}", UserId));
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader myStream = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string friendsIds = myStream.ReadToEnd();


            
          
            friendsIds = friendsIds.Substring(13);
            friendsIds = friendsIds.Trim(new char[] { '{', '}', ':', ']' });

            String[] friendsIdsArray = friendsIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);





            JObject jsonObj;
            string wallPosts = "";
            int maxLike = 0;
            int maxPostId = 0;
            string idWithMaxLikes = "";

           for (int i = 0; i < friendsIdsArray.Length; i++)
            {
                myRequest = (HttpWebRequest)HttpWebRequest.Create(String.Format("https://api.vk.com/method/wall.get?owner_id={0}", friendsIdsArray[i]));
                myResponse = (HttpWebResponse)myRequest.GetResponse();
                myStream = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                wallPosts = myStream.ReadToEnd();



               

                
                jsonObj = JObject.Parse(wallPosts);
               
                
              if (jsonObj["response"] != null) {
                foreach (var result in jsonObj["response"])
                {

                    if (result.Next != null)
                    {

                        var currentPostId = Convert.ToInt32(result.Next["id"]);
                        var currentLike = Convert.ToInt32(result.Next["likes"]["count"]);
                       
                        
                      
                       
                        

                        
                        if(currentLike > maxLike)
                        {

                            maxLike = currentLike;
                            maxPostId = currentPostId;
                            idWithMaxLikes = friendsIdsArray[i];
                        }
                        
                  
                    }
                    


                }
                }

             }
           Console.WriteLine("Вы проверяли друзей пользователя со следующим ID: " + UserId);
           Console.WriteLine("Максимум лайков у друзей пользователя:" + maxLike);
           Console.WriteLine("Ссылка на пост: " + "https://vk.com/wall" + idWithMaxLikes + "_" + maxPostId);
          // Console.WriteLine(idWithMaxLikes);
           Console.ReadLine();
        }
      
    }
    
}
