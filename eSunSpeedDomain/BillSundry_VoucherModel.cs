using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class BillSundry_VoucherModel
    {
        
        public long BSId { get; set; }
        public long ParentId { get; set; } //This should be the parent Id of transaction screen
                                          //Sales, Sales return, purchase, purchase return etc

        public string BillSundry { get; set; }
        public string Narration { get; set; }
        public string Type { get; set; }
        public decimal Percentage { get; set; }
        public string Extra { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }

        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
