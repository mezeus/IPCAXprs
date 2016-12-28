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
    public partial class formsissuedvoucher : Form
    {
        IssuedVoucherBL objibl = new IssuedVoucherBL();
        public formsissuedvoucher()
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

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void formsissuedvoucher_Load(object sender, EventArgs e)
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

            //Series Lookup Edit
            SeriesLookup objSeries = new SeriesLookup();
            tbxForm.Properties.DataSource = objSeries.Series;

            //Party Lookup Edit
            tbxParty.Properties.DataSource = objSeries.Series;

        }

        private void gdvFormsIssued_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
            IssuedVoucherModel objissued = new IssuedVoucherModel();

            //if (tbxVchNo.Text.Trim() == "")
            //{
            //    MessageBox.Show("Voucher Number Can Not Be Blank!");
            //    return;
            //}

            objissued.Date = Convert.ToDateTime(dtDate.Text);
            objissued.From = tbxForm.Text.Trim();
            objissued.fromNo= Convert.ToInt32(tbxFormnumber.Text);
            objissued.Authourity = Convert.ToDateTime(dtAuthority.Text.Trim());
            objissued.party = tbxParty.Text.Trim();
            objissued.Narration = tbxNarration.Text.Trim();

            //objissued.TotalAmount = Convert.ToDecimal(Amount.SummaryItem.SummaryValue);
            //objSales.TotalQty = Convert.ToInt32(Qty.SummaryItem.SummaryValue);

            //Items
            ReceviedModel objModel;
            List<ReceviedModel> lstIssued = new List<ReceviedModel>();

            for (int i = 0; i < gdvFormsIssued.DataRowCount; i++)
            {
                DataRow row = gdvFormsIssued.GetDataRow(i);

                objModel = new ReceviedModel();
                objModel.VoucherNo = Convert.ToInt32(row["VoucherNumber"]);

                objModel.Dated = row["Dated"].ToString();
                objModel.Amount =Convert.ToInt32(row["Amount"].ToString());
                objModel.BillNo = Convert.ToInt32(row["Purchase Bill No"].ToString());
                objModel.BillDate = Convert.ToInt32(row["Purchase Bill Date"].ToString());

                lstIssued.Add(objModel);
            }

            objissued.ReceviedModel = lstIssued;

            bool isSuccess = objibl.SaveIssuedVoucher(objissued);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                //   Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
                // d.ShowDialog();
            }
        }
    }
}
