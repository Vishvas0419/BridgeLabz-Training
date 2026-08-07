using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Polymorphism_Interfaces_AbstractClasses
{
    internal class BankAccount
    {
        private static readonly string bankName = "PNB";
        private string accountNumber;
        private string name;
        private double balance;

        //public BankAccount{
            
        //}
        public BankAccount(string accountNumber, string name,double balance)
        {
            Console.WriteLine("Welcome to "+bankName);
            this.accountNumber = accountNumber;
            this.name = name;
            this.balance = balance;
        }

        public string AccountNumber
        {
            get { return accountNumber; }
        }

        public double Balance
        {
            get { return balance; }
            set {
                if(value>=0)
                {
                    balance = value;
                }
                else
                {
                    Console.WriteLine("Gareeb...Balance nhi hai tere paas..");
                }
            }
        }

        public void Deposit(double amount)
        {
            Console.WriteLine($"Processing deposit of {amount}..");

            if (amount>0)
            {
                balance += amount;
                Console.WriteLine("Amount deposited successfully");
            }
            else
            {
                Console.WriteLine("Deposited amount should be positive,,,,oho aaj paise kaise aagye daalne ke liye");
            }
        }
        public void withdraw(double amount)
        {
            Console.WriteLine($"Processing withdrawal of {amount}..");

            if (amount > 0 && amount<=balance)
            {
                balance -= amount;
                Console.WriteLine("Amount deposited successfully..");
            }
            else
            {
                Console.WriteLine("Gareeb paise bhi dalwa liya kar, apni aukaat se zyada nikal rha hai tu paise....");
            }
        }

        public void displayAccountDetails()
        {
            Console.WriteLine("=========== Your Account Details ==========");
            Console.WriteLine("Account Number : "+accountNumber);
            Console.WriteLine("Name : "+name);
            Console.WriteLine("Current Balance: "+balance);
        }
    }

}
