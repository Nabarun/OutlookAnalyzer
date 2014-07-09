using EmailAnalyzerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EmailAnalyzerTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Starting Environment");
            String streamObj = String.Empty; ;
            //ReadEmails emailDataObj = new ReadEmails();
            //streamObj = emailDataObj.ReadFromPop("outlook.office365.com", 995, "SSL");

            //emailDataObj.ReadFromOutlook();
            Console.WriteLine(streamObj);
            Console.ReadLine();
        }
    }
}
