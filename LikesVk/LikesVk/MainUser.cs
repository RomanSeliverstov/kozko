using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikesVk
{
    class MainUser
    {
        List<Friend> userFriends = new List<Friend>();
        List<Post> posts = new List<Post>();
        string mainUserId, mainUserFirstName, mainUserSecondName, mainUserCity;
        string linq;
        public MainUser(string linq, int param)
        {
           
            Query query = new Query();
            this.linq = linq;
            Parser parser = new Parser(linq, "0");
            this.mainUserId = parser.GetUserInfo(parser.ParserLink(linq), 0);
            this.mainUserFirstName = parser.GetUserInfo(parser.ParserLink(linq), 1);
            this.mainUserSecondName = parser.GetUserInfo(parser.ParserLink(linq), 2);
            this.mainUserCity = parser.GetUserInfo(parser.ParserLink(linq), 3);
            query.insertMainUser(mainUserId, mainUserFirstName, mainUserSecondName);
            if (param == 1) AddUserFriend();
            else AddUserPost();
            
        }




        private void AddUserPost()
        {
           
            List<int> intPosts;
            Parser parser = new Parser(linq, mainUserId);
            intPosts = parser.GetUserPosts();
            for (int i = 0; i < intPosts.Count; i++)
            {
                Post post = new Post(intPosts[i], Convert.ToInt32(mainUserId), parser.GetLikes(intPosts[i]), parser.GetDate(intPosts[i]), 1, parser.GetTextPost(intPosts[i]));
                posts.Add(post);
            }
        }
   

        private void AddUserFriend()
        {
            
            List<int> friends;
            Parser parser = new Parser(linq, "0");
            friends = parser.ParseFriendsId();
            for (int i = 0; i < friends.Count; i++)
            {
                Friend friend =  new Friend(mainUserId, friends[i], linq);
                userFriends.Add(friend);
                
            }
          
        }
        


        

    }
}
