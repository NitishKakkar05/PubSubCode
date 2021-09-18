using System;
using System.Collections.Generic;
using System.Text;

namespace PubSubLib
{
    public class Subscriber : ISubscriber
    {
        public void Display(Message message)
        {
            message.ShowMessage();
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
