# Programming Principles

---

## 1. DRY (Don't Repeat Yourself)

Принцип DRY дотримується у класі `AutomatedTellerMachine` — перевірка `amount <= 0` винесена окремо на початку кожного методу, а не дублюється всередині логіки. Також метод `SetUiLoggedIn` у `Form1.cs` уникає повторення коду вмикання/вимикання кнопок.
**Опис:** Кожна частина знань повинна мати єдине, однозначне представлення в системі.

**Демонстрація:**

Метод [`SetUiLoggedIn`](https://github.com/ipz245imv-droid/lab_1/blob/master/WinFormsApp/Form1.cs#L41-L50) централізує керування станом кнопок, уникаючи дублювання:

**Приклад:**
- [`AutomatedTellerMachine.cs`, методи `Deposit`, `Withdraw`, `Transfer`](AutomatedTellerMachine.cs) — однотипна валідація суми на початку кожного методу.
- [`Form1.cs`, метод `SetUiLoggedIn`](Form1.cs#L36-L44) — централізоване керування станом UI.
```csharp
private void SetUiLoggedIn(bool isLoggedIn)
{
    btnBalance.Enabled = isLoggedIn;
    btnWithdraw.Enabled = isLoggedIn;
    btnDeposit.Enabled = isLoggedIn;
    btnTransfer.Enabled = isLoggedIn;
    txtAmount.Enabled = isLoggedIn;
    txtTargetCard.Enabled = isLoggedIn;
}
```

Завдяки цьому стан UI змінюється в одному місці — і після логіну, і після помилки автентифікації.

---

## 2. SRP (Single Responsibility Principle)
## 2. KISS (Keep It Simple, Stupid)

**Опис:** Простота повинна бути ключовою метою в проєктуванні. Слід уникати зайвої складності.

**Демонстрація:**

Кожен клас має одну зону відповідальності:
Метод [`FindAccount`](https://github.com/ipz245imv-droid/lab_1/blob/master/BankingLib/Bank.cs#L11-L12) у `Bank.cs` реалізовано максимально просто — в один рядок:

- `Account` — зберігає дані рахунку та виконує операції з балансом.
- `Bank` — управляє колекцією рахунків.
- `AutomatedTellerMachine` — реалізує логіку банкомату (автентифікація, операції).
- `Form1` — відповідає лише за UI та взаємодію з користувачем.
```csharp
public Account? FindAccount(string cardNumber)
    => Accounts.FirstOrDefault(a => a.CardNumber == cardNumber);
```

**Приклад:**
- [`Account.cs`](Account.cs) — містить лише дані та методи `Deposit`/`Withdraw`.
- [`Bank.cs`](Bank.cs) — містить лише список рахунків та метод пошуку `FindAccount`.
Метод виконує рівно одну задачу і не містить зайвих абстракцій.

---

## 3. OCP (Open/Closed Principle)
## 3. SRP — Single Responsibility Principle

Клас `AutomatedTellerMachine` відкритий для розширення через події (delegates/events), але закритий для модифікації. Нову поведінку при автентифікації чи транзакції можна додати підпискою на відповідну подію, не змінюючи сам клас.
**Опис:** Кожен клас повинен мати лише одну відповідальність.

**Приклад:**
- [`AutomatedTellerMachine.cs`, рядки з `event`](AutomatedTellerMachine.cs#L13-L18) — події `OnAuthenticate`, `OnDeposit`, `OnWithdraw`, `OnTransfer`, `OnBalanceCheck`.
- [`Form1.cs`](Form1.cs#L27-L32) та [`ConsoleApp/Program.cs`](Program.cs#L19-L23) — різна поведінка (MessageBox vs Console) підключається зовні без зміни ATM.
**Демонстрація:**

- [`Account.cs`](https://github.com/ipz245imv-droid/lab_1/blob/master/BankingLib/Account.cs) — відповідає виключно за дані рахунку та операції з балансом.
- [`Bank.cs`](https://github.com/ipz245imv-droid/lab_1/blob/master/BankingLib/Bank.cs) — відповідає виключно за зберігання та пошук рахунків.
- [`AutomatedTellerMachine.cs`](https://github.com/ipz245imv-droid/lab_1/blob/master/BankingLib/AutomatedTellerMachine.cs) — відповідає виключно за логіку банкомату.
- [`Form1.cs`](https://github.com/ipz245imv-droid/lab_1/blob/master/WinFormsApp/Form1.cs) — відповідає виключно за UI та взаємодію з користувачем.

---

## 4. KISS (Keep It Simple, Stupid)
## 4. OCP — Open/Closed Principle

**Опис:** Клас повинен бути відкритим для розширення, але закритим для модифікації.

**Демонстрація:**

[`AutomatedTellerMachine`](https://github.com/ipz245imv-droid/lab_1/blob/master/BankingLib/AutomatedTellerMachine.cs#L13-L18) використовує події для сповіщень — нову поведінку можна додати підпискою, не змінюючи сам клас:

Код написаний просто і без зайвої складності. Методи короткі та зрозумілі. `Bank.FindAccount` реалізований в один рядок за допомогою LINQ.
```csharp
public event AuthHandler? OnAuthenticate;
public event TransactionHandler? OnBalanceCheck;
public event TransactionHandler? OnWithdraw;
public event TransactionHandler? OnDeposit;
public event TransactionHandler? OnTransfer;
```

**Приклад:**
- [`Bank.cs`, метод `FindAccount`](Bank.cs#L11-L12) — лаконічна реалізація через `FirstOrDefault`.
- [`Account.cs`, методи `Deposit`/`Withdraw`](Account.cs#L19-L30) — проста і зрозуміла логіка без зайвих абстракцій.
У [`ConsoleApp/Program.cs`](https://github.com/ipz245imv-droid/lab_1/blob/master/ConsoleApp/Program.cs#L19-L23) виводить у консоль, у [`WinFormsApp/Form1.cs`](https://github.com/ipz245imv-droid/lab_1/blob/master/WinFormsApp/Form1.cs#L24-L28) — через `MessageBox`, але `AutomatedTellerMachine` не змінюється.

---

## 5. Fail Fast

Методи одразу повертають результат або виходять при невалідних даних, не продовжуючи виконання.
**Опис:** Помилки повинні виявлятися якомога раніше, щоб не поширюватись далі.

**Демонстрація:**

Метод [`Withdraw`](https://github.com/ipz245imv-droid/lab_1/blob/master/BankingLib/Account.cs#L23-L30) у `Account.cs` одразу повертає `false` при невалідних даних:

```csharp
public bool Withdraw(decimal amount)
{
    if (amount <= 0) return false;
    if (amount > Balance) return false;

**Приклад:**
- [`Account.cs`, метод `Withdraw`](Account.cs#L23-L27) — перевірки `amount <= 0` та `amount > Balance` на початку методу.
- [`AutomatedTellerMachine.cs`, метод `Transfer`](AutomatedTellerMachine.cs#L72-L95) — послідовні перевірки суми, наявності отримувача та балансу перед виконанням переказу.
    Balance -= amount;
    return true;
}
```
