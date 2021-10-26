using System;

namespace TM_Lab_1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var a = CurrencyDatabase.Local;
            var b = CurrencyDatabase.Local;

            if (a.Equals(b))
            {
                Console.WriteLine("OK");
            }
            
            ConsoleManager.PrintCurrencies();
            
            var userAccount = new Account();
            var end = false;

            while (!end)
            {
                Console.WriteLine("Current balance: " + userAccount.Balance());

                if (ConsoleManager.InputConfirm("Do you want deposit?"))
                    userAccount.Deposit(ConsoleManager.InputProvideCash());

                if (ConsoleManager.InputConfirm("Do you want currency conversion?"))
                    userAccount.ExchangeTo(ConsoleManager.InputProvideCurrency());

                Console.WriteLine("Current balance: " + userAccount.Balance());

                end = ConsoleManager.InputConfirm("Do you want to quit?");
                Console.Clear();
            }
        }
    }
}