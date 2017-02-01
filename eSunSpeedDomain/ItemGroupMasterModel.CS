using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class ItemGroupMasterModel
    {
        public int IGM_id { get; set; }
        public string ItemGroup { get; set; }
        public string Alias { get; set; }
        public bool PrimaryGroup { get; set; }
        public string UnderGroup { get; set; }
        public string StockAccount { get; set; }
        public string SalesAccount { get; set; }
        public string PurchaseAccount { get; set; }
        public bool DefaultConfig { get; set; }
        public bool SeparateConfig { get; set; }
        public int Parameters { get; set; }
        public bool SpecifyBillReferencegrp { get; set; }
        public string BillReferencegrp { get; set; }
        public int CrDaysforSale { get; set; }
        public int CrDaysforPurc { get; set; }
        public List<MasterseriesModel> IGMasterSeries { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
