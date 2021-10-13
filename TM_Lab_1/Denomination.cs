using System;

class Denomination
{

    Currency currency;
    float amount;
    public Denomination(Currency currency, float balance)
    {
        this.currency = currency;
        this.amount = balance;
    }

    public float Amount { get => amount; }
    public Currency Currency { get => currency; }

    public static Denomination Parse(String parse)
    {
        try
        {
            parse = parse.Trim();
            parse = parse.Replace("  ", " ");
            parse = parse.Replace(",", ".");
            parse = parse.ToUpper();
            string[] parts = parse.Split(' ', 2);
            return new Denomination(Database.local.GetCurrency(parts[1]), float.Parse(parts[0]));
        }
        catch (System.IndexOutOfRangeException)
        {
            return null;
        }
    }

    public override string ToString()
    {
        return String.Format("{0} {1}", this.amount, this.currency.Code);
    }
}