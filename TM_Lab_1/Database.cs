using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

class Database
{
    static String URLString = "https://www.nbp.pl/kursy/xml/lasta.xml";
    static Dictionary<String, Currency> currency_dictionary = new Dictionary<string, Currency>();
    static readonly Database _DatabaseSingletonInstance = new Database();

    private Database()
    {
        Update();
    }

    public void Update()
    {
        using (WebClient client = new WebClient())
        {
            String contentString = client.DownloadString(URLString);
            var documment = XDocument.Parse(contentString);
            var currences = documment.Root
                 .Elements("pozycja")
                 .Select(x => new Currency(x))
                 .ToArray();


            foreach (var currency in currences)
            {
                if (currency_dictionary.ContainsKey(currency.Code))
                {
                    currency_dictionary[currency.Code] = currency;
                }
                else
                {
                    currency_dictionary.Add(currency.Code, currency);
                }
            }
        }


    }

    public Currency GetCurrency(string currency_code)
    {
        Currency currency;
        if (currency_dictionary.TryGetValue(currency_code, out currency))
        {
            return currency;
        }
        else
        {
            throw new Exception("This currency does not exist in database");
        }
    }

    public List<Currency> GetCurrencies()
    {
        return currency_dictionary.Values.ToList<Currency>();
    }

    public static Database GetInstance() => _DatabaseSingletonInstance;
}