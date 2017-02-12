using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;
using IPCAUI.Models;

namespace IPCAUI.Transactions
{
    public partial class SalesVoucher : Form
    {
        DataTable dtItem = new DataTable();
        DataTable dtbs = new DataTable();
        DataTable dtParty = new DataTable();
        DataTable dtParticulars = new DataTable();
        DataTable dtItems = new DataTable();
        SalesVoucherBL objSVBL = new SalesVoucherBL();
        AccountMasterBL objAccBL = new AccountMasterBL();
        MaterialCentreMasterBL objMcBL = new MaterialCentreMasterBL();
        LedgerPostingBL objLPBL = new LedgerPostingBL();
        ItemMasterBL objIMBL = new ItemMasterBL();
        SaleTypeBL objStBL = new SaleTypeBL();
        BillSundryMaster objBSBL = new BillSundryMaster();
        RepositoryItemLookUpEdit UnitsLookup = new RepositoryItemLookUpEdit();
        public static long SalesId = 0;
        public static string Mode ="";
        public static string FormName = "";
        public SalesVoucher()
        {
            InitializeComponent();
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Settings.AccountsDemo frm = new Settings.AccountsDemo();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
            //Settings.Accountsettings frm = new Settings.Accountsettings();
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.ShowDialog(this);           
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            if(keyData==Keys.F3)
            {
                if(tbxParty.ContainsFocus)
                {
                    FormName = "IPCAUI.Administration.Account";
                    
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SalesVoucher_Load(object sender, EventArgs e)
        {
            LoadTables();
            ItemMode();
            cbxTerms.Focus();
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            
            //tbxParty.Properties.BestFitMode= DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            List<MaterialCentreMasterModel> lstMt = objMcBL.GetAllMaterials();
            List<string> lstMcenters = new List<string>();
            foreach(MaterialCentreMasterModel objMC in lstMt)
            {
                lstMcenters.Add(objMC.GroupName);
            }
            tbxMatcenter.Properties.DataSource = lstMcenters;
            List<SaleTypeModel> lstSalestypes = objStBL.GetAllSaleType();
            List<string> lstSales = new List<string>();
            foreach(SaleTypeModel objSale in lstSalestypes)
            {
                lstSales.Add(objSale.SalesType);
            }
            tbxSaleType.Properties.DataSource = lstSales;
            LoadGridColumns();
            tbxVoucherType.Properties.DataSource = new string[] { "Main" };
            
        }
        private void LoadGridColumns()
        {
            //Show Items Detais in Grid
            RepositoryItemLookUpEdit ItemsLookup = new RepositoryItemLookUpEdit();
            dtItems.Rows.Clear();
            DataRow drItems;
            List<ItemMasterModel> lstItems = objIMBL.GetAllItems();
            foreach (ItemMasterModel objItems in lstItems)
            {
                drItems = dtItems.NewRow();
                drItems["Item"] = objItems.Name;
                drItems["GroupName"] = objItems.Group;
                drItems["Company"] = objItems.Company;
                dtItems.Rows.Add(drItems);
            }
            ItemsLookup.DataSource = dtItems;
            ItemsLookup.ValueMember = "Item";
            ItemsLookup.DisplayMember = "Item";
            //ItemsLookup.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            ItemsLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            ItemsLookup.AutoSearchColumnIndex = 1;
            dvgItemDetails.Columns["Item"].ColumnEdit = ItemsLookup;
            dvgItemDetails.BestFitColumns();
            RepositoryItemLookUpEdit BSLookup = new RepositoryItemLookUpEdit();
            List<BillSundryMasterModel> lstBillSundary = objBSBL.GetAllBillSundry();
            List<string> lstbs = new List<string>();
            foreach(BillSundryMasterModel objBS in lstBillSundary)
            {
                lstbs.Add(objBS.Name);
            }
            BSLookup.DataSource = lstbs;
            BSLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            BSLookup.AutoSearchColumnIndex = 1;
            //BSLookup.ValueMember = "BillSundary";
            //BSLookup.DisplayMember = "BillSundary";
            dvgBsDetails.Columns["BillSundry"].ColumnEdit =BSLookup; 
            dvgBsDetails.BestFitColumns();
            dvgItemDetails.Columns["Unit"].ColumnEdit = UnitsLookup;
            dvgItemDetails.BestFitColumns();
            dvgItemDetails.Columns["Per"].ColumnEdit = UnitsLookup;
            dvgItemDetails.BestFitColumns();
            RepositoryItemLookUpEdit PartysLookup = new RepositoryItemLookUpEdit();
            dtParticulars.Rows.Clear();
            DataRow drParticulars;
            List<AccountMasterModel> lstAccounts = objAccBL.GetListofAccount();
            foreach (AccountMasterModel objAcc in lstAccounts)
            {
                if (objAcc.AccGroupId == 70 || objAcc.AccGroupId == 68)
                {
                    drParticulars = dtParticulars.NewRow();
                    drParticulars["Name"] = objAcc.AccountName;
                    drParticulars["Group"] = objAcc.Group;
                    drParticulars["Op.Bal"] = objAcc.OPBal;
                    drParticulars["Address"] = objAcc.address;
                    drParticulars["Mobile"] = objAcc.MobileNumber;
                    dtParticulars.Rows.Add(drParticulars);
                }           
            }
            PartysLookup.DataSource = dtParticulars;
            PartysLookup.ValueMember = "Name";
            PartysLookup.DisplayMember = "Name";
            PartysLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            PartysLookup.AutoSearchColumnIndex = 0;
            dvgItemDetails.Columns["Particulars"].ColumnEdit = PartysLookup;
            dvgItemDetails.BestFitColumns();
        }
        private void LoadTables()
        {
            dtItem.Columns.Add("Item");
            dtItem.Columns.Add("Particulars");
            dtItem.Columns.Add("Qty");
            dtItem.Columns.Add("Unit");
            dtItem.Columns.Add("Per");
            dtItem.Columns.Add("Price");
            dtItem.Columns.Add("Batch");
            dtItem.Columns.Add("Free");
            dtItem.Columns.Add("BasicAmt");
            dtItem.Columns.Add("DiscountPercentage");
            dtItem.Columns.Add("DiscountAmount");
            dtItem.Columns.Add("TaxAmount");
            dtItem.Columns.Add("Amount");
            dtItem.Columns.Add("Item_ID");
            dtItem.Columns.Add("ParentId");
            dvgMainItem.DataSource = dtItem;

            dtbs.Columns.Add("BillSundry");
            dtbs.Columns.Add("Percentage");
            dtbs.Columns.Add("Extra");
            dtbs.Columns.Add("Amount");
            dtbs.Columns.Add("BSId");
            dtbs.Columns.Add("ParentId");
            dvgBSMain.DataSource = dtbs;

            dtParty.Columns.Add("Name");
            dtParty.Columns.Add("Group");
            dtParty.Columns.Add("Op.Bal");
            dtParty.Columns.Add("Address");
            dtParty.Columns.Add("Mobile");

            //Show Items List
            dtItems.Columns.Add("Item");
            dtItems.Columns.Add("GroupName");
            dtItems.Columns.Add("Company");

            dtParticulars.Columns.Add("Name");
            dtParticulars.Columns.Add("Group");
            dtParticulars.Columns.Add("Op.Bal");
            dtParticulars.Columns.Add("Address");
            dtParticulars.Columns.Add("Mobile");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            TransSalesModel objSaleVch = new TransSalesModel();

            if (tbxVoucherNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }
            objSaleVch.VoucherType = tbxVoucherType.Text.Trim();
            objSaleVch.SaleDate = Convert.ToDateTime(dtDate.Text);
            objSaleVch.Terms = cbxTerms.SelectedItem.ToString();
            objSaleVch.VoucherNumber = Convert.ToInt64(tbxVoucherNumber.Text.Trim() == string.Empty ? "0" : tbxVoucherNumber.Text.Trim());
            objSaleVch.BillNo = Convert.ToInt64(tbxBillNo.Text.Trim() == string.Empty ? "0" : tbxBillNo.Text.Trim());
            objSaleVch.LedgerId =objAccBL.GetLedgerIdByAccountName(tbxParty.Text.Trim());
            objSaleVch.SalesType = tbxSaleType.Text.Trim()==null?string.Empty:tbxSaleType.Text.Trim();
            objSaleVch.MatCentre = tbxMatcenter.Text.Trim()==null?string.Empty: tbxMatcenter.Text.Trim();
            objSaleVch.PriceList =cbxPriceList.Text.Trim()==null?string.Empty: cbxPriceList.Text.Trim();
            objSaleVch.Narration = tbxNarration.Text.Trim()==null?string.Empty :tbxNarration.Text.Trim();
            objSaleVch.TotalAmount = Convert.ToDecimal(Amount.SummaryItem.SummaryValue);
            objSaleVch.TotalFree = Convert.ToDecimal(colFree.SummaryItem.SummaryValue);
            objSaleVch.TotalBasicAmount = Convert.ToDecimal(colBasicAmt.SummaryItem.SummaryValue);
            objSaleVch.TotalDisAmount = Convert.ToDecimal(colDisAmt.SummaryItem.SummaryValue);
            objSaleVch.TotalTaxAmount = Convert.ToDecimal(colTaxAmont.SummaryItem.SummaryValue);
            objSaleVch.TotalQty = Convert.ToDecimal(Qty.SummaryItem.SummaryValue);
            objSaleVch.BSTotalAmount= Convert.ToDecimal(BSAmount.SummaryItem.SummaryValue);

            //Items Details
            Item_VoucherModel objSaleItem;
            List<Item_VoucherModel> lstSaleItems = new List<Item_VoucherModel>();

            for (int i = 0; i < dvgItemDetails.DataRowCount; i++)
            {
                DataRow row = dvgItemDetails.GetDataRow(i);

                objSaleItem = new Item_VoucherModel();
                objSaleItem.ITM_Id =objIMBL.GetItemIdByItemName(row["Item"].ToString()==null?string.Empty: row["Item"].ToString());
                objSaleItem.LedgerId = objAccBL.GetLedgerIdByAccountName(row["Particulars"].ToString() == null ? string.Empty : row["Particulars"].ToString());
                objSaleItem.Qty = Convert.ToDecimal(row["Qty"].ToString()==string.Empty?"0.00": row["Qty"]);
                objSaleItem.Unit = row["Unit"].ToString() == null ? string.Empty : row["Unit"].ToString();
                objSaleItem.Per = row["Per"].ToString() == null ? string.Empty : row["Per"].ToString();
                objSaleItem.Price = Convert.ToDecimal(row["Price"].ToString() == string.Empty ? "0.00" : row["Price"].ToString());
                objSaleItem.Batch = row["Batch"].ToString() == null ? string.Empty : row["Batch"].ToString();
                objSaleItem.Free = Convert.ToDecimal(row["Free"].ToString() == string.Empty ? "0.00" : row["Free"].ToString());
                objSaleItem.BasicAmt = Convert.ToDecimal(row["BasicAmt"].ToString() == string.Empty ? "0.00" : row["BasicAmt"].ToString());
                objSaleItem.DiscountPercentage = Convert.ToDecimal(row["DiscountPercentage"].ToString() == string.Empty ? "0.00" : row["DiscountPercentage"].ToString());
                objSaleItem.DiscountAmount = Convert.ToDecimal(row["DiscountAmount"].ToString() == string.Empty ? "0.00" : row["DiscountAmount"].ToString());
                objSaleItem.TaxAmount = Convert.ToDecimal(row["TaxAmount"].ToString() == string.Empty ? "0.00" : row["TaxAmount"].ToString());
                objSaleItem.Amount = Convert.ToDecimal(row["Amount"].ToString()==string.Empty?"0.00":row["Amount"].ToString());
                if(objSaleVch.Trans_Sales_Id!=0)
                {
                    objSaleItem.Item_ID= Convert.ToInt64(row["Item_ID"].ToString() == string.Empty ? "0" : row["Item_ID"].ToString());
                    objSaleItem.ParentId = Convert.ToInt64(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());
                }
                lstSaleItems.Add(objSaleItem);
            }

            objSaleVch.SalesItem_Voucher = lstSaleItems;
            //Bill Sundry Details
            BillSundry_VoucherModel objSaleBS;
            List<BillSundry_VoucherModel> lstSaleBS = new List<BillSundry_VoucherModel>();

            for (int i = 0; i < dvgBsDetails.DataRowCount; i++)
            {
                DataRow row = dvgBsDetails.GetDataRow(i);

                objSaleBS = new BillSundry_VoucherModel();
                objSaleBS.BS_Id =objBSBL.GetBSIdByBSName(row["BillSundry"].ToString()==null?string.Empty: row["BillSundry"].ToString());
                objSaleBS.Percentage = Convert.ToDecimal(row["Percentage"].ToString()==string.Empty?"0.00":row["Percentage"].ToString());
                objSaleBS.Extra = row["Extra"].ToString() == null ? string.Empty : row["Extra"].ToString();
                objSaleBS.Amount = Convert.ToDecimal(row["Amount"].ToString()==string.Empty?"0.00": row["Amount"].ToString());
                
                lstSaleBS.Add(objSaleBS);
            }
            objSaleVch.SalesBillSundry_Voucher = lstSaleBS;

            bool isSuccess = objSVBL.SaveSalesVoucher(objSaleVch);
            if (isSuccess)
            {
                ledgerPostingAdd();
                MessageBox.Show("Saved Successfully!");
                SalesId = 0;
                //ClearControls();
            }
        }  
       
        public void ledgerPostingAdd()
        {

            eSunSpeedDomain.LedgerPostingModel infoLedgerPosting = new eSunSpeedDomain.LedgerPostingModel();
            BillSundry_VoucherModel objSaleBS;
            for (int i = 0; i < dvgBsDetails.DataRowCount; i++)
            {
                DataRow row = dvgBsDetails.GetDataRow(i);

                objSaleBS = new BillSundry_VoucherModel();
                objSaleBS.BS_Id = objBSBL.GetBSIdByBSName(row["BillSundry"].ToString() == null ? string.Empty : row["BillSundry"].ToString());
                //objSaleBS.Percentage = Convert.ToDecimal(row["Percentage"].ToString() == string.Empty ? "0.00" : row["Percentage"].ToString());
                //objSaleBS.Extra = row["Extra"].ToString() == null ? string.Empty : row["Extra"].ToString();
                //objSaleBS.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());
                BillSundryMasterModel objbs = objBSBL.GetAllBillSundryByName(row["BillSundry"].ToString() == null ? string.Empty : row["BillSundry"].ToString());
                if (objbs.SaleAdjustInSaleAmount == true && objbs.SaleAdjustInPartyAmount == true)
                {
                    //Party Debit Posting
                    infoLedgerPosting.VoucherTypeId = 1;
                    infoLedgerPosting.LedgerId = Convert.ToDecimal(objAccBL.GetLedgerIdByAccountName(tbxParty.Text.Trim() == null ? string.Empty : tbxParty.Text.Trim()));
                    infoLedgerPosting.Debit = Convert.ToDecimal((Convert.ToDecimal(colTaxAmont.SummaryItem.SummaryValue) + Convert.ToDecimal(Amount.SummaryItem.SummaryValue)) - (Convert.ToDecimal(BSAmount.SummaryItem.SummaryValue)));
                    infoLedgerPosting.Credit = 0;
                    infoLedgerPosting.Date = Convert.ToDateTime(dtDate.Text.ToString());
                    infoLedgerPosting.VoucherNo = tbxVoucherNumber.Text.Trim();
                    infoLedgerPosting.InvoiceNo = string.Empty;
                    infoLedgerPosting.YearId = 1;
                    infoLedgerPosting.DetailsId = 0;
                    infoLedgerPosting.ChequeNo = string.Empty;
                    infoLedgerPosting.ChequeDate = DateTime.Now;
                    infoLedgerPosting.Extra1 = string.Empty;
                    infoLedgerPosting.Extra2 = string.Empty;
                    objLPBL.LedgerPostingAdd(infoLedgerPosting);

                    //Sale Credit Posting
                    infoLedgerPosting.Debit = 0;
                    infoLedgerPosting.Credit = Convert.ToDecimal(Convert.ToDecimal(Amount.SummaryItem.SummaryValue) - Convert.ToDecimal(BSAmount.SummaryItem.SummaryValue));
                    infoLedgerPosting.Date = Convert.ToDateTime(dtDate.Text.ToString());
                    infoLedgerPosting.VoucherTypeId = 1;
                    infoLedgerPosting.VoucherNo = tbxVoucherNumber.Text.Trim();
                    infoLedgerPosting.InvoiceNo = string.Empty;
                    infoLedgerPosting.LedgerId = objStBL.GetSaleLedgerId(tbxSaleType.Text.Trim());
                    infoLedgerPosting.YearId = 1;
                    infoLedgerPosting.DetailsId = 0;
                    infoLedgerPosting.ChequeNo = string.Empty;
                    infoLedgerPosting.ChequeDate = DateTime.Now;
                    infoLedgerPosting.Extra1 = string.Empty;
                    infoLedgerPosting.Extra2 = string.Empty;
                    objLPBL.LedgerPostingAdd(infoLedgerPosting);
                    //Tax Credit Posting
                    infoLedgerPosting.Debit = 0;
                    infoLedgerPosting.Credit = Convert.ToDecimal(colTaxAmont.SummaryItem.SummaryValue);
                    infoLedgerPosting.Date = Convert.ToDateTime(dtDate.Text.ToString());
                    infoLedgerPosting.VoucherTypeId = 1;
                    infoLedgerPosting.VoucherNo = tbxVoucherNumber.Text.Trim();
                    infoLedgerPosting.InvoiceNo = string.Empty;
                    infoLedgerPosting.LedgerId = objStBL.GetTaxLedgerId(tbxSaleType.Text.Trim());
                    infoLedgerPosting.YearId = 1;
                    infoLedgerPosting.DetailsId = 0;
                    infoLedgerPosting.ChequeNo = string.Empty;
                    infoLedgerPosting.ChequeDate = DateTime.Now;
                    infoLedgerPosting.Extra1 = string.Empty;
                    infoLedgerPosting.Extra2 = string.Empty;
                    objLPBL.LedgerPostingAdd(infoLedgerPosting);

                    ////Discount Debit Posting
                    //infoLedgerPosting.Debit = Convert.ToDecimal(BSAmount.SummaryItem.SummaryValue);
                    //infoLedgerPosting.Credit = 0;
                    //infoLedgerPosting.Date = Convert.ToDateTime(dtDate.Text.ToString());
                    //infoLedgerPosting.VoucherTypeId = 1;
                    //infoLedgerPosting.VoucherNo = tbxVoucherNumber.Text.Trim();
                    //infoLedgerPosting.InvoiceNo = string.Empty;
                    //infoLedgerPosting.LedgerId = objBSBL.GetBSLedgerId(tbxSaleType.Text.Trim());
                    //infoLedgerPosting.YearId = 1;
                    //infoLedgerPosting.DetailsId = 0;
                    //infoLedgerPosting.ChequeNo = string.Empty;
                    //infoLedgerPosting.ChequeDate = DateTime.Now;
                    //infoLedgerPosting.Extra1 = string.Empty;
                    //infoLedgerPosting.Extra2 = string.Empty;
                    //objLPBL.LedgerPostingAdd(infoLedgerPosting);

                }

            }
            
            SessionVariables PublicVariables = new SessionVariables();
            try
            {

                //For Sales Voucher VoucherId= "1"
                
                
                //decTotalAmount = TotalNetAmountForLedgerPosting();
                //decRate = spExchangeRate.ExchangeRateViewByExchangeRateId(Convert.ToDecimal(cmbCurrency.SelectedValue.ToString()));
                //decTotalAmount = decTotalAmount * decRate;
               
                

                
                //BillSundry_VoucherModel objSaleBS;
                //for (int i = 0; i < dvgBsDetails.DataRowCount; i++)
                //{
                //    DataRow row = dvgBsDetails.GetDataRow(i);

                //    objSaleBS = new BillSundry_VoucherModel();
                //    objSaleBS.BS_Id = objBSBL.GetBSIdByBSName(row["BillSundry"].ToString() == null ? string.Empty : row["BillSundry"].ToString());
                //    objSaleBS.Percentage = Convert.ToDecimal(row["Percentage"].ToString() == string.Empty ? "0.00" : row["Percentage"].ToString());
                //    objSaleBS.Extra = row["Extra"].ToString() == null ? string.Empty : row["Extra"].ToString();
                //    objSaleBS.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());

                //    lstSaleBS.Add(objSaleBS);
                //}
                //if (dgvSalesInvoice.Columns["dgvcmbSalesInvoiceTaxName"].Visible)
                //{
                //    foreach (DataGridViewRow dgvrow in dgvSalesInvoiceTax.Rows)
                //    {
                //        if (dgvrow.Cells["dgvtxtTtaxId"].Value != null && dgvrow.Cells["dgvtxtTtaxId"].Value.ToString() != string.Empty)
                //        {
                //            decimal decTaxAmount = 0;
                //            decTaxAmount = Convert.ToDecimal(dgvrow.Cells["dgvtxtTtaxAmount"].Value.ToString());
                //            decRate = spExchangeRate.ExchangeRateViewByExchangeRateId(Convert.ToDecimal(cmbCurrency.SelectedValue.ToString()));
                //            decTaxAmount = decTaxAmount * decRate;
                //            if (decTaxAmount > 0)
                //            {
                //                infoLedgerPosting.Debit = 0;
                //                infoLedgerPosting.Credit = decTaxAmount;
                //                infoLedgerPosting.Date = Convert.ToDateTime(txtDate.Text.ToString());
                //                infoLedgerPosting.VoucherTypeId = DecSalesInvoiceVoucherTypeId;
                //                infoLedgerPosting.VoucherNo = strVoucherNo;
                //                infoLedgerPosting.InvoiceNo = txtInvoiceNo.Text.Trim();
                //                infoLedgerPosting.LedgerId = Convert.ToDecimal(dgvrow.Cells["dgvtxtTaxLedgerId"].Value.ToString());
                //                infoLedgerPosting.YearId = PublicVariables._decCurrentFinancialYearId;
                //                infoLedgerPosting.DetailsId = 0;
                //                infoLedgerPosting.ChequeNo = string.Empty;
                //                infoLedgerPosting.ChequeDate = DateTime.Now;
                //                infoLedgerPosting.Extra1 = string.Empty;
                //                infoLedgerPosting.Extra2 = string.Empty;
                //                spLedgerPosting.LedgerPostingAdd(infoLedgerPosting);
                //            }
                //        }
                //    }
                //}
                //if (cmbCashOrbank.Visible)
                //{
                //    foreach (DataGridViewRow dgvrow in dgvSalesInvoiceLedger.Rows)
                //    {
                //        if (dgvrow.Cells["dgvCmbAdditionalCostledgerName"].Value != null && dgvrow.Cells["dgvCmbAdditionalCostledgerName"].Value.ToString() != string.Empty)
                //        {
                //            decimal decAmount = 0;
                //            decAmount = Convert.ToDecimal(dgvrow.Cells["dgvtxtAdditionalCoastledgerAmount"].Value.ToString());
                //            decRate = spExchangeRate.ExchangeRateViewByExchangeRateId(Convert.ToDecimal(cmbCurrency.SelectedValue.ToString()));
                //            decAmount = decAmount * decRate;
                //            if (decAmount > 0)
                //            {
                //                infoLedgerPosting.Debit = decAmount;
                //                infoLedgerPosting.Credit = 0;
                //                infoLedgerPosting.Date = Convert.ToDateTime(txtDate.Text.ToString());
                //                infoLedgerPosting.VoucherTypeId = DecSalesInvoiceVoucherTypeId;
                //                infoLedgerPosting.VoucherNo = strVoucherNo;
                //                infoLedgerPosting.InvoiceNo = txtInvoiceNo.Text.Trim();
                //                infoLedgerPosting.LedgerId = Convert.ToDecimal(dgvrow.Cells["dgvCmbAdditionalCostledgerName"].Value.ToString());
                //                infoLedgerPosting.YearId = PublicVariables._decCurrentFinancialYearId;
                //                infoLedgerPosting.DetailsId = 0;
                //                infoLedgerPosting.ChequeNo = string.Empty;
                //                infoLedgerPosting.ChequeDate = DateTime.Now;
                //                infoLedgerPosting.Extra1 = string.Empty;
                //                infoLedgerPosting.Extra2 = string.Empty;
                //                spLedgerPosting.LedgerPostingAdd(infoLedgerPosting);
                //            }
                //        }
                //    }
                //    decimal decBankOrCashId = 0;
                //    decBankOrCashId = Convert.ToDecimal(cmbCashOrbank.SelectedValue.ToString());
                //    decimal decAmountForCr = 0;
                //    decAmountForCr = Convert.ToDecimal(lblLedgerTotalAmount.Text.ToString());
                //    decRate = spExchangeRate.ExchangeRateViewByExchangeRateId(Convert.ToDecimal(cmbCurrency.SelectedValue.ToString()));
                //    decAmountForCr = decAmountForCr * decRate;
                //    if (decAmountForCr > 0)
                //    {
                //        infoLedgerPosting.Debit = 0;
                //        infoLedgerPosting.Credit = decAmountForCr;
                //        infoLedgerPosting.Date = Convert.ToDateTime(txtDate.Text.ToString());
                //        infoLedgerPosting.VoucherTypeId = DecSalesInvoiceVoucherTypeId;
                //        infoLedgerPosting.VoucherNo = strVoucherNo;
                //        infoLedgerPosting.InvoiceNo = txtInvoiceNo.Text.Trim();
                //        infoLedgerPosting.LedgerId = decBankOrCashId;
                //        infoLedgerPosting.YearId = PublicVariables._decCurrentFinancialYearId;
                //        infoLedgerPosting.DetailsId = 0;
                //        infoLedgerPosting.ChequeNo = string.Empty;
                //        infoLedgerPosting.ChequeDate = DateTime.Now;
                //        infoLedgerPosting.Extra1 = "AddCash";
                //        infoLedgerPosting.Extra2 = string.Empty;
                //        spLedgerPosting.LedgerPostingAdd(infoLedgerPosting);
                //    }
                //}
                //else
                //{
                //    foreach (DataGridViewRow dgvrow in dgvSalesInvoiceLedger.Rows)
                //    {
                //        if (dgvrow.Cells["dgvCmbAdditionalCostledgerName"].Value != null && dgvrow.Cells["dgvCmbAdditionalCostledgerName"].Value.ToString() != string.Empty)
                //        {
                //            decimal decAmount = 0;
                //            decAmount = Convert.ToDecimal(dgvrow.Cells["dgvtxtAdditionalCoastledgerAmount"].Value.ToString());
                //            decRate = spExchangeRate.ExchangeRateViewByExchangeRateId(Convert.ToDecimal(cmbCurrency.SelectedValue.ToString()));
                //            decAmount = decAmount * decRate;
                //            if (decAmount > 0)
                //            {
                //                infoLedgerPosting.Debit = 0;
                //                infoLedgerPosting.Credit = decAmount;
                //                infoLedgerPosting.Date = Convert.ToDateTime(txtDate.Text.ToString());
                //                infoLedgerPosting.VoucherTypeId = DecSalesInvoiceVoucherTypeId;
                //                infoLedgerPosting.VoucherNo = strVoucherNo;
                //                infoLedgerPosting.InvoiceNo = txtInvoiceNo.Text.Trim();
                //                infoLedgerPosting.LedgerId = Convert.ToDecimal(dgvrow.Cells["dgvCmbAdditionalCostledgerName"].Value.ToString());
                //                infoLedgerPosting.YearId = PublicVariables._decCurrentFinancialYearId;
                //                infoLedgerPosting.DetailsId = 0;
                //                infoLedgerPosting.ChequeNo = string.Empty;
                //                infoLedgerPosting.ChequeDate = DateTime.Now;
                //                infoLedgerPosting.Extra1 = string.Empty;
                //                infoLedgerPosting.Extra2 = string.Empty;
                //                spLedgerPosting.LedgerPostingAdd(infoLedgerPosting);
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                //formMDI.infoError.ErrorString = "SI73:" + ex.Message;
            }
        }
        private void ClearControls()
        {
            tbxVoucherType.SelectedText = "";
            dtDate.Text = string.Empty;
            cbxTerms.Text = string.Empty;
            tbxVoucherNumber.Text = string.Empty;
            tbxBillNo.Text = string.Empty;
            tbxSaleType.SelectedText = "";
            tbxParty.SelectedText = "";
            tbxMatcenter.Text = string.Empty;
            tbxNarration.Text = string.Empty;
            cbxPriceList.Text = string.Empty;
            dtItem.Rows.Clear();
            dtbs.Rows.Clear();
        }
        private void tbxSeries_Enter(object sender, EventArgs e)
        {
            tbxVoucherType.ShowPopup();
        }

        private void tbxSaleType_Enter(object sender, EventArgs e)
        {
            tbxSaleType.ShowPopup();
        }

        private void dvgItemDetails_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Item")
            {
                dvgItemDetails.ShowEditor();
                ((LookUpEdit)dvgItemDetails.ActiveEditor).ShowPopup();

            }
            if (e.FocusedColumn.FieldName == "Unit" || e.FocusedColumn.FieldName == "Per" || e.FocusedColumn.FieldName == "Particulars")
            {
                dvgItemDetails.ShowEditor();
                ((LookUpEdit)dvgItemDetails.ActiveEditor).ShowPopup();
            }
        }

        private void dvgBsDetails_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "BillSundry")
            {
                dvgBsDetails.ShowEditor();
                ((LookUpEdit)dvgBsDetails.ActiveEditor).ShowPopup();

            }
        }

        private void dvgItemDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "SNo")
            {
                GridView gridView = (GridView)sender;
                e.DisplayText = (gridView.GetRowHandle(e.ListSourceRowIndex) + 1).ToString();

                if (Convert.ToInt32(e.DisplayText) < 0)
                {
                    e.DisplayText = "";
                }
            }
        }

        private void dvgBSMain_Click(object sender, EventArgs e)
        {

        }

        private void tbxVoucherNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar=='\r')
            {
                if (tbxVoucherNumber.Text.Trim() == "")
                {
                    MessageBox.Show("Voucher Number Can Not Be Blank!");
                    tbxVoucherNumber.Focus();
                    return;
                }
            }
        }

        private void dvgBsDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "SNo")
            {
                GridView gridView = (GridView)sender;
                e.DisplayText = (gridView.GetRowHandle(e.ListSourceRowIndex) + 1).ToString();

                if (Convert.ToInt32(e.DisplayText) < 0)
                {
                    e.DisplayText = "";
                }
            }
            
        }

        private void btnSaleVchList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
                Transaction.List.SalesVouchersList frmSaleVchList = new Transaction.List.SalesVouchersList();
                frmSaleVchList.StartPosition = FormStartPosition.CenterParent;

                frmSaleVchList.ShowDialog();
                FillSalesVoucherInfo();
            
        }
        private void FillSalesVoucherInfo()
        {
            if(SalesId==0)
            {
                tbxVoucherType.FindForm();
                laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                return;
            }
            TransSalesModel objSaleVch = objSVBL.GetAllSalesbyId(SalesId);
            tbxVoucherType.Text= objSaleVch.VoucherType.ToString();
            dtDate.Text= objSaleVch.SaleDate.ToString();
            cbxTerms.SelectedItem= objSaleVch.Terms.ToString();
            tbxVoucherNumber.Text= objSaleVch.VoucherNumber.ToString();
            tbxBillNo.Text= objSaleVch.BillNo.ToString();
            tbxSaleType.Text= objSaleVch.SalesType.ToString();
            tbxParty.Text= objSaleVch.Party;
            tbxMatcenter.Text= objSaleVch.MatCentre.ToString();
            tbxNarration.Text= objSaleVch.Narration.ToString();
            //Qty.SummaryItem= objSaleVch.TotalQty.ToString();
            //objSaleVch.TotalAmount = Convert.ToDecimal(dr["TotalAmount"].ToString());
            //objSaleVch.BSTotalAmount = Convert.ToDecimal(dr["BSTotalAmount"]);
            cbxPriceList.Text=objSaleVch.PriceList.ToString();
            //dvgMainItem.DataSource = objSaleVch.SalesItem_Voucher;
            //dvgBSMain.DataSource = objSaleVch.SalesBillSundry_Voucher;
            dtItem.Rows.Clear();
            DataRow idr;
            foreach (Item_VoucherModel objItems in objSaleVch.SalesItem_Voucher)
            {
                idr = dtItem.NewRow();

                idr["Item"] = objItems.Item;
                idr["Particulars"] = objItems.Particulars;
                idr["Qty"] = objItems.Qty;
                idr["Unit"] = objItems.Unit;
                idr["Per"] = objItems.Per;
                idr["Price"] = objItems.Price;
                idr["Batch"] = objItems.Batch;
                idr["Free"] = objItems.Free;
                idr["BasicAmt"] = objItems.BasicAmt;
                idr["DiscountPercentage"]=objItems.DiscountPercentage;
                idr["DiscountAmount"]=objItems.DiscountAmount;
                idr["TaxAmount"]=objItems.TaxAmount;
                idr["Amount"] = objItems.Amount;
                idr["Item_ID"]=objItems.Item_ID;
                idr["ParentId"]=objItems.ParentId;
                dtItem.Rows.Add(idr);
                if(objItems.ITM_Id!=0)
                {
                    ItemMode();
                }
                else
                {
                    AccountMode();
                }
                
            }
            dtbs.Rows.Clear();
            DataRow bsdr;
            foreach(BillSundry_VoucherModel objbs in objSaleVch.SalesBillSundry_Voucher)
            {
                bsdr = dtbs.NewRow();
                bsdr["BillSundry"]=objbs.BillSundry;
                bsdr["Percentage"]=objbs.Percentage;
                bsdr["Extra"]=objbs.Extra;
                bsdr["Amount"]=objbs.Amount;
                bsdr["BSId"]=objbs.BSId;
                bsdr["ParentId"]=objbs.ParentId;
                dtbs.Rows.Add(bsdr);
            }
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TransSalesModel objSaleVch = new TransSalesModel();

            if (tbxVoucherNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }

            objSaleVch.VoucherType = tbxVoucherType.Text.Trim();
            objSaleVch.SaleDate = Convert.ToDateTime(dtDate.Text);
            objSaleVch.Terms = cbxTerms.SelectedItem.ToString();
            objSaleVch.VoucherNumber = Convert.ToInt64(tbxVoucherNumber.Text.Trim() == string.Empty ? "0" : tbxVoucherNumber.Text.Trim());
            objSaleVch.BillNo = Convert.ToInt64(tbxBillNo.Text.Trim() == string.Empty ? "0" : tbxBillNo.Text.Trim());
            objSaleVch.LedgerId =objAccBL.GetLedgerIdByAccountName(tbxParty.Text.Trim());
            objSaleVch.SalesType = tbxSaleType.Text.Trim();
            objSaleVch.MatCentre = tbxMatcenter.Text.Trim() == null ? string.Empty : tbxMatcenter.Text.Trim();
            objSaleVch.PriceList = cbxPriceList.Text.Trim() == null ? string.Empty : cbxPriceList.Text.Trim();
            objSaleVch.Narration = tbxNarration.Text.Trim() == null ? string.Empty : tbxNarration.Text.Trim();
            objSaleVch.TotalAmount = Convert.ToDecimal(Amount.SummaryItem.SummaryValue);
            objSaleVch.TotalFree = Convert.ToDecimal(colFree.SummaryItem.SummaryValue);
            objSaleVch.TotalBasicAmount = Convert.ToDecimal(colBasicAmt.SummaryItem.SummaryValue);
            objSaleVch.TotalDisAmount = Convert.ToDecimal(colDisAmt.SummaryItem.SummaryValue);
            objSaleVch.TotalTaxAmount = Convert.ToDecimal(colTaxAmont.SummaryItem.SummaryValue);
            objSaleVch.TotalQty = Convert.ToDecimal(Qty.SummaryItem.SummaryValue);
            objSaleVch.BSTotalAmount = Convert.ToDecimal(BSAmount.SummaryItem.SummaryValue);

            //Items Details
            Item_VoucherModel objSaleItem;
            List<Item_VoucherModel> lstSaleItems = new List<Item_VoucherModel>();

            for (int i = 0; i < dvgItemDetails.DataRowCount; i++)
            {
                DataRow row = dvgItemDetails.GetDataRow(i);

                objSaleItem = new Item_VoucherModel();
                objSaleItem.ITM_Id =objIMBL.GetItemIdByItemName(row["Item"].ToString() == null ? string.Empty : row["Item"].ToString());
                objSaleItem.Qty = Convert.ToDecimal(row["Qty"].ToString() == string.Empty ? "0.00" : row["Qty"]);
                objSaleItem.LedgerId = objAccBL.GetLedgerIdByAccountName(row["Particulars"].ToString() == null ? string.Empty : row["Particulars"].ToString());
                objSaleItem.Unit = row["Unit"].ToString() == null ? string.Empty : row["Unit"].ToString();
                objSaleItem.Per = row["Per"].ToString() == null ? string.Empty : row["Per"].ToString();
                objSaleItem.Price = Convert.ToDecimal(row["Price"].ToString() == string.Empty ? "0.00" : row["Price"].ToString());
                objSaleItem.Batch = row["Batch"].ToString() == null ? string.Empty : row["Batch"].ToString();
                objSaleItem.Free = Convert.ToDecimal(row["Free"].ToString() == string.Empty ? "0.00" : row["Free"].ToString());
                objSaleItem.BasicAmt = Convert.ToDecimal(row["BasicAmt"].ToString() == string.Empty ? "0.00" : row["BasicAmt"].ToString());
                objSaleItem.DiscountPercentage = Convert.ToDecimal(row["DiscountPercentage"].ToString() == string.Empty ? "0.00" : row["DiscountPercentage"].ToString());
                objSaleItem.DiscountAmount = Convert.ToDecimal(row["DiscountAmount"].ToString() == string.Empty ? "0.00" : row["DiscountAmount"].ToString());
                objSaleItem.TaxAmount = Convert.ToDecimal(row["TaxAmount"].ToString() == string.Empty ? "0.00" : row["TaxAmount"].ToString());
                objSaleItem.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());
                objSaleItem.Item_ID = Convert.ToInt64(row["Item_ID"].ToString() == string.Empty ? "0" : row["Item_ID"].ToString());
                objSaleItem.ParentId = Convert.ToInt64(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());
               
                lstSaleItems.Add(objSaleItem);
            }

            objSaleVch.SalesItem_Voucher = lstSaleItems;
            //Bill Sundry Details
            BillSundry_VoucherModel objSaleBS;
            List<BillSundry_VoucherModel> lstSaleBS = new List<BillSundry_VoucherModel>();

            for (int i = 0; i < dvgBsDetails.DataRowCount; i++)
            {
                DataRow row = dvgBsDetails.GetDataRow(i);

                objSaleBS = new BillSundry_VoucherModel();
                objSaleBS.BS_Id =objBSBL.GetBSIdByBSName(row["BillSundry"].ToString() == null ? string.Empty : row["BillSundry"].ToString());
                objSaleBS.Percentage = Convert.ToDecimal(row["Percentage"].ToString() == string.Empty ? "0.00" : row["Percentage"].ToString());
                objSaleBS.Extra = row["Extra"].ToString() == null ? string.Empty : row["Extra"].ToString();
                objSaleBS.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());
                objSaleBS.BSId = Convert.ToInt64(row["BSId"].ToString() == string.Empty ? "0" : row["BSId"].ToString());
                objSaleBS.ParentId = Convert.ToInt64(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());
                lstSaleBS.Add(objSaleBS);
            }
            objSaleVch.SalesBillSundry_Voucher = lstSaleBS;
            objSaleVch.Trans_Sales_Id = SalesId;
            bool isSuccess = objSVBL.UpdateSalesVoucherMaster(objSaleVch);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                SalesId = 0;
                ClearControls();
                Transaction.List.SalesVouchersList frmSaleVchList = new Transaction.List.SalesVouchersList();
                frmSaleVchList.StartPosition = FormStartPosition.CenterParent;
                frmSaleVchList.ShowDialog();
                FillSalesVoucherInfo();
            }
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SalesId = 0;
            ClearControls();
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objSVBL.DeleteSalesVoucher(SalesId);
            if(isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                SalesId = 0;
                ClearControls();
                Transaction.List.SalesVouchersList frmSaleVchList = new Transaction.List.SalesVouchersList();
                frmSaleVchList.StartPosition = FormStartPosition.CenterParent;
                frmSaleVchList.ShowDialog();
                FillSalesVoucherInfo();
            }
        }

        private void tbxParty_Enter(object sender, EventArgs e)
        {
            tbxParty.ShowPopup();
        }

        private void tbxMatcenter_Enter(object sender, EventArgs e)
        {
            tbxMatcenter.ShowPopup();
        }

        private void dvgItemDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Caption == "Item")
            {
                if(e.Value.ToString()==null)
                {
                    dvgBsDetails.Focus();
                }
                else
                {
                    List<ItemMasterModel> lstItems = objIMBL.GetItemsByName(e.Value.ToString());
                    List<string> lstUnits = new List<string>();
                    foreach (ItemMasterModel objUnits in lstItems)
                    {
                        lstUnits.Add(objUnits.MainUnit);
                        lstUnits.Add(objUnits.AltUnit);
                    }
                    UnitsLookup.DataSource = lstUnits;
                }
                
            }
            if(e.Column.Caption=="Amount")
            {
               
            }
        }

        private void dvgItemDetails_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Caption == "Item")
            {
                List<ItemMasterModel> lstItems = objIMBL.GetItemsByName(e.Value.ToString());
                List<string> lstUnits = new List<string>();
                foreach (ItemMasterModel objUnits in lstItems)
                {
                    lstUnits.Add(objUnits.MainUnit);
                    lstUnits.Add(objUnits.AltUnit);
                }
                UnitsLookup.DataSource = lstUnits;
            }
        }

        private void barbtnAccountsMode_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AccountMode();
            ClearControls();
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void barbtnItemMode_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ItemMode();
            ClearControls();
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }
        private void ItemMode()
        {
            colItem.Visible = true;
            colItem.VisibleIndex = 1;
            colParty.Visible = false;
            colBatch.Visible = true;
            colBatch.VisibleIndex = 2;
            Qty.Visible = true;
            Qty.VisibleIndex = 3;
            Unit.Visible = true;
            Unit.VisibleIndex = 4;
            colFree.Visible = true;
            colFree.VisibleIndex = 5;
            Price.Visible = true;
            Price.VisibleIndex = 6;
            colPer.Visible = true;
            colPer.VisibleIndex = 7;
            colBasicAmt.Visible = true;
            colBasicAmt.VisibleIndex = 8;
            colDisPer.Visible = true;
            colDisPer.VisibleIndex = 9;
            colDisAmt.Visible = true;
            colDisAmt.VisibleIndex = 10;
            colTaxAmont.Visible = true;
            colTaxAmont.VisibleIndex = 11;
            Amount.Visible = true;
            Amount.VisibleIndex = 12;
            lactrlMatcenter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlPriceList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            barbtnAccountsMode.Visible = true;
            barbtnItemMode.Visible = false;
        }
        private void AccountMode()
        {
            colItem.Visible = false;
            colParty.Visible = true;
            colParty.VisibleIndex = 1;
            colBatch.Visible = false;
            Qty.Visible = false;
            Unit.Visible = false;
            colFree.Visible = false;
            Price.Visible = false;
            colPer.Visible = false;
            colBasicAmt.Visible = true;
            colBasicAmt.VisibleIndex = 2;
            colDisPer.Visible = true;
            colDisPer.VisibleIndex = 3;
            colDisAmt.Visible = true;
            colDisAmt.VisibleIndex = 4;
            colTaxAmont.Visible = true;
            colTaxAmont.VisibleIndex = 5;
            Amount.Visible = true;
            Amount.VisibleIndex = 6;
            lactrlMatcenter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlPriceList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            barbtnAccountsMode.Visible = false;
            barbtnItemMode.Visible = true;
        }

        private void cbxTerms_Enter(object sender, EventArgs e)
        {
            cbxTerms.ShowPopup();
        }

        private void cbxTerms_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                cbxTerms.ShowPopup();
            }
        }

        private void tbxVoucherType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                tbxVoucherType.ShowPopup();
            }
        }

        private void cbxPriceList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                cbxPriceList.ShowPopup();
            }
        }

        private void tbxMatcenter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                tbxMatcenter.ShowPopup();
            }
        }

        private void tbxSaleType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                tbxSaleType.ShowPopup();
            }
        }

        private void tbxParty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                dtParty.Rows.Clear();
                DataRow drparty;
                List<AccountMasterModel> lstAccounts = objAccBL.GetListofAccount();
                foreach (AccountMasterModel objAcc in lstAccounts)
                {
                    if (objAcc.AccGroupId == 85 || objAcc.AccGroupId == 86)
                    {
                        drparty = dtParty.NewRow();
                        drparty["Name"] = objAcc.AccountName;
                        drparty["Group"] = objAcc.Group;
                        drparty["Op.Bal"] = objAcc.OPBal;
                        drparty["Address"] = objAcc.address;
                        drparty["Mobile"] = objAcc.MobileNumber;
                        dtParty.Rows.Add(drparty);
                    }
                }
                tbxParty.Properties.DataSource = dtParty;
                tbxParty.Properties.DisplayMember = "Name";
                tbxParty.ShowPopup();
            }
        }

        private void dvgBsDetails_ColumnChanged(object sender, EventArgs e)
        {

        }

        private void dvgBsDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName== "Amount")
            {
                decimal value;
                value = Convert.ToDecimal(Amount.SummaryItem.SummaryValue)-Convert.ToDecimal(e.Value.ToString());

            }
        }
    }
}
