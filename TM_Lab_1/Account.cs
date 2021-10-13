using System;

class Account
{

    Currency currency;
    float balance;
    public Account(Currency currency, float balance)
    {
        this.currency = currency;
        this.balance = balance;
    }

    public float Balance { get => balance; }
    public Currency Currency { get => currency; }

    public static Account Parse(String parse)
    {
        try
        {
            parse = parse.Trim();
            parse = parse.Replace("  ", " ");
            parse = parse.Replace(",", ".");
            parse = parse.ToUpper();
            string[] parts = parse.Split(' ', 2);
            return new Account(Database.GetInstance().GetCurrency(parts[1]), float.Parse(parts[0]));
        }
        catch (System.IndexOutOfRangeException)
        {
            return null;
        }
    }

    public override string ToString()
    {
        return String.Format("{0} {1}", this.balance, this.currency.Code);
    }
}