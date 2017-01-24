using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class ItemCompanyMasterModel
    {
        public int ICM_id { get; set; }
        public string ItemCompany { get; set; }
        public string StockAccount { get; set; }
        public string SalesAccount { get; set; }
        public string PurchaseAccount { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
