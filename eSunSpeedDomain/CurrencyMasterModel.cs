using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class CurrencyMasterModel
    {
        public int CM_ID { get; set; }
        public string Symbol { get; set; }
        public string CString { get; set; }
        public string SubString { get; set; }
        public string ConvertionMode { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }

    }
}
