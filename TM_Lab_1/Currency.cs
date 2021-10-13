
using System;
using System.Globalization;
using System.Xml.Linq;

class Currency
    {
        String name;
        int multiplier;
        String code;
        double exchange_rate_avg;

        public Currency(XElement xml)
        {
            this.name = xml.Element("nazwa_waluty").Value;
            this.multiplier = Int32.Parse(xml.Element("przelicznik").Value);
            this.code = xml.Element("kod_waluty").Value;
            this.exchange_rate_avg = float.Parse(xml.Element("kurs_sredni").Value, new CultureInfo("PL-pl"));
        }


    public string Name { get => name;}
    public int Multiplier { get => multiplier; }
    public string Code { get => code; }
    public double AvgRate { get => exchange_rate_avg;}

    public override string ToString()
    {
        return String.Format("[{0}]: {1}",this.code, this.exchange_rate_avg);
    }
}