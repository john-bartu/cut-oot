namespace TM_Lab_1
{
    internal class Account
    {
        private Denomination _balance;

        public Account()
        {
            _balance = new Denomination(CurrencyDatabase.Local().GetCurrency("PLN"), 0);
        }

        public void Deposit(Denomination denomination)
        {
            _balance = new Denomination(_balance.Currency,
                _balance.Amount + denomination.ExchangeTo(_balance.Currency).Amount);
        }

        public void ExchangeTo(Currency currency)
        {
            _balance = _balance.ExchangeTo(currency);
        }

        public Denomination Balance()
        {
            return _balance;
        }
    }
}