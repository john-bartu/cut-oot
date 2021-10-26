namespace TM_Lab_1
{
    internal class Account
    {
        private Denomination _balance;

        public Account()
        {
            _balance = new Denomination(CurrencyDatabase.Local().GetCurrency("PLN"), 0);
        }

        public void Deposit(Denomination account)
        {
            _balance = new Denomination(_balance.Currency,
                _balance.Amount + account.convert_to(_balance.Currency).Amount);
        }

        public void Convert(Currency currency)
        {
            _balance = _balance.convert_to(currency);
        }

        public Denomination Balance()
        {
            return _balance;
        }
    }
}