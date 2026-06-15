namespace BankingLib
{
    public class Account
    {
        public string CardNumber { get; }
        public string OwnerName { get; }
        public string PinCode { get; }
        public decimal Balance { get; private set; }

        public Account(string cardNumber, string ownerName, string pinCode, decimal balance)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            PinCode = pinCode;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) return;
            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0) return false;
            if (amount > Balance) return false;

            Balance -= amount;
            return true;
        }
    }
}
