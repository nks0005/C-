using System;

namespace Delegate_ex_2
{
    delegate void EventHandler(string message);

    class Event
    {
        public event EventHandler Happend;
        public void DoHappend(int number)
        {
            int temp = number;

            if (temp == 30)
            {
                Happend(string.Format("축하합니다! 30번째 고객 이벤트에 당첨되셨습니다."));
            }
        }
    }

    class Program
    {
        static public void MyHandler(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            Event EV = new Event();
            EV.Happend += new EventHandler(MyHandler);

            for(int i=1; i<50; i++)
            {
                EV.DoHappend(i);
            }
        }
    }
}