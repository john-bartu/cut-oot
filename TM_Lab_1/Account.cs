class Account
{
    float balance;
    public Account()
    {
        balance = 0;
    }
    public void Deposit(Denomination account)
    {
        balance += account.Amount / account.Currency.Multiplier * account.Currency.AvgRate;
    }

    public Denomination Balance(Currency currency)
    {
        return new Denomination(currency, balance * currency.Multiplier / currency.AvgRate);
    }
}