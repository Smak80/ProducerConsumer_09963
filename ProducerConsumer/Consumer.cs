using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Consumer
    {
        CommonData Data { get; set; }
        public Consumer(CommonData data)
        {
            Data = data;
        }

        public void Start()
        {
            new Thread(run).Start();
        }

        private void run()
        {
            while (true)
            {
                var values = Data.Pop();
                var s = 0;
                foreach(var v in values)
                {
                    s += v;
                }
                Console.WriteLine("Consumed result: {0}", s);
            }
        }
    }
}
