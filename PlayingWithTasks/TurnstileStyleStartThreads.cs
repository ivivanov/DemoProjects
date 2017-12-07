using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithTasks
{
    public class TurnstileStyleStartThreads
    {
        public void Start()
        {
            AutoResetEvent resetEvent = new AutoResetEvent(false);
            //EventWaitHandle resetEventTwo = new EventWaitHandle(false, EventResetMode.AutoReset); //same as above

            new Thread(DoJobOnSignal).Start(resetEvent);
            new Thread(OneMoreJobOnSignal).Start(resetEvent);

            Thread.Sleep(2000);

            resetEvent.Set();
            //resetEvent.Set();
        }

        private void DoJobOnSignal(object resetEvent)
        {
            Console.WriteLine("Wating for a signal to start doing some amazing stuff");
            (resetEvent as AutoResetEvent).WaitOne();
            Console.WriteLine("Doing awesome job started");
            Thread.Sleep(3000);
            (resetEvent as AutoResetEvent).Set();
        }

        private void OneMoreJobOnSignal(object resetEvent)
        {
            Console.WriteLine("Wating for a signal to start doing task 2");
            (resetEvent as AutoResetEvent).WaitOne();
            Console.WriteLine("Finish task 2");
            (resetEvent as AutoResetEvent).Close();
        }
    }
}
