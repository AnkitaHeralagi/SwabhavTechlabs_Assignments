using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AccountApp_Serialization_Deserialization
{
    internal class Account
    {
        private int accountNo;
        private string accountHolderName;
        private string bankName;
        private double balance;

        public int AccountNo
        {
            get => accountNo;
            set => accountNo = value;
        }

        public string AccountHolderName
        {
            get => accountHolderName;
            set => accountHolderName = value;
        }

        public string BankName
        {
            get => bankName;
            set => bankName = value;
        }

        public double Balance
        {
            get => balance;
            set => balance = value;
        }

        public Account() { }

        public Account(int accNo, string name, string bank, double opening)
        {
            if (opening < 500)
                throw new Exception($"Minimum balance must be {500.ToString("C", new CultureInfo("hi-IN"))}");

            accountNo = accNo;
            accountHolderName = name;
            bankName = bank;
            balance = opening;
        }

        public bool Deposit(double amount)
        {
            if (amount <= 0) return false;
            balance += amount;
            return true;
        }

        public bool Withdraw(double amount)
        {
            if (amount <= 0) return false;

            if (balance - amount < 500)
                return false;

            balance -= amount;
            return true;
        }

        public double CheckBalance()
        {
            return balance;
        }
    }
}
