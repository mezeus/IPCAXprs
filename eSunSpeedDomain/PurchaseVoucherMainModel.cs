using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class PurchaseVoucherMainModel
    {
        public int PurchaseVoucher_ID { get; set; }
        public string PurchaseVoucher_Series { get; set; }
        public DateTime PurchaseVoucher_Date { get; set; }
        public bool IsDeleted { get; set; }
        public int PurchaseVoucher_Number { get; set; }
        public string PurchaseVoucher_PurchaseType { get; set; }
        public string PurchaseVoucher_Party { get; set; }
        public string PurchaseVoucher_MatCenter { get; set; }

        public List<Item_VoucherModel> PurchaseItem_Voucher { get; set; }
        public List<BillSundry_VoucherModel> BillSundry_Voucher { get; set; }
    }
}
