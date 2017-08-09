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

        public static event Action<bool> Acknowledge;

        public Sender()
        {
            _timer = new Timer() {Enabled = true, Interval = 1000};
            _timer.Elapsed += ResetMsgCount;
            Acknowledge += UpdateMsgCount;
        }

        private void UpdateMsgCount(bool isReceived)
        {
            if (isReceived)
                Interlocked.Increment(ref _msgCount);
        }

        private void ResetMsgCount(object sender, ElapsedEventArgs e)
        {
            lock (_locker)
            {
                _msgCount = 0;
            }
        }

        public static void RaiseAcknowlege(bool isReceived)
        {
            Acknowledge?.Invoke(isReceived);
        }

        public bool canTransmit()
        {
            int count;
            lock (_locker)
            {
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
            _msgCount = 0;
            _timer.Start();
            while (true)
            {
                while (!canTransmit())
                {
                    Thread.Sleep(1);
                }
                Message msg = generateMessage();
                sendMessage(msg);
                Receiver.RaiseReceived(msg);
            }
        }
    }
}
