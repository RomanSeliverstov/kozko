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
            Wall Wall = new Wall(new VkResponse());
            Console.WriteLine(Wall.GetMaxLike(Wall.GetIdsFriends(Wall.ParseVkLink("https://vk.com/seliverstov_roman"))));
          
            Console.ReadLine();
        }
      
    }
    
}
