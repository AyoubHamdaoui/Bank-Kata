using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_kata.Abstraction
{
    public class Transaction
    {
        public int Amount { get; }
        public string Date { get; }

        public Transaction(int amount, string date)
        {
            Amount = amount;
            Date = date;
        }
    }
}
