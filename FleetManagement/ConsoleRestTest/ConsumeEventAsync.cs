using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRestTest
{
    public class ConsumeEventAsync
    {
        public async Task<string> GetAllFuelData() 
        {
            try
            {
                using (var client = new HttpClient()) 
                {
                    Console.ReadLine();
                    //client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    //client.Headers.Add("Accept:application/json");
                    var byteArray = Encoding.ASCII.GetBytes("username4321:password1234");
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                                        
                    var result = await client.GetAsync("https://10.10.11.144:4435/api/Hello");
                    Console.WriteLine(result.Content.ReadAsStringAsync());
                    Console.ReadLine();
                    return result.Content.ReadAsStringAsync().ToString();
                }

            }catch(Exception ex)
            {
                return null;
                
            }
        }
    }

}
