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
        private int[] arr;
        private Random rnd;
        private readonly object locker = new object();

        public ThreadsConcurency()
        {
            this.arr = new int[1000];
            this.rnd = new Random();
        }

        internal void Start()
        {
            Thread fillArr = new Thread(() =>
            {
                Console.WriteLine($"Started: {Thread.CurrentThread.Name}");
                for (int i = 0; i < this.arr.Length; i++)
                {
                    arr[i] = 1;
                }
            });

            fillArr.Name = nameof(fillArr);

            Thread zeroArr = new Thread(() =>
            {
                Console.WriteLine($"Started: {Thread.CurrentThread.Name}");
                for (int i = 0; i < this.arr.Length; i++)
                {
                    arr[i] = 0;
                }
            });

            zeroArr.Name = nameof(zeroArr);

            Thread printArr = new Thread(() =>
            {
                Console.WriteLine($"Started: {Thread.CurrentThread.Name}");
                foreach (var item in arr)
                {
                    Console.Write(item);
                }

            });

            printArr.Name = nameof(printArr);

            fillArr.Start();
            zeroArr.Start();
            printArr.Start();
            printArr.Join();
            Console.WriteLine("end");
        }
    }
}
