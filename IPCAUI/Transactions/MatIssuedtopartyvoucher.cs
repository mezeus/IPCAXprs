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
    public partial class Matissuedtopartyvoucher : Form
    {
        eSunSpeed.BusinessLogic.MatIssuedBL objMatBL = new MatIssuedBL();
        public Matissuedtopartyvoucher()
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

        private void Matissuedtopartyvoucher_Load(object sender, EventArgs e)
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
            gdvItem.Columns["Item"].ColumnEdit = riLookup;
            gdvItem.BestFitColumns();

            //Bill Sundry Lookup Edit
            gridBs.Columns["BillSundry"].ColumnEdit = riLookup;
            gridBs.BestFitColumns();

            //Series Lookup Edit
            SeriesLookup objSeries = new SeriesLookup();
            tbxSeries.Properties.DataSource = objSeries.Series;

            //Type Lookup Edit
            tbxType.Properties.DataSource = objSeries.Series;

            //Party Lookup Edit
            tbxParty.Properties.DataSource = acc.Categories;
            tbxParty.Properties.DisplayMember = "CategoryName";
            tbxParty.Properties.ValueMember = "CategoryName";

            //Mat Centre Lookup Edit
            tbxMatcenter.Properties.DataSource = acc.Categories;
            tbxMatcenter.Properties.DisplayMember = "CategoryName";
            tbxMatcenter.Properties.ValueMember = "CategoryName";
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

        private void gdvItem_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Item")
            {
                gdvItem.ShowEditor();
                ((LookUpEdit)gdvItem.ActiveEditor).ShowPopup();
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
            if (e.FocusedColumn.FieldName == "BillSundry")
            {
                gridBs.ShowEditor();
                ((LookUpEdit)gridBs.ActiveEditor).ShowPopup();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            eSunSpeedDomain.MatIssuedModel objissue = new MatIssuedModel();

            if (tbxVchNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }

            objissue.Series = tbxSeries.Text.Trim();
            objissue.Type = tbxType.Text.Trim();
            objissue.Issued_Date = Convert.ToDateTime(dtDate.Text);
            objissue.Voucher_Number = Convert.ToInt32(tbxVchNumber.Text.Trim());
            objissue.Party = tbxParty.Text.Trim();
            objissue.MatCenter = tbxVchNumber.Text.Trim();
            objissue.Narration = tbxNarration.Text.Trim();

            objissue.TotalAmount = Convert.ToDecimal(Amount.SummaryItem.SummaryValue);
            objissue.TotalQty = Convert.ToInt32(Qty.SummaryItem.SummaryValue);

            //MatIssued Items
            Item_VoucherModel objItem;
            List<Item_VoucherModel> lstItems = new List<Item_VoucherModel>();

            for (int i = 0; i < gdvItem.DataRowCount; i++)
            {
                DataRow row = gdvItem.GetDataRow(i);
                                
                objItem = new Item_VoucherModel();
                objItem.Item = row["Item"].ToString();          
                objItem.Qty = Convert.ToDecimal(row["Qty"]);
                objItem.Unit = row["Unit"].ToString();
                objItem.Amount = Convert.ToDecimal(row["Amount"].ToString());
                objItem.Price =Convert.ToDecimal(row["Price"].ToString());            
                lstItems.Add(objItem);
            }
                                  
            objissue.IssuedItem_Voucher = lstItems;

            //Bill Sundry
            BillSundry_VoucherModel objBS;
            List<BillSundry_VoucherModel> lstBS = new List<BillSundry_VoucherModel>();

            for (int i = 0; i < gridBs.DataRowCount; i++)
            {
                DataRow row = gridBs.GetDataRow(i);

                objBS = new BillSundry_VoucherModel();
                objBS.BillSundry = row["BillSundry"].ToString();
                objBS.Narration = row["Narration"].ToString();
                objBS.Percentage = Convert.ToDecimal(row["Percentage"]);
                objBS.Amount = Convert.ToDecimal(row["Amount"]);
                objBS.Type = row["Extra"].ToString();

                lstBS.Add(objBS);
            }

            objissue.BSTotalAmount = Convert.ToDecimal(BSAmount.SummaryItem.SummaryValue);

            objissue.IssuedBillSundry_Voucher = lstBS;

            bool isSuccess = objMatBL.SaveMatIssuedVoucher(objissue);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                //   Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
                // d.ShowDialog();
            }
        }
    }
}
