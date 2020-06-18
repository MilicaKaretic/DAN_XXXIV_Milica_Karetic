using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXIV_Milica_Karetic
{
    class Bank
    {
        //amount in bank
        public static int maxAmount = 10000;
        private readonly object locker = new object();

        Random rnd = new Random();

        /// <summary>
        /// Method for withdraw money
        /// </summary>
        /// <param name="amount"></param>
        private void Withdraw(int amount)
        {
            //lock critical section
            lock (locker)
            {
                //if there is no enough money in bank
                if(maxAmount < amount)
                {
                    Console.WriteLine("Transaction rejected." + Thread.CurrentThread.Name + " try to withdraw " + amount + " RSD.\n");
                }
                else
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " try to withdraw " + amount + " RSD.");
                    maxAmount -= amount;
                    Console.WriteLine("In bank left " + maxAmount + " RSD.\n");
                }
            }          
        }

        /// <summary>
        /// Do transaction method calls withdraw method and passes random amount to withdraw method
        /// </summary>
        internal void DoTransaction()
        {
            Withdraw(rnd.Next(100, 10001));
        }
    }
}
