using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class PhysicalStockModel
    {
        public int Phycial_Id { get; set; }
        public int Voucher_Number { get; set; }
        public DateTime PSDate { get; set; }
        public string MatCenter { get; set; }
        public string Narration { get; set; }
        public int SVSeries { get; set; }
        public bool StockJournalVoucher { get; set; }
        public bool InputSubDetails { get; set; }
        public bool ScannBarcode { get; set; }
        public bool UpdateVoucher { get; set; }
        public bool Items { get; set; }
        public bool BCN { get; set; }
        public bool SerialNo { get; set; }
        public bool Batch { get; set; }
       
        public decimal physicalStock { get; set; }
        public decimal BookStock { get; set; }
        public decimal Difference { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<StockItemsModel> StockItemsModel { get; set; }
    }
}
