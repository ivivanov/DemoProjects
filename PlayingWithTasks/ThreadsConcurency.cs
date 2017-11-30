using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithTasks
{
    class ThreadsConcurency
    {
        private int divider;
        private int val;
        private Random rnd;
        private readonly object locker = new object();

        public ThreadsConcurency()
        {
            divider = 1;
            val = 1;
            this.rnd = new Random();
        }

        internal void Start()
        {
            Thread doWorkTaskOne = new Thread(() =>
            {
                Console.WriteLine($"Started: {Thread.CurrentThread.Name}");
                while (true)
                {
                    DoWork();
                }
            });

            doWorkTaskOne.Name = nameof(doWorkTaskOne);

            Thread doWorkTaskTwo = new Thread(() =>
            {
                Console.WriteLine($"Started: {Thread.CurrentThread.Name}");
                while (true)
                {
                    DoWork();
                }
            });

            doWorkTaskTwo.Name = nameof(doWorkTaskTwo);

            doWorkTaskOne.Start();
            doWorkTaskTwo.Start();
        }

        private void DoWork()
        {
            //Uncoment to prevent dirty read of divider
            //lock (locker)
            {
                double result = 0;

                if (divider != 0)
                {
                    Thread.Sleep(1);// representation of some time consuming operation
                    result = val / divider;
                }

                divider = rnd.Next(0, 2);
                Console.WriteLine(divider);
            }
        }
    }
}
