using System;
using System.Collections.Generic;
using System.Text;

namespace PubSubLib
{
    public interface ISubscriber
    {
        void Subscribe(Message message, PubSubService pubSubService);
        void UnSubscribe(Message message, PubSubService pubSubService);
        void Display(Message message);
    }
}
