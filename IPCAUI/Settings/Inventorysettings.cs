using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;

namespace IPCAUI.Settings
{
    public partial class Inventorysettings : Form
    {
        InventorySettingsBL objInvBl = new InventorySettingsBL();
        public Inventorysettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InventorySettingsModel objmodel = new InventorySettingsModel();
            objmodel.qtydecimalplaces =Convert.ToInt32(tbxDecimalpla.Text.Trim());
            objmodel.ItemwiseDecPlaces = Convert.ToInt32(tbxItemwiseDp.Text.Trim());
            objmodel.AlternateUnitsofItems = chkUnititems.Checked == true ? true : false;
            objmodel.EnableMultiGodownInventory = chkEnablemultiGowon.Checked == true ? true : false;
            objmodel.EnableManufacturingFeatures = chkMultifeature.Checked == true ? true : false;
            objmodel.EnableSalesQuotation = chkEnableSalesquation.Checked == true ? true : false;
            objmodel.EnablePurchaseQuotation = chkEnablePurQuation.Checked == true ? true : false;
            objmodel.EnableOrderProcessing = chkEnableOrderProc.Checked == true ? true : false;
            objmodel.EnableSalePurchaseChallan = chkBudgets.Checked == true ? true : false;
            objmodel.CarryMaterialIssuedReceiptNextFY = chkCarrymaterialIssued.Checked == true ? true : false;
            objmodel.ItenSizingInformationfromItemDescp = chkPickItemSizeingInformation.Checked == true ? true : false;
            objmodel.StockUpdationdateinDualVouchers = chkSeparateStockUpdationDual.Checked == true ? true : false;
            objmodel.StockValuatioriforItems = chkSeparatestockvalation.Checked == true ? true : false;
            objmodel.AccountingPureInventory = chkAccountinginPureInventory.Checked == true ? true : false;
            objmodel.PartyWiseItemcode = chkEnablePartywiseItems.Checked == true ? true : false;
            objmodel.AllowSalesReturninsalesVoucher = chkAllowsalesreturnSalesvoucher.Checked == true ? true : false;
            objmodel.AllowPurchaseReturninPurchase = chkAllowPurchaseReturninpv.Checked == true ? true : false;
            objmodel.ValidateSalesReturnWithOrginal = chkValidatesaleswithos.Checked == true ? true : false;
            objmodel.ValidatePurcReturnWithOrginal = chkValidatePurcwithOp.Checked = true ? true : false;
            objmodel.BillSundryNarration = chkEnableBillsudarynarration.Checked == true ? true : false;
            objmodel.InvoiceBarcode = chkInvoicebarcodePrinting.Checked == true ? true : false;
            objmodel.ItemwiseDiscountType = cbxItemwisetype.SelectedItem.ToString();

            objmodel.StockValMethod = cbxStockvalmethod.SelectedItem.ToString();
            objmodel.TagSalePurcAcc = cbxSalePurcAcc.SelectedItem.ToString();
            objmodel.TagStockAccWith = cbxStockvalmethod.SelectedItem.ToString();

            objmodel.Scheme = chkEnableScheme.Checked == true ? true : false;
            objmodel.JobWork = chkEnablejobwork.Checked == true ? true : false;
            objmodel.ParameterizedDetails = chkParmeterrized.Checked == true ? true : false;
            objmodel.BatchWiseDetails = chkBatchwise.Checked == true ? true : false;
            objmodel.SerialnowiseDetails = chkSerialnoWise.Checked == true ? true : false;
            objmodel.MRPwiseDetails = chkMrpWise.Checked == true ? true : false;
            objmodel.ItemDefaultPrisceDuringvchModifi = chkItemdefaultPrise.Checked == true ? true : false;
            objmodel.FreeQuantityinVouchers = chkEnablefreeQuantity.Checked == true ? true : false;
            objmodel.LastTransactionSales = chkTransationduringsales.Checked == true ? true : false;
            objmodel.LastTransactionPurchase = chkTransDuringPurchase.Checked == true ? true : false;
            objmodel.AdditionalExpensesVchwise = chkAllowExpensesVoucherwise.Checked=true ? true : false;
            objmodel.ExpensePurctoItems = chkAllowExpensetoItems.Checked = true ? true : false;
            objmodel.ImagesNoteswithMaster = chkMaintainimage.Checked = true ? true : false;
            objmodel.ItemsCurrentBalVchEntry = chkShowItemscurrentBalance.Checked = true ? true : false;
            objmodel.DrugLicence = chkMaintaindurgLice.Checked = true ? true : false;
            objmodel.DatewiseItemPricing = chkEnableDatewiseItemPricing.Checked = true ? true : false;
            objmodel.CalItemSalePricePurchasePrice = chkCalculateItemsale.Checked = true ? true : false;
            objmodel.UpdatePricesItemMaster = chkUpdatePrices.Checked = true ? true : false;
            objmodel.PackingDetailsinVouchers = chkEnablepackingDetails.Checked = true ? true : false;
            objmodel.DonotMaintainStockBala = cbxDontMaintainStockBalance.SelectedItem.ToString();
            objmodel.ItemwiseMarkupType = cbxItemwisemarkup.SelectedItem.ToString();

            bool isscusses = objInvBl.SaveInventorySetting(objmodel);
            if (isscusses)
            {
                MessageBox.Show("Saved Scussfully");
            }
        }
    }
}
