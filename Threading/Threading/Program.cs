using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            var pc = new ProducerConsumer(3,5);
            for (int i = 0; i < 10; i++)
            {
                var j = i;
                pc.Produce(() => { Console.Write("Performing task {0} by ", j); Thread.Sleep(1000); });
            }

            pc.ShutDown(true);
            Console.ReadKey();
        }
    }
}
