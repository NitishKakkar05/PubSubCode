using System;
using System.Collections.Generic;
using System.Text;

namespace PubSubLib
{
    /// <summary>
    /// Interface for publisher
    /// </summary>
    public interface IPublisher
    {
        /// <summary>
        /// Process message before publishing
        /// </summary>
        /// <param name="message">Message to be processed</param>
        /// <returns>Message after processing.</returns>
        Message ProcessMessage(Message message);

        /// <summary>
        /// Publish the message to service.
        /// </summary>
        /// <param name="message">Message to be published.</param>
        /// <param name="pubSubService">Service to broadcast message.</param>
        void Publish(Message message, PubSubService pubSubService);
    }
}
