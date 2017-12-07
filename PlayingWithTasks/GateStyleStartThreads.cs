using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithTasks
{
    public class GateStyleStartThreads
    {
        private EventWaitHandle _manualEventHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
        //private ManualResetEvent test = new ManualResetEvent(false);

        public void Start()
        {
            Thread one = new Thread(DoWork);
            one.Name = "one";
            one.Start();

            Thread two = new Thread(DoWork);
            two.Name = "two";
            two.Start();

            Thread three = new Thread(DoWork);
            three.Name = "three";
            three.Start();

            Thread.Sleep(1000);
            _manualEventHandle.Set();
        }

        private void DoWork()
        {
            Console.WriteLine($"Wait the gate to open: {Thread.CurrentThread.Name}");
            _manualEventHandle.WaitOne();
            Console.WriteLine($"{DateTime.Now.TimeOfDay} DoWork: {Thread.CurrentThread.Name}");
        }
    }
}
