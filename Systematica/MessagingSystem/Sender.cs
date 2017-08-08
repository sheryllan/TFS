using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace MessagingSystem
{
    public class Sender
    {
        private int _msgCount;
        private readonly object _locker = new object();
        private readonly Timer _timer;
        private const int LIMIT = 500;

        public Sender()
        {
            _msgCount = 0;
            _timer = new Timer() {Enabled = true, Interval = 1000};
            _timer.Elapsed += ResetMsgCount;
            _timer.Start();
        }

        private void ResetMsgCount(object sender, ElapsedEventArgs e)
        {
            lock (_locker)
            {
                //Console.WriteLine("On reset: {0}", _msgCount);
                _msgCount = 0;
            }
        }

        public bool canTransmit()
        {
            int count;
            lock (_locker)
            {
                //Console.WriteLine("On check: {0}", _msgCount);
                count = _msgCount;
            }
            return count < LIMIT;
        }

        public Message generateMessage()
        {
            return new Message() {Data = "Hello World"};
        }

        public void sendMessage(Message msg)
        {
            msg.SentTimeStamp = DateTime.Now;

        }


        public void Run()
        {
            while (true)
            {
                while (!canTransmit())
                {
                    Thread.Sleep(1);
                }
                Message msg = generateMessage();
                sendMessage(msg);
                //Console.WriteLine("Message sent!!");
                Interlocked.Increment(ref _msgCount);
                Receiver.OnReceived(msg);
            }
        }
    }
}
