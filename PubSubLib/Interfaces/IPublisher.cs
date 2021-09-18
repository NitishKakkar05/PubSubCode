using System;
using System.Collections.Generic;
using System.Text;

namespace PubSubLib
{
    public interface IPublisher
    {
        Message ProcessMessage(Message message);
        void Publish(Message message, PubSubService pubSubService);
    }
}
