using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TM_Lab_1
{
    internal class CurrencyDatabase
    {
        private readonly Dictionary<string, Currency> _currencyDictionary;

        static CurrencyDatabase()
        {
        }

        private CurrencyDatabase()
        {
            _currencyDictionary = new Dictionary<string, Currency>();
            Update();
        }

        public static CurrencyDatabase Local { get; } = new();

        public void Update()
        {
            Console.WriteLine("[DB] Preparing for database update");
            var newCurrencies = XMLTools.CurrenciesRemoteGet();

            for (var i = 0; i < 3 && newCurrencies.Length == 0; i++)
            {
                Console.WriteLine($"[DB] Preparing for database update, retry: {i}");
                Thread.Sleep(1000);
                newCurrencies = XMLTools.CurrenciesRemoteGet();
            }

            _currencyDictionary["PLN"] = new Currency("Złoty Polski", 1, "PLN", 1.000f);

            foreach (var currency in newCurrencies)
                if (_currencyDictionary.ContainsKey(currency.Code))
                    _currencyDictionary[currency.Code] = currency;
                else
                    _currencyDictionary.Add(currency.Code, currency);

            Console.WriteLine("[DB] Database updated");
        }

        public Currency GetCurrency(string currencyCode)
        {
            if (_currencyDictionary.TryGetValue(currencyCode, out var currency))
                return currency;
            throw new IndexOutOfRangeException("This currency does not exist in database");
        }

        public List<Currency> GetCurrencies()
        {
            return _currencyDictionary.Values.ToList();
        }
    }
}