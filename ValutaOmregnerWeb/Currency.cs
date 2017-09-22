using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValutaOmregnerWeb
{
    public class Currency
    {
        public string Name { get; set; }

        public string ISOcode { get; set; }

        public decimal ExchangeRate { get; set; }

        public Currency(string name, string isocode, decimal rate)
        {
            this.Name = name;
            this.ISOcode = isocode;
            this.ExchangeRate = rate;
        }
        public Currency()
        { }

        public override string ToString()
        {
            return $"Name: {Name} - ISO: {ISOcode} - Exchange Rate: {ExchangeRate}";
        }
    }
}