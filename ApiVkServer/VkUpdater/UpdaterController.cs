using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVkServer
{
    class UpdaterController
    {
        public static void UpdateAllFriends(string currentOwnerId)
        {
            
            UserUpdater.AddNewFriends(UserUpdater.CheckCurrentFriends(UserUpdater.ReturnFriendsList(currentOwnerId)), currentOwnerId);
            List<int> friendsId = Parser.ParseFriendsId(ApiVkRequests.GetUserFriends(currentOwnerId));
            List<PostModel> postsList = new List<PostModel>();

            foreach(int friend in friendsId)
            {
                MySqlQuery.DeleteFriendPosts(friend.ToString());
                
                List<int> postsId = Parser.GetUserPosts(ApiVkRequests.GetUserPosts(friend));


                for (int j = 0; j < postsId.Count; j++)
                {
                    PostModel postModel = new PostModel();
                    postModel.userId = friend;
                    postModel.id = postsId[j];
                    postModel.Date = Parser.GetDate(ApiVkRequests.GetUserPosts(friend), postsId[j]);
                    postsList.Add(postModel);

                }
                MySqlQuery.insertNewPosts(postsList, friend.ToString());
            }
        }
    }
}
