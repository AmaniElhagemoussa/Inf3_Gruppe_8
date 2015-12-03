using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Producer_Consumer_Problem
{
    class Consumer
    {
        private Buffer <int> _buff;
        public Consumer(Buffer <int> b)
        {
            _buff = b;
           
            
        }

        public void consume()
        {
            Monitor.Enter(this);

            try
            {
            while (true)
            {
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
