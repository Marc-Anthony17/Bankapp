
namespace FirstApp
{
    internal class Banking
    {
        private string cardNum;
        private int pin;
        private string firstName;
        private string lastName;
        private double balance;

        public Banking(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }

        public string GetCardNum()
        {
            return cardNum;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public int GetPin()
        {
            return pin;
        }

        public double GetBalance()
        {
            return balance;
        }

        public void SetPin(int pin)
        {
            this.pin = pin;
        }

        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public void SetCardNum(string cardNum)
        {
            this.cardNum = cardNum;
        }

        public void SetBalance(double balance)
        {
            this.balance = balance;
        }

        public static void Main(string[] args)
        {
            void DisplayInstructions()
            {
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
            }

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
                        Console.WriteLine("Thank you for your deposit. your current Value is: " + currentCustomer.GetBalance());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }
            }

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
                        Console.WriteLine("Withdrawal was successful. your current amount is: " + currentCustomer.GetBalance());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }
            }

            void ViewBalance(Banking currentCustomer)
            {
                Console.WriteLine($"Your current balance: {currentCustomer.GetBalance()}");
            }

            List<Banking> customers = new List<Banking>
            {
                new Banking("0000000000000", 1234, "Adam", "Blake", 87000.30),
                new Banking("0000000000002", 2334, "Eve", "Ronald", 80000.50)
            };
            Banking validUser;
            string userCardNumber = "";

            Console.WriteLine("Welcome to the best bank in the east.");

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

            Console.WriteLine("Please enter pin: ");
            int pin = 0;

            while (true)
            {
                try
                {
                    pin = int.Parse(Console.ReadLine());

                    if (validUser.GetPin() != pin)
                    {
                        Console.WriteLine("Pin incorrect. Please try again.");
                        continue;
                    }

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid pin.");
                }
            }

            int option = 0;

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
