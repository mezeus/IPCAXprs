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
    public partial class StockJournalvoucher : Form
    {
        eSunSpeed.BusinessLogic.StockJournalBL objSJBL = new StockJournalBL();
        public StockJournalvoucher()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void StockJournalvoucher_Load(object sender, EventArgs e)
        {
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
            // riLookup.PopulateColumns();
            // riLookup.Columns["Description"].Visible = false;

            // Assign the in-place LookupEdit control to the grid's CategoryID column.
            //// Note that the data types of the "ID" and "CategoryID" fields match.
            gdvItemIG.Columns["Item"].ColumnEdit = riLookup;
            gdvItemIG.BestFitColumns();

            gdvItemIC.Columns["Item"].ColumnEdit = riLookup;
            gdvItemIC.BestFitColumns();

            //Bill Sundry Lookup Edit
            //gridBs.Columns["BillSundry"].ColumnEdit = riLookup;
            //gridBs.BestFitColumns();

            //Series Lookup Edit
            SeriesLookup objSeries = new SeriesLookup();
            tbxSeries.Properties.DataSource = objSeries.Series;

            //Productin matecenter Lookup Edit
            tbxMatcenterIC.Properties.DataSource = objSeries.Series;
            tbxMatcenterIG.Properties.DataSource = objSeries.Series;
        }

        private void gdvItemIG_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void gdvItemIG_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Item")
            {
                gdvItemIG.ShowEditor();
                ((LookUpEdit)gdvItemIG.ActiveEditor).ShowPopup();
            }
        }

        private void gdvItemIC_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void gdvItemIC_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Item")
            {
                gdvItemIC.ShowEditor();
                ((LookUpEdit)gdvItemIC.ActiveEditor).ShowPopup();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            eSunSpeedDomain.StockJournalModel objjournal = new eSunSpeedDomain.StockJournalModel();

            if (tbxVoucherNo.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }

            objjournal.Series = tbxSeries.Text.Trim();
            objjournal.SJ_Date = Convert.ToDateTime(dtDate.Text);
            objjournal.Voucher_Number = Convert.ToInt32(tbxVoucherNo.Text.Trim());
            objjournal.MatCenterIC = tbxMatcenterIC.Text.Trim();
            objjournal.MatCenterIG = tbxMatcenterIG.Text.Trim();
            objjournal.Narration = tbxNarration.Text.Trim();

            objjournal.TotalAmountIG = Convert.ToDecimal(Amount.SummaryItem.SummaryValue);
            objjournal.TotalQtyIG = Convert.ToInt32(Qty.SummaryItem.SummaryValue);

            //Item Generated Details
            Item_VoucherModel objItem;
            List<Item_VoucherModel> lstItems = new List<Item_VoucherModel>();

            for (int i = 0; i < gdvItemIG.DataRowCount; i++)
            {
                DataRow row = gdvItemIG.GetDataRow(i);

                objItem = new Item_VoucherModel();
                objItem.Item = row["Item"].ToString();

                objItem.Qty = Convert.ToDecimal(row["Qty"]);
                objItem.Unit = row["Unit"].ToString();
                objItem.Amount = Convert.ToDecimal(row["Amount"].ToString());
                objItem.Price = Convert.ToDecimal(row["Price"].ToString());
                lstItems.Add(objItem);
            }

            objjournal.Item_Generated = lstItems;

            //Item Consumed Details
            ItemConsumedModel objItemCon;
            List<ItemConsumedModel> lstItemConsumed = new List<ItemConsumedModel>();

            for (int i = 0; i < gdvItemIG.DataRowCount; i++)
            {
                DataRow row = gdvItemIG.GetDataRow(i);

                objItemCon = new ItemConsumedModel();

                objItemCon.Item = row["Item"].ToString();
                objItemCon.Qty = Convert.ToDecimal(row["Qty"]);
                objItemCon.Unit = row["Unit"].ToString();
                objItemCon.Amount = Convert.ToDecimal(row["Amount"].ToString());
                objItemCon.Price = Convert.ToDecimal(row["Price"].ToString());
                lstItemConsumed.Add(objItemCon);
            }

            objjournal.Item_Consumed = lstItemConsumed;

            //objProdu.TotalQtyIG = Convert.ToDecimal(BSAmount.SummaryItem.SummaryValue);

            //objSales.SalesBillSundry_Voucher = lstBS;

            bool isSuccess = objSJBL.SaveStockJournalMaster(objjournal);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                //   Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
                // d.ShowDialog();
            }
        }
    }
}
