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
    /// test class - starts the programm
    /// <remarks>author: Group 8 - Sarah, Kathi, Amani;</remarks>
    /// history: 03.12.15
    /// </summary>
    class Program
    {
    
        /// <summary>
        /// calls method ProducerConsumer
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ProducerConsumer(3, 5, 5);
        
        }

        /// <summary>
        /// method ProducerConsumer 
        /// <para>creates new Object of buffer with size of input parameter </para>
        /// <para>creates new Object/s of Producer and Consumer in a loop</para>
        /// <para>and starts a thread for each of the Producer/Consumer</para>
        /// </summary>
        /// <param name="bufferSize"></param>
        /// <param name="prodCount"></param>
        /// <param name="consCount"></param>
        static void ProducerConsumer(int bufferSize, int prodCount, int consCount)
        {
            Buffer <int> buff = new Buffer<int>(bufferSize);

            for (int i = 0; i < prodCount; i++)
            {
                Producer prod = new Producer(buff);
                Thread p = new Thread(new ThreadStart(prod.produce));
                p.Start();
            }
            for (int i = 0; i < consCount; i++)
            {
                Consumer cons = new Consumer(buff);
                Thread c = new Thread(new ThreadStart(cons.consume));
                c.Start();
            }
           
            Console.ReadKey();
        }
    }
}
