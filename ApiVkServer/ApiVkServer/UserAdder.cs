using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiVkServer
{
    class UserAdder
    {
        public static UserModel AddMainUser(int userId){
             UserModel user = new UserModel();
             List<PostModel> posts = new List<PostModel>();
             PostModel post = new PostModel();
             JObject userInfo = ApiVkRequests.GetUserInfo(userId.ToString());
             user.Id = Convert.ToInt32(Parser.GetUserId(userInfo));
             user.FirstName = Parser.GetUserFirstName(userInfo);
             user.LastName = Parser.GetUserLastName(userInfo);
             List<int> postsId = Parser.GetUserPosts(ApiVkRequests.GetUserPosts(userId));
             for (int j = 0; j < postsId.Count; j++)
             {
                 post.userId = userId;
                 post.id = postsId[j];
                 post.Date = Parser.GetDate(ApiVkRequests.GetUserPosts(userId), postsId[j]);
                 post.likesCount = Parser.GetLikes(ApiVkRequests.GetUserPosts(userId), postsId[j]);
                 posts.Add(post);
             }

             user.Posts = posts;
             return user;

         }
       
         
         public static List<UserModel> AddFriends(List<int> friendsId, int ownerId){
           
             List<UserModel> friendsList = new List<UserModel>();
         
             
             for (int i = 0; i < 20; i++)
            {
               JObject friendInfo = ApiVkRequests.GetUserInfo(friendsId[i].ToString());
               UserModel friend = new UserModel();
               
               List<PostModel> postsList = new List<PostModel>();
               postsList.Clear();
               friend.ownerId = ownerId;
               friend.Id = Convert.ToInt32(Parser.GetUserId(friendInfo));
               friend.FirstName = Parser.GetUserFirstName(friendInfo);
               friend.LastName = Parser.GetUserLastName(friendInfo);
               friend.City = Parser.GetUserCity(friendInfo);
               List<int> postsId = Parser.GetUserPosts(ApiVkRequests.GetUserPosts(friendsId[i]));

               for (int j = 0; j < postsId.Count; j++)
               {
                   PostModel postModel = new PostModel();
                   postModel.userId = friendsId[i];
                   postModel.id = postsId[j];
                   postModel.Date = Parser.GetDate(ApiVkRequests.GetUserPosts(friendsId[i]),postsId[j]);
                   postModel.likesCount = Parser.GetLikes(ApiVkRequests.GetUserPosts(friendsId[i]), postsId[j]);
                   postsList.Add(postModel);
               }

               Console.WriteLine(postsList.Count);
               friend.Posts = postsList;
               friendsList.Add(friend);
               
           
            }
             return friendsList;
         }
         public static void InsertMainUser(UserModel user)
         {
             
                 MySqlQuery.insertMainUser(user);
             
         }
         public static void InsertFriends(List<UserModel> friends)
         {
             MySqlQuery.insertFriends(friends);
         }
     
      
    }


   
}
