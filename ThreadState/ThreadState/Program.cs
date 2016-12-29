using System;
using System.Threading;

namespace UsingThreadState
{
    class Program
    {
        public static void PrintThreadState(ThreadState state)
        {
            Console.WriteLine("{0,-20} : {1}", state, (int)state);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            PrintThreadState(ThreadState.Running);
            // 0
            PrintThreadState(ThreadState.StopRequested);
            // 1
            PrintThreadState(ThreadState.SuspendRequested);
            // 2
            PrintThreadState(ThreadState.Background);
            // 4
            PrintThreadState(ThreadState.Unstarted);
            // 8
            PrintThreadState(ThreadState.Stopped);
            // 16
            PrintThreadState(ThreadState.WaitSleepJoin);
            // 32
            PrintThreadState(ThreadState.Suspended);
            // 64
            PrintThreadState(ThreadState.AbortRequested);
            // 128
            PrintThreadState(ThreadState.Aborted);
            // 256  
            PrintThreadState(ThreadState.Aborted | ThreadState.Stopped);
            // 256 + 16 = 272 
            /*
             ThreadState.Running = 0000 0000
             ThreadState.StopRequested = 0000 0001
             ThreadState.SuspendRequested = 0000 0010
             ThreadState.Background = 0000 0100
             ThreadState.Unstarted = 0000 1000
             ThreadState.Stopped = 0001 0000
             ThreadState.WaitSleepJoin = 0010 0000
             ThreadState.Suspended = 0100 0000
             ThreadState.AbortRequested = 1000 0000
             ThreadState.Aborted = 1 0000 0000      

             ThreadState.Aborted | ThreadState.Stopped = 1 0001 0000 => 272
             */
        }
    }
}