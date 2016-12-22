using System;

namespace DerivedInterface
{
    interface ILogger
    {
        void WriteLog(string message);
    }

    interface IFormattableLogger : ILogger
    {
        void WriteLog(string format, params Object[] args);
    }

    class ConsoleLogger2 : IFormattableLogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
        }

        public void WriteLog(string format, params object[] args)
        {
            String message = String.Format(format, args);
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
        }
        
        public void Test()
        {
            Console.WriteLine("Test");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IFormattableLogger logger = new ConsoleLogger2();

            logger.WriteLog("The world is not flat");
            logger.WriteLog("{0} + {1} = {2}", 1, 1, 2);
            // logger.Test(); logger 인터페이스에는 Test가 없어서 안됨.... 

            ConsoleLogger2 CL = new ConsoleLogger2();
            CL.Test(); 
        }
    }
}