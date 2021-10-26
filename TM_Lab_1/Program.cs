using System;

namespace TM_Lab_1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Database.Update();
            var userAccount = new Account();
            
            bool end = false;
            while (!end)
            {
                Console.WriteLine("Current balance: " + userAccount.Balance());

                if (InputConfirm("Do you want deposit?"))
                    userAccount.Deposit(InputProvideCash());

                if (InputConfirm("Do you want currency conversion?"))
                    userAccount.Convert(InputProvideCurrency());

                end = InputConfirm("Do you want to quit?");
            }
        }

        private static bool InputConfirm(string title)
        {
            ConsoleKey input;
            do
            {
                Console.Write($"{title} [y/n] ");
                input = Console.ReadKey(false).Key;
                if (input != ConsoleKey.Enter) Console.WriteLine();
            } while (input != ConsoleKey.Y && input != ConsoleKey.N);

            return input == ConsoleKey.Y;
        }

        private static void PrintCurrencies()
        {
            Console.WriteLine("----------------- Currencies ------------------");
            var index = 1;
            foreach (var curr in Database.Local.GetCurrencies())
            {
                Console.Write(curr.Code + "\t");
                if (index % 10 == 0)
                    Console.WriteLine();
                index++;
            }

            Console.WriteLine();
        }

        private static void PrintCurrenciesWithExchangeRate()
        {
            Console.WriteLine("--------------- Currency Cantor ---------------");
            var index = 1;
            foreach (var currency in Database.Local.GetCurrencies())
            {
                Console.Write(currency + "\t");
                if (index % 4 == 0)
                    Console.WriteLine();
                index++;
            }

            Console.WriteLine();
        }


        private static Denomination InputProvideCash()
        {
            Denomination denomination;
            do
            {
                PrintCurrenciesWithExchangeRate();
                Console.WriteLine("Enter currency with amount. Example: '0.00 PLN'");
                Console.Write("> ");

                var response = Console.ReadLine();
                denomination = Denomination.Parse(response);

                if (denomination == null)
                {
                    Console.Write("Currency with amount not recognised.");
                }
            } while (denomination == null);

            return denomination;
        }

        static Currency InputProvideCurrency()
        {
            Currency currency;
            do
            {
                try
                {
                    PrintCurrencies();
                    Console.WriteLine("In which currency show you balance? Example: 'PLN'");
                    Console.Write("> ");
                    var response = Console.ReadLine();
                    response = response?.Trim();
                    response = response?.ToUpper();
                    currency = Database.Local.GetCurrency(response);
                }
                catch (IndexOutOfRangeException)
                {
                    currency = null;
                }
            } while (currency == null);

            return currency;
        }
    }
}