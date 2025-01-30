using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_kata.Abstraction
{
    public class Account : AccountService
    {
        
        private readonly List<Transaction> _transactions = new List<Transaction>();
       public void Deposit(int amount)
        {
            _transactions.Add(new Transaction(amount, DateTime.UtcNow.Date));
        }
        public void PrintStatement()
        {
            Console.WriteLine("DATE | AMOUNT | BALANCE");
             int balance = 0;
            foreach (var transaction in _transactions.OrderBy(t => t.Date))
            {
                balance += transaction.Amount;
                Console.WriteLine($"{transaction.Date.ToString("dd-MM-yyyy")} | {transaction.Amount} | {balance}");
            }
        }

        
        public void Withdraw(int amount)
        {
            _transactions.Add(new Transaction(-amount, DateTime.UtcNow.Date));
        }
       
        public List<Transaction> GetTransactions()
        {
            return _transactions;
        }
    }
}
