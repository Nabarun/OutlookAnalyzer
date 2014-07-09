using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogger
{
    public static class LoggerClass
    {
        public static void WriteException(DateTime logDate, string exceptionThrownAt, string ExceptionDetails)
        {
            using (StreamWriter sw = new StreamWriter("ExceptionLog.txt", true))
            {
                sw.WriteLine(logDate+" | "+ "Exception thrown at : "+ exceptionThrownAt+" | "+ExceptionDetails);
            }
        }
    }
}
