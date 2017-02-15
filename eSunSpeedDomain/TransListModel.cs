using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class TransListModel
    {
        //Model Used For Geting List In Sales Voucher/Purchase Voucher
        public int Stock_Id { get; set; }
        public DateTime StockDate { get; set; }
        public int trans_sales_id { get; set; }
        public long PurcVchId { get; set; }
        public long PurcRetId { get; set; }
        public int MatIssued_id { get; set; }
        public int MatRcvd_id { get; set; }
        public int item_id { get; set; }
        public DateTime saledate { get; set; }
        public DateTime Purcdate { get; set; }
        public DateTime Issued_date { get; set; }
        public DateTime Rcvd_date { get; set; }
        public string series { get; set; }
        public int voucherno { get; set; }
        public string party { get; set; }
        public string item { get; set; }
        public int qty { get; set; }
        public string unit { get; set; }
        public int price { get; set; }
        public decimal amount { get; set; }
        public int totalqty { get; set; }
        public int totalamount { get; set; }
    }
}
