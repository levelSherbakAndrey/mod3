using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SystemFileReader;

namespace FinalConsoleTask
{
    class Program
    {
        static void Main(string[] args)
        {
            read();
        }

        static void read()
        {
            FileLibrary ob = new FileLibrary();

            List<Thread> list = new List<Thread>();
            list.Add(new Thread(ob.Show));
            list.Add(new Thread(ob.Show));
            list.Add(new Thread(ob.Show));


            while (true)
            {
                foreach (Thread a in list)
                {
                    a.Start();
                }
                ob.path = Console.ReadLine();
            }
        }
    }
}
