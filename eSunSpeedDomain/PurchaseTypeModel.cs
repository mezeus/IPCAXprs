using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
  public   class PurchaseTypeModel
    {
        public int Purchase_Id { get; set; }
        public string PurchaseType { get; set; }
        //this GroupBox for sales Account Information of RadioButton
        public bool typeSpecifyHereSingleAccount { get; set; }//if select button Ledger CoboBoxWillope
        public string LedgerAccountBox { get; set; }
        public bool typeDifferentTaxRate { get; set; }//Setting Button will come enable thisRadioButton
        public bool typeSpecifyINVoucher { get; set; }

        //TaxationType: RadioButton Group
        public bool typeTaxable { get; set; }//if Enable Tax Calculation RadioButton Group Visible
        public bool typeMultiTax { get; set; }//if Enable:1)TaxInvoice: Y/N 2)Calculate Tax on Item MRP: Y/N 3)Tax Incluse Item Price:Y/N 4) Calculate Tax on: TexBox, 5)Adjust Tax in Sales Account: Y/N 6) Tax Account: Ledger List(cbx)
        public bool typeAgainstSTFrom { get; set; }
        public bool typeTaxpaid { get; set; }
        public bool typeExempt { get; set; }//if Enabble TaxInvoice: Y/N Will Hide
        public bool typeTaxFree { get; set; }
        public bool typeLUMSumDealer { get; set; }
        public bool typeUnRegDealer { get; set; }

        // other Information Group

        public string InputTaxCedit { get; set; }
        public string CapitalPurchase { get; set; }//This is Combobox;
        public string TaxReport { get; set; }
        
        //if Enable MultiTax Will Show on other Information Group
        public bool CalculateTaxonItemMRP { get; set; }
        public bool TaxInclusiveItemPrice { get; set; }
        public decimal CalculateTaxonpercentofAmount { get; set; }
        public bool AdjustTaxinSaleAccount { get; set; }
        public string TaxAccount { get; set; }

        //Tax Calculation
        public bool SingleTaxRate { get; set; }
        public bool MultiTaxRate { get; set; }
        public int TaxInPercentage { get; set; }
        public int TaxInSurcharge { get; set; }
        public string FreezTaxInPurchase { get; set; }
        public string FreezTaxInPurchaseReturn { get; set; }

        //Printing Documents
        public string InvoiceHeading { get; set; }
        public string InvoicDescription { get; set; }

        //Region Radio Button GroupBox

        public bool TypeLocal { get; set; }
        public bool TypeCentral { get; set; }
        
        
        //Type of Transaction on Region GrupBox Sub

        public bool TypeStockTransfer { get; set; }
        public bool TypeOther { get; set;}
        public bool ImportNormal { get; set; }
        
        public bool PurchaseinTransit { get; set; }
        public bool ImportHighsea { get; set; }

        // Form Information:if Enabl typeAgainstSTFromT
        public string IssueSTFrom { get; set; }// if Enable This STFrom List ComboBox will Show
        public string FromIssuable { get; set; }
        public string ReceiveSTForm { get; set; }// if Enable This ReceiveFrom List
        public string FromReceivable { get; set; }
        public string CreatedBy { get; set; }



    }
}
