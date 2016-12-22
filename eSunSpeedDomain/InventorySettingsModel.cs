using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class InventorySettingsModel
    {
        public int inventoryid { get; set; }
        public int qtydecimalplaces { get; set; }
        public int ItemwiseDecPlaces { get; set; }
        public bool AlternateUnitsofItems { get; set; }
        public bool EnableMultiGodownInventory { get; set; }
        public bool EnableManufacturingFeatures { get; set; }
        public bool EnableSalesQuotation { get; set; }
        public bool EnablePurchaseQuotation { get; set; }
        public bool EnableOrderProcessing { get; set; }
        public bool EnableSalePurchaseChallan { get; set; }
        public bool CarryMaterialIssuedReceiptNextFY { get; set; }
        public bool ItenSizingInformationfromItemDescp { get; set; }
        public bool StockUpdationdateinDualVouchers { get; set; }
        public bool StockValuatioriforItems { get; set; }
        public bool AccountingPureInventory { get; set; }
        public bool PartyWiseItemcode { get; set; }

        public bool AllowSalesReturninsalesVoucher { get; set; }
        public bool AllowPurchaseReturninPurchase { get; set; }

        public bool ValidateSalesReturnWithOrginal { get; set; }
        public bool ValidatePurcReturnWithOrginal { get; set; }
        public bool BillSundryNarration { get; set; }
        public bool InvoiceBarcode { get; set; }
        public string ItemwiseDiscountType { get; set; }
        public string StockValMethod { get; set; }
        public string TagSalePurcAcc { get; set; }
        public string TagStockAccWith { get; set; }

        public bool Scheme { get; set; }
        public bool JobWork { get; set; }
        public bool ParameterizedDetails { get; set; }
        public bool BatchWiseDetails { get; set; }
        public bool SerialnowiseDetails { get; set; }
        public bool MRPwiseDetails { get; set; }
        public bool ItemDefaultPrisceDuringvchModifi { get; set; }
        public bool FreeQuantityinVouchers { get; set; }
        public bool LastTransactionSales { get; set; }
        public bool LastTransactionPurchase { get; set; }
        public bool AdditionalExpensesVchwise { get; set; }
        public bool ExpensePurctoItems { get; set; }
        public bool ImagesNoteswithMaster { get; set; }
        public bool ItemsCurrentBalVchEntry { get; set; }
        public bool DrugLicence { get; set; }
        public bool CalItemSalePricePurchasePrice { get; set; }
        public bool PackingDetailsinVouchers { get; set; }
        public bool UpdatePricesItemMaster { get; set; }
        public string DonotMaintainStockBala { get; set; }
        public string ItemwiseMarkupType { get; set; }
        public bool DatewiseItemPricing { get; set; }

    }
}
