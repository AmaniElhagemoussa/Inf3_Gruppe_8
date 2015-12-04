using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Programm
    {


        static void Main(string[] args)
        {
            string datei = System.IO.File.ReadAllText(@"C:\Users\user\Desktop\mails1.txt");
            //string inhalt = datei;
            string gesuchteswort = ".edu";

            // using (StreamReader SourceReader = File.OpenText(datei + "mails1.txt"))
            //{

            Console.WriteLine(getAnzahlFindStrings(gesuchteswort, datei));

                Console.ReadKey();
            //}
        }

private static int getAnzahlFindStrings(string wort, string Dateiinhalt)
        {
            int pos = 0;
            int zaehler = 0;

            while (pos > -1)
            {
                pos = Dateiinhalt.IndexOf(wort);
                if (pos > -1)
                {
                    zaehler++;
                    Dateiinhalt = Dateiinhalt.Substring(pos + wort.Length);
                }
            }
            return zaehler;
        }
    }

    }

