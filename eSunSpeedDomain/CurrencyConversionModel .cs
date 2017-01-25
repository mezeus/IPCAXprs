using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class CurrencyConversionModel
    {
        public int CcID { get; set; }
        public DateTime Date { get; set; }
        public List<CurrencyConversionDetailsModel> CurrenyDetails { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }

    }
}
