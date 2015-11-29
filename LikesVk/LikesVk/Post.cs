using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikesVk
{
    class Post
    {
        private int userId;
        private int likes;
        private DateTime date;
        private int postId;
        private string text;

        public Post(int postId, int userId, int likes, DateTime date, int isChecked, string text)
        {
            this.likes = likes;
            this.date = date;
            this.postId = postId;
            this.userId = userId;
            this.text = text;
            Query query = new Query();
            if (isChecked == 0) query.insertPostsFriends(userId.ToString(), postId.ToString(), likes.ToString(), date, text);
            else query.insertPostMainUser(userId.ToString(), postId.ToString(), likes.ToString(), date);
            
        }


       
      public void Display()
        {
            Console.WriteLine("Владелец: " + userId + "Пост айди: " + postId + "Количество лайков: " + likes + "Дата:" + date);
        }

   
    }
}
