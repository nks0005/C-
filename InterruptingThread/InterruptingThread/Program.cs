using System;
using System.Threading;

namespace InterruptingThread
{
    class SideTask
    {
        int count;

        public SideTask(int count)
        {
            this.count = count;
        }

        public void KeepAlive()
        {
            try
            {
                Console.WriteLine("Running thread isn't gonna be interrupted");
                Thread.SpinWait(100);

                while (count > 0)
                {
                    Console.WriteLine("{0} left", count--);

                    Console.WriteLine("Entering into WaitJoinSleep State ...");
                    Thread.Sleep(10);
                }
                Console.WriteLine("Count : 0");
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Clearing resource...");
            }
        }
    }

    class Program
    {
        static public void CheckThreadState(Thread t1)
        {
            Console.WriteLine("t1 ThreadState : {0} \n", t1.ThreadState);
        }

        static void Main(string[] args)
        {
            SideTask task = new InterruptingThread.SideTask(100);
            Thread t1 = new Thread(new ThreadStart(task.KeepAlive));
            t1.IsBackground = false;

            // Check Thread State Func
            CheckThreadState(t1);

            Console.WriteLine("Starting thread...");
            t1.Start();

            CheckThreadState(t1);

            Thread.Sleep(1);

            Console.WriteLine("Interrupting thread...");
            t1.Interrupt();
            CheckThreadState(t1);

            Console.WriteLine("Waiting until thread stops...");
            t1.Join();
            CheckThreadState(t1);

            Console.WriteLine("Finished");
        }
    }
}