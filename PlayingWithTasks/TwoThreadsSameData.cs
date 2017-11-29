using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithTasks
{

    public class TwoThreadsSameData
    {
        private ConcurrentQueue<string> msgQueue;

        public TwoThreadsSameData()
        {
            this.msgQueue = new ConcurrentQueue<string>();
        }

        public void Start()
        {
            Thread.CurrentThread.Name = "main";

            Thread handleDataWorker = new Thread(DataConsumer);
            handleDataWorker.Name = nameof(handleDataWorker);
            handleDataWorker.Start();

            Thread pullDataWorker = new Thread(PullData);
            pullDataWorker.Name = nameof(pullDataWorker);
            pullDataWorker.Start();

        }

        private void BurstDataConsumer()
        {
            Console.WriteLine(nameof(BurstDataConsumer));

            while (msgQueue.Count > 3)
            {
                if (msgQueue.TryDequeue(out string msg))
                {
                    Console.WriteLine($"{msg}. Messages in the queue: {msgQueue.Count}");
                }
                Thread.Sleep(300);
            }
        }

        private void DataConsumer()
        {
            while (true)
            {
                Console.WriteLine("Current thread count: " + Process.GetCurrentProcess().Threads.Count);
                if (msgQueue.Count > 0)
                {
                    if (msgQueue.TryDequeue(out string msg))
                    {
                        Thread.Sleep(2000);
                        Console.WriteLine($"{Thread.CurrentThread.Name} : {msg}. Messages in the queue: {msgQueue.Count}");
                    }

                    if (msgQueue.Count > 10)
                    {
                        new Thread(BurstDataConsumer).Start();
                    }
                }
            }
        }

        private void PullData()
        {
            Random rnd = new Random();
            while (true)
            {
                this.msgQueue.Enqueue($"{DateTime.Now.TimeOfDay} : {rnd.Next(100)}");
                Thread.Sleep(rnd.Next(0, 1000));
            }
        }
    }
}
