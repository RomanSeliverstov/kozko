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
            wall Wall = new wall();

            Console.WriteLine("Ссылка на пост: " + "https://vk.com/wall" + Wall.getMaxLikePost());
          
            Console.ReadLine();
        }
      
    }
    
}
