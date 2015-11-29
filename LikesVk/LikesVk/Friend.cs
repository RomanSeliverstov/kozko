using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikesVk
{
    class Friend
    {
        string friendId, ownerId, linq;
        List<Post> posts = new List<Post>();
        public Friend(string ownerId, int friendId, string linq)
        {
           
            Query query = new Query();
            this.linq = linq;
            this.ownerId = ownerId;
            this.friendId = friendId.ToString();
            insertUserFriend(ownerId, friendId);
            AddFriendPost();
            

 
        }

        private void AddFriendPost()
        {
            int postLike;
            DateTime postDate;
            List<int> intPosts;
            Parser parser = new Parser(linq, friendId);
            intPosts = parser.GetUserPosts();
            for (int i = 0; i < intPosts.Count; i++)
            {
                postLike = parser.GetLikes(intPosts[i]);
                postDate = parser.GetDate(intPosts[i]);
                Post post = new Post(intPosts[i], Convert.ToInt32(friendId),postLike, postDate);
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
