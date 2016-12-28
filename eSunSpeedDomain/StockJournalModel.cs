using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class StockJournalModel
    {
        public int SJ_Id { get; set; }
        public string Series { get; set; }
        public int Voucher_Number { get; set; }
        public DateTime SJ_Date { get; set; }
        //public string BOM_Name { get; set; }
        public string MatCenterIG { get; set; }
        public string MatCenterIC { get; set; }
        public string Narration { get; set; }
        public decimal TotalQtyIG { get; set; }
        public decimal TotalAmountIG { get; set; }
        public decimal BSTotalAmount { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<Item_VoucherModel> Item_Generated { get; set; }
        public List<ItemConsumedModel> Item_Consumed { get; set; }
    }
}
