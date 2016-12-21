using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class TransSalesModel
    {
        public int Trans_Sales_Id { get; set; }
        public string Series { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDeleted { get; set; }
        public int BillNo { get; set; }
        public int VoucherNumber { get; set; }
        public string SalesType { get; set; }
        public string Party { get; set; }
        public string MatCentre { get; set; }

        public string Narration { get; set; }
        public decimal TotalQty { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BSTotalAmount { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<Item_VoucherModel> SalesItem_Voucher { get; set; }
        public List<BillSundry_VoucherModel> SalesBillSundry_Voucher { get; set; }
    }
}
