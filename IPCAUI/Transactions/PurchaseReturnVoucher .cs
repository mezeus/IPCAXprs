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
    public partial class PurhcaseReturnvoucher : Form
    {
        DataTable dtItem = new DataTable();
        DataTable dtbs = new DataTable();
        DataTable dtParty = new DataTable();
        DataTable dtItems = new DataTable();
        PurchaseReturnVoucherBL objPurcBL = new PurchaseReturnVoucherBL();
        AccountMasterBL objAccBL = new AccountMasterBL();
        MaterialCentreMasterBL objMcBL = new MaterialCentreMasterBL();
        ItemMasterBL objIMBL = new ItemMasterBL();
        PurchaseTypeBL objPTBL = new PurchaseTypeBL();
        BillSundryMaster objBSBL = new BillSundryMaster();
        RepositoryItemLookUpEdit UnitsLookup = new RepositoryItemLookUpEdit();
        public static long PurcRetId = 0;
        public PurhcaseReturnvoucher()
        {
            InitializeComponent();
        }

        private void PurhcaseReturnvoucher_Load(object sender, EventArgs e)
        {
            LoadTables();
            cbxTerms.Focus();
            lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            LoadGridColumns();

            dtParty.Rows.Clear();
            DataRow drparty;
            List<AccountMasterModel> lstAccounts = objAccBL.GetListofAccount();
            foreach (AccountMasterModel objAcc in lstAccounts)
            {
                drparty = dtParty.NewRow();
                drparty["Name"] = objAcc.AccountName;
                drparty["Group"] = objAcc.Group;
                drparty["Op.Bal"] = objAcc.OPBal;
                drparty["Address"] = objAcc.address;
                drparty["Mobile"] = objAcc.MobileNumber;
                dtParty.Rows.Add(drparty);
            }
            cbxParty.Properties.DataSource = dtParty;
            cbxParty.Properties.DisplayMember = "Name";

            List<MaterialCentreMasterModel> lstMt = objMcBL.GetAllMaterials();
            List<string> lstMcenters = new List<string>();
            foreach (MaterialCentreMasterModel objMC in lstMt)
            {
                lstMcenters.Add(objMC.GroupName);
            }
            cbxMatcenter.Properties.DataSource = lstMcenters;
            List<PurchaseTypeModel> lstPurctypes = objPTBL.GetAllPurchaseType();
            List<string> lstPurc = new List<string>();
            foreach (PurchaseTypeModel objPurc in lstPurctypes)
            {
                lstPurc.Add(objPurc.PurchType);
            }
            cbxPurcRetType.Properties.DataSource = lstPurc;
            cbxVoucherType.Properties.DataSource = new string[] { "Main" };
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
            foreach (BillSundryMasterModel objBS in lstBillSundary)
            {
                lstbs.Add(objBS.Name);
            }
            BSLookup.DataSource = lstbs;
            BSLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            BSLookup.AutoSearchColumnIndex = 1;
            //BSLookup.ValueMember = "BillSundary";
            //BSLookup.DisplayMember = "BillSundary";
            dvgBSDetails.Columns["BillSundry"].ColumnEdit = BSLookup;
            dvgBSDetails.BestFitColumns();

            dvgItemDetails.Columns["Unit"].ColumnEdit = UnitsLookup;
            dvgItemDetails.BestFitColumns();
            dvgItemDetails.Columns["Per"].ColumnEdit = UnitsLookup;
            dvgItemDetails.BestFitColumns();
        }
        private void gdvItem_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Item")
            {
                dvgItemDetails.ShowEditor();
                ((LookUpEdit)dvgItemDetails.ActiveEditor).ShowPopup();
            }
        }

        private void gdvItem_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            PurchaseReturnVoucherModel objPurcRet = new PurchaseReturnVoucherModel();

            if (tbxVoucherNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }
            objPurcRet.VoucherType = cbxVoucherType.Text.Trim();
            objPurcRet.PR_Date = Convert.ToDateTime(dtDate.Text);
            objPurcRet.Terms = cbxTerms.SelectedItem.ToString();
            objPurcRet.VoucherNumber = Convert.ToInt64(tbxVoucherNumber.Text.Trim() == string.Empty ? "0" : tbxVoucherNumber.Text.Trim());
            objPurcRet.BillNo = Convert.ToInt64(tbxBillNo.Text.Trim() == string.Empty ? "0" : tbxBillNo.Text.Trim());
            objPurcRet.LedgerId = objAccBL.GetLedgerIdByAccountName(cbxParty.Text.Trim());
            objPurcRet.PurchaseType = cbxPurcRetType.Text.Trim() == null ? string.Empty : cbxPurcRetType.Text.Trim();
            objPurcRet.MatCenter = cbxMatcenter.Text.Trim();
            objPurcRet.Narration = tbxNarration.Text.Trim() == null ? string.Empty : tbxNarration.Text.Trim();

            objPurcRet.TotalQty = Convert.ToDecimal(colQty.SummaryItem.SummaryValue);
            objPurcRet.TotalFree = Convert.ToDecimal(colFree.SummaryItem.SummaryValue);
            objPurcRet.TotalBasicAmount = Convert.ToDecimal(colBasicAmt.SummaryItem.SummaryValue);
            objPurcRet.TotalDisAmount = Convert.ToDecimal(colDisAmt.SummaryItem.SummaryValue);
            objPurcRet.TotalTaxAmount = Convert.ToDecimal(colTaxAmt.SummaryItem.SummaryValue);
            objPurcRet.TotalAmount = Convert.ToDecimal(colAmount.SummaryItem.SummaryValue);
            objPurcRet.BSTotalAmount = Convert.ToDecimal(colBSAmount.SummaryItem.SummaryValue);

            //Items Details
            Item_VoucherModel objPurcRetItem;
            List<Item_VoucherModel> lstPurcRetItems = new List<Item_VoucherModel>();

            for (int i = 0; i < dvgItemDetails.DataRowCount; i++)
            {
                DataRow row = dvgItemDetails.GetDataRow(i);

                objPurcRetItem = new Item_VoucherModel();
                objPurcRetItem.ITM_Id = objIMBL.GetItemIdByItemName(row["Item"].ToString() == null ? string.Empty : row["Item"].ToString());
                objPurcRetItem.Qty = Convert.ToDecimal(row["Qty"].ToString() == string.Empty ? "0.00" : row["Qty"]);
                objPurcRetItem.Unit = row["Unit"].ToString() == null ? string.Empty : row["Unit"].ToString();
                objPurcRetItem.Per = row["Per"].ToString() == null ? string.Empty : row["Per"].ToString();
                objPurcRetItem.Price = Convert.ToDecimal(row["Price"].ToString() == string.Empty ? "0.00" : row["Price"].ToString());
                objPurcRetItem.Batch = row["Batch"].ToString() == null ? string.Empty : row["Batch"].ToString();
                objPurcRetItem.Free = Convert.ToDecimal(row["Free"].ToString() == string.Empty ? "0.00" : row["Free"].ToString());
                objPurcRetItem.BasicAmt = Convert.ToDecimal(row["BasicAmt"].ToString() == string.Empty ? "0.00" : row["BasicAmt"].ToString());
                objPurcRetItem.DiscountPercentage = Convert.ToDecimal(row["DiscountPercentage"].ToString() == string.Empty ? "0.00" : row["DiscountPercentage"].ToString());
                objPurcRetItem.DiscountAmount = Convert.ToDecimal(row["DiscountAmount"].ToString() == string.Empty ? "0.00" : row["DiscountAmount"].ToString());
                objPurcRetItem.TaxAmount = Convert.ToDecimal(row["TaxAmount"].ToString() == string.Empty ? "0.00" : row["TaxAmount"].ToString());
                objPurcRetItem.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());
                if(objPurcRet.PR_Id!=0)
                { 
                    objPurcRetItem.Item_ID = Convert.ToInt64(row["Item_ID"].ToString() == string.Empty ? "0" : row["Item_ID"].ToString());
                    objPurcRetItem.ParentId = Convert.ToInt64(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());
                }
                lstPurcRetItems.Add(objPurcRetItem);
            }

            objPurcRet.Item_Voucher = lstPurcRetItems;
            //Bill Sundry Details
            BillSundry_VoucherModel objPurcRetBS;
            List<BillSundry_VoucherModel> lstPurcRetBS = new List<BillSundry_VoucherModel>();
            for (int i = 0; i < dvgBSDetails.DataRowCount; i++)
            {
                DataRow row = dvgBSDetails.GetDataRow(i);

                objPurcRetBS = new BillSundry_VoucherModel();
                objPurcRetBS.BS_Id = objBSBL.GetBSIdByBSName(row["BillSundry"].ToString() == null ? string.Empty : row["BillSundry"].ToString());
                objPurcRetBS.Percentage = Convert.ToDecimal(row["Percentage"].ToString() == string.Empty ? "0.00" : row["Percentage"].ToString());
                objPurcRetBS.Extra = row["Extra"].ToString() == null ? string.Empty : row["Extra"].ToString();
                objPurcRetBS.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());

                lstPurcRetBS.Add(objPurcRetBS);
            }
            objPurcRet.BillSundry_Voucher = lstPurcRetBS;

            bool isSuccess = objPurcBL.SavePurcahseReturnVoucher(objPurcRet);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                PurcRetId = 0;
                ClearControls();
            }
        }
        private void ClearControls()
        {
            cbxVoucherType.Text = string.Empty;
            dtDate.Text = string.Empty;
            cbxTerms.SelectedItem = string.Empty;
            tbxVoucherNumber.Text = string.Empty;
            tbxBillNo.Text = string.Empty;
            cbxPurcRetType.Text = string.Empty;
            cbxParty.Text = string.Empty;
            cbxMatcenter.Text = string.Empty;
            tbxNarration.Text = string.Empty;

            dtItem.Rows.Clear();
            dtbs.Rows.Clear();
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPurcRetList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Transaction.List.PurchaseReturnVouchersList frmPurcRetList = new Transaction.List.PurchaseReturnVouchersList();
            frmPurcRetList.StartPosition = FormStartPosition.CenterParent;
            frmPurcRetList.ShowDialog();
            FillPurchaseReturnInfo();
        }
        private void FillPurchaseReturnInfo()
        {
            if (PurcRetId == 0)
            {
                cbxTerms.Focus();
                ClearControls();
                lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                return;
            }
            PurchaseReturnVoucherModel objPurcRet = objPurcBL.GetAllPurchaseVchDetailsbyId(PurcRetId);
            cbxVoucherType.Text = objPurcRet.VoucherType.ToString();
            dtDate.Text = objPurcRet.PR_Date.ToString();
            cbxTerms.SelectedItem = objPurcRet.Terms.ToString();
            tbxVoucherNumber.Text = objPurcRet.VoucherNumber.ToString();
            tbxBillNo.Text = objPurcRet.BillNo.ToString();
            cbxPurcRetType.Text = objPurcRet.PurchaseType.ToString();
            cbxParty.Text = objPurcRet.Party;
            cbxMatcenter.Text = objPurcRet.MatCenter.ToString();
            tbxNarration.Text = objPurcRet.Narration.ToString();
         
            dtItem.Rows.Clear();
            DataRow idr;
            foreach (Item_VoucherModel objItems in objPurcRet.Item_Voucher)
            {
                idr = dtItem.NewRow();

                idr["Item"] = objItems.Item;
                idr["Qty"] = objItems.Qty;
                idr["Unit"] = objItems.Unit;
                idr["Per"] = objItems.Per;
                idr["Price"] = objItems.Price;
                idr["Batch"] = objItems.Batch;
                idr["Free"] = objItems.Free;
                idr["BasicAmt"] = objItems.BasicAmt;
                idr["DiscountPercentage"] = objItems.DiscountPercentage;
                idr["DiscountAmount"] = objItems.DiscountAmount;
                idr["TaxAmount"] = objItems.TaxAmount;
                idr["Amount"] = objItems.Amount;
                idr["Item_ID"] = objItems.Item_ID;
                idr["ParentId"] = objItems.ParentId;
                dtItem.Rows.Add(idr);
            }
            dtbs.Rows.Clear();
            DataRow bsdr;
            foreach (BillSundry_VoucherModel objbs in objPurcRet.BillSundry_Voucher)
            {
                bsdr = dtbs.NewRow();
                bsdr["BillSundry"] = objbs.BillSundry;
                bsdr["Percentage"] = objbs.Percentage;
                bsdr["Extra"] = objbs.Extra;
                bsdr["Amount"] = objbs.Amount;
                bsdr["BSId"] = objbs.BSId;
                bsdr["ParentId"] = objbs.ParentId;
                dtbs.Rows.Add(bsdr);
            }
            lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PurchaseReturnVoucherModel objPurcRet = new PurchaseReturnVoucherModel();

            if (tbxVoucherNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }
            objPurcRet.VoucherType = cbxVoucherType.Text.Trim();
            objPurcRet.PR_Date = Convert.ToDateTime(dtDate.Text);
            objPurcRet.Terms = cbxTerms.SelectedItem.ToString();
            objPurcRet.VoucherNumber = Convert.ToInt64(tbxVoucherNumber.Text.Trim() == string.Empty ? "0" : tbxVoucherNumber.Text.Trim());
            objPurcRet.BillNo = Convert.ToInt64(tbxBillNo.Text.Trim() == string.Empty ? "0" : tbxBillNo.Text.Trim());
            objPurcRet.LedgerId = objAccBL.GetLedgerIdByAccountName(cbxParty.Text.Trim());
            objPurcRet.PurchaseType = cbxPurcRetType.Text.Trim() == null ? string.Empty : cbxPurcRetType.Text.Trim();
            objPurcRet.MatCenter = cbxMatcenter.Text.Trim();
            objPurcRet.Narration = tbxNarration.Text.Trim() == null ? string.Empty : tbxNarration.Text.Trim();

            objPurcRet.TotalQty = Convert.ToDecimal(colQty.SummaryItem.SummaryValue);
            objPurcRet.TotalFree = Convert.ToDecimal(colFree.SummaryItem.SummaryValue);
            objPurcRet.TotalBasicAmount = Convert.ToDecimal(colBasicAmt.SummaryItem.SummaryValue);
            objPurcRet.TotalDisAmount = Convert.ToDecimal(colDisAmt.SummaryItem.SummaryValue);
            objPurcRet.TotalTaxAmount = Convert.ToDecimal(colTaxAmt.SummaryItem.SummaryValue);
            objPurcRet.TotalAmount = Convert.ToDecimal(colAmount.SummaryItem.SummaryValue);
            objPurcRet.BSTotalAmount = Convert.ToDecimal(colBSAmount.SummaryItem.SummaryValue);

            //Items Details
            Item_VoucherModel objPurcRetItem;
            List<Item_VoucherModel> lstPurcRetItems = new List<Item_VoucherModel>();

            for (int i = 0; i < dvgItemDetails.DataRowCount; i++)
            {
                DataRow row = dvgItemDetails.GetDataRow(i);

                objPurcRetItem = new Item_VoucherModel();
                objPurcRetItem.ITM_Id = objIMBL.GetItemIdByItemName(row["Item"].ToString() == null ? string.Empty : row["Item"].ToString());
                objPurcRetItem.Qty = Convert.ToDecimal(row["Qty"].ToString() == string.Empty ? "0.00" : row["Qty"]);
                objPurcRetItem.Unit = row["Unit"].ToString() == null ? string.Empty : row["Unit"].ToString();
                objPurcRetItem.Per = row["Per"].ToString() == null ? string.Empty : row["Per"].ToString();
                objPurcRetItem.Price = Convert.ToDecimal(row["Price"].ToString() == string.Empty ? "0.00" : row["Price"].ToString());
                objPurcRetItem.Batch = row["Batch"].ToString() == null ? string.Empty : row["Batch"].ToString();
                objPurcRetItem.Free = Convert.ToDecimal(row["Free"].ToString() == string.Empty ? "0.00" : row["Free"].ToString());
                objPurcRetItem.BasicAmt = Convert.ToDecimal(row["BasicAmt"].ToString() == string.Empty ? "0.00" : row["BasicAmt"].ToString());
                objPurcRetItem.DiscountPercentage = Convert.ToDecimal(row["DiscountPercentage"].ToString() == string.Empty ? "0.00" : row["DiscountPercentage"].ToString());
                objPurcRetItem.DiscountAmount = Convert.ToDecimal(row["DiscountAmount"].ToString() == string.Empty ? "0.00" : row["DiscountAmount"].ToString());
                objPurcRetItem.TaxAmount = Convert.ToDecimal(row["TaxAmount"].ToString() == string.Empty ? "0.00" : row["TaxAmount"].ToString());
                objPurcRetItem.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());
                objPurcRetItem.Item_ID = Convert.ToInt64(row["Item_ID"].ToString() == string.Empty ? "0" : row["Item_ID"].ToString());
                objPurcRetItem.ParentId = Convert.ToInt64(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());
                
                lstPurcRetItems.Add(objPurcRetItem);
            }

            objPurcRet.Item_Voucher = lstPurcRetItems;
            //Bill Sundry Details
            BillSundry_VoucherModel objPurcRetBS;
            List<BillSundry_VoucherModel> lstPurcRetBS = new List<BillSundry_VoucherModel>();
            for (int i = 0; i < dvgBSDetails.DataRowCount; i++)
            {
                DataRow row = dvgBSDetails.GetDataRow(i);

                objPurcRetBS = new BillSundry_VoucherModel();
                objPurcRetBS.BS_Id = objBSBL.GetBSIdByBSName(row["BillSundry"].ToString() == null ? string.Empty : row["BillSundry"].ToString());
                objPurcRetBS.Percentage = Convert.ToDecimal(row["Percentage"].ToString() == string.Empty ? "0.00" : row["Percentage"].ToString());
                objPurcRetBS.Extra = row["Extra"].ToString() == null ? string.Empty : row["Extra"].ToString();
                objPurcRetBS.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());
                objPurcRetBS.BSId = Convert.ToInt64(row["BSId"].ToString() == string.Empty ? "0" : row["BSId"].ToString());
                objPurcRetBS.ParentId = Convert.ToInt64(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());

                lstPurcRetBS.Add(objPurcRetBS);
            }
            objPurcRet.BillSundry_Voucher = lstPurcRetBS;
            objPurcRet.PR_Id = PurcRetId;
            bool isSuccess = objPurcBL.UpdatePurchaseReturn(objPurcRet);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                PurcRetId = 0;
                ClearControls();
                Transaction.List.PurchaseReturnVouchersList frmPurcRetList = new Transaction.List.PurchaseReturnVouchersList();
                frmPurcRetList.StartPosition = FormStartPosition.CenterParent;
                frmPurcRetList.ShowDialog();
                FillPurchaseReturnInfo();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objPurcBL.DeletePurchaseReturn(PurcRetId);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                PurcRetId = 0;
                ClearControls();
                Transaction.List.PurchaseReturnVouchersList frmPurcRetList = new Transaction.List.PurchaseReturnVouchersList();
                frmPurcRetList.StartPosition = FormStartPosition.CenterParent;
                frmPurcRetList.ShowDialog();
                FillPurchaseReturnInfo();
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

        private void dvgBSDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void dvgBSDetails_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "BillSundry")
            {
                dvgBSDetails.ShowEditor();
                ((LookUpEdit)dvgBSDetails.ActiveEditor).ShowPopup();
            }
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

        private void btnNewEntery_ItemChanged(object sender, EventArgs e)
        {
            PurcRetId = 0;
            ClearControls();
            lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void cbxParty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar=='\r')
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
                cbxParty.Properties.DataSource = dtParty;
                cbxParty.Properties.DisplayMember = "Name";
                cbxParty.ShowPopup();
            }
        }

        private void cbxTerms_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                cbxTerms.ShowPopup();
            }
        }

        private void cbxVoucherType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                cbxVoucherType.ShowPopup();
            }
        }

        private void cbxPurcRetType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                cbxPurcRetType.ShowPopup();
            }
        }

        private void cbxMatcenter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                cbxMatcenter.ShowPopup();
            }
        }
    }
}
