using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //TaskDelay.Start();
            new TimerAndTasks().Start();
            //new Threads().Start();
            //new ThreadsConcurency().Start();
            //new TwoThreadsSameData().Start();
            //new ForeGRAndBGR().Start();
            //new Deadlock().Start();
            //new MutexDemo().Start();
            //new SemaphoreDemo().Start();
            //new SignalingEventWaitHandles().Start();
            //new GateStyleStartThreads().Start();
            //new DeadlockDemoTwo().Start();
            //new PlayingWithBackgroundWorker().Start();
        }
    }
}
