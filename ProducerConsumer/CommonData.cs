using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class CommonData
    {
        Queue<int>[] data = {
            new Queue<int>(),
            new Queue<int>(),
            new Queue<int>()
        };

        public int ValuesCount{
            get => data.Length;
        }
        public void Push(int index, int value)
        {
            Monitor.Enter(data);
            lock (data)
            {
                try
                {
                    data[index].Enqueue(value);
                    Monitor.PulseAll(data);
                }
                finally
                {
                    Monitor.Exit(data);
                }
            }
        }

        public int[] Pop()
        {
            Monitor.Enter(data);
            int[] res = new int[ValuesCount];
            try
            {
                for (int i = 0; i < ValuesCount; i++) {
                    while (data[i].Count() == 0)
                    {
                        Monitor.Wait(data);
                    }
                    res[i] = data[i].Dequeue();
                }
            }
            finally
            {
                Monitor.Exit(data);
            }
            return res;
        }
    }
}
