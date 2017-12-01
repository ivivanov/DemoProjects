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
        private static object locker1 = new object();
        private static object locker2 = new object();

        static void Main(string[] args)
        {
            //TaskDelay.Start();
            //new TimerAndTasks().Start();
            //new Threads().Start();
            //new ThreadsConcurency().Start();
            //new TwoThreadsSameData().Start();
            //new ForeGRAndBGR().Start();
            //new Deadlock().Start();
            //new MutexDemo().Start();
            new SemaphoreDemo().Start();
        }
    }
}
