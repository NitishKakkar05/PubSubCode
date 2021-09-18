using System;
using System.Collections.Generic;
using System.Text;

namespace PubSubLib
{
    public class Publisher : IPublisher
    {
        public Message ProcessMessage(Message message)
        {
            var msg = message as Message;
            msg.Content = "Hello " + msg.Content;
            return msg;
        }

        public void Publish(Message message, PubSubService pubSubService)
        {
            pubSubService.AddMessage(message);
        }
    }
}
