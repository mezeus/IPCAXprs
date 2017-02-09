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
        ItemMasterBL objIMBL = new ItemMasterBL();
        SaleTypeBL objStBL = new SaleTypeBL();
        BillSundryMaster objBSBL = new BillSundryMaster();
        RepositoryItemLookUpEdit UnitsLookup = new RepositoryItemLookUpEdit();
        public static long SalesId = 0;
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
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SalesVoucher_Load(object sender, EventArgs e)
        {
            LoadTables();
            tbxVoucherType.Focus();
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            
            dtParty.Rows.Clear();
            DataRow drparty;
            //List<AccountMasterModel> lstAccounts = objAccBL.GetListofAccountsByUnderSCSD();
            //foreach(AccountMasterModel objAcc in lstAccounts)
            //{
            //    drparty = dtParty.NewRow();
            //    drparty["Name"]=objAcc.AccountName;
            //    drparty["Group"]=objAcc.Group;
            //    drparty["Op.Bal"]=objAcc.OPBal;
            //    drparty["Address"]=objAcc.address;
            //    drparty["Mobile"]=objAcc.MobileNumber;
            //    dtParty.Rows.Add(drparty);
            //}
            tbxParty.Properties.DataSource = dtParty;
            tbxParty.Properties.DisplayMember = "Name";
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
            //DataRow drParticulars;
            //List<AccountMasterModel> lstAccounts = objAccBL.get();
            //foreach (ItemMasterModel objItems in lstItems)
            //{
            //    drParticulars = dtItems.NewRow();
            //    drItems["Item"] = objItems.Name;
            //    drItems["GroupName"] = objItems.Group;
            //    drItems["Company"] = objItems.Company;
            //    dtItems.Rows.Add(drItems);
            //}
        }
        private void LoadTables()
        {
            dtItem.Columns.Add("Item");
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
            objSaleVch.SalesType = tbxSaleType.Text.Trim();
            objSaleVch.MatCentre = tbxMatcenter.Text.Trim();
            objSaleVch.PriceList =cbxPriceList.Text.Trim();
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
                MessageBox.Show("Saved Successfully!");
                SalesId = 0;
                //ClearControls();
            }
        }
        private void ClearControls()
        {
            tbxVoucherType.Text = string.Empty;
            dtDate.Text = string.Empty;
            cbxTerms.Text = string.Empty;
            tbxVoucherNumber.Text = string.Empty;
            tbxBillNo.Text = string.Empty;
            tbxSaleType.Text = string.Empty;
            tbxParty.Text = string.Empty;
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
            if (e.FocusedColumn.FieldName == "Unit" || e.FocusedColumn.FieldName == "Per")
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
                idr["Particulars"] = objItems.Item;
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
            objSaleVch.MatCentre = tbxMatcenter.Text.Trim();
            objSaleVch.PriceList = cbxPriceList.Text.Trim();
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
            dvgItemDetails.Columns[1].Visible = false;

            //colParty.Visible = true;
            //colBatch.Visible = false;
            //Qty.Visible = false;
            //Unit.Visible = false;
            //colFree.Visible = false;
            //Price.Visible = false;
            //colPer.Visible = false;
            //colBasicAmt.Visible = true;
            //colDisPer.Visible = true;
            //colDisAmt.Visible = true;
            //colTaxAmont.Visible = true;
            //Amount.Visible = true;
            lactrlMatcenter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlPriceList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            barbtnAccountsMode.Visible = false;
            barbtnItemMode.Visible = true;
            
            
        }

        private void barbtnItemMode_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //colItem.Visible = true;
            //colParty.Visible = false;
            //colBatch.Visible = true;
            //Qty.Visible = true;
            //Unit.Visible = true;
            //colFree.Visible = true;
            //Price.Visible = true;
            //colPer.Visible = true;
            //colBasicAmt.Visible = true;
            //colDisPer.Visible = true;
            //colDisAmt.Visible = true;
            //colTaxAmont.Visible = true;
            //Amount.Visible = true;
            lactrlMatcenter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlPriceList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            barbtnAccountsMode.Visible = true;
            barbtnItemMode.Visible = false;
            
           
        }
    }
}
