class Bank
{
    float balance;
    public Bank()
    {
        balance = 0;
    }
    public void Deposit(Account account)
    {
        balance += account.Balance / account.Currency.Multiplier * account.Currency.AvgRate;
    }

    public Account Balance(Currency currency)
    {
        return new Account(currency, balance * currency.Multiplier / currency.AvgRate);
    }
}