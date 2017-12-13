using System;
using System.Threading;
using System.Threading.Tasks;
using WampSharp.V2;
using WampSharp.V2.Client;
using WampSharp.V2.Realm;

namespace WebsocketsPlayground
{
    class Program
    {

        static void Main(string[] args)
        {
            EventWaitHandle resetEvent = new EventWaitHandle(false, EventResetMode.AutoReset);
            var socketConnection = new TestWampSharp();

            socketConnection.StartClient();
            new Thread((x) =>
            {
                while (true)
                {
                    resetEvent.WaitOne();
                    Console.WriteLine("loop");
                }
            }).Start(socketConnection);

            while (true)
            {
                Thread.Sleep(300);
                resetEvent.Set();
            }
        }
    }

    public class TestWampSharp : IDisposable
    {
        private string location = "wss://api.poloniex.com";
        IWampChannel channel;
        IDisposable subscription;

        public void Dispose()
        {
            channel.Close();
            subscription.Dispose();
        }

        public void StartClient()
        {
            DefaultWampChannelFactory factory = new DefaultWampChannelFactory();
            channel = factory.CreateJsonChannel(location, "realm1");
            channel.Open();
            IWampRealmProxy realmProxy = channel.RealmProxy;

            subscription =
                realmProxy.Services
                .GetSubject("ticker")
                .Subscribe(x =>
                {
                    Console.WriteLine("Got Event: " + x);
                });

        }
    }
}
