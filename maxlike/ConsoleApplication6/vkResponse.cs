using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ConsoleApplication6
{
    class VkResponse : IVkResponse
    {
        HttpWebRequest myRequest;
        HttpWebResponse myResponse;
        StreamReader myStream;
        String response;
        public string Send(string request, string param)
        {
            myRequest = (HttpWebRequest)HttpWebRequest.Create(String.Format(request, param));
            myResponse = (HttpWebResponse)myRequest.GetResponse();
            myStream = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            return myStream.ReadToEnd();
        }
    }
}
