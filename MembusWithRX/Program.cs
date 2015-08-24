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
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MembusWithRX
{
    class Program
    {
        public class IvanSubject : ISubject<int, int>
        {

            public void OnCompleted()
            {
                throw new NotImplementedException();
            }

            public void OnError(Exception error)
            {
                throw new NotImplementedException();
            }

            public void OnNext(int value)
            {
                throw new NotImplementedException();
            }

            public IDisposable Subscribe(IObserver<int> observer)
            {
                throw new NotImplementedException();
            }
        }
        //Takes an IObservable<string> as its parameter. 
        //Subject<string> implements this interface.
        public static void WriteSequenceToConsole(IObservable<int> sequence)
        {
            //The next two lines are equivalent.
            //sequence.Subscribe(value=>Console.WriteLine(value));
            sequence.Subscribe(Console.WriteLine);
        }
         
        static void Main(string[] args)
        {
            var subject = new IvanSubject();
            //WriteSequenceToConsole(subject);
            subject.OnNext(1);
            subject.OnNext(2);
            subject.OnNext(3);
            Console.ReadKey();

            //InitRunClock();
            //IBus bus = 
            //    BusSetup.StartWith<Fast>()
            //    .Apply<FlexibleSubscribeAdapter>(cfg => cfg.ByInterface(typeof(IObservable<>))) 
            //    .Construct();
            //Clock clock = new Clock(bus);
            //bus.Subscribe<DateTime>(SomeFunction);
            ////bus.Observe<Clock>();
            //clock.Start();
            //bus.Dispose();
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
