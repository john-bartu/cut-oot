using System;

namespace TM_Lab_1
{
    public class ConsoleManager
    {
        public static void PrintCurrencies()
        {
            Console.WriteLine("----------------- Currencies ------------------");
            var index = 1;
            foreach (var curr in CurrencyDatabase.Local().GetCurrencies())
            {
                Console.Write(curr.Code + "\t");
                if (index % 10 == 0)
                    Console.WriteLine();
                index++;
            }

            Console.WriteLine();
        }

        public static void PrintCurrenciesWithExchangeRate()
        {
            Console.WriteLine("--------------- Currency Cantor ---------------");
            var index = 1;
            foreach (var currency in CurrencyDatabase.Local().GetCurrencies())
            {
                Console.Write(currency + "\t");
                if (index % 4 == 0)
                    Console.WriteLine();
                index++;
            }

            Console.WriteLine();
        }

        public static bool InputConfirm(string title)
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

        public static Denomination InputProvideCash()
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

        public static Currency InputProvideCurrency()
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
                    currency = CurrencyDatabase.Local().GetCurrency(response);
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