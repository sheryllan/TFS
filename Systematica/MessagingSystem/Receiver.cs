using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MessagingSystem
{
    public class Receiver
    {
        public static event Action<Message> Received;

        private const int LIMIT = 500;
        private const int BUFSIZE = LIMIT + 1;
        private Message[] _messages; 
        private int _head;
        private readonly object _locker = new object();

        public static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            
            Sender sender = new Sender();
            new Thread(sender.Run).Start();
            while (true)
            {
                Thread.Sleep(1000); // important!!longer enough period to have gathered timestamps of the last second
                Console.WriteLine("Data received at {0}/s", receiver.GetReceiveRate());
            }
            
        }

        public Receiver()
        {
            _head = 0;
            _messages = new Message[BUFSIZE];
            Received += SaveMsg;
        }

        public static void RaiseReceived(Message msg)
        {
            Received?.Invoke(msg);
        }

        private void SaveMsg(Message msg)
        {
            msg.ReceivedTimeStamp = DateTime.Now;
            lock (_locker)
            {
                // messages are saved cyclically with a buffer size of 500
                _messages[_head] = msg;
                _head = (_head + 1) % BUFSIZE;
                //Console.WriteLine("head: {0}, time: {1}", (_head + LIMIT) % BUFSIZE, msg.ReceivedTimeStamp.TimeOfDay);
            }
            Sender.RaiseAcknowlege(true);
            
        }

        public int GetReceiveRate()
        {
            DateTime currTime;
            Message olderMsg, currMsg;
            int old_i, curr_i;
            lock (_locker)
            {
                curr_i = (_head + LIMIT) % BUFSIZE;
                old_i = _messages[_head] == null ? 0 : _head; 
                currMsg = _messages[curr_i];
                olderMsg = _messages[old_i];
                currTime = DateTime.Now;

            }

            int count = curr_i > old_i ? curr_i - old_i + 1 : curr_i - old_i + BUFSIZE;
            DateTime oldTime = olderMsg.ReceivedTimeStamp;
            //DateTime currTime = currMsg.ReceivedTimeStamp - oldTime < TimeSpan.FromMilliseconds(500) 
            //    ? now : currMsg.ReceivedTimeStamp;
            
            double interval = (currTime - oldTime).TotalSeconds;

            Console.WriteLine("curr_i: {0}, old_i: {1}", curr_i, old_i);
            Console.WriteLine("curr_time: {0}", currTime.TimeOfDay);
            Console.WriteLine("old_time: {0}", oldTime.TimeOfDay);
            Console.WriteLine("interval: {0}, count: {1}", interval, count);
            Console.WriteLine("-----------------------------------------------------");

            return (int)(interval == 0.0 ? 0 : count / interval);

        }

        

    }
}
