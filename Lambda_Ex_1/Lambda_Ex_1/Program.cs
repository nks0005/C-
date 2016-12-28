using System;

namespace Lambda_Ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 11, 22, 33, 44, 55 };

            foreach(int a in array)
            {
                Action action = () => Console.WriteLine(a * a);
                action.Invoke();
            }
        }
    }
}