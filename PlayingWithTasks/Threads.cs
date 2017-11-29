using System;
using System.Threading;

namespace PlayingWithTasks
{
    public class Threads
    {
        public void Start()
        {
            Thread clock = new Thread(WriteClockTime);
            clock.Start();

            Thread rnd = new Thread(GetRndNumber);
            rnd.Start();

            WriteClockTime();// main thread
        }

        private void GetRndNumber()
        {
            Random rnd = new Random();
            while (true)
            {
                Console.WriteLine(rnd.Next());
                Thread.Sleep(800);
            }
        }

        public void WriteClockTime()
        {
            while (true)
            {
                Console.WriteLine(DateTime.Now.TimeOfDay);
                Thread.Sleep(1000);
            }
        }
    }
}
