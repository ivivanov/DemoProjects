using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithTasks
{
    public class ForeGRAndBGR
    {
        public void Start()
        {
            Thread clock = new Thread(WriteClockTime);
            clock.IsBackground = true;
            clock.Start();
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
