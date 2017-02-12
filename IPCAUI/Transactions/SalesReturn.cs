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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace IPCAUI.Transactions
{
    public partial class SalesReturn : Form
    {
        DataTable dtItem = new DataTable();
        DataTable dtbs = new DataTable();
        DataTable dtParty = new DataTable();
        DataTable dtItems = new DataTable();
        SalesReturnVoucherBL objSRBL = new SalesReturnVoucherBL();
        AccountMasterBL objAccBL = new AccountMasterBL();
        MaterialCentreMasterBL objMcBL = new MaterialCentreMasterBL();
        ItemMasterBL objIMBL = new ItemMasterBL();
        SaleTypeBL objStBL = new SaleTypeBL();
        BillSundryMaster objBSBL = new BillSundryMaster();
        RepositoryItemLookUpEdit UnitsLookup = new RepositoryItemLookUpEdit();
        public static long SalesRetId = 0;
        public SalesReturn()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TransSalesModel objSaleRet = new TransSalesModel();

            if (tbxVoucherNo.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }

            objSaleRet.VoucherType = cbxVoucherType.Text.Trim();
            objSaleRet.SaleDate = Convert.ToDateTime(dtDate.Text);
            objSaleRet.Terms = cbxTerms.SelectedItem.ToString();
            objSaleRet.VoucherNumber = Convert.ToInt64(tbxVoucherNo.Text.Trim() == string.Empty ? "0" : tbxVoucherNo.Text.Trim());
            objSaleRet.BillNo = Convert.ToInt64(tbxBillNo.Text.Trim() == string.Empty ? "0" : tbxBillNo.Text.Trim());
            objSaleRet.LedgerId = objAccBL.GetLedgerIdByAccountName(cbxParty.Text.Trim());
            objSaleRet.SalesType = cbxSaleType.Text.Trim();
            objSaleRet.MatCentre = cbxMatCenter.Text.Trim();
            objSaleRet.PriceList = cbxPriceList.Text.Trim();
            objSaleRet.Narration = tbxNarration.Text.Trim() == null ? string.Empty : tbxNarration.Text.Trim();
            objSaleRet.TotalAmount = Convert.ToDecimal(colAmount.SummaryItem.SummaryValue);
            objSaleRet.TotalFree = Convert.ToDecimal(colFree.SummaryItem.SummaryValue);
            objSaleRet.TotalBasicAmount = Convert.ToDecimal(colBasicAmt.SummaryItem.SummaryValue);
            objSaleRet.TotalDisAmount = Convert.ToDecimal(colDisAmt.SummaryItem.SummaryValue);
            objSaleRet.TotalTaxAmount = Convert.ToDecimal(colTaxAmont.SummaryItem.SummaryValue);
            objSaleRet.TotalQty = Convert.ToDecimal(Qty.SummaryItem.SummaryValue);
            objSaleRet.BSTotalAmount = Convert.ToDecimal(colBSAmount.SummaryItem.SummaryValue);

            //Items Details
            Item_VoucherModel objSaleRetItem;
            List<Item_VoucherModel> lstSaleRetItems = new List<Item_VoucherModel>();

            for (int i = 0; i < dvgItemDetails.DataRowCount; i++)
            {
                DataRow row = dvgItemDetails.GetDataRow(i);

                objSaleRetItem = new Item_VoucherModel();
                objSaleRetItem.ITM_Id = objIMBL.GetItemIdByItemName(row["Item"].ToString() == null ? string.Empty : row["Item"].ToString());
                objSaleRetItem.Qty = Convert.ToDecimal(row["Qty"].ToString() == string.Empty ? "0.00" : row["Qty"]);
                objSaleRetItem.Unit = row["Unit"].ToString() == null ? string.Empty : row["Unit"].ToString();
                objSaleRetItem.Per = row["Per"].ToString() == null ? string.Empty : row["Per"].ToString();
                objSaleRetItem.Price = Convert.ToDecimal(row["Price"].ToString() == string.Empty ? "0.00" : row["Price"].ToString());
                objSaleRetItem.Batch = row["Batch"].ToString() == null ? string.Empty : row["Batch"].ToString();
                objSaleRetItem.Free = Convert.ToDecimal(row["Free"].ToString() == string.Empty ? "0.00" : row["Free"].ToString());
                objSaleRetItem.BasicAmt = Convert.ToDecimal(row["BasicAmt"].ToString() == string.Empty ? "0.00" : row["BasicAmt"].ToString());
                objSaleRetItem.DiscountPercentage = Convert.ToDecimal(row["DiscountPercentage"].ToString() == string.Empty ? "0.00" : row["DiscountPercentage"].ToString());
                objSaleRetItem.DiscountAmount = Convert.ToDecimal(row["DiscountAmount"].ToString() == string.Empty ? "0.00" : row["DiscountAmount"].ToString());
                objSaleRetItem.TaxAmount = Convert.ToDecimal(row["TaxAmount"].ToString() == string.Empty ? "0.00" : row["TaxAmount"].ToString());
                objSaleRetItem.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());
                if (objSaleRet.Trans_Sales_Id != 0)
                {
                    objSaleRetItem.Item_ID = Convert.ToInt64(row["Item_ID"].ToString() == string.Empty ? "0" : row["Item_ID"].ToString());
                    objSaleRetItem.ParentId = Convert.ToInt64(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());
                }
                lstSaleRetItems.Add(objSaleRetItem);
            }

            objSaleRet.SalesItem_Voucher = lstSaleRetItems;
            //Bill Sundry Details
            BillSundry_VoucherModel objSaleRetBS;
            List<BillSundry_VoucherModel> lstSaleRetBS = new List<BillSundry_VoucherModel>();

            for (int i = 0; i < dvgBsDetails.DataRowCount; i++)
            {
                DataRow row = dvgBsDetails.GetDataRow(i);

                objSaleRetBS = new BillSundry_VoucherModel();
                objSaleRetBS.BS_Id = objBSBL.GetBSIdByBSName(row["BillSundry"].ToString() == null ? string.Empty : row["BillSundry"].ToString());
                objSaleRetBS.Percentage = Convert.ToDecimal(row["Percentage"].ToString() == string.Empty ? "0.00" : row["Percentage"].ToString());
                objSaleRetBS.Extra = row["Extra"].ToString() == null ? string.Empty : row["Extra"].ToString();
                objSaleRetBS.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());

                lstSaleRetBS.Add(objSaleRetBS);
            }
            objSaleRet.SalesBillSundry_Voucher = lstSaleRetBS;

            bool isSuccess = objSRBL.SaveSalesReturn(objSaleRet);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                SalesRetId = 0;
                ClearControls();
            }
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

        private void SalesReturn_Load(object sender, EventArgs e)
        {
            LoadTables();
            cbxTerms.Focus();
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlUpadet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            //tbxParty.Properties.BestFitMode= DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            List<MaterialCentreMasterModel> lstMt = objMcBL.GetAllMaterials();
            List<string> lstMcenters = new List<string>();
            foreach (MaterialCentreMasterModel objMC in lstMt)
            {
                lstMcenters.Add(objMC.GroupName);
            }
            cbxMatCenter.Properties.DataSource = lstMcenters;

            List<SaleTypeModel> lstSalestypes = objStBL.GetAllSaleType();
            cbxSaleType.Properties.Items.Clear();
            foreach (SaleTypeModel objSale in lstSalestypes)
            {
                cbxSaleType.Properties.Items.Add(objSale.SalesType);
            }
            LoadGridColumns();
            cbxVoucherType.Properties.DataSource = new string[] { "Main" };
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
            dvgBsDetails.Columns["BillSundry"].ColumnEdit = BSLookup;
            dvgBsDetails.BestFitColumns();
            dvgItemDetails.Columns["Unit"].ColumnEdit = UnitsLookup;
            dvgItemDetails.BestFitColumns();
            dvgItemDetails.Columns["Per"].ColumnEdit = UnitsLookup;
            dvgItemDetails.BestFitColumns();
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
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dvgItemDetails_ColumnChanged(object sender, EventArgs e)
        {
            
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

        private void dvgBsDetails_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "BillSundry")
            {
                dvgBsDetails.ShowEditor();
                ((LookUpEdit)dvgBsDetails.ActiveEditor).ShowPopup();

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

        private void btnSaleRetList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Transaction.List.SalesReturnVouchersList frmList = new Transaction.List.SalesReturnVouchersList();
            frmList.StartPosition = FormStartPosition.CenterParent;
            frmList.ShowDialog();
            FillSalesReturnInfo();
        }
        private void FillSalesReturnInfo()
        {
            if (SalesRetId == 0)
            {
                cbxTerms.Focus();
                lactrlUpadet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                return;
            }
            TransSalesModel objSaleVch = objSRBL.GetAllSaleReturnbyId(SalesRetId);
            cbxVoucherType.Text = objSaleVch.VoucherType.ToString();
            dtDate.Text = objSaleVch.SaleDate.ToString();
            cbxTerms.SelectedItem = objSaleVch.Terms.ToString();
            tbxVoucherNo.Text = objSaleVch.VoucherNumber.ToString();
            tbxBillNo.Text = objSaleVch.BillNo.ToString();
            cbxSaleType.Text = objSaleVch.SalesType.ToString();
            cbxParty.Text = objSaleVch.Party;
            cbxMatCenter.Text = objSaleVch.MatCentre.ToString();
            tbxNarration.Text = objSaleVch.Narration.ToString();
            //Qty.SummaryItem= objSaleVch.TotalQty.ToString();
            //objSaleVch.TotalAmount = Convert.ToDecimal(dr["TotalAmount"].ToString());
            //objSaleVch.BSTotalAmount = Convert.ToDecimal(dr["BSTotalAmount"]);
            cbxPriceList.Text = objSaleVch.PriceList.ToString();
            //dvgMainItem.DataSource = objSaleVch.SalesItem_Voucher;
            //dvgBSMain.DataSource = objSaleVch.SalesBillSundry_Voucher;
            dtItem.Rows.Clear();
            DataRow idr;
            foreach (Item_VoucherModel objItems in objSaleVch.SalesItem_Voucher)
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
            foreach (BillSundry_VoucherModel objbs in objSaleVch.SalesBillSundry_Voucher)
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
            lactrlUpadet.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            cbxTerms.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TransSalesModel objSaleRet = new TransSalesModel();

            if (tbxVoucherNo.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }

            objSaleRet.VoucherType = cbxVoucherType.Text.Trim();
            objSaleRet.SaleDate = Convert.ToDateTime(dtDate.Text);
            objSaleRet.Terms = cbxTerms.SelectedItem.ToString();
            objSaleRet.VoucherNumber = Convert.ToInt64(tbxVoucherNo.Text.Trim() == string.Empty ? "0" : tbxVoucherNo.Text.Trim());
            objSaleRet.BillNo = Convert.ToInt64(tbxBillNo.Text.Trim() == string.Empty ? "0" : tbxBillNo.Text.Trim());
            objSaleRet.LedgerId = objAccBL.GetLedgerIdByAccountName(cbxParty.Text.Trim());
            objSaleRet.SalesType = cbxSaleType.Text.Trim();
            objSaleRet.MatCentre = cbxMatCenter.Text.Trim();
            objSaleRet.PriceList = cbxPriceList.Text.Trim();
            objSaleRet.Narration = tbxNarration.Text.Trim() == null ? string.Empty : tbxNarration.Text.Trim();
            objSaleRet.TotalAmount = Convert.ToDecimal(colAmount.SummaryItem.SummaryValue);
            objSaleRet.TotalFree = Convert.ToDecimal(colFree.SummaryItem.SummaryValue);
            objSaleRet.TotalBasicAmount = Convert.ToDecimal(colBasicAmt.SummaryItem.SummaryValue);
            objSaleRet.TotalDisAmount = Convert.ToDecimal(colDisAmt.SummaryItem.SummaryValue);
            objSaleRet.TotalTaxAmount = Convert.ToDecimal(colTaxAmont.SummaryItem.SummaryValue);
            objSaleRet.TotalQty = Convert.ToDecimal(Qty.SummaryItem.SummaryValue);
            objSaleRet.BSTotalAmount = Convert.ToDecimal(colBSAmount.SummaryItem.SummaryValue);

            //Items Details
            Item_VoucherModel objSaleRetItem;
            List<Item_VoucherModel> lstSaleRetItems = new List<Item_VoucherModel>();

            for (int i = 0; i < dvgItemDetails.DataRowCount; i++)
            {
                DataRow row = dvgItemDetails.GetDataRow(i);

                objSaleRetItem = new Item_VoucherModel();
                objSaleRetItem.ITM_Id = objIMBL.GetItemIdByItemName(row["Item"].ToString() == null ? string.Empty : row["Item"].ToString());
                objSaleRetItem.Qty = Convert.ToDecimal(row["Qty"].ToString() == string.Empty ? "0.00" : row["Qty"]);
                objSaleRetItem.Unit = row["Unit"].ToString() == null ? string.Empty : row["Unit"].ToString();
                objSaleRetItem.Per = row["Per"].ToString() == null ? string.Empty : row["Per"].ToString();
                objSaleRetItem.Price = Convert.ToDecimal(row["Price"].ToString() == string.Empty ? "0.00" : row["Price"].ToString());
                objSaleRetItem.Batch = row["Batch"].ToString() == null ? string.Empty : row["Batch"].ToString();
                objSaleRetItem.Free = Convert.ToDecimal(row["Free"].ToString() == string.Empty ? "0.00" : row["Free"].ToString());
                objSaleRetItem.BasicAmt = Convert.ToDecimal(row["BasicAmt"].ToString() == string.Empty ? "0.00" : row["BasicAmt"].ToString());
                objSaleRetItem.DiscountPercentage = Convert.ToDecimal(row["DiscountPercentage"].ToString() == string.Empty ? "0.00" : row["DiscountPercentage"].ToString());
                objSaleRetItem.DiscountAmount = Convert.ToDecimal(row["DiscountAmount"].ToString() == string.Empty ? "0.00" : row["DiscountAmount"].ToString());
                objSaleRetItem.TaxAmount = Convert.ToDecimal(row["TaxAmount"].ToString() == string.Empty ? "0.00" : row["TaxAmount"].ToString());
                objSaleRetItem.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());
                
                objSaleRetItem.Item_ID = Convert.ToInt64(row["Item_ID"].ToString() == string.Empty ? "0" : row["Item_ID"].ToString());
                objSaleRetItem.ParentId = Convert.ToInt64(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());
                
                lstSaleRetItems.Add(objSaleRetItem);
            }

            objSaleRet.SalesItem_Voucher = lstSaleRetItems;
            //Bill Sundry Details
            BillSundry_VoucherModel objSaleRetBS;
            List<BillSundry_VoucherModel> lstSaleRetBS = new List<BillSundry_VoucherModel>();

            for (int i = 0; i < dvgBsDetails.DataRowCount; i++)
            {
                DataRow row = dvgBsDetails.GetDataRow(i);

                objSaleRetBS = new BillSundry_VoucherModel();
                objSaleRetBS.BS_Id = objBSBL.GetBSIdByBSName(row["BillSundry"].ToString() == null ? string.Empty : row["BillSundry"].ToString());
                objSaleRetBS.Percentage = Convert.ToDecimal(row["Percentage"].ToString() == string.Empty ? "0.00" : row["Percentage"].ToString());
                objSaleRetBS.Extra = row["Extra"].ToString() == null ? string.Empty : row["Extra"].ToString();
                objSaleRetBS.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());
                objSaleRetBS.BSId = Convert.ToInt64(row["BSId"].ToString() == string.Empty ? "0" : row["BSId"].ToString());
                objSaleRetBS.ParentId = Convert.ToInt64(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());
                lstSaleRetBS.Add(objSaleRetBS);
            }
            objSaleRet.SalesBillSundry_Voucher = lstSaleRetBS;
            objSaleRet.Trans_Sales_Id = SalesRetId;

            bool isSuccess = objSRBL.UpdateSalesReturnMaster(objSaleRet);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                SalesRetId = 0;
                ClearControls();
                Transaction.List.SalesReturnVouchersList frmList = new Transaction.List.SalesReturnVouchersList();
                frmList.StartPosition = FormStartPosition.CenterParent;
                frmList.ShowDialog();
                FillSalesReturnInfo();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objSRBL.DeleteSalesReturn(SalesRetId);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                SalesRetId = 0;
                ClearControls();
                Transaction.List.SalesReturnVouchersList frmList = new Transaction.List.SalesReturnVouchersList();
                frmList.StartPosition = FormStartPosition.CenterParent;
                frmList.ShowDialog();
                FillSalesReturnInfo();
            }
        }
        private void ClearControls()
        {
            cbxVoucherType.Text = string.Empty;
            dtDate.Text = string.Empty;
            cbxTerms.Text = string.Empty;
            tbxVoucherNo.Text = string.Empty;
            tbxBillNo.Text = string.Empty;
            cbxSaleType.Text = string.Empty;
            cbxParty.Text = string.Empty;
            cbxMatCenter.Text = string.Empty;
            tbxNarration.Text = string.Empty;
            cbxPriceList.Text = string.Empty;
            dtItem.Rows.Clear();
            dtbs.Rows.Clear();
        }

        private void dvgMainItem_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void cbxParty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                dtParty.Rows.Clear();
                DataRow drparty;
                List<AccountMasterModel> lstAccounts = objAccBL.GetListofAccount();
                foreach (AccountMasterModel objAcc in lstAccounts)
                {
                    if(objAcc.AccGroupId == 85 || objAcc.AccGroupId == 86)
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

        private void cbxMatCenter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                cbxMatCenter.ShowPopup();
            }
        }

        private void cbxSaleType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                cbxSaleType.ShowPopup();
            }
        }

        private void cbxPriceList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                cbxPriceList.ShowPopup();
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
    }
}
