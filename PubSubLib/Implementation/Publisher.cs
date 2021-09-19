using System;
using System.Collections.Generic;
using System.Text;

namespace PubSubLib
{
    public class Publisher : IPublisher
    {
        public Message ProcessMessage(Message message)
        {
            message.Content = "Hello " + message.Content;
            return message;
        }

        public void Publish(Message message, PubSubService pubSubService)
        {
            pubSubService.AddMessage(message);
        }
    }
}
