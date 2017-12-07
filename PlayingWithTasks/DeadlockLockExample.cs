using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithTasks
{
    public class DeadlockLockExample
    {
        private readonly object locker1 = new object();
        private readonly object locker2 = new object();

        public void Start()
        {
            new Thread(() =>
            {
                Console.WriteLine("hello from NT");
                lock (locker1)
                {
                    Console.WriteLine("NT 1st lock");
                    Thread.Sleep(1000);
                    lock (locker2) { Console.WriteLine("NT 2nd lock"); }
                }
            }).Start();

            Console.WriteLine("main thread");

            lock (locker2)
            {
                Console.WriteLine("main 2nd lock");
                Thread.Sleep(1000);
                lock (locker1) { Console.WriteLine("main 1st lock"); }
            }
        }
    }
}
