using System;
using System.Globalization;

namespace AccountApp_Serialization_Deserialization
{
    internal class BankUI
    {
        FileHandler file = new FileHandler();

        private string FormatCurrency(double amount)
        {
            return string.Format(new CultureInfo("hi-IN"), "{0:C}", amount);
        }

        public void Start()
        {
            Account acc = file.Load();

            if (acc == null)
            {
                acc = CreateAccount();
                Console.WriteLine("Account created successfuly");
            }
            else
            {
                Console.WriteLine("\nWelcome Back!");
                Console.WriteLine($"Account Balance is: {FormatCurrency(acc.CheckBalance())}");
            }

            RunMenu(acc);
        }

        private Account CreateAccount()
        {
            Console.WriteLine("Welcome! Enter Account Details to create new Account:");

            int accNo;
            double opening;

            Console.Write("Account Number: ");
            while (!int.TryParse(Console.ReadLine(), out accNo))
                Console.Write("Enter valid number: ");

            Console.Write("Account Holder Name: ");
            string name = Console.ReadLine();

            Console.Write("Bank Name: ");
            string bank = Console.ReadLine();

            Console.Write("Opening Balance: ");
            while (!double.TryParse(Console.ReadLine(), out opening) || opening < 500)
                Console.Write($"Minimum {500.ToString("C0", new CultureInfo("hi-IN"))} required: ");

            return new Account(accNo, name, bank, opening);
        }

        private void RunMenu(Account acc)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nWhat do you wish to do?");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Display Balance");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Deposit(acc);
                        break;

                    case "2":
                        Withdraw(acc);
                        break;

                    case "3":
                        Console.WriteLine($"Balance for AccNo {acc.AccountNo} is {FormatCurrency(acc.CheckBalance())}");
                        break;

                    case "4":
                        file.Save(acc);
                        Console.WriteLine("Thank you!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine($"Balance for AccNo {acc.AccountNo} is {FormatCurrency(acc.CheckBalance())}");
                        break;
                }

                file.Save(acc);
            }
        }

        private void Deposit(Account acc)
        {
            Console.Write("Enter amount to deposit: ");

            if (double.TryParse(Console.ReadLine(), out double amt))
            {
                if (acc.Deposit(amt))
                    Console.WriteLine($"Amount Deposited Successfully. New Balance: {FormatCurrency(acc.CheckBalance())}");
                else
                    Console.WriteLine("Invalid Amount");
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        private void Withdraw(Account acc)
        {
            Console.Write("Enter amount to withdraw: ");

            if (double.TryParse(Console.ReadLine(), out double amt))
            {
                if (acc.Withdraw(amt))
                    Console.WriteLine($"Amount withdrawn successfully. Remaining Balance: {FormatCurrency(acc.CheckBalance())}");
                else
                    Console.WriteLine("Insufficient Balance!");
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
    }
}