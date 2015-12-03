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
 /// history:03.12.15
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
        /// </summary>
        /// <param name="size"></param>
        public Buffer(int size)
    {
            if(size <= 0)
                throw new ArgumentException("Must be greater than zero","size");
            _size = size;
            _buffer = new T[_size];
    }

        /// <summary>Add Method
        /// <para>adds an item to the buffer</para>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="name"></param>

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Add(T item)
        {
            if(IsFull)
            {
                Console.WriteLine("Cannot add -- Buffer full");
            }

            ///add value at position with value _count in buffer
            _buffer[_write] = item;
            Console.WriteLine("Add " + item);

            _count++;
            _write = (_write + 1) % _size;
        }

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

        //returns true if buffer is empty
        public bool IsEmpty
        {
            get { return (_read == _write) && (_count == 0);}
        }

        public bool IsFull
        {
            get { return (_read == _write) && (_count > 0); }
        }

    
    }
}
