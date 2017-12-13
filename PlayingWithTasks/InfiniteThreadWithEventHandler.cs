using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithTasks
{
    public class InfiniteThreadWithEventHandler
    {
        public delegate void NewNumberHandler(int num);
        public event NewNumberHandler NewNumber;

        private Thread _receiveThread;
        private readonly EventWaitHandle _resetEvent;
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;

        public InfiniteThreadWithEventHandler()
        {
            _resetEvent = new AutoResetEvent(false);
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
        }

        public void Start()
        {
            //Thread.CurrentThread.Name = "main";
            lock (_cancellationTokenSource)
            {
                if (_receiveThread == null)
                {
                    _receiveThread = new Thread(() =>
                    {

                        Console.WriteLine("Enter receiveThread");
                        while (!_cancellationToken.IsCancellationRequested)
                        {
                            Console.WriteLine("looping in receiveThread");

                            //_resetEvent.Reset();
                            try
                            {
                                ReceiveLoop().Wait(_cancellationToken);
                            }
                            catch (OperationCanceledException)
                            {
                                break;
                            }
                        }
                    });
                }
                _receiveThread.Name = nameof(_receiveThread);
                _receiveThread.Start();
            }

            //_resetEvent.WaitOne();
        }

        private async Task ReceiveLoop()
        {
            //If there is some work in order to initialize or connect to NewNumberProvider we can use reset event to make sure everything is rdy
            //_resetEvent.Set();
            Console.WriteLine("Enter ReceiveLoop");
            while (true)
            {
                Console.WriteLine("looping in ReceiveLoop");

                Random rnd = new Random();
                int number = rnd.Next(0, 20);
                //Console.WriteLine(number);
                OnNewNumber(number);
                if (number == 0)
                {
                    Console.WriteLine("Cancellation token sent");

                    _cancellationTokenSource.Cancel();
                }
                await Task.Delay(100);
            }
        }

        private void OnNewNumber(int num)
        {
            if (NewNumber != null)
            {
                NewNumber(num);
            }
        }
    }

    public class NumbersProcessor
    {
        public NumbersProcessor(InfiniteThreadWithEventHandler numsReceiver)
        {
            numsReceiver.NewNumber += NumsReceiver_NewNumber;
        }

        private void NumsReceiver_NewNumber(int num)
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            Console.WriteLine(num);
        }
    }
}
