// compile with: /doc:ProducerConsumerProblem.xml
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Producer_Consumer_Problem
{
    /// <summary>
    /// class Consumer 
    /// <remarks>author: Group 8 - Sarah, Kathi, Amani;</remarks>
    /// history: 03.12.15
    /// </summary>
    class Consumer
    {
        private Buffer <int> _buff;

        /// <summary>
        /// construcor Consumer with buffer as input parameter
        /// </summary>
        /// <param name="b"></param>
        public Consumer(Buffer <int> b)
        {
            _buff = b;
           
            
        }

        public void consume()
        {
            ///acquire monitor lock for the passed object
            ///If another thread has executed an Enter on the object but has not yet executed the corresponding Exit
            ///the current thread will block until the other thread releases the object
            Monitor.Enter(this);

            try
            {
            while (true)
            {

                ///calls method getNextElement in buffer class
                _buff.getNextElement();

            }

            }
            finally
            {
                Monitor.Exit(this);
            }

               
    
               
        
        }


    }
}
