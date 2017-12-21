using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PlayingWithTasks
{
    public class TimerSimulateLoop
    {
        private Timer t;
        private object locker = new object();

        public void Start()
        {
            t = new Timer(
               _ => DoJob(),
               null,
               TimeSpan.Zero,
               Timeout.InfiniteTimeSpan);
            Console.Read();
        }

        private void DoJob()
        {
            lock (locker)
            {
                Console.WriteLine(DateTime.Now);
            }

            lock (locker)
            {
                t.Change(TimeSpan.FromMilliseconds(1000), TimeSpan.FromMilliseconds(1000));
            }
        }
    }
}
