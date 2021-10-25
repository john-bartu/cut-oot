using System.Globalization;
using System.Xml.Linq;

namespace TM_Lab_1
{
    internal class Currency
    {
        public Currency(XElement xml)
        {
            Name = xml.Element("nazwa_waluty")?.Value;
            Multiplier = int.Parse(xml.Element("przelicznik")?.Value);
            Code = xml.Element("kod_waluty")?.Value;
            AvgRate = float.Parse(xml.Element("kurs_sredni").Value, new CultureInfo("PL-pl"));
        }

        public Currency(string name, int multiplier, string code, float exchangeRateAvg)
        {
            Name = name;
            Multiplier = multiplier;
            Code = code;
            AvgRate = exchangeRateAvg;
        }

        public string Name { get; }

        public int Multiplier { get; }

        public string Code { get; }

        public float AvgRate { get; }

        public override string ToString()
        {
            return $"[{Code}]: {AvgRate}";
        }
    }
}