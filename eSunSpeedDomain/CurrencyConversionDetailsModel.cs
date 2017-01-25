using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class CurrencyConversionDetailsModel
    {
        public int id { get; set; }
        public int ParentId { get; set; }
        public DateTime Date { get; set; }
        public string Currency { get; set; }
        public decimal StandardRate { get; set; }
        public decimal SellingRate { get; set; }
        public decimal BuyingRate { get; set; }
    }
}
