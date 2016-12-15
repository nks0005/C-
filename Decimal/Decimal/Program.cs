using System;

namespace Decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            float a = 3.1415926535897932384626433383279f;
            double b = 3.1415926535897932384626433383279;
            decimal c = 3.1415926535897932384626433383279m;

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }
    }
}