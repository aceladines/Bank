using BankNameSpace;
using System;

namespace BankNameSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new bank instance
            Bank myBank = new Bank();

            // Create a new account
            Console.WriteLine("Enter account number:");
            long accountNumber;
            while (!long.TryParse(Console.ReadLine(), out accountNumber))
            {
                Console.WriteLine("Invalid input. Please enter a valid account number:");
            }

            Console.WriteLine("Enter account name:");
            string accountName = Console.ReadLine();
            while (string.IsNullOrEmpty(accountName))
            {
                Console.WriteLine("Invalid input. Please enter a valid account name:");
                accountName = Console.ReadLine();
            }


            Console.WriteLine("Enter initial balance:");
            float initialBalance;
            while (!float.TryParse(Console.ReadLine(), out initialBalance))
            {
                Console.WriteLine("Invalid input. Please enter a valid initial balance:");
            }

            Account newAccount = new Account(accountNumber, accountName, initialBalance);

            // Add the account to the bank
            myBank.CreateAccount(newAccount);

            // Display all accounts in the bank
            Console.WriteLine("\nAll accounts in the bank:");
            foreach (var account in myBank.GetAllAccounts())
            {
                Console.WriteLine(account.DisplayAccountDetails());
            }

            // Perform transactions
            while (true)
            {
                Console.WriteLine("\nEnter 'D' to deposit, 'W' to withdraw, or 'Q' to quit:");
                string choice = Console.ReadLine()?.ToUpper();

                if (choice == "D")
                {
                    Console.WriteLine("Enter deposit amount:");
                    float depositAmount;
                    while (!float.TryParse(Console.ReadLine(), out depositAmount))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid deposit amount:");
                    }
                    string depositResult = myBank.DepositMoney(accountNumber, depositAmount);
                    Console.WriteLine(depositResult);
                }
                else if (choice == "W")
                {
                    Console.WriteLine("Enter withdrawal amount:");
                    float withdrawAmount;
                    while (!float.TryParse(Console.ReadLine(), out withdrawAmount))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid withdrawal amount:");
                    }
                    string withdrawResult = myBank.WithdrawMoney(accountNumber, withdrawAmount);
                    Console.WriteLine(withdrawResult);
                }
                else if (choice == "Q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

                // Display the updated account details
                Console.WriteLine("\nUpdated account details:");
                Console.WriteLine(myBank.FindAccount(accountNumber)?.DisplayAccountDetails());
            }

            Console.WriteLine("\nThank you for using our banking system!");
        }
    }
}
