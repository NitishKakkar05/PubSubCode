using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PubSubLib
{
    public class PubSubService
    {
        readonly Dictionary<Message, HashSet<ISubscriber>> subscribersToMessage = new Dictionary<Message, HashSet<ISubscriber>>();

        Queue<Message> messageQueue = new Queue<Message>();

        public void AddMessage(Message message)
        {
            messageQueue.Enqueue(message);
        }

        public void AddSubscriber(Message message, ISubscriber subscriber)
        {
            if (subscribersToMessage.ContainsKey(message))
            {
                subscribersToMessage[message].Add(subscriber);
            }
            else
            {
                subscribersToMessage.Add(message, new HashSet<ISubscriber>() { subscriber });
            }
        }

        public void RemoveSubscriber(Message message, ISubscriber subscriber)
        {
            if (subscribersToMessage.ContainsKey(message))
            {
                subscribersToMessage[message].Remove(subscriber);
            }
        }

        public void BroadCast()
        {
            while (messageQueue.Any())
            {
                var message = messageQueue.Dequeue();
                if (subscribersToMessage.ContainsKey(message))
                {
                    var subscriberSet = subscribersToMessage[message];

                    foreach (var subscriber in subscriberSet)
                    {
                        subscriber.Display(message);
                    }
                }
            }
        }


    }
}
