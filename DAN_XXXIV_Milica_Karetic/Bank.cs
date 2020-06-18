using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXIV_Milica_Karetic
{
    class Bank
    {
        public static int maxAmount = 10000;

        Random rnd = new Random();

        public Bank()
        {

        }

        public int Withdraw(int amount)
        {
            return 0;
        }

        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {
                Withdraw(rnd.Next(100, 10000));
            }
        }
    }
}
