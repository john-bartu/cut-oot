using System;

namespace TM_Lab_1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            ConsoleManager.PrintCurrencies();
            var userAccount = new Account();

            bool end = false;
            while (!end)
            {
                Console.WriteLine("Current balance: " + userAccount.Balance());
                if (ConsoleManager.InputConfirm("Do you want deposit?"))
                    userAccount.Deposit(ConsoleManager.InputProvideCash());

                if (ConsoleManager.InputConfirm("Do you want currency conversion?"))
                    userAccount.ExchangeTo(ConsoleManager.InputProvideCurrency());

                end = ConsoleManager.InputConfirm("Do you want to quit?");
                Console.Clear();
            }
        }
    }
}