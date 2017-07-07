using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    public class ProducerConsumer
    {
        private readonly object _locker;
        private Queue<Action> _queue;
        private Thread[] _workers;
        private int _queueLimit;

        public ProducerConsumer(int workCount, int queueLimit)
        {
            _locker = new object();
            _queue = new Queue<Action>();
            _workers = new Thread[workCount];
            _queueLimit = queueLimit;

            for (int i = 0; i < workCount; i++)
            {
                (_workers[i] = new Thread(Consume)).Start();
            }
        }

        public void ShutDown(bool waitForWorker)
        {
            foreach (var w in _workers)
            {
                Produce(null);
            }
            if (waitForWorker)
            {
                foreach (var w in _workers)
                {
                    w.Join();
                }
            }
        }

        public void Produce(Action task)
        {
            lock (_locker)
            {

                while (_queue.Count >= _queueLimit)
                {
                    Console.WriteLine("Waiting on queue...");
                    Monitor.Wait(_locker);
                }
                _queue.Enqueue(task);
                Monitor.PulseAll(_locker);
            }
        }

        private void Consume()
        {
            while (true)
            {
                Action task;
                lock (_locker)
                {
                    while (_queue.Count == 0) // use while loop to make sure the queue is
                        //not empty after notification received to regain the lock
                    {
                        Monitor.Wait(_locker);
                    }
                        
                    task = _queue.Dequeue();
                    Monitor.PulseAll(_locker);
                }
                if(task == null)
                    return;
                task.Invoke();
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            }
                            
        }
    }
}
