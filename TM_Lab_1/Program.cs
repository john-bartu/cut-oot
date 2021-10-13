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
            ConsoleKey response;
            do
            {
                Console.Write($"{ title } [y/n] ");
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                {
                    Console.WriteLine();
                }
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            return (response == ConsoleKey.Y);
        }

        public static Denomination ProvideCash()
        {
            Denomination account;
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


                account = Denomination.Parse(response);


            } while (account == null);

            return account;
        }

        public static Currency ProvideCurrency()
        {
            Currency temp_currency;
            do
            {

                Console.WriteLine("----------------- WALUTY ------------------");
                int index = 1;
                foreach (var currency in Database.local.GetCurrencies())
                {

                    Console.Write(currency.Code + "\t");

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
                temp_currency = Database.local.GetCurrency(response);


            } while (temp_currency == null);

            return temp_currency;
        }
    }


}
