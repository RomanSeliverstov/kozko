using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebApplication1
{
    public class Query
    {
         DataBase sql = new DataBase();

        public void InsertLink (string link)
        {
            sql.InsertIntoTable("INSERT INTO links (`link`) VALUES ('" + link + "');");
        }

        public void InsertEmptyLink()
        {
            sql.InsertIntoTable("INSERT INTO links (`link`) VALUES ('0');");
        }

        public DataTable GetInfo ()
        {
            return sql.GetComments("SELECT `UserID`, `FirstName`, `SecondName` FROM friendsposts WHERE ;");
        }

        public DataTable GetTopWeek()
        {
            return sql.GetComments("SELECT DISTINCT f.FriendId as 'ID пользователя', f.FirstName as Имя, f.SecondName as Фамилия, fp.PostID as 'ID сообщения', fp.CountLikes as Лайки, fp.Date as Дата, fp.Text as Текст FROM friendsposts fp, friends f WHERE fp.Date >= DATE_SUB(CURRENT_DATE, INTERVAL 7 DAY) ORDER BY fp.CountLikes desc LIMIT 0,10;");
            
        }

        public DataTable GetTopDay()
        {
            return sql.GetComments("SELECT DISTINCT f.FriendId as 'ID пользователя', f.FirstName as Имя, f.SecondName as Фамилия, fp.PostID as 'ID сообщения', fp.CountLikes as Лайки, fp.Date as Дата, fp.Text as Текст FROM friendsposts fp, friends f WHERE fp.Date >= CURRENT_DATE and fp.FriendId = f.FriendID ORDER BY fp.CountLikes desc LIMIT 0,10;");

        }

        public DataTable GetTopBetween(string dateStart, string dateStop)
        {
            return sql.GetComments("SELECT DISTINCT f.FriendId as 'ID пользователя', f.FirstName as Имя, f.SecondName as Фамилия, fp.PostID as 'ID сообщения', fp.CountLikes as Лайки, fp.Date as Дата, fp.Text as Текст FROM friendsposts fp, friends f WHERE fp.Date BETWEEN '" + dateStart + "' AND '" + dateStop + "' ORDER BY fp.CountLikes desc LIMIT 0,10;");
        }

        public DataTable GetTopCity (string city)
        {
            return sql.GetComments("Select DISTINCT f.FriendId as 'ID пользователя', f.FirstName as Имя, f.SecondName as Фамилия, fp.PostID as 'ID сообщения', fp.CountLikes as Лайки, fp.Date as Дата, fp.Text as Текст, f.City as Город from friendsposts fp, friends f where fp.FriendID = f.FriendID and city like '" + city + "' ORDER BY CountLikes desc LIMIT 0,10;");
        }

        public DataTable GetCities ()
        {
            return sql.GetComments("select distinct city from friends where city != '-'");
        }
    }
}