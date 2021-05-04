using System;
using System.Threading;

namespace ProducerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            CommonData d = new CommonData();
            Consumer c = new Consumer(d);
            c.Start();
            for (int i = 0; i<d.ValuesCount; i++)
            {
                new Producer(d, i).Start();
            }
        }
    }
}
