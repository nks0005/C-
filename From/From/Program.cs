using System;
using System.Linq;

namespace From
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 9, 2, 6, 4, 5, 3, 7, 8, 1, 10 };

            var result = from n in numbers
                         where n % 2 == 0
                         orderby n 
                         select n;
            /*
             * from in : in 안에 있는 각 데이터로부터,
             * where 조건식 : 조건식이 true 인 객체만 골라,
             * orderby 객체의 변수 : 객체의 변수로 정렬(만약 키면, 키순)
             * select 객체 : 객체를 추출.
             */

            foreach (int n in result)
                Console.WriteLine("짝수 : {0}", n);
        }
    }
}