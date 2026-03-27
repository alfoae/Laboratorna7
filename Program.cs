using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main()
    {
        List<Action> actions = new List<Action>();

        for (int i = 1; i <= 5; i++)
        {
            int j = i;
            actions.Add(() => Console.WriteLine(j));
        }

        foreach (var action in actions)
        {
            action();
        }
    }
}