using System;
using System.Linq;
using System.Xml.Linq;
using System.Text;
namespace TM_Lab_1
{
    enum Command
    {
        EXIT,
        DEPOSIT,
        BALANCE
    }
    class Program
    {
        static void Main(string[] args)
        {
            Account bank = new Account();

            while (true)
            {

                if (Confirm("🏧️ Czy chcesz dodać środki?"))
                {
                    bank.Deposit(ProvideCash());
                }

                Console.WriteLine("Obecny stan konta: " + bank.Balance(ProvideCurrency()).ToString() + " 💰️\n");
            }

        }

        public static bool Confirm(string title)
        {
            ConsoleKey input;
            do
            {
                Console.Write($"{ title } [y/n] ");
                input = Console.ReadKey(false).Key;
                if (input != ConsoleKey.Enter)
                {
                    Console.WriteLine();
                }
            } while (input != ConsoleKey.Y && input != ConsoleKey.N);

            return (input == ConsoleKey.Y);
        }

        public static Denomination ProvideCash()
        {
            Denomination denomination;
            do
            {

                Console.WriteLine("--------------- KURS WALUT ---------------");
                int index = 1;
                foreach (var currency in Database.local.GetCurrencies())
                {

                    Console.Write(currency.ToString() + "\t");

                    if (index % 4 == 0)
                        Console.WriteLine();

                    index++;
                }
                Console.WriteLine();
                Console.WriteLine("Wpisz kwotę np. '0.00 PLN'");
                Console.Write("> ");

                String response = Console.ReadLine();
                denomination = Denomination.Parse(response);

            } while (denomination == null);

            return denomination;
        }

        public static Currency ProvideCurrency()
        {
            Currency currency;
            do
            {

                Console.WriteLine("----------------- WALUTY ------------------");
                int index = 1;
                foreach (var curr in Database.local.GetCurrencies())
                {
                    Console.Write(curr.Code + "\t");

                    if (index % 8 == 0)
                        Console.WriteLine();

                    index++;
                }
                Console.WriteLine();
                Console.WriteLine("W jakiej walucie wyświetlic stan konta? np.'PLN'");
                Console.Write("> ");
                String response = Console.ReadLine();
                response = response.Trim();
                response = response.ToUpper();
                currency = Database.local.GetCurrency(response);


            } while (currency == null);

            return currency;
        }
    }


}
