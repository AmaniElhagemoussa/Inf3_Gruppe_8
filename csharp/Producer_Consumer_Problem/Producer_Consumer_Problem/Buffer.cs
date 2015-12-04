// compile with: /doc:ProducerConsumerProblem.xml
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Producer_Consumer_Problem
{
 /// <summary>
 /// generic class buffer 
 /// <remarks>author: Group 8 - Sarah, Kathi, Amani;
 /// history: 03.12.15
 /// </remarks>
 /// </summary>
 /// <typeparam name="T"></typeparam>
    class Buffer<T>
    {
        private T[] _buffer;
        private int _count;
        private int _read;
        private int _write;
        private int _size;

        /// <summary>
        /// constructor
        /// define size of buffer
        /// </summary>
        /// <param name="size"></param>
        public Buffer(int size)
        {
            if (size <= 0)
                throw new ArgumentException("Must be greater than zero", "size");

            _size = size;

            _buffer = new T[_size];
        }

        /// <summary
        /// >Method add
        /// <para>adds an item to the buffer as long as it is not full</para>
        /// <para>only one thread can have access to this method</para>
        /// </summary>
        /// <param name="item"></param>
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Add(T item)
        {
            if(IsFull)
            {
                Console.WriteLine("Cannot add -- Buffer full");
            }

            ///add item at position with the value of _count in buffer
            _buffer[_write] = item;
            Console.WriteLine("Add " + item);

            _count++;
           
            _write = (_write + 1) % _size;
        }

        /// <summary>
        /// Method getNextElement
        /// <para>returns the item at postition with value of _read</para>
        /// </summary>
        /// <returns>item</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public T getNextElement()
        {

            if (IsEmpty)
            {
                Console.WriteLine("Cannot get -- Buffer empty");
            }

           
            T item = _buffer[_read];
            _count--;

            Console.WriteLine("Get " + item);
            _read = (_read + 1) % _size;

            return item;
               
        }

        /// <summary>
        /// returns true if buffer is empty
        /// </summary>

        public bool IsEmpty
        {
            get { return (_read == _write) && (_count == 0);}
        }
        /// <summary>
        /// returns true if buffer is full
        /// </summary>
        public bool IsFull
        {
            get { return (_read == _write) && (_count > 0); }
        }

    
    }
}
