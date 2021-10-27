using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace TM_Lab_1
{
    public static class XmlTools
    {
        private const string UrlString = "https://www.nbp.pl/kursy/xml/lasta.xml";

        private static Currency CurrencyFromXml(XContainer xml)
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
                // throw new ArgumentException("XML data contains unexpected data");
                return null;
            }
        }

        public static Currency[] CurrenciesRemoteGet()
        {
            using var client = new WebClient();
            try
            {
                Console.WriteLine("[DB] Downloading XML data");
                var contentString = client.DownloadString(UrlString);

                Console.WriteLine("[DB] XML data downloaded");
                var documents = XDocument.Parse(contentString);
                var currencies = documents.Root?
                    // ReSharper disable once StringLiteralTypo
                    .Elements("pozycja")
                    .Select(CurrencyFromXml)
                    .ToArray();

                return currencies;
            }
            catch (WebException)
            {
                Console.WriteLine("[DB] HTTPs server not responding");
                return Array.Empty<Currency>();
            }
        }
    }
}