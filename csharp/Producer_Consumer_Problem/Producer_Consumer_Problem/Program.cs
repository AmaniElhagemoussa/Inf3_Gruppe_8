using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Producer_Consumer_Problem
{
    class Program
    {
    

        static void Main(string[] args)
        {
            ProducerConsumer(3, 5, 5);
       


            
        }

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
