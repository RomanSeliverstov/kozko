using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ApiVkServer
{
    class UserUpdater
    {
        public static List<int> ReturnFriendsList(string currentOwnerId)
        {
            List<int> friendsId = Parser.ParseFriendsId(ApiVkRequests.GetUserFriends(currentOwnerId));
            return friendsId;
            

        }

        public static List<int> CheckCurrentFriends(List<int> friendsId)
        {
            DataTable friendsCount;
            int countFriends;
            List<int> currentFriendsList = new List<int>();
            List<int> diffrerenceFriendsList = new List<int>();

            friendsCount = MySqlQuery.ReturnIdFriendsCount();
            countFriends = friendsCount.Rows[0].Field<int>("count(FriendID)");
            DataTable currentFriendsTable = MySqlQuery.ReturnIdFriends();
            for (int i = 0; i <= countFriends; i++ )
            {
                currentFriendsList[i] = currentFriendsTable.Rows[i].Field<int>("FriendID");
                

            }
              diffrerenceFriendsList = friendsId.Except(currentFriendsList).ToList();

              return diffrerenceFriendsList;
         }

        public static void AddNewFriends(List<int> newfriends, string owner)
        {
            foreach (int friend in newfriends)
            {
                MySqlQuery.InsertNewUsers(owner, friend.ToString());
            }
        }

    }
}
