using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRestTest
{
    public class ConsumeEventAsync
    {
        public void GetAllFuelData() //Get All Events Records  
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:57303/api/Combustivels"); //URI  
                Console.WriteLine(Environment.NewLine + result);
                Console.ReadLine();
            }
        }
    }

}
