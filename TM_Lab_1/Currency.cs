using System.Globalization;
using System.Xml.Linq;

namespace TM_Lab_1
{
    public class Currency
    {
        public Currency(string name, int multiplier, string code, float exchangeRateAvg)
        {
            Name = name;
            Multiplier = multiplier;
            Code = code;
            AvgRate = exchangeRateAvg;
        }

        private string Name { get; }

        public int Multiplier { get; }

        public string Code { get; }

        public float AvgRate { get; }

        public override string ToString()
        {
            return $"[{Code}]: {AvgRate}";
        }
    }
}