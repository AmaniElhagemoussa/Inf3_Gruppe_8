// compile with: /doc:Threading.xml

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;


namespace Excercise2_Threading
{

    /// <summary>
    /// class Programm 
    /// <remarks>author:Group 8-Sarah,Katherina,Amani
    /// history:03.12.2015
    /// </remarks>
    /// </summary>
    class Programm
    {
        ///List for the two .txt files
        private static List<String> lines = new List<String>();

        /// <summary> 
        ///add all the lines from first .txt file to the List 
        /// </summary>
        private static void Work1()
        {
            lines.AddRange(System.IO.File.ReadAllLines(@"C:\Users\user\Desktop\mails1.txt"));
        }

        /// <summary>
        /// add all lines from the second .txt file to the List
        /// </summary>
        private static void Work2()
        {
            lines.AddRange(System.IO.File.ReadAllLines(@"C:\Users\user\Desktop\mails2.txt"));
        }
        /// <summary>
        /// Method for counting the " .edu " endings 
        /// </summary> 
        private static void FindStrings()
        {
            ///ToArray: Convert the List in a Array
            string content = string.Join(" ", lines.ToArray());
            string word = ".edu";

            int pos = 0;
            int counter = 0;

            while (pos > -1)
            {
                pos = content.IndexOf(word);
                if (pos > -1)
                {
                    counter++;

                    ///.Substring: gets parts of strings
                    content = content.Substring(pos + word.Length);
                }
            }
            Console.WriteLine("The Number of the mails that ends with .edu is: " + counter);
        }

        /// <summary>
        /// main Method to start the Programm
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            Thread t1 = new Thread(new ThreadStart(Work1));
            t1.Start();

            Thread t2 = new Thread(new ThreadStart(Work2));
            ///.Join(): block Thread t1 until t2 finishes.  
            t2.Start();
            t2.Join();
            t1.Join();

            Thread t3 = new Thread(new ThreadStart(FindStrings));
            t3.Start();


            Console.ReadKey();



        }


    }
}
