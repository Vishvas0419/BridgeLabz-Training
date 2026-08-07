using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Polymorphism_Interfaces_AbstractClasses
{
    internal interface ILoanable
    {
        bool ApplyForLoan(double loanAmount);
        double CalculateLoanEligibility();
    }
    internal abstract class BankAccount
    {
        //accountNumber, holderName, and balance.
        private string accountNumber;
        private string holderName;
        private double balance;

        public BankAccount(string accountNumber,string holderName,double balance)
        {
            this.accountNumber = accountNumber;
            this.holderName = holderName;
            this.balance = balance;
        }

        public string AccountNumber
        {
            get {  return accountNumber; }
            private set
            {
                accountNumber = value;
            }
        }

        public string HolderName
        {
            get { return holderName; }

            private set
            {
                holderName = value;
            }
        }

        public double Balance
        {
            get { return balance; }
            private set
            {
                balance = value;
            }
        }

        public void Deposit(double amount)
        {
            Console.WriteLine($"Processing deposit of {amount}..");

            if (amount > 0)
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

            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine("Amount withdrawn successfully..");
            }
            else
            {
                Console.WriteLine("Gareeb paise bhi dalwa liya kar, apni aukaat se zyada nikal rha hai tu paise....");
            }
        }

        public abstract double CalculateInterest();

        public void DisplayAcccountDetails()
        {
            Console.WriteLine("===== Account Details =====");

            Console.WriteLine("Account Number "+accountNumber);
            Console.WriteLine("Account Holder Name : "+holderName);
            Console.WriteLine("Account Balance : "+balance);
            Console.WriteLine("Interest : "+CalculateInterest());

            if(this is ILoanable LoanableAccount)
            {
                Console.WriteLine("Loan Eligibility : "+ LoanableAccount.CalculateLoanEligibility());
            }
            Console.WriteLine("=====================================================");
        }
    }

    internal class SavingsAccount : BankAccount, ILoanable
    {
        public SavingsAccount(string accountNumber, string holderName, double balance) : base(accountNumber, holderName, balance) { }

        public override double CalculateInterest()
        {
            return Balance * 0.80;
        }

        public bool ApplyForLoan(double loanAmount)
        {
            return loanAmount < CalculateLoanEligibility();
        }
        public double CalculateLoanEligibility()
        {
            return Balance * 0.60; //can borrow upto 60% of your balance amount
        }
    }

    internal class CurrentAccount : BankAccount,ILoanable
    {
        public CurrentAccount(string accountNumber, string holderName, double balance) : base(accountNumber,holderName,balance) { }
        public override double CalculateInterest()
        {
            return Balance * 0.04; //4% interest  
        }

        public bool ApplyForLoan(double loanAmount)
        {
            return loanAmount < CalculateLoanEligibility();
        }
        public double CalculateLoanEligibility()
        {
            return Balance * 0.60; //can borrow upto 60% of your balance amount
        }

    }
}
