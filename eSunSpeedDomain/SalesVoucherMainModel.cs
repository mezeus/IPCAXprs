using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class TransSalesModel
    {
        public long Trans_Sales_Id { get; set; }
        public string VoucherType { get; set; }
        public string Series { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDeleted { get; set; }
        public long BillNo { get; set; }
        public string PriceList { get; set; }
        public string Terms { get; set; }
        public long VoucherNumber { get; set; }
        public string SalesType { get; set; }
        public string Party { get; set; }
        public long LedgerId { get; set; }
        public string MatCentre { get; set; }

        public string Narration { get; set; }
        public decimal TotalQty { get; set; }
        public decimal TotalFree { get; set; }
        public decimal TotalBasicAmount { get; set; }
        public decimal TotalDisAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BSTotalAmount { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<Item_VoucherModel> SalesItem_Voucher { get; set; }
        public List<BillSundry_VoucherModel> SalesBillSundry_Voucher { get; set; }
    }
}
