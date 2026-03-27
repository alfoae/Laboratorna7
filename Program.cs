class BankTerminal
{
    public Action<int> OnMoneyWithdraw;

    public void Withdraw(int amount)
    {
        Console.WriteLine($"Зняття {amount} грн");

        OnMoneyWithdraw?.Invoke(amount);
    }
}

class Program
{
    static void Main()
    {
        BankTerminal terminal = new BankTerminal();

        terminal.OnMoneyWithdraw += Log;

        terminal.Withdraw(100);

        //"ЗЛОМ" 1 — видаляє всіх підписників
        //terminal.OnMoneyWithdraw = null;

        terminal.Withdraw(200);

        //ЗЛОМ 2 — виклик вручну без операції
        terminal.OnMoneyWithdraw?.Invoke(9999);
    }

    static void Log(int amount)
    {
        Console.WriteLine($"[LOG] Знято: {amount}");
    }
}