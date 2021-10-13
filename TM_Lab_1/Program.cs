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
        static Database DataBase = Database.GetInstance();
        static void Main(string[] args)
        {
            Bank bank = new Bank();

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

        public static Account ProvideCash()
        {
            Account account;
            do
            {

                Console.WriteLine("--------------- KURS WALUT ---------------");
                int index = 1;
                foreach (var currency in DataBase.GetCurrencies())
                {

                    Console.Write(currency.ToString() + "\t");

                    if (index % 4 == 0)
                        Console.WriteLine();

                    index++;
                }
                Console.WriteLine("Wpisz kwotę np. '0.00 PLN'");
                Console.WriteLine("> ");

                String response = Console.ReadLine();


                account = Account.Parse(response);


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
                foreach (var currency in DataBase.GetCurrencies())
                {

                    Console.Write(currency.Code + "\t");

                    if (index % 8 == 0)
                        Console.WriteLine();

                    index++;
                }
                Console.WriteLine("W jakiej walucie wyświetlic stan konta? np.'PLN'");
                Console.WriteLine("> ");
                String response = Console.ReadLine();
                response = response.Trim();
                response = response.ToUpper();
                temp_currency = Database.GetInstance().GetCurrency(response);


            } while (temp_currency == null);

            return temp_currency;
        }
    }


}
