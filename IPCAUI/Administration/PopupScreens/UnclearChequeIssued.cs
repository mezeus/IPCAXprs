using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSunSpeedDomain;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using eSunSpeed.BusinessLogic;

namespace IPCAUI.Administration.PopupScreens
{
    public partial class UnclearChequeIssued : Form
    {
        DataTable dt = new DataTable();
        AccountMasterBL objAccBL = new AccountMasterBL();
        public UnclearChequeIssued()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UnclearedChecqueDetailsModel objIssued;
            Account.objAccount.ChequesIssued = new List<UnclearedChecqueDetailsModel>();
            //Loop through the grid and get the values
            for (int i = 0; i < dvgChequeIssueDetails.DataRowCount; i++)
            {
                DataRow row = dvgChequeIssueDetails.GetDataRow(i);
                objIssued = new UnclearedChecqueDetailsModel();
                objIssued.Date =Convert.ToDateTime(row["Date"].ToString() == null? string.Empty : row["Date"].ToString());
                objIssued.Vchno = Convert.ToInt64(row["Vchno"].ToString() == string.Empty?"0": row["Vchno"].ToString());
                objIssued.Account = row["Account"].ToString() == null ? string.Empty : row["Account"].ToString();
                objIssued.Amount =Convert.ToDecimal(row["Amount"].ToString() == null ? string.Empty : row["Amount"].ToString());
                objIssued.Shortnarration = row["Shortnarration"].ToString() == null ? string.Empty : row["Shortnarration"].ToString();           
                if (Account.objAccount.AccountId != 0)
                {
                    objIssued.id = Convert.ToInt32(row["id"].ToString() == string.Empty ? "0" : row["id"]);
                    objIssued.ParentId = Convert.ToInt32(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"]);
                }
                objIssued.TotalAmount = Convert.ToDecimal(colAmount.SummaryItem.SummaryValue);
                Account.objAccount.ChequesIssued.Add(objIssued);
            }
            this.Close();
        }

        private void UnclearChequeIssued_Load(object sender, EventArgs e)
        {
            dvgChequeIssue.Focus();
            dt.Columns.Add("Date");
            dt.Columns.Add("Vchno");
            dt.Columns.Add("Account");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Shortnarration");
            dt.Columns.Add("id");
            dt.Columns.Add("ParentId");
            dvgChequeIssue.DataSource = dt;
            LoadAccountColumn();
            if (Account.groupId != 0)
            {
                dt.Rows.Clear();
                DataRow dr;
                foreach (UnclearedChecqueDetailsModel objIssued in Account.objAccount.ChequesIssued)
                {
                    dr = dt.NewRow();

                    dr["Date"] = objIssued.Date;
                    dr["Vchno"] = objIssued.Vchno;
                    dr["Account"] = objIssued.Account;
                    dr["Amount"] = objIssued.Amount;
                    dr["Shortnarration"] = objIssued.Shortnarration;
                    dr["id"] = objIssued.id;
                    dr["ParentId"] = objIssued.ParentId;
                    dt.Rows.Add(dr);
                }
                dvgChequeIssue.DataSource = dt;
            }
        }

        private void dvgChequeIssueDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dvgChequeIssue_Click(object sender, EventArgs e)
        {

        }
        private void LoadAccountColumn()
        {
            RepositoryItemLookUpEdit AccountsLookup = new RepositoryItemLookUpEdit();
            List<AccountMasterModel> lstAccounts = objAccBL.GetListofAccount();
            List<string> lstAccount = new List<string>();
            foreach (AccountMasterModel objAccounts in lstAccounts)
            {
                lstAccount.Add(objAccounts.AccountName);
            }
            AccountsLookup.DataSource = lstAccount;
            AccountsLookup.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            AccountsLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            AccountsLookup.AutoSearchColumnIndex = 1;
            dvgChequeIssueDetails.Columns["Account"].ColumnEdit = AccountsLookup;
            dvgChequeIssueDetails.BestFitColumns();
        }

        private void dvgChequeIssueDetails_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Account")
            {
                dvgChequeIssueDetails.ShowEditor();
                ((LookUpEdit)dvgChequeIssueDetails.ActiveEditor).ShowPopup();

            }
        }
    }
}
