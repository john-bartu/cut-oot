using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Xml.Linq;

namespace TM_Lab_1
{
    internal class CurrencyDatabase
    {
        private static Dictionary<string, Currency> _currencyDictionary;

        static CurrencyDatabase()
        {
        }

        private CurrencyDatabase()
        {
            _currencyDictionary = new Dictionary<string, Currency>();
            Update();
        }

        private static readonly CurrencyDatabase Instance = new();

        public static CurrencyDatabase Local()
        {
            return Instance;
        }

        public static void Update()
        {
            Console.WriteLine("[DB] Preparing for database update");
            Currency[] newCurrencies = XMLTools.CurrenciesRemoteGet();
            Console.WriteLine(newCurrencies.Length);

            for (int i = 0; i < 3 && newCurrencies.Length == 0; i++)
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