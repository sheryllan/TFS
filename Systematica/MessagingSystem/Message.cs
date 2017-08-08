using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingSystem
{
    public class Message
    {
        public string Data { get; set; }
        public DateTime SentTimeStamp { get; set; }
        public DateTime ReceivedTimeStamp { get; set; }
    }
}
