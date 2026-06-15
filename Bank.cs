using System.Collections.Generic;
using System.Linq;

namespace BankingLib
{
    public class Bank
    {
        public string Name { get; }
        public List<Account> Accounts { get; } = new();

        public Bank(string name) => Name = name;

        public Account? FindAccount(string cardNumber)
            => Accounts.FirstOrDefault(a => a.CardNumber == cardNumber);
    }
}
