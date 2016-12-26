using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using System.Data;

namespace eSunSpeed.BusinessLogic
{
    public class InventorySettingsBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region Save Inventory Settings
        /// <summary>
        /// </summary>
        /// <param name="objAccountGrp"></param>
        /// <returns>True/False</returns>
        public bool SaveInventorySetting(InventorySettingsModel objInventory)
        {
            string Query = string.Empty;           

            DBParameterCollection paramCollection = new DBParameterCollection();
            
            paramCollection.Add(new DBParameter("@DecemalPlaces", objInventory.qtydecimalplaces));
            paramCollection.Add(new DBParameter("@IwDecPlaces", objInventory.ItemwiseDecPlaces));
            paramCollection.Add(new DBParameter("@altunits", objInventory.AlternateUnitsofItems, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@multigodown", objInventory.EnableMultiGodownInventory, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@manufacturing", objInventory.EnableManufacturingFeatures, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@salequotation", objInventory.EnableSalesQuotation, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@Purchasequotation", objInventory.EnablePurchaseQuotation, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@orderprocessing", objInventory.EnableOrderProcessing, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@salesbypurchasechall", objInventory.EnableSalePurchaseChallan, System.Data.DbType.Boolean));

            paramCollection.Add(new DBParameter("@carrypendingmat", objInventory.CarryMaterialIssuedReceiptNextFY, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@pickitemWSizing", objInventory.ItenSizingInformationfromItemDescp, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@separatestockUpdation", objInventory.StockUpdationdateinDualVouchers, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@separatestockvalidation",objInventory.StockValuatioriforItems, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@Accountinginpure", objInventory.AccountingPureInventory, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@enablepartwise", objInventory.PartyWiseItemcode, System.Data.DbType.Boolean));

            paramCollection.Add(new DBParameter("@allowsalesreturn", objInventory.AllowSalesReturninsalesVoucher, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@allowpurchasereturn", objInventory.AllowPurchaseReturninPurchase, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@validatesalesreturn", objInventory.ValidateSalesReturnWithOrginal, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@validatepurchasereturn", objInventory.ValidatePurcReturnWithOrginal, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@enablebillsundary", objInventory.BillSundryNarration, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@invoicebarcode", objInventory.InvoiceBarcode, System.Data.DbType.Boolean));

            paramCollection.Add(new DBParameter("@itemwisediscount", objInventory.ItemwiseDiscountType));
            paramCollection.Add(new DBParameter("@stockvalmethod", objInventory.StockValMethod));
            paramCollection.Add(new DBParameter("@tagsalacc", objInventory.TagSalePurcAcc));
            paramCollection.Add(new DBParameter("@tagstockacc", objInventory.TagStockAccWith));
            paramCollection.Add(new DBParameter("@enablescheme", objInventory.Scheme, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@enablejobwork", objInventory.JobWork, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@parameterizeddetail", objInventory.ParameterizedDetails, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@batchwisedetails", objInventory.BatchWiseDetails, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@serialnowise", objInventory.SerialnowiseDetails, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@mrpwise", objInventory.MRPwiseDetails, System.Data.DbType.Boolean));

            paramCollection.Add(new DBParameter("@skipitems", objInventory.ItemDefaultPrisceDuringvchModifi, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@enablefreequantity", objInventory.FreeQuantityinVouchers, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@SLTSales", objInventory.LastTransactionSales, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@SLTPurchase", objInventory.LastTransactionSales, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@AAEvoucher", objInventory.AdditionalExpensesVchwise, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@AEPurchase", objInventory.ExpensePurctoItems, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@Matainimages", objInventory.ImagesNoteswithMaster, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@Showitemcurrentblancevoucher", objInventory.ItemsCurrentBalVchEntry, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@DurgLicence", objInventory.DrugLicence, System.Data.DbType.Boolean));
            
            paramCollection.Add(new DBParameter("@calItemsaleprcfrompurcprc", objInventory.CalItemSalePricePurchasePrice, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@updatepriceinit", objInventory.UpdatePricesItemMaster, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@enablepackingdetails", objInventory.PackingDetailsinVouchers, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@donotmaintainstockbal", objInventory.DonotMaintainStockBala));
            paramCollection.Add(new DBParameter("@itemwisemarkuptype", objInventory.ItemwiseMarkupType));
            paramCollection.Add(new DBParameter("@datewiseItemprising", objInventory.DatewiseItemPricing, System.Data.DbType.Boolean));
            //paramCollection.Add(new DBParameter("@companyact", objInventory.CreatedBy));


            Query = "INSERT INTO inventorysettings (`qtydecimalplaces`,`ItemwiseDecPlaces`,`AlternateUnitsofItems`,`MultiGodownInventory`,`ManufacturingFeatures`,`SalesQuotation`," +
                "`PurchaseQuotation`,`OrderProcessing`,`SalePurchaseChallan`,`MaterialIssuedReceiptNextFY`,`ItenSizingInformationfromItemDescp`," +
                "`StockUpdationdateinDualVouchers`,`StockValuatioriforItems`,`AccountingPureInventory`,`PartyWiseItemcode`,`SalesReturninsalesVoucher`,`PurchaseReturninPurchase`," +
                "`ValidateSalesReturnWithOrginal`,`ValidatePurcReturnWithOrginal`,`BillSundryNarration`,`InvoiceBarcode`,`ItemwiseDiscountType`,`StockValMethod`,`TagSalePurcAcc`," +
                "`TagStockAccWith`,`Scheme`,`JobWork`,`ParameterizedDetails`,`BatchWiseDetails`,`Serialno.wiseDetails`,`MRPwiseDetails`,`ItemDefaultPrisceDuringvchModifi`," +
                "`FreeQuantityinVouchers`,`LastTransactionSales`,`LastTransactionPurchase`,`AdditionalExpensesVchwise`,`ExpensePurctoItems`,`ImagesNoteswithMaster`,`ItemsCurrentBalVchEntry`,`DrugLicence`,`CalItemSalePricePurchasePrice`,`UpdatePricesItemMaster`,`PackingDetailsinVouchers`,`DonotMaintainStockBala`,`ItemwiseMarkupType`,`DatewiseItemPricing`)" +
                "VALUES (@DecemalPlaces,@IwDecPlaces,@altunits,@multigodown,@manufacturing,@salequotation,@Purchasequotation,@orderprocessing,@salesbypurchasechall," +
                "@carrypendingmat,@pickitemWSizing,@separatestockUpdation,@separatestockvalidation,@Accountinginpure,@enablepartwise,@allowsalesreturn,@allowpurchasereturn," +
                "@validatesalesreturn,@validatepurchasereturn,@enablebillsundary,@invoicebarcode,@itemwisediscount,@stockvalmethod,@tagsalacc,@tagstockacc,@enablescheme,@enablejobwork,@parameterizeddetail,@batchwisedetails,@serialnowise,@mrpwise," +
                "@skipitems,@enablefreequantity,@SLTSales,@SLTPurchase,@AAEvoucher,@AEPurchase,@Matainimages,@Showitemcurrentblancevoucher,@DurgLicence,@calItemsaleprcfrompurcprc,@updatepriceinit,@enablepackingdetails,@donotmaintainstockbal,@itemwisemarkuptype,@datewiseItemprising)";
                //"@decimalplac,@maitainsubled,@postingaccounts,@doubleentery,@showaccountbal,@maintainimages,@balancesheet,@ledgerrecon,@chekprinting,@interestrate,@enableparty,@showparydashbord)";

            return _dbHelper.ExecuteNonQuery(Query,paramCollection) > 0;                  
        }
        #endregion   
      
    }

}
