using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace TM_Lab_1
{
    internal class Database
    {
        private static readonly Dictionary<string, Currency> CurrencyDictionary = new();

        static Database()
        {
        }

        private Database()
        {
            Update();
        }

        public static Database Local { get; } = new();

        public void Update()
        {
            Currency[] newCurrencies = XMLTools.CurrenciesRemoteGet();

            CurrencyDictionary["PLN"] = new Currency("Złoty Polski", 1, "PLN", 1.000f);

            foreach (var currency in newCurrencies)
                if (CurrencyDictionary.ContainsKey(currency.Code))
                    CurrencyDictionary[currency.Code] = currency;
                else
                    CurrencyDictionary.Add(currency.Code, currency);

            Console.WriteLine("[DB] Database updated");
        }

        public Currency GetCurrency(string currencyCode)
        {
            if (CurrencyDictionary.TryGetValue(currencyCode, out var currency))
                return currency;
            throw new IndexOutOfRangeException("This currency does not exist in database");
        }

        public List<Currency> GetCurrencies()
        {
            return CurrencyDictionary.Values.ToList();
        }
    }
}