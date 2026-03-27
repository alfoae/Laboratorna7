using System;

class BankTerminal
{
    // ПУБЛІЧНИЙ делегат (погано)
    public Action<int> OnMoneyWithdraw;

    public void Withdraw(int amount)
    {
        Console.WriteLine($"Зняття {amount} грн");

        // Виклик делегата
        OnMoneyWithdraw?.Invoke(amount);
    }
}

class Program
{
    static void Main()
    {
        BankTerminal terminal = new BankTerminal();

        // Підписка
        terminal.OnMoneyWithdraw += Log;

        // Нормальна робота
        terminal.Withdraw(100);

        // ❌ "ЗЛОМ" 1 — видаляємо всіх підписників
        //terminal.OnMoneyWithdraw = null;

        // тепер нічого не викличеться
        terminal.Withdraw(200);

        // ❌ "ЗЛОМ" 2 — викликаємо вручну БЕЗ операції
        terminal.OnMoneyWithdraw?.Invoke(9999);
    }

    static void Log(int amount)
    {
        Console.WriteLine($"[LOG] Знято: {amount}");
    }
}