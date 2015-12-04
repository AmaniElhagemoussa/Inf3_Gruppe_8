// compile with: /doc:ProducerConsumerProblem.xml
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Producer_Consumer_Problem
{
    /// <summary>
    /// class Producer 
    /// <remarks>author: Group 8 - Sarah, Kathi, Amani;</remarks>
    /// history: 03.12.15
    /// </summary>
    class Producer
    {
        private Buffer <int> _buff;
        private Random _rand;

        /// <summary>
        /// constructor with buffer as input parameter
        /// </summary>
        /// <param name="b"></param>
        public Producer(Buffer<int> b)
        {
            _buff = b;
            _rand = new Random();
   
        }

        /// <summary>
        /// method produce
        /// <para>produces a random number and adds it to the buffer</para>
        /// </summary>
        public void produce()
        {
            ///acquire monitor lock for the passed object
            ///If another thread has executed an Enter on the object but has not yet executed the corresponding Exit
            ///the current thread will block until the other thread releases the object
            Monitor.Enter(this);

            try
            {
            while (true)
            {
               ///calls add method in buffer class
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
