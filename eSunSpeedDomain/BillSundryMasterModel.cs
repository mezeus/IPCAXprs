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

        //Accounting In Sale
        public bool SaleAffectsAccounting { get; set; }
        public bool SaleAdjustInSaleAmount { get; set; }
        public string SaleAccounttoHeadPost { get; set; }
        public bool SaleAdjustInPartyAmount { get; set; }
        public string SaleAccounttoHeadPostParty { get; set; }
        public string SalePostOverandAbove { get; set; }

        //Accounting In Purchase
        public bool PurcAffectsAccounting { get; set; }
        public bool PurcAdjustInPurcAmount { get; set; }
        public string PurcAccounttoHeadPost { get; set; }
        public bool PurcAdjustInPartyAmount { get; set; }
        public string PurcAccounttoHeadPostParty { get; set; }
        public string PurcPostOverandAbove { get; set; }

        //This code RadioButtotick of any one in three
        public  bool typeMaterialIssue { get; set; }
        public bool typeMaterialReceipt { get; set; }
        public bool StockTransfer { get; set; }

        public bool AffectAccounting { get; set; }
        public string OtherSide { get; set; }
        public string AdjustinMC { get; set; }
        public string Accountheadtopost { get; set; }
        public string AccountheadtopostParty { get; set; }
        public bool postoverandabove { get; set; }
        
        //Account of Bill Sundary
        public bool typeAbsoluteAmount { get; set; }
        public bool typePercentage { get; set; }
        public bool typePerMainQty { get; set; }
        public bool PerAltQty { get; set; }

        public decimal Percentoff { get; set; }

        public bool typeNetBillAmount { get; set; } 
        public bool SelectiveCalculation { get; set; }
        public bool tyeItemsBasicAmt { get; set; }
        public bool typeTotalMRPofItems { get; set; }
        public bool typeTaxableAmount { get; set; }
        public bool typePreviousBillSundryAmount { get; set; }
        public bool typeOtherBillsundry { get; set; }
        public bool IncludeFreeQty { get; set; }
        //Groupbox of Bill Sundry(s) Details
        public int NoOfBillSundry { get; set; }
        public bool ConsolidateBillSundriesAmount { get; set; }

        public bool roundoffBillsundry { get; set; }
        //This singel GroupBox
        public bool RBSAmt { get; set; }

        //Billsundry to be Calculated on Group
        public bool BSAmt { get; set; }
        public bool BSAppOn { get; set; }
        // if Enable Other Bill Sundry This Textboxwill open 
        public string TextBox { get; set; }
      
        public string ModifiedBy { get; set; }

    }
}
 