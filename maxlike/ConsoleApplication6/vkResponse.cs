using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ConsoleApplication6
{
    class vkResponse
    {
        HttpWebRequest myRequest;
        HttpWebResponse myResponse;
        StreamReader myStream;
        String response;
        public string send(string request, string param)
        {
            myRequest = (HttpWebRequest)HttpWebRequest.Create(String.Format(request, param));
            myResponse = (HttpWebResponse)myRequest.GetResponse();
            myStream = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            return response = myStream.ReadToEnd();

            
        }

    }
}
