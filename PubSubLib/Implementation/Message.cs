using System;
using System.Collections.Generic;
using System.Text;

namespace PubSubLib
{
    public class Message
    {
        public DateTime CreatedTime { get; }
        public string Content { get; set; }

        public Message()
        {
            CreatedTime = DateTime.Now;
        }
        public void ShowMessage()
        {
            Console.WriteLine(Content);
        }
    }
}
