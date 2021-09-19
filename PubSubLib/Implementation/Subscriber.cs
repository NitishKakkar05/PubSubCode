using System;
using System.Collections.Generic;
using System.Text;

namespace PubSubLib
{
    public class Subscriber : ISubscriber
    {
        public string SubscriberId { get; }
        public Subscriber(string subscriberId)
        {
            SubscriberId = subscriberId;
        }
        public void Display(Message message)
        {
            message.ShowMessage(SubscriberId);
        }

        public void Subscribe(Message message, PubSubService pubSubService)
        {
            pubSubService.AddSubscriber(message, this);
        }

        public void UnSubscribe(Message message, PubSubService pubSubService)
        {
            pubSubService.RemoveSubscriber(message, this);
        }
    }
}
