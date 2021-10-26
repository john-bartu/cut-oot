using System;
using System.Net.Http.Headers;

namespace TM_Lab_1
{
    public class Denomination
    {
        public Denomination(Currency currency, float balance)
        {
            Currency = currency;
            Amount = balance;
        }

        public float Amount { get; }

        public Currency Currency { get; }

        public Denomination ExchangeTo(Currency newCurrency)
        {
            return new Denomination(newCurrency,
                (Currency.AvgRate / Currency.Multiplier) / (newCurrency.AvgRate / newCurrency.Multiplier) * Amount);
        }

        public static Denomination ParseOrNull(string parse)
        {
            try
            {
                parse = parse.Trim();
                parse = parse.Replace("  ", " ");
                parse = parse.Replace(",", ".");
                parse = parse.ToUpper();
                var parts = parse.Split(' ', 2);
                var currencyCode = parts[1];
                var amount = float.Parse(parts[0]);
                return new Denomination(CurrencyDatabase.Local().GetCurrency(currencyCode), amount);
            }
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException or FormatException)
                {
                    return null;
                }
                else
                {
                    Console.WriteLine("Unexpected error during denomination parsing");
                    return null;
                }
            }
        }

        public override string ToString()
        {
            return $"{Amount} {Currency.Code}";
        }
    }
}