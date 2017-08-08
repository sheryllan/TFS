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
        private Message[] _messages; 
        private int _head;
        private readonly object _locker = new object();

        public static void Main(string[] args)
        {
            Receiver receiver = new Receiver() {_head = 0, _messages = new Message[LIMIT]};
            Received += receiver.SaveMsg;
            Sender sender = new Sender();
            new Thread(sender.Run).Start();
            while (true)
            {
                Console.WriteLine("Data received at {0}/s", receiver.GetReceiveRate());
                //Thread.Sleep(1000);
            }
            
        }

        public static void OnReceived(Message msg)
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
                _head = (_head + 1) % LIMIT;
            }
            //if(GetReceiveRate() > 500)
            //    Console.WriteLine("<<< Warning: the receiver is accepting data at a rate over the limit! >>>");
        }

        public int GetReceiveRate()
        {
            Message olderMsg, currentMsg;
            int curr_i, old_i;
            lock (_locker)
            {
                curr_i = (_head - 1 + LIMIT) % LIMIT;
                old_i = _messages[_head] != null ? _head : 0;
                currentMsg = _messages[curr_i];
                olderMsg = _messages[old_i];
            }
            //if (olderMsg == null || currentMsg == null)
            if (olderMsg == null)
                    return 0;

            double interval = (DateTime.Now - olderMsg.ReceivedTimeStamp).TotalSeconds;
            int count = curr_i - old_i + 1;
            count = count > 0 ? count : count + LIMIT;

            return (int) (interval == 0.0 ? 0 : count / interval);

        }

        

    }
}
