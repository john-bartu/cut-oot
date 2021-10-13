namespace TM_Lab_1
{
    internal class Account
    {
        private float _balance;

        public Account()
        {
            _balance = 0;
        }

        public void Deposit(Denomination account)
        {
            _balance += account.Amount / account.Currency.Multiplier * account.Currency.AvgRate;
        }

        public Denomination Balance(Currency currency)
        {
            return new Denomination(currency, _balance * currency.Multiplier / currency.AvgRate);
        }
    }
}