using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;
using IPCAUI.Models;

namespace IPCAUI.Transactions
{
    public partial class formsreceivedvoucher : Form
    {
        ReceviedVoucherModelBL objrcvdbl = new ReceviedVoucherModelBL();
        public formsreceivedvoucher()
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

        private void gdvMain_Click(object sender, EventArgs e)
        {

        }

        private void formsreceivedvoucher_Load(object sender, EventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            ReceviedVoucherModel objissued = new ReceviedVoucherModel();

            objissued.Date = Convert.ToDateTime(dtDate.Text);
            objissued.form = tbxForm.Text.Trim();
            objissued.fromNo = Convert.ToInt32(tbxFormNumber.Text);
            objissued.Series = tbxSeries.Text.Trim();
            objissued.issuingoffice = tbxIssingoffice.Text.Trim();
            objissued.issuedDate = Convert.ToDateTime(dtDateIssue.Text);
            objissued.Narration = tbxNarration.Text.Trim();
            objissued.stateofissue = tbxStateIssue.Text.Trim();
            objissued.party = tbxParty.Text.Trim();

            //Form Recevied Details
            ReceviedModel objModel;
            List<ReceviedModel> lstIssued = new List<ReceviedModel>();

            for (int i = 0; i < gdvFormsRcvd.DataRowCount; i++)
            {
                DataRow row = gdvFormsRcvd.GetDataRow(i);

                objModel = new ReceviedModel();
                objModel.VoucherNo = Convert.ToInt32(row["VoucherNumber"]);
                objModel.Dated = row["Dated"].ToString();
                objModel.Amount = Convert.ToInt32(row["Amount"].ToString());

                lstIssued.Add(objModel);
            }

            objissued.ReceviedModel = lstIssued;

            bool isSuccess = objrcvdbl.SaveReceviedVoucher(objissued);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                //   Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
                // d.ShowDialog();
            }
        }
    }
}
