using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace DotNetCore.Models
{
class RestClient
    { 
        public static void SendOrderToDrone()
        {
            var api_url = "/Station/Read";
            string ip = "portal.clujbike.eu";
            string port = "";
            string protocol = "http";

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] data = encoder.GetBytes("");
            HttpWebRequest request = WebRequest.Create(@"" + protocol + "://" + ip + "" + port + api_url) as HttpWebRequest;
            request.ContentType = "application/x-www-form-urlencoded";//"application/json"  //"application/x-www-form-urlencoded"
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.Expect = "application/json";
            request.Timeout = 5000;

            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return ;
                    }

                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        var content = reader.ReadToEnd();
                        if (string.IsNullOrWhiteSpace(content))
                        {
                            response.Close();
                            Console.WriteLine("erros volt");
                            return ;
                        }
                        else
                        {
                            response.Close();
                            Console.WriteLine("jo volt");
                            return ;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                 Console.WriteLine("error volt"+ex);
                return ;
            }
        }
    }
}