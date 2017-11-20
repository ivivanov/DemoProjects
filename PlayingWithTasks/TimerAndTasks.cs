using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

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

            //DateTime nowTime = DateTime.Now;
            //DateTime scheduledTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day,
                                                    //nowTime.Hour, nowTime.Minute, nowTime.Second + 2, 0);


            //double tickTime = (double)(scheduledTime - DateTime.Now).TotalMilliseconds;
            //timer = new Timer(tickTime);
            var timerA = new Timer(maxTime - a.ResponseTime);
            timerA.Elapsed += new ElapsedEventHandler((object sender, ElapsedEventArgs e) =>
            {
                Console.WriteLine("### Timer Stopped ### \n");
                timerA.Stop();
                Console.WriteLine("### Scheduled Task Started ### \n\n");
                a.DoWork();
                Console.WriteLine($"{DateTime.Now.TimeOfDay}### Task A Finished ### \n\n");
            });
            timerA.Start();

            var timerB = new Timer(maxTime - b.ResponseTime);
            timerB.Elapsed += new ElapsedEventHandler((object sender, ElapsedEventArgs e) =>
            {
                Console.WriteLine("### Timer Stopped ### \n");
                timerB.Stop();
                Console.WriteLine("### Scheduled Task Started ### \n\n");
                b.DoWork();
                Console.WriteLine($"{DateTime.Now.TimeOfDay}### Task B Finished ### \n\n");
            });
            timerB.Start();

            var timerC = new Timer(maxTime - c.ResponseTime);
            timerC.Elapsed += new ElapsedEventHandler((object sender, ElapsedEventArgs e) =>
            {
                Console.WriteLine("### Timer Stopped ### \n");
                timerC.Stop();
                Console.WriteLine("### Scheduled Task Started ### \n\n");
                c.DoWork();
                Console.WriteLine($"{DateTime.Now.TimeOfDay}### Task C Finished ### \n\n");
            });
            timerC.Start();

            Console.WriteLine("END");
        }

        class ServiceA
        {
            public int ResponseTime { get => 1000; }
            public void DoWork() => System.Threading.Thread.Sleep(1000);
        }

        class ServiceB
        {
            public int ResponseTime { get => 2000; }
            public void DoWork() => System.Threading.Thread.Sleep(2000);
        }

        class ServiceC
        {
            public int ResponseTime { get => 2999; }
            public void DoWork() => System.Threading.Thread.Sleep(2999);
        }
    }
}
