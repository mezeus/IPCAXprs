using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
 public class BillSundryMasterModel
    {
        public int BS_Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string PrintName { get; set; }
        public string BillSundryType { get; set; }
        public string BillSundryNature { get; set; }
        public decimal DefaultValue { get; set; }
        public string subtotalheading { get; set; }
        public bool AffectstheCostofGoodsinSale { get; set; }
        public bool AffectstheCostofGoodsinPurchase { get; set; }
        public bool AffectstheCostofGoodsinMaterialIssue { get; set; }
        public bool AffectstheCostofGoodsinMaterialReceipt { get; set; }
        public bool AffectstheCostofGoodsinStockTransfer { get; set; }
        public bool AffectsAccounting { get; set; }
        public string AccounttoHeadPost { get; set; }
        public bool AdjustInSaleAmount { get; set; }
        public bool AdjustInPartyAmount { get; set; }
        public string PostOverandAbove { get; set; }
        public bool AdjustInPurchaseAmount { get; set; }
        //This code RadioButtotick of any one in three
        public  bool typeMaterialIssue { get; set; }
        public string typeMaterialReceipt { get; set; }
        public string StockTransfer { get; set; }

        public bool AffectAccounting { get; set; }
        public string OtherSide { get; set; }
        public string Accountheadtopost { get; set; }
        public string Adjustinparty { get; set; }
        public bool postoverandabove { get; set; }
        public string AdjustinMC { get; set; }
        public string typeAbsoluteAmount { get; set; }
        public string typePercentage { get; set; }
        public string typePerMainQty { get; set; }
        public string PerAltQty { get; set; }

        public string Percentoff { get; set; }

        public string typeNetBillAmount { get; set; } 
        public bool SelectiveCalculation { get; set; }
        public string tyeItemsBasicAmt { get; set; }
        public string typeTotalMRPofItems { get; set; }
        public string typeTaxableAmount { get; set; }
        public string typePreviousBillSundryAmount { get; set; }
        public string typeOtherBillsundry { get; set; }
        public string roundoffBillsundry { get; set; }
        //This singel GroupBox
        public bool RBSAmt { get; set; }
        //Billsundry to be Calculated on Group
        public string BSAmt { get; set; }
        public string BSAppOn { get; set; }
        // if Enable Other Bill Sundry This Textboxwill open 
        public string TextBox { get; set; }
        //Groupbox of Bill Sundry(s) Details
        public string NoOfBillSundry { get; set; }
        public bool ConsolidateBillSundriesAmount { get; set; }
        public string ModifiedBy { get; set; }

    }
}
 