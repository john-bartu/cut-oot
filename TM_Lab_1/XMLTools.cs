using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace TM_Lab_1
{
    public class XMLTools
    {
        private static readonly string URLString = "https://www.nbp.pl/kursy/xml/lasta.xml";

        public static Currency CurrencyFromXML(XContainer xml)
        {
            try
            {
                return new Currency(
                    xml.Element("nazwa_waluty").Value,
                    int.Parse(xml.Element("przelicznik").Value),
                    xml.Element("kod_waluty").Value,
                    float.Parse(xml.Element("kurs_sredni").Value, new CultureInfo("PL-pl"))
                );
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                throw new ArgumentException("XML data contains unexpected data");
            }
        }

        public static Currency[] CurrenciesRemoteGet()
        {
            using var client = new WebClient();
            try
            {
                Console.WriteLine("[DB] Downloading XML data");
                var contentString = client.DownloadString(URLString);

                Console.WriteLine("[DB] XML data downloaded");
                var documents = XDocument.Parse(contentString);
                var currencies = documents.Root?
                    // ReSharper disable once StringLiteralTypo
                    .Elements("pozycja")
                    .Select(CurrencyFromXML)
                    .ToArray();

                return currencies;
            }
            catch (WebException)
            {
                Console.WriteLine("[DB] Server not responding, retrying...");
                return Array.Empty<Currency>();
            }
        }
    }
}