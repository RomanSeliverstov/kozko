using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ConsoleApplication6
{
    public class VkResponse : IVkResponse
    {
         public string Send(string request, string param)
        {
            HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(String.Format(request, param));
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader myStream = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            return myStream.ReadToEnd();
        }
    }
}
