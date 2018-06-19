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
        public static void SendOrderToDrone(Order order)
        {
            var api_url = "/api/orders";
            string ip = "localhost";
            string port = ":8081";
            string protocol = "http";
            string url = "" + protocol + "://" + ip + "" + port + api_url;

            string postData = Newtonsoft.Json.JsonConvert.SerializeObject(order);
            Console.WriteLine("%%%%  "+ url +"   "+ postData);
            ASCIIEncoding encoding = new ASCIIEncoding ();
            byte[] byte1 = encoding.GetBytes (postData);
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ContentType = "application/json";//"application/x-www-form-urlencoded";//"application/json"  //"application/x-www-form-urlencoded"
            request.Method = "POST";
            request.Expect = "application/json";
            request.Timeout = 5000;
            System.Net.ServicePointManager.Expect100Continue = false;
            request.ContentLength = byte1.Length;
            Stream newStream = request.GetRequestStream ();
            newStream.Write (byte1, 0, byte1.Length);
            newStream.Close();
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