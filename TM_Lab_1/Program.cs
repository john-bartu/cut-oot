using System;

namespace TM_Lab_1
{
    internal enum Command
    {
        Exit,
        Deposit,
        Balance
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            var bank = new Account();

            while (true)
            {
                if (Confirm("🏧️ Czy chcesz dodać środki?")) bank.Deposit(ProvideCash());

                Console.WriteLine("Obecny stan konta: " + bank.Balance(ProvideCurrency()) + " 💰️\n");
            }
        }

        static bool Confirm(string title)
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

        static Denomination ProvideCash()
        {
            Denomination denomination;
            do
            {
                Console.WriteLine("--------------- KURS WALUT ---------------");
                var index = 1;
                foreach (var currency in Database.Local.GetCurrencies())
                {
                    Console.Write(currency + "\t");

                    if (index % 4 == 0)
                        Console.WriteLine();

                    index++;
                }

                Console.WriteLine();
                Console.WriteLine("Wpisz kwotę np. '0.00 PLN'");
                Console.Write("> ");

                var response = Console.ReadLine();
                denomination = Denomination.Parse(response);
            } while (denomination == null);

            return denomination;
        }

        static Currency ProvideCurrency()
        {
            Currency currency;
            do
            {
                try
                {
                    Console.WriteLine("----------------- WALUTY ------------------");
                    var index = 1;
                    foreach (var curr in Database.Local.GetCurrencies())
                    {
                        Console.Write(curr.Code + "\t");

                        if (index % 8 == 0)
                            Console.WriteLine();

                        index++;
                    }

                    Console.WriteLine();
                    Console.WriteLine("W jakiej walucie wyświetlic stan konta? np.'PLN'");
                    Console.Write("> ");
                    var response = Console.ReadLine();
                    response = response.Trim();
                    response = response.ToUpper();
                    currency = Database.Local.GetCurrency(response);
                }
                catch (IndexOutOfRangeException e)
                {
                    currency = null;
                }
            } while (currency == null);

            return currency;
        }
    }
}