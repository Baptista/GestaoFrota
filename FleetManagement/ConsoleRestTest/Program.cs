using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRestTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsumeEventAsync objsync = new ConsumeEventAsync();
            objsync.GetAllFuelData();
        }
    }
}
