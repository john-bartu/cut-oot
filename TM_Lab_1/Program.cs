using System;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace TM_Lab_1
{

    class Program
    {
        static void Main(string[] args)
        {
            Database DataBase = Database.GetInstance();
            DataBase.Update();
            foreach (var currency in DataBase.GetCurrencies())
            {
                // Console.WriteLine(currency.ToString());
            }

            Console.WriteLine(DataBase.GetCurrency("USD").ToString());

        }
    }
}
