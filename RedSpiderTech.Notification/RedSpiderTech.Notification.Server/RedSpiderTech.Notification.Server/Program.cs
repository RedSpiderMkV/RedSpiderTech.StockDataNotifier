using System;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;

namespace RedSpiderTech.Notification.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(Subscribe);
            thread.Start();

            Thread thread2 = new Thread(Publish);
            thread2.Start();
        }

        private static void Subscribe()
        {
            using (var subscriber = new SubscriberSocket())
            {
                subscriber.Connect("tcp://127.0.0.1:5556");
                subscriber.Subscribe("B");

                while (true)
                {
                    var topic = subscriber.ReceiveFrameString();
                    var msg = subscriber.ReceiveFrameString();
                    Console.WriteLine("From Publisher: {0} {1}", topic, msg);
                }
            }
        }

        private static void Publish()
        {
            using (var publisher = new PublisherSocket())
            {
                publisher.Bind("tcp://*:5556");

                int i = 0;

                while (true)
                {
                    publisher
                        .SendMoreFrame("B") // Topic
                        .SendFrame(i.ToString()); // Message

                    i++;
                    Thread.Sleep(1000);
                }
            }
        }

        private static void StartClient()
        {
            using (var client = new RequestSocket())
            {
                client.Connect("tcp://localhost:5555");
                for (int i = 0; i < 10; i++)
                {
                    client.SendFrame("Hello");
                    var message = client.ReceiveFrameString();
                    Console.WriteLine("CLIENT: Received {0}", message);
                }
            }
        }

        private static void StartServer()
        {
            using (var server = new ResponseSocket())
            {
                server.Bind("tcp://localhost:5555");
                while (true)
                {
                    var message = server.ReceiveFrameString();
                    Console.WriteLine("SERVER: Received {0}", message);
                    // processing the request
                    Thread.Sleep(100);
                    server.SendFrame("World");
                }
            }
        }
    }
}
