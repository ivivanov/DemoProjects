using Pusher;
using Pusher.Connections.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PusherPlayground
{
    class Program
    {
        private CancellationToken _cancellationToken;
        private Thread _receiveThread;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly EventWaitHandle _waitHandle;
        private Pusher.Pusher _pusher;
        private Channel _channel;

        public Program()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            _waitHandle = new AutoResetEvent(false);
            _pusher = new Pusher.Pusher(new WebSocketConnectionFactory(), "de504dc5763aeef9ff52");
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.Start();
        }

        public void Start()
        {
            lock (_cancellationTokenSource)
            {
                if (_receiveThread == null)
                {
                    _receiveThread = new Thread(() =>
                    {
                        while (!_cancellationToken.IsCancellationRequested)
                        {
                            _waitHandle.Reset();
                            try
                            {
                                ReceiveLoop().Wait(_cancellationToken);
                            }
                            catch (OperationCanceledException)
                            {
                                // User requested a stop. Do nothing.
                                break;
                            }
                            catch
                            {
                                // Keep spinning                                                            
                            }
                        }
                    });
                }
                _receiveThread.Start();
            }

            _waitHandle.WaitOne();
        }

        private async Task ReceiveLoop()
        {
            await EnsureConnection();
            await EnsureSubscription();
            _waitHandle.Set();


            //while (_channel.Established)
            //{

            //    OnNewMessage(jsonMsg);
            //}
        }


        private async Task EnsureConnection()
        {
            await _pusher.ConnectAsync();
        }

        private async Task EnsureSubscription()
        {
            _channel = await _pusher.SubscribeToChannelAsync("live_trades");
            _channel.EventEmitted += _channel_EventEmitted;
        }

        private void _channel_EventEmitted(object sender, IIncomingEvent e)
        {
            Console.WriteLine("stuff");
        }
    }
}
