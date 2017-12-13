using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithTasks
{
    public class InfiniteThreadWithEventHandler
    {
        private delegate void NewMessageEvent();
        private event NewMessageEvent OnNewMessageEvent;
        private ConcurrentQueue<string> concurrentQueue;

        public InfiniteThreadWithEventHandler()
        {
            concurrentQueue = new ConcurrentQueue<string>();
        }

        public void Start()
        {

            Thread.CurrentThread.Name = "main";

            //subscribe first!
            Thread queueProccessor = new Thread(() =>
            {
                OnNewMessageEvent += OnNewMessageEventHandler;
            });
            queueProccessor.Name = nameof(queueProccessor);
            queueProccessor.Start();

            // rise events
            Thread queueFiller = new Thread(() =>
            {
                Random random = new Random();
                while (true)
                {
                    string newMsg = $"{random.Next(1000)} new int produced!";
                    concurrentQueue.Enqueue(newMsg);
                    OnNewMessageEvent();
                    Thread.Sleep(400);
                }
            });
            queueFiller.Name = nameof(queueFiller);
            queueFiller.Start();

        }

        private void OnNewMessageEventHandler()
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            if (concurrentQueue.TryDequeue(out string msg))
            {
                Console.WriteLine(msg);
            }
        }
    }

    public class MyConcurentQueue<T> : ConcurrentQueue<T>
    {
        public delegate int QueueNeedsProccessing();
        public event QueueNeedsProccessing OnQueueNeedsProccessing;


    }
}
