using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class BankAcct
    {
        private Object acctLock = new object();

        double Balance { get; set; }
        string Name {  get; set; }

        public BankAcct(double bal)
        {
            Balance = bal;
        }

        public double Withdraw(double amt)
        {
            double remBalance = Balance - amt;
            if(remBalance < 0)
            {
                Console.WriteLine($"Sorry ${Balance} in Account");
                return Balance;
            }
            lock (acctLock)
            {
                Console.WriteLine("Removed {0} and {1} left in Account", amt, remBalance);
                Balance = remBalance;
                return remBalance;
            }
        }

        public void IssuWithdraw()
        {
            Withdraw(1);
        }

    }
}
