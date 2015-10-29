using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;




namespace ConsoleApplication6

{
    class Program
    {
        static void Main(string[] args)
        {
            wall Wall = new wall(false);
           Console.WriteLine(Wall.getMaxLikePost(Wall.getFriendsId(Wall.getMyId("https://vk.com/seliverstov_roman"))));
          
            Console.ReadLine();
        }
      
    }
    
}
