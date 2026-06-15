using System;
using BankingLib;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var bank = new Bank("MonoBank");
            bank.Accounts.Add(new Account("1111", "Іван Іваненко", "1234", 5000));
            bank.Accounts.Add(new Account("2222", "Петро Петренко", "4321", 3000));

            var atm = new AutomatedTellerMachine("ATM01", "Центр міста", 100000, bank);

            atm.OnAuthenticate += msg => Console.WriteLine(msg);
            atm.OnBalanceCheck += msg => Console.WriteLine(msg);
            atm.OnWithdraw += msg => Console.WriteLine(msg);
            atm.OnDeposit += msg => Console.WriteLine(msg);
            atm.OnTransfer += msg => Console.WriteLine(msg);

            Account? current = null;

            while (true)
            {
                Console.WriteLine("\n===== ATM MENU =====");
                Console.WriteLine("1 - Увійти");
                Console.WriteLine("2 - Баланс");
                Console.WriteLine("3 - Зняти кошти");
                Console.WriteLine("4 - Поповнити");
                Console.WriteLine("5 - Переказ");
                Console.WriteLine("0 - Вихід");
                Console.Write("Ваш вибір: ");
                var choice = Console.ReadLine();

                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        Console.Write("Номер картки: ");
                        var card = Console.ReadLine() ?? "";
                        Console.Write("PIN: ");
                        var pin = Console.ReadLine() ?? "";
                        current = atm.Authenticate(card, pin);
                        break;

                    case "2":
                        if (current == null) { Console.WriteLine("Спочатку увійдіть."); break; }
                        atm.CheckBalance(current);
                        break;

                    case "3":
                        if (current == null) { Console.WriteLine("Спочатку увійдіть."); break; }
                        Console.Write("Сума: ");
                        if (decimal.TryParse(Console.ReadLine(), out var w))
                            atm.Withdraw(current, w);
                        else
                            Console.WriteLine("Некоректна сума.");
                        break;

                    case "4":
                        if (current == null) { Console.WriteLine("Спочатку увійдіть."); break; }
                        Console.Write("Сума: ");
                        if (decimal.TryParse(Console.ReadLine(), out var d))
                            atm.Deposit(current, d);
                        else
                            Console.WriteLine("Некоректна сума.");
                        break;

                    case "5":
                        if (current == null) { Console.WriteLine("Спочатку увійдіть."); break; }
                        Console.Write("Картка отримувача: ");
                        var to = Console.ReadLine() ?? "";
                        Console.Write("Сума: ");
                        if (decimal.TryParse(Console.ReadLine(), out var t))
                            atm.Transfer(current, to, t);
                        else
                            Console.WriteLine("Некоректна сума.");
                        break;

                    default:
                        Console.WriteLine("Невірний пункт меню.");
                        break;
                }
            }
        }
    }
}
