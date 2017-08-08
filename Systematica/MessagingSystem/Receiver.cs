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

        private readonly object _locker = new object();
        private readonly Timer _timer;
        private int _msgCount;

        public static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            Received += receiver.SaveMsg;
            
            Sender sender = new Sender();
            new Thread(sender.Run).Start();
        }

        public Receiver()
        {
            _msgCount = 0;
            _timer = new Timer() {Enabled = true, Interval = 1000};
            _timer.Elapsed += OnElapsed;
            _timer.Start();
        }

        private void OnElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (_locker)
            {
                Console.WriteLine("Data received at {0}/s", _msgCount);
                _msgCount = 0;
            }
        }

        public static void OnReceived(Message msg)
        {
            Received?.Invoke(msg);
        }

        private void SaveMsg(Message msg)
        {
            msg.ReceivedTimeStamp = DateTime.Now;
            Interlocked.Increment(ref _msgCount);

        }

        

    }
}
