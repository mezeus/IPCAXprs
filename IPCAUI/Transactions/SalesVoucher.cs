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
            tbxSeries.Focus();
            //this.tbxSeries.Enter += new System.EventHandler(this.tbxSeries_Enter);

            Models.AccountLookup acc = new Models.AccountLookup();


            // Create an in-place LookupEdit control.
            RepositoryItemLookUpEdit riLookup = new RepositoryItemLookUpEdit();

            acc.InitData();

            riLookup.DataSource = acc.Categories;
            riLookup.ValueMember = "ID";
            riLookup.DisplayMember = "CategoryName";

            // Enable the "best-fit" functionality mode in which columns have proportional widths and the popup window is resized to fit all the columns.
            riLookup.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            // Specify the dropdown height.
            riLookup.DropDownRows = acc.Categories.Count;

            // Enable the automatic completion feature. In this mode, when the dropdown is closed, 
            // the text in the edit box is automatically completed if it matches a DisplayMember field value of one of dropdown rows. 
            riLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            // Specify the column against which an incremental search is performed in SearchMode.AutoComplete and SearchMode.OnlyInPopup modes
            riLookup.AutoSearchColumnIndex = 1;

            // Optionally hide the Description column in the dropdown.
            //riLookup.PopulateColumns();
            // riLookup.Columns["Description"].Visible = false;

            // Assign the in-place LookupEdit control to the grid's CategoryID column.
            //// Note that the data types of the "ID" and "CategoryID" fields match.
            dvgItemDetails.Columns["Item"].ColumnEdit = riLookup;
            dvgItemDetails.BestFitColumns();

            ////Bill Sundry Lookup Edit
            dvgBsDetails.Columns["BillSundry"].ColumnEdit = riLookup;
            dvgBsDetails.BestFitColumns();

            //Series Lookup Edit
            //SeriesLookup objSeries = new SeriesLookup();
            tbxSeries.Properties.DataSource = new string[] { "Main" };

            //Purchase Type Lookup Edit
            tbxSaleType.Properties.DataSource = new string[] { "Main" };

            //Party Lookup Edit
            tbxParty.Properties.DataSource = acc.Categories;
            tbxParty.Properties.DisplayMember = "CategoryName";
            tbxParty.Properties.ValueMember = "CategoryName";

            //Mat Centre Lookup Edit
            tbxMatcenter.Properties.DataSource = acc.Categories;
            tbxMatcenter.Properties.DisplayMember = "CategoryName";
            tbxMatcenter.Properties.ValueMember = "CategoryName";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TransSalesModel objSaleVch = new TransSalesModel();

            if (tbxVoucherNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }

            objSaleVch.Series = tbxSeries.Text.Trim();
            objSaleVch.SaleDate = Convert.ToDateTime(dtDate.Text);
            objSaleVch.Terms = cbxTerms.SelectedItem.ToString();
            objSaleVch.VoucherNumber = Convert.ToInt64(tbxVoucherNumber.Text.Trim() == string.Empty ? "0" : tbxVoucherNumber.Text.Trim());
            objSaleVch.BillNo = Convert.ToInt64(tbxBillNo.Text.Trim() == string.Empty ? "0" : tbxBillNo.Text.Trim());
            objSaleVch.Party = tbxParty.Text.Trim();
            objSaleVch.SalesType = tbxSaleType.Text.Trim();
            objSaleVch.MatCentre = tbxMatcenter.Text.Trim();
            objSaleVch.Narration = tbxNarration.Text.Trim()==null?string.Empty :tbxNarration.Text.Trim();
            objSaleVch.TotalAmount = Convert.ToDecimal(Amount.SummaryItem.SummaryValue);
            objSaleVch.TotalQty = Convert.ToDecimal(Qty.SummaryItem.SummaryValue);
            objSaleVch.BSTotalAmount= Convert.ToDecimal(BSAmount.SummaryItem.SummaryValue);

            //Items Details
            Item_VoucherModel objSaleItem;
            List<Item_VoucherModel> lstSaleItems = new List<Item_VoucherModel>();

            for (int i = 0; i < dvgItemDetails.DataRowCount; i++)
            {
                DataRow row = dvgItemDetails.GetDataRow(i);

                objSaleItem = new Item_VoucherModel();
                objSaleItem.Item = row["Item"].ToString()==null?string.Empty: row["Item"].ToString();
                objSaleItem.Qty = Convert.ToDecimal(row["Qty"].ToString()==string.Empty?"0.00": row["Qty"]);
                objSaleItem.Unit = row["Unit"].ToString()==null?string.Empty: row["Unit"].ToString();
                objSaleItem.Amount = Convert.ToDecimal(row["Amount"].ToString()==string.Empty?"0.00":row["Amount"].ToString());
                objSaleItem.Price = Convert.ToDecimal(row["Price"].ToString()==string.Empty?"0.00": row["Price"].ToString());
                lstSaleItems.Add(objSaleItem);
            }

            objSaleVch.SalesItem_Voucher = lstSaleItems;
            //Bill Sundry
            BillSundry_VoucherModel objSaleBS;
            List<BillSundry_VoucherModel> lstSaleBS = new List<BillSundry_VoucherModel>();

            for (int i = 0; i < dvgBsDetails.DataRowCount; i++)
            {
                DataRow row = dvgBsDetails.GetDataRow(i);

                objSaleBS = new BillSundry_VoucherModel();
                objSaleBS.BillSundry = row["BillSundry"].ToString()==null?string.Empty: row["BillSundry"].ToString();
                objSaleBS.Percentage = Convert.ToDecimal(row["Percentage"].ToString()==string.Empty?"0.00":row["Percentage"].ToString());
                objSaleBS.Amount = Convert.ToDecimal(row["Amount"].ToString()==string.Empty?"0.00": row["Amount"].ToString());
                objSaleBS.Type = row["Extra"].ToString() == null ? string.Empty : row["Extra"].ToString();

                lstSaleBS.Add(objSaleBS);
            }
            objSaleVch.SalesBillSundry_Voucher = lstSaleBS;

            SalesVoucherBL objSVBL = new SalesVoucherBL();
            bool isSuccess = objSVBL.SaveSalesVoucher(objSaleVch);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }
        private void ClearControls()
        {
     
        }
        private void tbxSeries_Enter(object sender, EventArgs e)
        {
            tbxSeries.ShowPopup();
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
        }

        private void dvgBsDetails_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "BillSundary")
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
    }
}
