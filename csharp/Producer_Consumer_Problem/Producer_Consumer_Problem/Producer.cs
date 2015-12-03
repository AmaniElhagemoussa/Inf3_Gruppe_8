using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Producer_Consumer_Problem
{
    class Producer
    {
        private Buffer <int> _buff;
        private Random _rand;

        public Producer(Buffer<int> b)
        {
            _buff = b;
            _rand = new Random();
   
        }
        public void produce()
        {

            try
            {
            while (true)
            {
               
                _buff.Add(_rand.Next(1, 9));
            }

            }
            finally
            {
                Monitor.Exit(this);
            }

         }
 


    }
}
