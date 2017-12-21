using System;
using System.Threading.Tasks;
using WebSocketSharp;

namespace WebsocketsPlayground
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var ws = new WebSocket("wss://api.bitfinex.com/ws/2"))
            {
                ws.OnMessage += (sender, e) =>
                    Console.WriteLine(e.Data);

                ws.Connect();
                ws.Send("{'event':'subscribe','channel':'ticker','symbol':'BTCUSD'}");
                Task.Delay(1000).Wait();
                Console.ReadKey(true);
            }
        }
    }
}
