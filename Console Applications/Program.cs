using EntityFramework;
using System;
using System.Globalization;
using System.Linq;

namespace Console_Applications
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime YourDate = new DateTime(2020, 12, 2);
            string formattedDate = YourDate.ToString("dd MMMM yyyy");


            Console.WriteLine("formattedDate :" + formattedDate);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
    
}
