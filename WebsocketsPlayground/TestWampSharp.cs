using System;
using WampSharp.V2;
using WampSharp.V2.Client;

namespace WebsocketsPlayground
{
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
