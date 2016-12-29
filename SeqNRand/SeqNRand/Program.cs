using System;
using System.IO;

namespace SeqNRand
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream outStream = new FileStream("a.dat", FileMode.Create);
            Console.WriteLine("Position : {0}", outStream.Position);

            outStream.WriteByte(0x01);
            Console.WriteLine("Position : {0}", outStream.Position);

            outStream.WriteByte(0x02);
            Console.WriteLine("Position : {0}", outStream.Position);

            outStream.Seek(5, SeekOrigin.Current);
            Console.WriteLine("Position : {0}", outStream.Position);

            outStream.Seek(0, SeekOrigin.Begin);
            Console.WriteLine("Position : {0}", outStream.Position);

            outStream.Close();
        }
    }
}