using MemBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MembusWithRX
{
    public class Clock
    {
        public const string Title = "I am Clock";

        private DateTime CurrentTime { get; set; }

        private IBus bus;

        public Clock()
        {

        }

        public Clock(IBus bus)
        {
            this.bus = bus;
        }

        public void Start()
        {
             while (true)
            {
                if (DateTime.Now.Second != CurrentTime.Second)
                {
                    CurrentTime = DateTime.Now;
                    bus.Publish(CurrentTime);
                }
            }
        }

        public void BlockThread(int sec = 3)
        {
            Thread.Sleep(sec * 1000);
        }

        public void Print()
        {
            Console.WriteLine(this.CurrentTime.ToString());
        }

        #region Classic Events

        // A delegate type for hooking up change notifications.
        public delegate void ChangedEventHandler(Clock sender, EventArgs e);
        public event ChangedEventHandler Changed;

        public void StartWithEvents()
        {

            while (true)
            {
                if (DateTime.Now.Second != CurrentTime.Second)
                {
                    CurrentTime = DateTime.Now;

                    Changed(this, EventArgs.Empty);
                }
            }
        }

        public async Task StartWithEventsAsync()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    if (DateTime.Now.Second != CurrentTime.Second)
                    {
                        CurrentTime = DateTime.Now;

                        Changed(this, EventArgs.Empty);
                    }
                }
            });
        }

        #endregion
    }
}
