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
        PurchaseVoucherBL objbl = new PurchaseVoucherBL();
        public Purhcasevoucher()
        {
            InitializeComponent();
        }

        private void Purhcasevoucher_Load(object sender, EventArgs e)
        {
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
            //gdvItem.Columns["Item"].ColumnEdit = riLookup;
            //gdvItem.BestFitColumns();

            //////Bill Sundry Lookup Edit
            //gridBs.Columns["BillSundry"].ColumnEdit = riLookup;
            //gridBs.BestFitColumns();

            //Series Lookup Edit
            SeriesLookup objSeries = new SeriesLookup();
            cbxVoucherType.Properties.DataSource = objSeries.Series;

            //Purchase Type Lookup Edit
            cbxPurcType.Properties.DataSource = objSeries.Series;

            //Party Lookup Edit
            cbxParty.Properties.DataSource = acc.Categories;
            cbxParty.Properties.DisplayMember = "CategoryName";
            cbxParty.Properties.ValueMember = "CategoryName";

            //Mat Centre Lookup Edit
            cbxMatcenter.Properties.DataSource = acc.Categories;
            cbxMatcenter.Properties.DisplayMember = "CategoryName";
            cbxMatcenter.Properties.ValueMember = "CategoryName";
        }

        private void gdvItem_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Item")
            {
                //gdvItem.ShowEditor();
                //((LookUpEdit)gdvItem.ActiveEditor).ShowPopup();
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
            //PurchaseVoucherMainModel objPurc = new PurchaseVoucherMainModel();

            //if (tbxVoucherNumber.Text.Trim() == "")
            //{
            //    MessageBox.Show("Voucher Number Can Not Be Blank!");
            //    return;
            //}

            //objPurc.PurchaseVoucher_Series = cbxVoucherType.Text.Trim();
            //objPurc.PurchaseVoucher_PurchaseType = cbxPurcType.Text.Trim();
            //objPurc.PurchaseVoucher_Date = Convert.ToDateTime(dtDate.Text);
            //objPurc.PurchaseVoucher_Number = Convert.ToInt32(tbxVoucherNumber.Text.Trim());
            //objPurc.PurchaseVoucher_Party = cbxParty.Text.Trim();
            //objPurc.PurchaseVoucher_MatCenter = cbxMatcenter.Text.Trim();
            //objPurc.Narration = tbxNarration.Text.Trim();

            //objPurc.TotalAmount = Convert.ToDecimal(Amount.SummaryItem.SummaryValue);
            //objPurc.TotalQty = Convert.ToInt32(Qty.SummaryItem.SummaryValue);

            ////Bill Number and Due date not captured- check with Ravi if these are required


            ////Items
            //Item_VoucherModel objItem;
            //List<Item_VoucherModel> lstItems = new List<Item_VoucherModel>();

            //for (int i = 0; i < gdvItem.DataRowCount; i++)
            //{
            //    DataRow row = gdvItem.GetDataRow(i);

            //    objItem = new Item_VoucherModel();
            //    objItem.Item = row["Item"].ToString();

            //    objItem.Qty = Convert.ToDecimal(row["Qty"]);
            //    objItem.Unit = row["Unit"].ToString();
            //    objItem.Amount = Convert.ToDecimal(row["Amount"].ToString());
            //    objItem.Price = Convert.ToDecimal(row["Price"].ToString());
            //    lstItems.Add(objItem);
            //}

            //objPurc.PurchaseItem_Voucher = lstItems;

            ////Bill Sundry
            //BillSundry_VoucherModel objBS;
            //List<BillSundry_VoucherModel> lstBS = new List<BillSundry_VoucherModel>();

            //for (int i = 0; i < gridBs.DataRowCount; i++)
            //{
            //    DataRow row = gridBs.GetDataRow(i);

            //    objBS = new BillSundry_VoucherModel();
            //    objBS.BillSundry = row["BillSundry"].ToString();
            //    objBS.Percentage = Convert.ToDecimal(row["Percentage"]);
            //    objBS.Amount = Convert.ToDecimal(row["Amount"]);
            //    objBS.Type = row["Extra"].ToString();

            //    lstBS.Add(objBS);
            //}

            //objPurc.BSTotalAmount = Convert.ToDecimal(BSAmount.SummaryItem.SummaryValue);

            //objPurc.BillSundry_Voucher = lstBS;

            ////objSalesVoucher = new SalesVoucherBL();

            //bool isSuccess = objbl.SavePurchaseVoucher(objPurc);
            //if (isSuccess)
            //{
            //    MessageBox.Show("Saved Successfully!");
            //    //   Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //    // d.ShowDialog();
            //}
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
