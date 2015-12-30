using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;

namespace ApiVkServer
{
    class AdderController
    {
    
        public static void AddAllFriends(string linq)
        {
            List<UserModel> friendsList = new List<UserModel>();
            List<UserModel> ownersList = new List<UserModel>();
            JObject userInfo = ApiVkRequests.GetUserInfo(Parser.ParserLink(linq));
            string currentOwnerId = Parser.GetUserId(userInfo);
            List<int> friendsId = Parser.ParseFriendsId(ApiVkRequests.GetUserFriends(currentOwnerId));
            UserModel currentOwner = UserAdder.AddMainUser(Convert.ToInt32(currentOwnerId));
            ownersList.Add(currentOwner);
            friendsList.AddRange(UserAdder.AddFriends(friendsId, Convert.ToInt32(currentOwnerId)));
            UserAdder.InsertMainUser(currentOwner);
            UserAdder.InsertFriends(friendsList);
        }
    }
}
