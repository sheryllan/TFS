using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace MessagingSystem
{
    public class Receiver
    {
        public static event Action<Message> Received;

        public static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            Sender sender = new Sender();

            new Thread(sender.Run).Start();
            Console.WriteLine("Press any KEY to shut down the messaging system.");
            Console.ReadKey();
            sender.Stop();
            sender.Dispose();
        }

        public Receiver()
        {
            Received += SaveMsg;
        }

        public static void OnReceived(Message msg)
        {
            Received?.Invoke(msg);
        }

        private void SaveMsg(Message msg)
        {
            msg.ReceivedTimeStamp = DateTime.Now;
            Sender.OnAcknowledge(true);
        }

    }
}
