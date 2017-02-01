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
using eSunSpeed.BusinessLogic;
using DevExpress.XtraEditors;

namespace IPCAUI.Administration.PopupScreens
{
    public partial class UnclearChequeDeposite : Form
    {
        DataTable dt = new DataTable();
        AccountMasterBL objAccBL = new AccountMasterBL();
        public UnclearChequeDeposite()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UnclearedChecqueDetailsModel objDeposite;
            Account.objAccount.ChequesDeposites = new List<UnclearedChecqueDetailsModel>();
            //Loop through the grid and get the values
            for (int i = 0; i < dvgChequeDepositeDetails.DataRowCount; i++)
            {
                DataRow row = dvgChequeDepositeDetails.GetDataRow(i);
                objDeposite = new UnclearedChecqueDetailsModel();
                objDeposite.Date =Convert.ToDateTime(row["Date"].ToString() == null? string.Empty : row["Date"].ToString());
                objDeposite.Vchno = Convert.ToInt64(row["Vchno"].ToString() == string.Empty?"0": row["Vchno"].ToString());
                objDeposite.Account = row["Account"].ToString() == null ? string.Empty : row["Account"].ToString();
                objDeposite.Amount =Convert.ToDecimal(row["Amount"].ToString() == string.Empty? string.Empty : row["Amount"].ToString());
                objDeposite.Shortnarration = row["Shortnarration"].ToString() == null ? string.Empty : row["Shortnarration"].ToString();           
                if (Account.objAccount.AccountId != 0)
                {
                    objDeposite.id = Convert.ToInt32(row["id"].ToString() == string.Empty ? "0" : row["id"]);
                    objDeposite.ParentId = Convert.ToInt32(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"]);
                }
                objDeposite.TotalAmount = Convert.ToDecimal(colAmount.SummaryItem.SummaryValue);
                Account.objAccount.ChequesDeposites.Add(objDeposite);
            }
            this.Close();
        }

        private void UnclearChequeDeposite_Load(object sender, EventArgs e)
        {
            dvgChequeDeposite.Focus();
            dt.Columns.Add("Date");
            dt.Columns.Add("Vchno");
            dt.Columns.Add("Account");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Shortnarration");
            dt.Columns.Add("id");
            dt.Columns.Add("ParentId");
            dvgChequeDeposite.DataSource = dt;
            LoadAccountColumn();
            if (Account.groupId != 0)
            {
                dt.Rows.Clear();
                DataRow dr;
                foreach (UnclearedChecqueDetailsModel objDeposit in Account.objAccount.ChequesDeposites)
                {
                    dr = dt.NewRow();

                    dr["Date"] = objDeposit.Date;
                    dr["Vchno"] = objDeposit.Vchno;
                    dr["Account"] = objDeposit.Account;
                    dr["Amount"] = objDeposit.Amount;
                    dr["Shortnarration"] = objDeposit.Shortnarration;
                    dr["id"] = objDeposit.id;
                    dr["ParentId"] = objDeposit.ParentId;
                    dt.Rows.Add(dr);
                }
                dvgChequeDeposite.DataSource = dt;
            }
        }

        private void dvgChequeDepositeDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
            dvgChequeDepositeDetails.Columns["Account"].ColumnEdit = AccountsLookup;
            dvgChequeDepositeDetails.BestFitColumns();
        }

        private void dvgChequeDepositeDetails_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Account")
            {
                dvgChequeDepositeDetails.ShowEditor();
                ((LookUpEdit)dvgChequeDepositeDetails.ActiveEditor).ShowPopup();

            }
        }
    }
}
