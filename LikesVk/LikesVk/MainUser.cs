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
        List<Post> posts;
        string mainUserId, mainUserFirstName, mainUserSecondName;
        string linq;
        public MainUser(string linq, bool param)
        {
           
            Query query = new Query();
            this.linq = linq;
            Parser parser = new Parser(linq, "0");
            this.mainUserId = parser.GetUserInfo(linq, 0);
            this.mainUserFirstName = parser.GetUserInfo(linq, 1);
            this.mainUserSecondName = parser.GetUserInfo(linq, 2);
            if (param == true) AddUserFriend();
            if (param == false) query.insertMainUser(mainUserId, mainUserFirstName, mainUserSecondName);
        }

     
        private void AddUserFriend()
        {
            List<int> friends;
            Parser parser = new Parser(linq, "0");
            friends = parser.parseFriendsId();
            for (int i = 0; i < friends.Count; i++)
            {
                Friend friend =  new Friend(mainUserId, friends[i], linq);
                userFriends.Add(friend);
                
            }
          
        }
        


        

    }
}
