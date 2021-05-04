using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Producer
    {
        private CommonData Data { get; set; }
        private int index = -1;
        public int Index
        {
            get => index;
            private set
            {
                index = Math.Abs(value) % Data.ValuesCount;
            }
        }
        public Producer(CommonData d, int index)
        {
            Data = d;
            Index = index;
        }

        public void Start()
        {
            new Thread(run).Start();
        }

        private void run()
        {
            while (true)
            {
                Thread.Sleep(r.Next(500, 6000));
                int prodecedValue = r.Next(0, 100);
                Console.WriteLine("Produced value #{0} = {1}", Index, prodecedValue);
                Data.Push(Index, prodecedValue);
            }
        }

        static Random r = new Random((int)new DateTime().Ticks);
    }
}
