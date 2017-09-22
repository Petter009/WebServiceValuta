using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ValutaOmregnerWeb
{
    /// <summary>
    /// Summary description for ValutaService
    /// </summary>
    [WebService(Namespace = "http://peterc.pro/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ValutaService : System.Web.Services.WebService
    {
        List<Currency> pricelist;
        public ValutaService()
        {
            pricelist = new List<Currency>();
            Currency USD = new Currency("Amerika", "USD", 524.0200m);
            Currency EUR = new Currency("Europa", "EUR", 745.9900m);
            Currency CAD = new Currency("Canada", "CAD", 492.2700m);
            Currency NOK = new Currency("Norge", "NOK", 90.3400m);
            Currency GBP = new Currency("Storbritannien", "GBP", 947.5300m);
            Currency SEK = new Currency("Sverige", "SEK", 78.2100m);

            pricelist.Add(USD);
            pricelist.Add(EUR);
            pricelist.Add(CAD);
            pricelist.Add(NOK);
            pricelist.Add(GBP);
            pricelist.Add(SEK);
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public decimal exchange_DNK_to_EUR(decimal sum)
        {
            return sum / (745.9900m / 100);
        }

        [WebMethod]
        public decimal exchange_isofrom_to_isoto(string isofrom, string isoto, decimal amount)
        {
            decimal firstrate = find_exchange_rate(isofrom);
            decimal secondrate = find_exchange_rate(isoto);
            return amount / (secondrate / firstrate);
        }

        [WebMethod]
        public List<Currency> GetAllRates()
        {
            return pricelist;
        }

        [WebMethod]
        public decimal find_exchange_rate(string iso_code)
        {
            switch (iso_code.ToUpper())
            {
                case "EUR":
                    Currency EURtmp = pricelist.Find(x => x.ISOcode == "EUR");
                    return EURtmp.ExchangeRate;

                case "USD":
                    Currency USDtmp = pricelist.Find(x => x.ISOcode == "USD");
                    return USDtmp.ExchangeRate;

                case "CAD":
                    Currency CADtmp = pricelist.Find(x => x.ISOcode == "CAD");
                    return CADtmp.ExchangeRate;

                case "NOK":
                    Currency NOKtmp = pricelist.Find(x => x.ISOcode == "NOK");
                    return NOKtmp.ExchangeRate;

                case "GBP":
                    Currency GBPtmp = pricelist.Find(x => x.ISOcode == "GBP");
                    return GBPtmp.ExchangeRate;

                case "SEK":
                    Currency SEKtmp = pricelist.Find(x => x.ISOcode == "SEK");
                    return SEKtmp.ExchangeRate;

                default:
                    return 0;
            };
        }
    }
}
