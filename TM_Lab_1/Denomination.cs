using System;

namespace TM_Lab_1
{
    internal class Denomination
    {
        public Denomination(Currency currency, float balance)
        {
            Currency = currency;
            Amount = balance;
        }

        public float Amount { get; }

        public Currency Currency { get; }

        public static Denomination Parse(string parse)
        {
            try
            {
                parse = parse.Trim();
                parse = parse.Replace("  ", " ");
                parse = parse.Replace(",", ".");
                parse = parse.ToUpper();
                var parts = parse.Split(' ', 2);
                return new Denomination(Database.Local.GetCurrency(parts[1]), float.Parse(parts[0]));
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        public override string ToString()
        {
            return $"{Amount} {Currency.Code}";
        }
    }
}