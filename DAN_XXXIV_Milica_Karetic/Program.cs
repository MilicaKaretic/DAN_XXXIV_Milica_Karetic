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
                Console.Write("Invalid input. Try again: ");
                s = Console.ReadLine();
                b = Int32.TryParse(s, out Num);
            }
            return Num;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter first number");
            int firstNum = ValidPositiveNumber();
            Console.WriteLine("Please enter second number");
            int secondNum = ValidPositiveNumber();

            int sumNum = firstNum + secondNum;

            Thread[] threads = new Thread[sumNum];
            Bank b = new Bank();

            for (int i = 0; i < sumNum; i++)
            {
                Thread t = new Thread(new ThreadStart(b.DoTransactions));
                threads[i] = t;
            }

            for (int i = 0; i < sumNum; i++)
            {
                threads[i].Start();
            }

            Console.ReadKey();
        }
    }
}
