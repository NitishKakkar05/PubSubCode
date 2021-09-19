using PubSubLib;
using System;
using System.IO;
using Xunit;

namespace PubSubLibTest
{
    public class PubSubTest
    {
        PubSubService service;
        Message message;
        Publisher publisher;
        Subscriber subscriber;
        StringWriter output;
        const string subscriberId = "sub01";
        public PubSubTest()
        {
            output = new StringWriter();
            Console.SetOut(output);
            service = new PubSubService();
            message = new Message { Content = "Test Message" };
            publisher = new Publisher();
            subscriber = new Subscriber(subscriberId);
        }

        [Fact]
        public void PublishMessage_Subscriber_ReceiveMessage()
        {
            // Arrange 
            subscriber.Subscribe(message, service);

            // Act
            publisher.Publish(message, service);
            service.BroadCast();

            // Assert
            Assert.Equal(subscriberId + " " + message.Content + Environment.NewLine, output.ToString());
        }

        [Fact]
        public void PublishMessage_NoSubscriber_NoReceiveMessage()
        {
            // Act
            publisher.Publish(message, service);
            service.BroadCast();

            // Assert
            Assert.Equal(string.Empty, output.ToString());
        }

        [Fact]
        public void PublisMessage_DifferentSubscriber_NoReceiveMessage()
        {
            // Arrange
            subscriber.Subscribe(new Message { Content = "DifferentMessage" }, service);

            // Act
            publisher.Publish(message, service);
            service.BroadCast();

            // Assert
            Assert.Equal(string.Empty, output.ToString());
        }

        [Fact]
        public void PublishMessage_ManySubscriber_AllReceiveMessage()
        {

            // Arrange
            string subscriberId02 = "sub02";
            Subscriber subscriber02 = new Subscriber(subscriberId02);

            subscriber.Subscribe(message, service);
            subscriber02.Subscribe(message,service);

            // Act
            publisher.Publish(message, service);
            service.BroadCast();

            // Assert
            Assert.Equal(subscriberId + " "  + message.Content + Environment.NewLine +
                subscriberId02 + " " + message.Content + Environment.NewLine, output.ToString());
        }

        [Fact]
        public void PublishProcessMessage_Subscriber_ReceiveProcessedMessage()
        {
            // Arrange 
            subscriber.Subscribe(message, service);

            // Act
            publisher.ProcessMessage(message);
            publisher.Publish(message, service);

            service.BroadCast();

            // Assert
            Assert.Equal(subscriberId + " " + message.Content + Environment.NewLine, output.ToString());
        }

        [Fact]
        public void PublishMessage_UnSubscriber_NotReceiveMessage()
        {
            // Arrange 
            subscriber.UnSubscribe(message, service);

            publisher.Publish(message, service);
            service.BroadCast();

            // Assert
            Assert.Equal(string.Empty, output.ToString());
        }

    }
}
