using MemBus;
using MemBus.Configurators;
using MemBus.Setup;
using MemBus.Subscribing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MembusWithRX
{
    class Program
    {

        static void Main(string[] args)
        {
            //InitRunClock();
            IBus bus = 
                BusSetup.StartWith<Fast>()
                .Apply<FlexibleSubscribeAdapter>(cfg => cfg.ByInterface(typeof(IObservable<>))) 
                .Construct();
            Clock clock = new Clock(bus);
            bus.Subscribe<DateTime>(SomeFunction);
            //bus.Observe<Clock>();
            clock.Start();
            bus.Dispose();
        }

        public static void SomeFunction(DateTime value)
        {
            Console.WriteLine(value.ToString());
        }

        public static void InitRunClock()
        {
            Clock clock = new Clock();
            clock.Changed += new Clock.ChangedEventHandler(ChangedClock);
            Task res = clock.StartWithEventsAsync();
            //clock.StartWithEvents();
            clock.BlockThread();

            Thread.Sleep(100000);

        }

        private static void ChangedClock(object sender, EventArgs e)
        {
            (sender as Clock).Print();
        }
    }
}
