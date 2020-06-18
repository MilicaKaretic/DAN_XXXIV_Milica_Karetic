using System;
using System.Collections.Generic;
using System.Threading;

namespace DAN_XXXIV_Milica_Karetic
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Validation v = new Validation();

            //first line clients
            Console.WriteLine("Please enter number of clients for first cash machine");
            int firstNum = v.ValidPositiveNumber();
            //second line clients
            Console.WriteLine("Please enter number od clients for second cash machine");
            int secondNum = v.ValidPositiveNumber();

            //number of threads
            int sumNum = firstNum + secondNum;

            //Thread[] threads = new Thread[sumNum];
            List<Thread> threads = new List<Thread>();
            Bank b = new Bank();
            
            //create threads for first cash machine
            for (int i = 0; i < firstNum; i++)
            {
                Thread t = new Thread(new ThreadStart(b.DoTransaction))
                {
                    Name = string.Format("Client_{0} on first cash machine", i + 1)
                };
                //threads[i] = t;
                threads.Add(t);
            }

            //create threads for second cash machine
            for (int i = firstNum; i < sumNum; i++)
            {
                Thread t = new Thread(new ThreadStart(b.DoTransaction))
                {
                    Name = string.Format("Client_{0} on second cash machine", i + 1)
                };
                // threads[i] = t;
                threads.Add(t);
            }
            

            //starting all threads
            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Start();
            }

            for (int i = 0; i < sumNum; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
