using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class ItemMasterModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string PrintName { get; set; }

        //Group

        public string Group { get; set; }
        public string Unit { get; set; }
        
        public double OpStockQty { get; set; }
        
        public double OpStockValue { get; set; }

        public string AltUnit { get; set; }
        
        public double Confactor { get; set; }
        
        public string ConType { get; set; }
        
        public double AltOpQty { get; set; }

        public bool ApplySalesPrice { get; set; }
        public bool ApplyPurchPrice { get; set; }

        //Item Price Info
        public double SalePrice { get; set; }
        public double Purprice { get; set; }
        public double MRP { get; set; }
        public double MinSalePrice { get; set; }
        public double SelfValuePrice { get; set; }

        //Discount
        
        public double SaleDiscount { get; set; }
        
        public double PurDiscount { get; set; }
        
        public double SaleCompoundDiscount { get; set; }
        
        public double PurCompoundDiscount { get; set; }

        //Settings
        public bool SpecifySaleDiscStructure { get; set; }
        public bool SpecifyPurDiscStructure { get; set; }

        public string SaleMarkup { get; set; }
        public string PurMarkup { get; set; }
        public string SaleCompMarkup { get; set; }
        public string PurCompMarkup { get; set; }

        public bool SpecifySaleMarkupStruct { get; set; }
        public bool SpecifyPurMarkupStruct { get; set; }

        //Tax Details
        public string TaxCategory { get; set; }
        public string TaxType { get; set; }

        
        public double ServiceTaxRate { get; set; }
        
        public double RateofTax_Local { get; set; }
        
        public double RateofTax_Central { get; set; }
        public bool TaxonMRP { get; set; }
        public string HSNCode { get; set; }
        
        //Item Description
        public string ItemDescription1 { get; set; }
        public string ItemDescription2 { get; set; }
        public string ItemDescription3 { get; set; }
        public string ItemDescription4 { get; set; }
        public string ItemDescription5 { get; set; }
        public string ItemDescription6 { get; set; }

        public bool SetCriticalLevel { get; set; }
        public bool MaintainRG23D { get; set; }
        public string TariffHeading { get; set; }
        public bool SerialNumberwiseDetails { get; set; }
        public bool MRPWiseDetails { get; set; }
        public bool ParameterizedDetails { get; set; }
        public bool BatchwiseDetails { get; set; }
        public bool ExpDateRequired { get; set; }
        public int ExpiryDays { get; set; }

        public string SalesAccount { get; set; }
        public string PurcAccount { get; set; }


        public bool SpecifyDefaultMC { get; set; }
        public bool FreezeMCforItem { get; set; }

        public int TotalNumberofAuthors { get; set; }
        public bool DontMaintainStockBal { get; set; }
        public bool PickItemSizefromDescription { get; set; }
        public bool SpecifyDefaultVendor { get; set; }

        //Audit 
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        //public ItemMasterModel()
        //{
        //    foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(this))
        //    {
        //        DefaultValueAttribute myAttribute = (DefaultValueAttribute)property.Attributes[typeof(DefaultValueAttribute)];

        //        if (myAttribute != null)
        //        {
        //            property.SetValue(this, myAttribute.Value);
        //        }
        //    }
        //}

    }
}
