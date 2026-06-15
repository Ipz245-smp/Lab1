namespace BankingLib
{
    public delegate void AuthHandler(string message);
    public delegate void TransactionHandler(string message);

    public class AutomatedTellerMachine
    {
        public string Id { get; }
        public string Address { get; }
        public decimal CashInMachine { get; private set; }
        public Bank Bank { get; }

        public event AuthHandler? OnAuthenticate;
        public event TransactionHandler? OnBalanceCheck;
        public event TransactionHandler? OnWithdraw;
        public event TransactionHandler? OnDeposit;
        public event TransactionHandler? OnTransfer;

        public AutomatedTellerMachine(string id, string address, decimal cash, Bank bank)
        {
            Id = id;
            Address = address;
            CashInMachine = cash;
            Bank = bank;
        }

        public Account? Authenticate(string cardNumber, string pin)
        {
            var acc = Bank.FindAccount(cardNumber);

            if (acc != null && acc.PinCode == pin)
            {
                OnAuthenticate?.Invoke($"Успішний вхід: {acc.OwnerName}");
                return acc;
            }

            OnAuthenticate?.Invoke("Помилка: невірний номер картки або PIN.");
            return null;
        }

        public void CheckBalance(Account acc)
            => OnBalanceCheck?.Invoke($"Баланс: {acc.Balance} грн");

        public void Deposit(Account acc, decimal amount)
        {
            if (amount <= 0)
            {
                OnDeposit?.Invoke("Сума має бути більшою за 0.");
                return;
            }

            acc.Deposit(amount);
            CashInMachine += amount;
            OnDeposit?.Invoke($"Поповнення {amount} грн. Баланс: {acc.Balance} грн");
        }

        public void Withdraw(Account acc, decimal amount)
        {
            if (amount <= 0)
            {
                OnWithdraw?.Invoke("Сума має бути більшою за 0.");
                return;
            }

            if (amount > CashInMachine)
            {
                OnWithdraw?.Invoke("У банкоматі недостатньо готівки.");
                return;
            }

            if (acc.Withdraw(amount))
            {
                CashInMachine -= amount;
                OnWithdraw?.Invoke($"Знято {amount} грн. Баланс: {acc.Balance} грн");
            }
            else
            {
                OnWithdraw?.Invoke("Недостатньо коштів на рахунку.");
            }
        }

        public void Transfer(Account from, string toCard, decimal amount)
        {
            if (amount <= 0)
            {
                OnTransfer?.Invoke("Сума має бути більшою за 0.");
                return;
            }

            var toAcc = Bank.FindAccount(toCard);
            if (toAcc == null)
            {
                OnTransfer?.Invoke("Картку отримувача не знайдено.");
                return;
            }

            if (!from.Withdraw(amount))
            {
                OnTransfer?.Invoke("Недостатньо коштів для переказу.");
                return;
            }

            toAcc.Deposit(amount);
            OnTransfer?.Invoke($"Переказ {amount} грн на {toCard} успішний.");
        }
    }
}
