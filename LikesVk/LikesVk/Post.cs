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

        public Post(int postId, int userId, int likes, DateTime date)
        {
            this.likes = likes;
            this.date = date;
            this.postId = postId;
            this.userId = userId;
            Query query = new Query();
            query.insertPostsFriends(userId.ToString(), postId.ToString(), likes.ToString(), date);
        }


       
      public void Display()
        {
            Console.WriteLine("Владелец: " + userId + "Пост айди: " + postId + "Количество лайков: " + likes + "Дата:" + date);
        }

   
    }
}
