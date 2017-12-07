using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Th = System.Threading;

namespace PlayingWithTasks
{
    class TimerAndTasks
    {
        public void Start()
        {
            ServiceA a = new ServiceA();
            ServiceB b = new ServiceB();
            ServiceC c = new ServiceC();
            int maxTime = 3000;
            
            var timerA = new Timer(maxTime - a.ResponseTime);
            timerA.Elapsed += new ElapsedEventHandler((object sender, ElapsedEventArgs e) =>
            {
                Console.WriteLine("### Timer Stopped ### \n");
                timerA.Stop();
                Console.WriteLine("### Scheduled Task Started ### \n\n");
                a.DoWork();
                Console.WriteLine($"{DateTime.Now.TimeOfDay}### Task A Finished ### \n\n");
            });

            var timerB = new Timer(maxTime - b.ResponseTime);
            timerB.Elapsed += new ElapsedEventHandler((object sender, ElapsedEventArgs e) =>
            {
                Console.WriteLine("### Timer Stopped ### \n");
                timerB.Stop();
                Console.WriteLine("### Scheduled Task Started ### \n\n");
                b.DoWork();
                Console.WriteLine($"{DateTime.Now.TimeOfDay}### Task B Finished ### \n\n");
            });

            var timerC = new Timer(maxTime - c.ResponseTime);
            timerC.Elapsed += new ElapsedEventHandler((object sender, ElapsedEventArgs e) =>
            {
                Console.WriteLine("### Timer Stopped ### \n");
                timerC.Stop();
                Console.WriteLine("### Scheduled Task Started ### \n\n");
                c.DoWork();
                Console.WriteLine($"{DateTime.Now.TimeOfDay}### Task C Finished ### \n\n");
            });

            timerA.Start();
            timerB.Start();
            timerC.Start();

            //timerA.Dispose();
            //timerB.Dispose();
            //timerC.Dispose();

            Console.ReadLine();
            Console.WriteLine("END");
        }

        // TODO - use one timer to execute 3 services
        //public void StartTwo()
        //{
        //    ServiceA a = new ServiceA();
        //    ServiceB b = new ServiceB();
        //    ServiceC c = new ServiceC();

        //    int max = 3000;
        //    object sender = null;
             
        //    Timer timer = new Timer();
        //    timer.Interval = max - a.ResponseTime;
        //    timer.Elapsed += Timer_Elapsed;
        //    timer.SynchronizingObject
        //}

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        class ServiceA
        {
            public int ResponseTime { get => 1000; }
            public void DoWork()
            {
                Console.WriteLine("Service A is working");
                Th.Thread.Sleep(1000);
            }
        }

        class ServiceB
        {
            public int ResponseTime { get => 2000; }
            public void DoWork()
            {
                Console.WriteLine("Service B is working");
                Th.Thread.Sleep(2000);
            }
        }

        class ServiceC
        {
            public int ResponseTime { get => 2999; }
            public void DoWork()
            {
                Console.WriteLine("Service C is working");
                Th.Thread.Sleep(2999);
            }
        }
    }
}
