using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class StockTransferModel
    {
        public int ST_Id { get; set; }

        public string SalesType { get; set; }
        public string Series { get; set; }
        public int Voucher_Number { get; set; }
        public int BillNo { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public DateTime ST_Date { get; set; }                        
        public string Party { get; set; }
        public string MatCenter { get; set; }
        public string Narration { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalQty { get; set; }
        public decimal BSTotalAmount { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<Item_VoucherModel> StockItem_Voucher { get; set; }
        public List<BillSundry_VoucherModel> StockBillSundry_Voucher { get; set; }
    }
}
