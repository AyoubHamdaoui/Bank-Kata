using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_kata.Abstraction
{
    public class Account : AccountService
    {
        public void Deposit(int ammount)
        {
            throw new NotImplementedException();
        }

        public void PrintStatement()
        {
            throw new NotImplementedException();
        }

        public void Withdraw(int ammount)
        {
            throw new NotImplementedException();
        }
    }
}
