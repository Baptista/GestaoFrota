using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleRestTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback =
    delegate (object s, X509Certificate certificate,
             X509Chain chain, SslPolicyErrors sslPolicyErrors)
    { return true; };

                //new Program().callMethod();


                new Thread(() =>
                {
                    using (var client = new HttpClient())
                    {
                        Console.ReadLine();
                        var byteArray = Encoding.ASCII.GetBytes("username4321:password1234");
                        client.DefaultRequestHeaders.Authorization =
                            new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                        var result = client.GetAsync("https://10.10.11.144:4435/api/Hello");

                        var a = result.Result.Content.ReadAsStringAsync();
                        Console.WriteLine(a.Result);
                        Console.ReadLine();
                    }

                }).Start();



            }
            catch(Exception ex)
            {
                var a = 0;
            }
        }

        public async void callMethod()
        {
            ConsumeEventAsync objsync = new ConsumeEventAsync();
            
            var a = await objsync.GetAllFuelData();
            
        }

    }
}
