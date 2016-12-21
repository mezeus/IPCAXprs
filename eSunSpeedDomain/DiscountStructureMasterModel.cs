using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
 public  class DiscountStructureMasterModel
    { 
        //Discountype RadioButton Group
        public int Ds_id { get; set; }
        public string StructureName { get; set; }
        public bool SimpleDiscount { get; set; }
        public bool CompoundDiscountwithSameNature { get; set; }
        public bool CompoundDiscountDifferentNature { get; set; }
        public int NoOfDiscounts { get; set; }
        public string SpecifyCaptionForDiscount { get; set; }
        //Amount of Discount to be Fed As
        public bool AbsoluteDiscount { get; set; }
        public bool PerMainQty { get; set; }
        public bool Percentage { get; set; }
        public bool PerAltQty { get; set; }
        //Percentage Calculated on Group
        public bool ItemPrice { get; set; }
        public bool ItemMRP { get; set; }
        public bool ItemAmount { get; set; }
        public bool ItemListPrice { get; set; }

        public string CreatedBy { get; set; }

        public List<DSAccountPosting> ListofAccountPosting { get; set; }
        
    }
}
