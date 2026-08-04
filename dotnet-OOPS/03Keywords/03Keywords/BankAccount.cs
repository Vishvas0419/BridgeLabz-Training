using System;
using System.Collections.Generic;
using System.Text;

namespace _03Keywords
{
    internal class BankAccount
    {
        private static string BankName = "Punjab National Bank";
        private static int accounts = 0;
        private string accountHolderName;
        private readonly long accountNumber;

        public BankAccount() : this("",0L) { }

        public BankAccount(string accountHolderName,long accountNumber)
        {
            accounts++;
            this.accountNumber = accountNumber;
            this.accountHolderName = accountHolderName;
        }

        public void  GetTotalAccounts()
        {
            Console.WriteLine("No of accounts created : "+accounts);
        }

        public void display()
        {
            Console.WriteLine("Bank Name : "+BankName);
            Console.WriteLine("Account holder Name : "+accountHolderName);
            Console.WriteLine("Account Number : "+accountNumber);


        }

    }
}
