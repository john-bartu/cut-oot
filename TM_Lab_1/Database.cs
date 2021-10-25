using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
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
        }

        public static Database Local { get; } = new();

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