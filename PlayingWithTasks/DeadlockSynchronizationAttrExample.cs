using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithTasks
{
    public class DeadlockDemoTwo
    {
        public void Start()
        {
            DeadlockSynchronizationAttrExample objOne = new DeadlockSynchronizationAttrExample();
            DeadlockSynchronizationAttrExample objTwo = new DeadlockSynchronizationAttrExample();
            objOne.Other = objTwo;
            objTwo.Other = objOne;

            Thread.CurrentThread.Name = "main";
            Thread otherThred = new Thread(objOne.DeadlockDemo);
            otherThred.Name = "Other thread";
            otherThred.Start();
            objTwo.DeadlockDemo();
        }
    }

    [Synchronization]
    public class DeadlockSynchronizationAttrExample : ContextBoundObject
    {
        public DeadlockSynchronizationAttrExample Other { get; set; }

        public void DeadlockDemo()
        {
            Thread.Sleep(1000);
            Console.WriteLine("a");
            Other.DoWork();
            Console.WriteLine("b");
        }

        private void DoWork()
        {
            Console.WriteLine($"I'm working: {Thread.CurrentThread.Name}");
        }
    }
}
