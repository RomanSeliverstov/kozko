using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikesVk
{
    class Friend
    {
        string friendId, ownerId, friendFam, friendName, linq, city;
        List<Post> posts = new List<Post>();
        
        public Friend(string ownerId, int friendId, string linq)
        {
         
            Query query = new Query();
            this.linq = linq;
            this.ownerId = ownerId;
           
            this.friendId = friendId.ToString();
            Parser parser = new Parser(this.linq, this.friendId);
            this.friendName = parser.GetUserInfo(this.friendId, 1);
            this.friendFam = parser.GetUserInfo(this.friendId, 2);
            this.city = parser.GetUserInfo(this.friendId, 3);
            insertUserFriend(ownerId, friendId);
            query.insertFriendInformation(this.friendId, this.friendName,this.friendFam,this.city);
            AddFriendPost();
            

 
        }

        private void AddFriendPost()
        {
            
            List<int> intPosts;
            Parser parser = new Parser(linq, friendId);
            intPosts = parser.GetUserPosts();
            for (int i = 0; i < intPosts.Count; i++)
            {
                Post post = new Post(intPosts[i], Convert.ToInt32(friendId),parser.GetLikes(intPosts[i]), parser.GetDate(intPosts[i]), 0, parser.GetTextPost(intPosts[i]));
                posts.Add(post);                
            }
        }

        private void insertUserFriend(string mainUserId, int userFriends)
        {
            Query query = new Query();
            query.insertFriends(mainUserId.ToString(), userFriends.ToString());
        }
        
       
    }
}
