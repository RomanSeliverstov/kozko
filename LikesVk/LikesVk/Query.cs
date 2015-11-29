using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikesVk
{
    class Query
    {
        MySQLConnectionBuilder sql = new MySQLConnectionBuilder();

        public  string GetUserLink(string param)
        {
            return sql.GetData("SELECT `link` FROM `vk_app`.`links`", param);
        }

        public string GetChecked(string param)
        {
            return sql.GetData("SELECT `param` FROM `vk_app`.`links`", param);
        }

        public void insertFriends(string mainUserId, string friendId)
        {
            sql.InsertIntoTable("INSERT INTO `vk_app`.`userfriends` (`UserID`, `FriendsID`) VALUES ("+mainUserId+","+ friendId+");");
        }

        public void insertPostsFriends(string friendId, string postId, string countLike, DateTime date, string text)
        {
            sql.InsertIntoTable("INSERT INTO `vk_app`.`friendsposts` (`FriendID`, `PostID`, `CountLikes`, `Date`, `Text`) VALUES (" + friendId + "," + postId + "," + countLike + ",'" + date.ToString("yyyy-MM-dd HH:mm:ss") + "','"+text+"');");
        }

        public void DeleteAllData()
        {
            sql.InsertIntoTable("DELETE FROM friendsposts");
            sql.InsertIntoTable("DELETE FROM userposts");
            sql.InsertIntoTable("DELETE FROM friends");
            sql.InsertIntoTable("DELETE FROM userfriends");
            sql.InsertIntoTable("DELETE FROM user");
            
        }

        public void insertPostMainUser(string userId, string postId, string countLike, DateTime date)
        {
            sql.InsertIntoTable("INSERT INTO `vk_app`.`userposts` (`userId`, `postID`, `CountLikes`, `Date`) VALUES (" + userId + "," + postId + "," + countLike + ",'" + date.ToString("yyyy-MM-dd HH:mm:ss") + "');");
        }

        public void insertMainUser(string param, string firstName, string secondName)
        {
            //string strParam = param.ToString();
            sql.InsertIntoTable("INSERT INTO `vk_app`.`user` (`UserID`,`FirstName`,`SecondName`) VALUES (" + param + ",'" + firstName + "','" + secondName + "');");
            
        }

        public void insertFriendInformation(string friendId, string firstName, string secondName, string city)
        {
            sql.InsertIntoTable("INSERT INTO `vk_app`.`friends` (`FriendID`, `FirstName`, `SecondName`, `City`) VALUES ("+friendId+", '"+firstName+"', '"+secondName+"', '"+city+"');");
        }
    }
}
