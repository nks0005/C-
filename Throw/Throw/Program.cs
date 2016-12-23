using System;

namespace Throw
{
    class Program
    {
        static void DoSomething(int arg)
        {
            if (arg < 10)
                Console.WriteLine("arg : {0}", arg);
            else
                throw new Exception("arg가 10보다 큽니다.");
        }

        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < 13; i++)
                    DoSomething(i);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}