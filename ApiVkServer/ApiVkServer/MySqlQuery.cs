using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;


namespace ApiVkServer
{
    public class MySqlQuery
    {

      public static void insertMainUser(UserModel user)
        {
           MySqlOperations.InsertIntoTable("INSERT INTO `vk`.`user` (`UserID`,`FirstName`,`SecondName`) VALUES (" + @user.Id + ",'" + @user.FirstName + "','" + @user.LastName + "');");
           for (int j = 0; j < user.Posts.Count; j++)
           {
               MySqlOperations.InsertIntoTable("INSERT INTO `vk`.`userposts` (`userId`, `postId`, `CountLikes`, `Date`, `postText`) VALUES (" + @user.Id + ", " + @user.Posts[j].id + ", " + @user.Posts[j].likesCount + ", '" + @user.Posts[j].Date.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + @user.Posts[j].text + "');");
           }
        }
      public static void insertFriends(List<UserModel> friends)
      {
          for (int i = 0; i < friends.Count; i++)
          {
              MySqlOperations.InsertIntoTable("INSERT INTO `vk`.`friends` (`FriendID`, `FirstName`, `SecondName`, `City`, `OwnerId`) VALUES (" + @friends[i].Id +",'" + @friends[i].FirstName +"', '" + @friends[i].LastName +"', '" + @friends[i].City +"'," + @friends[i].ownerId +");");
              for(int j = 0; j < friends[i].Posts.Count; j++){
                  MySqlOperations.InsertIntoTable("INSERT INTO `vk`.`friendsposts` (`FriendID`, `PostID`, `CountLikes`, `Date`, `Text`) VALUES (" + @friends[i].Id + "," + @friends[i].Posts[j].id + "," + @friends[i].Posts[j].likesCount + ", '" + @friends[i].Posts[j].Date.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + @friends[i].Posts[j].text + "');");
              }
          }
      }

      public static void insertNewPosts(List<PostModel> Posts, string friend)
      {
         for (int j = 0; j < Posts.Count; j++)
              {
                  MySqlOperations.InsertIntoTable("INSERT INTO `vk`.`friendsposts` (`FriendID`, `PostID`, `CountLikes`, `Date`, `Text`) VALUES (" + @friend + "," + @Posts[j].id + "," + @Posts[j].likesCount + ", '" + @Posts[j].Date.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + @Posts[j].text + "');");
              }
      }
      
      public static DataTable ReturnUserName(string id)
      {
          return MySqlOperations.GetData("SELECT FirstName FROM user WHERE UserID = " + @id);
      }
      
      public static DataTable ReturnIdFriends()
      {
          return MySqlOperations.GetData("SELECT FriendID from friends");
      }

        
      public static DataTable ReturnIdFriendsCount()
      {
          return MySqlOperations.GetData("Select count(FriendID) from friends");
      }

      public static void InsertNewUsers(string mainUser, string friendId)
      {
          MySqlOperations.InsertIntoTable("INSERT INTO `vk`.`friends` (`FriendID`, `OwnerId`) VALUES ("+@friendId + ", "+@mainUser+")");
          
      }

      public static void DeleteFriendPosts(string friendID)
      {
          MySqlOperations.InsertIntoTable("DELETE FROM friendsposts where FriendID ="+@friendID+"");
          
      }
      public static DataTable ReturnLinks()
      {
         return MySqlOperations.GetData("select * from links");
      }

      public static DataTable Checkuser(string userId)
      {
         return MySqlOperations.GetData("select FirstName from user where UserId =" + @userId +"");
      }
        public static DataTable ReturnUsers()
      {
          return MySqlOperations.GetData("select * from user");
      }
    }
}
