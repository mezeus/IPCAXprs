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
    public partial class Purhcasevoucher : Form
    {
        DataTable dtItem = new DataTable();
        DataTable dtbs = new DataTable();
        DataTable dtParty = new DataTable();
        DataTable dtItems = new DataTable();
        PurchaseVoucherBL objPurcBL = new PurchaseVoucherBL();
        AccountMasterBL objAccBL = new AccountMasterBL();
        MaterialCentreMasterBL objMcBL = new MaterialCentreMasterBL();
        ItemMasterBL objIMBL = new ItemMasterBL();
        PurchaseTypeBL objPTBL = new PurchaseTypeBL();
        BillSundryMaster objBSBL = new BillSundryMaster();
        PurchaseVoucherBL objbl = new PurchaseVoucherBL();
        RepositoryItemLookUpEdit UnitsLookup = new RepositoryItemLookUpEdit();
        public static long PurcId = 0;
        public Purhcasevoucher()
        {
            InitializeComponent();
        }

        private void Purhcasevoucher_Load(object sender, EventArgs e)
        {
            cbxTerms.Focus();
            LoadTables();
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
            cbxPurcType.Properties.DataSource = lstPurc;
            cbxVoucherType.Properties.DataSource = new string[] { "Main" };
           
        }

        private void gdvItem_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Item")
            {
                //gdvItem.ShowEditor();
                //((LookUpEdit)gdvItem.ActiveEditor).ShowPopup();
            }
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
            dvgItemMain.DataSource = dtItem;

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

        private void gridBs_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void gridBs_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PurchaseVoucherModel objPurcVch = new PurchaseVoucherModel();

            if (tbxVoucherNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }

            objPurcVch.VoucherType = cbxVoucherType.Text.Trim();
            objPurcVch.PurcDate = Convert.ToDateTime(dtDate.Text);
            objPurcVch.Terms = cbxTerms.SelectedItem.ToString();
            objPurcVch.VoucherNumber = Convert.ToInt64(tbxVoucherNumber.Text.Trim() == string.Empty ? "0" : tbxVoucherNumber.Text.Trim());
            objPurcVch.BillNo = Convert.ToInt64(tbxBillNo.Text.Trim() == string.Empty ? "0" : tbxBillNo.Text.Trim());
            objPurcVch.LedgerId =objAccBL.GetLedgerIdByAccountName(cbxParty.Text.Trim());
            objPurcVch.PurcType = cbxPurcType.Text.Trim()==null?string.Empty: cbxPurcType.Text.Trim();
            objPurcVch.MatCentre = cbxMatcenter.Text.Trim();
            objPurcVch.Narration = tbxNarration.Text.Trim() == null ? string.Empty : tbxNarration.Text.Trim();
            
            objPurcVch.TotalQty = Convert.ToDecimal(colQty.SummaryItem.SummaryValue);
            objPurcVch.TotalFree = Convert.ToDecimal(colFree.SummaryItem.SummaryValue);
            objPurcVch.TotalBasicAmount = Convert.ToDecimal(colBasicAmt.SummaryItem.SummaryValue);
            objPurcVch.TotalDisAmount = Convert.ToDecimal(colDisAmt.SummaryItem.SummaryValue);
            objPurcVch.TotalTaxAmount = Convert.ToDecimal(colTaxAmt.SummaryItem.SummaryValue);
            objPurcVch.TotalAmount = Convert.ToDecimal(colItemAmount.SummaryItem.SummaryValue);
            objPurcVch.BSTotalAmount = Convert.ToDecimal(colBSAmt.SummaryItem.SummaryValue);

            //Items Details
            Item_VoucherModel objPurcItem;
            List<Item_VoucherModel> lstPurcItems = new List<Item_VoucherModel>();

            for (int i = 0; i < dvgItemDetails.DataRowCount; i++)
            {
                DataRow row = dvgItemDetails.GetDataRow(i);

                objPurcItem = new Item_VoucherModel();
                objPurcItem.ITM_Id = objIMBL.GetItemIdByItemName(row["Item"].ToString() == null ? string.Empty : row["Item"].ToString());
                objPurcItem.Qty = Convert.ToDecimal(row["Qty"].ToString() == string.Empty ? "0.00" : row["Qty"]);
                objPurcItem.Unit = row["Unit"].ToString() == null ? string.Empty : row["Unit"].ToString();
                objPurcItem.Per = row["Per"].ToString() == null ? string.Empty : row["Per"].ToString();
                objPurcItem.Price = Convert.ToDecimal(row["Price"].ToString() == string.Empty ? "0.00" : row["Price"].ToString());
                objPurcItem.Batch = row["Batch"].ToString() == null ? string.Empty : row["Batch"].ToString();
                objPurcItem.Free = Convert.ToDecimal(row["Free"].ToString() == string.Empty ? "0.00" : row["Free"].ToString());
                objPurcItem.BasicAmt = Convert.ToDecimal(row["BasicAmt"].ToString() == string.Empty ? "0.00" : row["BasicAmt"].ToString());
                objPurcItem.DiscountPercentage = Convert.ToDecimal(row["DiscountPercentage"].ToString() == string.Empty ? "0.00" : row["DiscountPercentage"].ToString());
                objPurcItem.DiscountAmount = Convert.ToDecimal(row["DiscountAmount"].ToString() == string.Empty ? "0.00" : row["DiscountAmount"].ToString());
                objPurcItem.TaxAmount = Convert.ToDecimal(row["TaxAmount"].ToString() == string.Empty ? "0.00" : row["TaxAmount"].ToString());
                objPurcItem.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());
                if (objPurcVch.Trans_Purc_Id != 0)
                {
                    objPurcItem.Item_ID = Convert.ToInt64(row["Item_ID"].ToString() == string.Empty ? "0" : row["Item_ID"].ToString());
                    objPurcItem.ParentId = Convert.ToInt64(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());
                }
                lstPurcItems.Add(objPurcItem);
            }

            objPurcVch.Item_Voucher = lstPurcItems;
            //Bill Sundry Details
            BillSundry_VoucherModel objPurcBS;
            List<BillSundry_VoucherModel> lstPurcBS = new List<BillSundry_VoucherModel>();

            for (int i = 0; i < dvgBSDetails.DataRowCount; i++)
            {
                DataRow row = dvgBSDetails.GetDataRow(i);

                objPurcBS = new BillSundry_VoucherModel();
                objPurcBS.BS_Id = objBSBL.GetBSIdByBSName(row["BillSundry"].ToString() == null ? string.Empty : row["BillSundry"].ToString());
                objPurcBS.Percentage = Convert.ToDecimal(row["Percentage"].ToString() == string.Empty ? "0.00" : row["Percentage"].ToString());
                objPurcBS.Extra = row["Extra"].ToString() == null ? string.Empty : row["Extra"].ToString();
                objPurcBS.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());

                lstPurcBS.Add(objPurcBS);
            }
            objPurcVch.BillSundry_Voucher = lstPurcBS;

            bool isSuccess = objPurcBL.SavePurcahseVoucher(objPurcVch);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                PurcId = 0;
                ClearControls();
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PurchaseVoucherModel objPurcVch = new PurchaseVoucherModel();

            if (tbxVoucherNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }

            objPurcVch.VoucherType = cbxVoucherType.Text.Trim();
            objPurcVch.PurcDate = Convert.ToDateTime(dtDate.Text);
            objPurcVch.Terms = cbxTerms.SelectedItem.ToString();
            objPurcVch.VoucherNumber = Convert.ToInt64(tbxVoucherNumber.Text.Trim() == string.Empty ? "0" : tbxVoucherNumber.Text.Trim());
            objPurcVch.BillNo = Convert.ToInt64(tbxBillNo.Text.Trim() == string.Empty ? "0" : tbxBillNo.Text.Trim());
            objPurcVch.LedgerId = objAccBL.GetLedgerIdByAccountName(cbxParty.Text.Trim());
            objPurcVch.PurcType = cbxPurcType.Text.Trim() == null ? string.Empty : cbxPurcType.Text.Trim();
            objPurcVch.MatCentre = cbxMatcenter.Text.Trim();
            objPurcVch.Narration = tbxNarration.Text.Trim() == null ? string.Empty : tbxNarration.Text.Trim();

            objPurcVch.TotalQty = Convert.ToDecimal(colQty.SummaryItem.SummaryValue);
            objPurcVch.TotalFree = Convert.ToDecimal(colFree.SummaryItem.SummaryValue);
            objPurcVch.TotalBasicAmount = Convert.ToDecimal(colBasicAmt.SummaryItem.SummaryValue);
            objPurcVch.TotalDisAmount = Convert.ToDecimal(colDisAmt.SummaryItem.SummaryValue);
            objPurcVch.TotalTaxAmount = Convert.ToDecimal(colTaxAmt.SummaryItem.SummaryValue);
            objPurcVch.TotalAmount = Convert.ToDecimal(colItemAmount.SummaryItem.SummaryValue);
            objPurcVch.BSTotalAmount = Convert.ToDecimal(colBSAmt.SummaryItem.SummaryValue);

            //Items Details
            Item_VoucherModel objPurcItem;
            List<Item_VoucherModel> lstPurcItems = new List<Item_VoucherModel>();

            for (int i = 0; i < dvgItemDetails.DataRowCount; i++)
            {
                DataRow row = dvgItemDetails.GetDataRow(i);

                objPurcItem = new Item_VoucherModel();
                objPurcItem.ITM_Id = objIMBL.GetItemIdByItemName(row["Item"].ToString() == null ? string.Empty : row["Item"].ToString());
                objPurcItem.Qty = Convert.ToDecimal(row["Qty"].ToString() == string.Empty ? "0.00" : row["Qty"]);
                objPurcItem.Unit = row["Unit"].ToString() == null ? string.Empty : row["Unit"].ToString();
                objPurcItem.Per = row["Per"].ToString() == null ? string.Empty : row["Per"].ToString();
                objPurcItem.Price = Convert.ToDecimal(row["Price"].ToString() == string.Empty ? "0.00" : row["Price"].ToString());
                objPurcItem.Batch = row["Batch"].ToString() == null ? string.Empty : row["Batch"].ToString();
                objPurcItem.Free = Convert.ToDecimal(row["Free"].ToString() == string.Empty ? "0.00" : row["Free"].ToString());
                objPurcItem.BasicAmt = Convert.ToDecimal(row["BasicAmt"].ToString() == string.Empty ? "0.00" : row["BasicAmt"].ToString());
                objPurcItem.DiscountPercentage = Convert.ToDecimal(row["DiscountPercentage"].ToString() == string.Empty ? "0.00" : row["DiscountPercentage"].ToString());
                objPurcItem.DiscountAmount = Convert.ToDecimal(row["DiscountAmount"].ToString() == string.Empty ? "0.00" : row["DiscountAmount"].ToString());
                objPurcItem.TaxAmount = Convert.ToDecimal(row["TaxAmount"].ToString() == string.Empty ? "0.00" : row["TaxAmount"].ToString());
                objPurcItem.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());
                objPurcItem.Item_ID = Convert.ToInt64(row["Item_ID"].ToString() == string.Empty ? "0" : row["Item_ID"].ToString());
                objPurcItem.ParentId = Convert.ToInt64(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());
                
                lstPurcItems.Add(objPurcItem);
            }

            objPurcVch.Item_Voucher = lstPurcItems;
            //Bill Sundry Details
            BillSundry_VoucherModel objPurcBS;
            List<BillSundry_VoucherModel> lstPurcBS = new List<BillSundry_VoucherModel>();

            for (int i = 0; i < dvgBSDetails.DataRowCount; i++)
            {
                DataRow row = dvgBSDetails.GetDataRow(i);

                objPurcBS = new BillSundry_VoucherModel();
                objPurcBS.BS_Id = objBSBL.GetBSIdByBSName(row["BillSundry"].ToString() == null ? string.Empty : row["BillSundry"].ToString());
                objPurcBS.Percentage = Convert.ToDecimal(row["Percentage"].ToString() == string.Empty ? "0.00" : row["Percentage"].ToString());
                objPurcBS.Extra = row["Extra"].ToString() == null ? string.Empty : row["Extra"].ToString();
                objPurcBS.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());
                objPurcBS.BSId = Convert.ToInt64(row["BSID"].ToString() == string.Empty ? "0" : row["BSID"].ToString());
                objPurcBS.ParentId = Convert.ToInt64(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());
                lstPurcBS.Add(objPurcBS);
            }
            objPurcVch.BillSundry_Voucher = lstPurcBS;
            objPurcVch.Trans_Purc_Id = PurcId;
            bool isSuccess = objPurcBL.UpdatePurchaseVoucher(objPurcVch);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                PurcId = 0;
                ClearControls();
                Transaction.List.PurchaseVouchersList frmPurcVchList = new Transaction.List.PurchaseVouchersList();
                frmPurcVchList.StartPosition = FormStartPosition.CenterParent;
                frmPurcVchList.ShowDialog();
                FillPurchaseVoucherInfo();
            }
        }

        private void btnPurcVchList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Transaction.List.PurchaseVouchersList frmPurcVchList = new Transaction.List.PurchaseVouchersList();
            frmPurcVchList.StartPosition = FormStartPosition.CenterParent;
            frmPurcVchList.ShowDialog();
            FillPurchaseVoucherInfo();
        }
        private void FillPurchaseVoucherInfo()
        {
            if (PurcId == 0)
            {
                cbxTerms.Focus();
                lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                return;
            }
            PurchaseVoucherModel objPurcVch = objPurcBL.GetAllPurchaseVchDetailsbyId(PurcId);
            cbxVoucherType.Text = objPurcVch.VoucherType.ToString();
            dtDate.Text = objPurcVch.PurcDate.ToString();
            cbxTerms.SelectedItem = objPurcVch.Terms.ToString();
            tbxVoucherNumber.Text = objPurcVch.VoucherNumber.ToString();
            tbxBillNo.Text = objPurcVch.BillNo.ToString();
            cbxPurcType.Text = objPurcVch.PurcType.ToString();
            cbxParty.Text = objPurcVch.Party;
            cbxMatcenter.Text = objPurcVch.MatCentre.ToString();
            tbxNarration.Text = objPurcVch.Narration.ToString();
            //Qty.SummaryItem= objSaleVch.TotalQty.ToString();
            //objSaleVch.TotalAmount = Convert.ToDecimal(dr["TotalAmount"].ToString());
            //objSaleVch.BSTotalAmount = Convert.ToDecimal(dr["BSTotalAmount"]);
            //dvgMainItem.DataSource = objSaleVch.SalesItem_Voucher;
            //dvgBSMain.DataSource = objSaleVch.SalesBillSundry_Voucher;
            dtItem.Rows.Clear();
            DataRow idr;
            foreach (Item_VoucherModel objItems in objPurcVch.Item_Voucher)
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
            foreach (BillSundry_VoucherModel objbs in objPurcVch.BillSundry_Voucher)
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
            cbxTerms.Focus();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objPurcBL.DeletePurchaseVoucher(PurcId);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                PurcId = 0;
                ClearControls();
                Transaction.List.PurchaseVouchersList frmPurcVchList = new Transaction.List.PurchaseVouchersList();
                frmPurcVchList.StartPosition = FormStartPosition.CenterParent;
                frmPurcVchList.ShowDialog();
                FillPurchaseVoucherInfo();
            }
        }
        private void ClearControls()
        {
            cbxVoucherType.Text = string.Empty;
            dtDate.Text = string.Empty;
            cbxTerms.SelectedItem = string.Empty;
            tbxVoucherNumber.Text = string.Empty;
            tbxBillNo.Text = string.Empty;
            cbxPurcType.Text = string.Empty;
            cbxParty.Text = string.Empty;
            cbxMatcenter.Text = string.Empty;
            tbxNarration.Text = string.Empty;

            dtItem.Rows.Clear();
            dtbs.Rows.Clear();
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
            if(e.FocusedColumn.FieldName=="Unit" || e.FocusedColumn.FieldName=="Per")
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

        private void cbxParty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar!='\r')
            {
                cbxParty.ShowPopup();
            }
        }

        private void cbxMatcenter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                cbxMatcenter.ShowPopup();
            }
        }

        private void dvgItemDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.Caption=="Item")
            {
                List<ItemMasterModel> lstItems = objIMBL.GetItemsByName(e.Value.ToString());
                List<string> lstUnits = new List<string>();
                foreach(ItemMasterModel objUnits in lstItems)
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
    }
}
