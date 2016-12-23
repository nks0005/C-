using System;

namespace InitializingArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Array = new string[3] { "안녕", "Hello", "Halo" };
            Console.WriteLine("array...");
            foreach (string greeting in Array)
                Console.WriteLine(" {0}", greeting);
        }
    }
}