using PubSubLib;
using System;

namespace PubSubConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PubSubService service = new PubSubService();

            Message fashionMessage = new Message
            {
                Content = "Fashion Message"
            };

            Message newsMessage = new Message
            {
                Content = "Breaking News!!"
            };

            Message movieMessage = new Message
            {
                Content = "Movie Released"
            };

            Publisher pub = new Publisher();


            Subscriber sub01 = new Subscriber();
            Subscriber sub02 = new Subscriber();
            Subscriber sub03 = new Subscriber();

            sub01.Subscribe(fashionMessage, service);

            sub02.Subscribe(fashionMessage, service);
            sub02.Subscribe(newsMessage, service);

            sub03.Subscribe(fashionMessage, service);
            sub03.Subscribe(newsMessage, service);
            sub03.Subscribe(movieMessage, service);


            pub.ProcessMessage(fashionMessage);
            pub.Publish(fashionMessage, service);

            service.BroadCast();

            Console.Read();
        }
    }
}
