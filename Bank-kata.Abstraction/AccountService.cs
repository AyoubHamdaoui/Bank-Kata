using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_kata.Abstraction
{
    public interface AccountService
    {
        void Deposit(int ammount);
        void Withdraw(int ammount);
        void PrintStatement();
    }
}
