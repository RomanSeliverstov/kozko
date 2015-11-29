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

    

        public void insertFriends(string mainUserId, string friendId)
        {
            sql.InsertIntoTable("INSERT INTO `vk_app`.`userfriends` (`UserID`, `FriendsID`) VALUES ("+mainUserId+","+ friendId+");");
        }

        public void insertPostsFriends(string friendId, string postId, string countLike, DateTime date)
        {
            sql.InsertIntoTable("INSERT INTO `vk_app`.`post` (`FriendID`, `PostID`, `CountLikes`, `Date`) VALUES (" + friendId + "," + postId + "," + countLike + ",'" + date.ToString("yyyy-MM-dd HH:mm:ss") +"');");
        }

        public void insertMainUser(string param, string firstName, string secondName)
        {
            //string strParam = param.ToString();
            sql.InsertIntoTable("INSERT INTO `vk_app`.`user` (`UserID`,`FirstName`,`SecondName`) VALUES (" + param + ",'" + firstName + "','" + secondName + "');");
            
        }

        public string GetUserLink()
        {
            return sql.GetLink("SELECT `link` FROM `vk_app`.`links`");
        }
    }
}
