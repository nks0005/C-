using System;

namespace SignedUnsigned
{
    class Program
    {
        static void Main(string[] args)
        {
            byte a = 255; // 1111 1111
            sbyte b = (sbyte)a; // 1111 1111
            
            // 1111 1111을 2의 보수법 > 0000 0000 > 0000 0001 = 1 => -1

            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}