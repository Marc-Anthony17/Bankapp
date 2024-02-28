using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstApp
{
    /// <summary>
    /// Represents a banking account.
    /// </summary>
    internal class Banking
    {
        private string cardNum;
        private int pin;
        private string firstName;
        private string lastName;
        private double balance;

        /// <summary>
        /// Initializes a new instance of the <see cref="Banking"/> class.
        /// </summary>
        public Banking(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }

        // Getters and setters for private fields

        /// <summary>
        /// Gets the card number.
        /// </summary>
        public string GetCardNum()
        {
            return cardNum;
        }

        /// <summary>
        /// Gets the first name.
        /// </summary>
        public string GetFirstName()
        {
            return firstName;
        }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        public string GetLastName()
        {
            return lastName;
        }

        /// <summary>
        /// Gets the PIN.
        /// </summary>
        public int GetPin()
        {
            return pin;
        }

        /// <summary>
        /// Gets the balance.
        /// </summary>
        public double GetBalance()
        {
            return balance;
        }

        /// <summary>
        /// Sets the PIN.
        /// </summary>
        public void SetPin(int pin)
        {
            this.pin = pin;
        }

        /// <summary>
        /// Sets the first name.
        /// </summary>
        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        /// <summary>
        /// Sets the last name.
        /// </summary>
        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        /// <summary>
        /// Sets the card number.
        /// </summary>
        public void SetCardNum(string cardNum)
        {
            this.cardNum = cardNum;
        }

        /// <summary>
        /// Sets the balance.
        /// </summary>
        public void SetBalance(double balance)
        {
            this.balance = balance;
        }

        /// <summary>
        /// Main entry point of the application.
        /// </summary>
        public static void Main(string[] args)
        {
            // Display instructions for the user
            void DisplayInstructions()
            {
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
            }

            // Perform deposit operation for the current customer
            void DepositToBank(Banking currentCustomer)
            {
                while (true)
                {
                    try
                    {
                        Console.Write("How much would you like to deposit: ");
                        string deposit = Console.ReadLine();
                        double amountValue = Convert.ToDouble(deposit);
                        currentCustomer.SetBalance(currentCustomer.GetBalance() + amountValue);
                        Console.WriteLine("Thank you for your deposit. Your current balance is: " + currentCustomer.GetBalance());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }
            }

            // Perform withdrawal operation for the current customer
            void Withdraw(Banking currentCustomer)
            {
                while (true)
                {
                    try
                    {
                        Console.Write("How much would you like to withdraw: ");
                        string amount = Console.ReadLine();
                        double amountValue = Convert.ToDouble(amount);

                        if (amountValue > currentCustomer.GetBalance())
                        {
                            Console.WriteLine("The specified amount is greater than the amount you have.");
                            continue;
                        }

                        currentCustomer.SetBalance(currentCustomer.GetBalance() - amountValue);
                        Console.WriteLine("Withdrawal was successful. Your current balance is: " + currentCustomer.GetBalance());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }
            }

            // View the current balance for the customer
            void ViewBalance(Banking currentCustomer)
            {
                Console.WriteLine($"Your current balance: {currentCustomer.GetBalance()}");
            }

            // List of customer accounts
            List<Banking> customers = new List<Banking>
            {
                new Banking("0000000000000", 1234, "Adam", "Blake", 87000.30),
                new Banking("0000000000002", 2334, "Eve", "Ronald", 80000.50)
            };

            Banking validUser;
            string userCardNumber = "";

            Console.WriteLine("Welcome to the best bank in the east.");

            // Validate user account number
            while (true)
            {
                Console.WriteLine("Please enter your account number: ");
                userCardNumber = Console.ReadLine();

                validUser = customers.FirstOrDefault(a => a.GetCardNum() == userCardNumber);

                if (validUser != null)
                {
                    Console.WriteLine($"Welcome, {validUser.GetFirstName()}, to the best bank ever");
                    break;
                }

                Console.WriteLine("Card not recognized. Please try again.");
            }

            // Validate user PIN
            Console.WriteLine("Please enter PIN: ");
            int pin = 0;

            while (true)
            {
                try
                {
                    pin = int.Parse(Console.ReadLine());

                    if (validUser.GetPin() != pin)
                    {
                        Console.WriteLine("PIN incorrect. Please try again.");
                        continue;
                    }

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid PIN.");
                }
            }

            int option = 0;

            // Main menu for user interaction
            do
            {
                DisplayInstructions();

                try
                {
                    option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            DepositToBank(validUser);
                            break;
                        case 2:
                            Withdraw(validUser);
                            break;
                        case 3:
                            ViewBalance(validUser);
                            break;
                        case 4:
                            Console.WriteLine("Thank you. Have a nice day.");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                }
            } while (option != 4);
        }
    }
}
