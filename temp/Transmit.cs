using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MessagingSystem
{
    public class Sender : ISender
    {
        private Message[] _buffer; // cyclic buffer
        private int _head; // head of the cyclic buffer pointing to the earliest sent message in the last 500
        private int _tail; // tail of the cyclic buffer where new message is to be pushed in
        private readonly int _limit = 500; // size of the buffer

        private int _msgCount;
        private readonly object _locker = new object();
        private readonly Timer _timer;

        public Sender()
        {
            _buffer = new Message[_limit];
            _head = 0;
            _tail = 0;

            _msgCount = 0;
            _timer = new Timer() { Enabled = true, Interval = 1000 };
            _timer.Elapsed += ResetMsgCount;
            _timer.Start();
        }

        private void ResetMsgCount(object sender, ElapsedEventArgs e)
        {
            lock (_locker)
            {
                _msgCount = 0;
            }
        }

        public bool canTransmit()
        {
            if (_buffer.Any(m => m == null))
                return true;
            return _buffer[_head].TimeStamp_Sent + TimeSpan.FromMilliseconds(1000) < DateTime.Now;
        }

        public Message generateMessage()
        {
            throw new NotImplementedException();
        }

        public void sendMessage(Message msg)
        {
            throw new NotImplementedException();
        }
    }
}
