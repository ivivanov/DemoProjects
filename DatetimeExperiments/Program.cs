using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatetimeExperiments
{
    class Program
    {
        public static readonly DateTime epocTime = new DateTime(1970, 1, 1);

        static void Main(string[] args)
        {
            var time1 = DateTime.Now;
            var time2 = time1.AddSeconds(1);
            var ts1 = ConvertToTimestamp(time1);
            var ts2 = ConvertToTimestamp(time2);
            Console.WriteLine(ts2 - ts1);

            Console.WriteLine($"time2> time1 = {time2 > time1}");

            TimeSpan a = DateTime.Now.TimeOfDay;
            TimeSpan b = DateTime.Now.TimeOfDay;
            Console.WriteLine(b-a);
        }

        public static long ConvertToTimestamp(DateTime time)
        {
            DateTime dt = time.ToUniversalTime();
            Int32 unixTimeStamp = (Int32)(dt.Subtract(epocTime)).TotalSeconds;
            return unixTimeStamp;
        }
    }
}
