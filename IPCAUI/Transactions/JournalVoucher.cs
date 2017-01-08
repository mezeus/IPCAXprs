using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPCAUI.Models;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;

namespace IPCAUI.Transactions
{
    public partial class JournalVoucher : Form
    {
        JournalVoucherModelBL objJVbal = new JournalVoucherModelBL();
        DataTable dt = new DataTable();
        public static int Journl_Id = 0; 
        public JournalVoucher()
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
        
        private void JournalVoucher_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("S.No");
            dt.Columns.Add("DC");
            dt.Columns.Add("Account");
            dt.Columns.Add("Debit");
            dt.Columns.Add("Credit");
            dt.Columns.Add("Narration");
            dt.Columns.Add("ParentId");
            dt.Columns.Add("Ac_Id");
            dvgJournalMain.DataSource = dt;
            Models.AccountLookup acc = new Models.AccountLookup();

            //gdvJournal.DataSource = DataSets.JournalDs.;
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
            // Note that the data types of the "ID" and "CategoryID" fields match.
            gdvJournalDetails.Columns["Account"].ColumnEdit = riLookup;
            gdvJournalDetails.BestFitColumns();

            //Series Lookup Edit
            SeriesLookup objSeries = new SeriesLookup();
            tbxVoucherSeries.Properties.DataSource = objSeries.Series;


            RepositoryItemLookUpEdit riDCLookup = new RepositoryItemLookUpEdit();
            riDCLookup.DataSource = new string[] { "D", "C" };
            gdvJournalDetails.Columns["DC"].ColumnEdit = riDCLookup;

            riDCLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            riDCLookup.AutoSearchColumnIndex = 1;

            riDCLookup.DropDownRows = 0;

        }              

        private void gdvJournal_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void gdvJournal_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Account")
            {
                gdvJournalDetails.ShowEditor();
                ((LookUpEdit)gdvJournalDetails.ActiveEditor).ShowPopup();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            JournalVoucherModel objJVmodel = new JournalVoucherModel();

            if (tbxVchNo.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }
            objJVmodel.Voucher_Series = tbxVoucherSeries.Text.Trim();
            objJVmodel.JV_Date = Convert.ToDateTime(dtDate.Text);
            objJVmodel.Type = tbxType.Text.Trim()==null?string.Empty:tbxType.Text.Trim();
            objJVmodel.Voucher_Number = Convert.ToInt32(tbxVchNo.Text.Trim());
            objJVmodel.PDCDate = Convert.ToDateTime(dtPDCDate.Text);
            objJVmodel.LongNarration = tbxLongNarration.Text.Trim() == null ? string.Empty : tbxLongNarration.Text.Trim();
            objJVmodel.TotalCreditAmt= Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);
            objJVmodel.TotalDebitAmt = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);

            //Journal details
            AccountModel objacc;
            List<AccountModel> lstAccounts = new List<AccountModel>();

            for (int i = 0; i < gdvJournalDetails.DataRowCount; i++)
            {
                DataRow row = gdvJournalDetails.GetDataRow(i);

                objacc = new AccountModel();
                objacc.DC = row["DC"].ToString();

                objacc.Account = row["Account"].ToString(); 
                objacc.Debit = Convert.ToDecimal(row["Debit"].ToString()==string.Empty?"0":row["Debit"].ToString());
                objacc.Credit = Convert.ToDecimal(row["Credit"].ToString() == string.Empty ? "0" : row["Credit"].ToString());
                objacc.Narration = row["Narration"].ToString() == string.Empty ? string.Empty : row["Debit"].ToString();
                lstAccounts.Add(objacc);
            }

            objJVmodel.JournalAccountModel = lstAccounts;

            bool isSuccess = objJVbal.SaveJournalVoucher(objJVmodel);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }

        private void btnJournalList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Transaction.List.JournalVouchersList frmList = new Transaction.List.JournalVouchersList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();

            if (Journl_Id != 0)
            {
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                tbxVoucherSeries.Focus();
                FillJournalVoucherInfo();
            }
       
    }
        public void FillJournalVoucherInfo()
        {

        }
    }
}
