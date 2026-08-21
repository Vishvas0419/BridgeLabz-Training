using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling
{

    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }
    internal class BankAccount
    {
        private double balance;

        public BankAccount(double balance)
        {
            this.balance = balance;
        }

        public void Withdraw(double amount)
        {
            if(amount<0)
            {
                throw new ArgumentException("Invalid amount!");
            }
            if(amount>balance)
            {
                throw new InsufficientFundsException("Insufficient balance!");
            }

            balance = balance - amount;
            Console.WriteLine($"Withdrawal successful, new balance: {balance}");
        }






    }
}
