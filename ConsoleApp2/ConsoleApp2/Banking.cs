namespace FirstApp
{
    using System;
    internal class Banking
    {
        String cardNum;
        int pin;
        String firstName;
        String lastName;
        double balence;

        public Banking(string cardNum, int pin, string firstName, string lastName, double balence)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balence = balence;
        }

        public String getCardNum()
        {
            return cardNum;
        }
        public String getFirstName()
        {
            return firstName;
        }
        public String getLastName() { return lastName; }
        public int getPin()
        {
            return pin;
        }
        public double getBalence() { return balence; }
        public void setPin(int pin)
        {
            this.pin = pin;
        }
        public void setFirstName(String firstName)
        {
            this.firstName = firstName;
        }
        public void setName(String lastName)
        {
            this.lastName = lastName;
        }
        public void setCardNum(String cardNum)
        {
            this.cardNum = cardNum;
        }
        public void setBalence(double balence) { this.balence = balence; }

        public static void Main(String[] args)
        {
            void displayInstructions () {
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balence");
                Console.WriteLine("4. Exit");


            }
           // void deposit(Banking currentCustomer) {
                //try()
           // }
        }
    }
}

