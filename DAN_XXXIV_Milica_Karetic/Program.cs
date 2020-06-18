using System;
using System.Threading;

namespace DAN_XXXIV_Milica_Karetic
{
    class Program
    {
        /// <summary>
        /// Valid positive int input
        /// </summary>
        /// <returns></returns>
        public static int ValidPositiveNumber()
        {
            string s = Console.ReadLine();
            int Num;
            bool b = Int32.TryParse(s, out Num);
            while (!b || Num < 0)
            {
                Console.WriteLine("Invalid input. Try again: ");
                s = Console.ReadLine();
                b = Int32.TryParse(s, out Num);
            }
            return Num;
        }

        static void Main(string[] args)
        {
            //first line clients
            Console.WriteLine("Please enter number for first cash machine");
            int firstNum = ValidPositiveNumber();
            //second line clients
            Console.WriteLine("Please enter number for second cash machine");
            int secondNum = ValidPositiveNumber();

            //number of threads
            int sumNum = firstNum + secondNum;

            Thread[] threads = new Thread[sumNum];
            Bank b = new Bank();

            for (int i = 0; i < sumNum; i++)
            {
                Thread t = new Thread(new ThreadStart(b.DoTransaction))
                {
                    Name = string.Format("Client_{0}", i + 1)
                };
                threads[i] = t;
            }

            for (int i = 0; i < sumNum; i++)
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
