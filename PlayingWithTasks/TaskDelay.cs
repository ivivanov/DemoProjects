using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithTasks
{
    class TaskDelay
    {
        public static void Start()
        {
            ServiceA a = new ServiceA();
            ServiceB b = new ServiceB();
            ServiceC c = new ServiceC();

            int maxDelay = 3000;
            var sw = new Stopwatch();
            sw.Start();

            Task taskA = Task.Delay(maxDelay - a.ResponseTime).ContinueWith(x =>
            {
                Console.WriteLine("a");
                a.DoWork();
                Console.WriteLine($"taskA ready for {sw.Elapsed}");
            });

            Task taskB = Task.Delay(maxDelay - b.ResponseTime).ContinueWith(x =>
            {
                Console.WriteLine("b");
                b.DoWork();
                Console.WriteLine($"taskB ready for {sw.Elapsed}");
            });

            Task taskC = Task.Delay(maxDelay - c.ResponseTime).ContinueWith(x =>
            {
                Console.WriteLine("c");
                c.DoWork();
                Console.WriteLine($"taskC ready for {sw.Elapsed}");
            });

            Task.WaitAll(new Task[] { taskA, taskB, taskC});

            //taskA.Wait();
            //taskB.Wait();
            //taskC.Wait();
        }
    }



    class ServiceA
    {
        public int ResponseTime { get => 500; }
        public void DoWork() => Thread.Sleep(500);
    }

    class ServiceB
    {
        public int ResponseTime { get => 1000; }
        public void DoWork() => Thread.Sleep(1000);
    }

    class ServiceC
    {
        public int ResponseTime { get => 3000; }
        public void DoWork() => Thread.Sleep(3000);
    }
}
