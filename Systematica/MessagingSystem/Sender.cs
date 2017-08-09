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
    public class Sender : IDisposable
    {
        private int _msgCount;
        private readonly object _locker = new object();
        private readonly Timer _timer;
        private const int LIMIT = 500;
        private bool _stop;

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
                Console.WriteLine("Data received at {0}/s", _msgCount);
                _msgCount = 0;
            }
        }

        public static void OnAcknowledge(bool isReceived)
        {
            Acknowledge?.Invoke(isReceived);
        }

        public bool canTransmit()
        {
            lock (_locker)
            {
                return _msgCount < LIMIT;
            }
           
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
            _stop = false;
            while (!_stop)
            {
                while (!canTransmit())
                {
                    Thread.Sleep(1);
                }
                Message msg = generateMessage();
                sendMessage(msg);
                Receiver.OnReceived(msg);
            }
        }

        public void Stop()
        {
            _stop = true;
            _timer.Stop();
            lock (_locker)
            {
                _msgCount = 0;
            }
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
