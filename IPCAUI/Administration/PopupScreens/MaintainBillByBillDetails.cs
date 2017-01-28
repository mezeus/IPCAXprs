using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using eSunSpeedDomain;
using DevExpress.XtraEditors.Repository;
using eSunSpeed.BusinessLogic;
using DevExpress.XtraEditors;

namespace IPCAUI.Administration.PopupScreens
{
    public partial class MaintainBillByBillDetails : Form
    {
        DataTable dt = new DataTable();
        SalesManBL objSMBL = new SalesManBL();
        ReferenceGroupBL objRefBL = new ReferenceGroupBL();
        public MaintainBillByBillDetails()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            MaintainBillbyBillModel objbillbybill;
            Account.objAccount.BillbyBillDetails = new List<MaintainBillbyBillModel>();
            //Loop through the grid and get the values

            for (int i = 0; i < dvgBillbyBillDetails.DataRowCount; i++)
            {
                DataRow row = dvgBillbyBillDetails.GetDataRow(i);
                objbillbybill = new MaintainBillbyBillModel();
                objbillbybill.Reference = row["Reference"].ToString() == null ? string.Empty : row["Reference"].ToString();
                objbillbybill.Reference = row["Salesman"].ToString() == null ? string.Empty : row["Salesman"].ToString();
                objbillbybill.Dated = Convert.ToDateTime(row["Dated"].ToString() == null ? string.Empty : row["Dated"].ToString());
                objbillbybill.Amount = Convert.ToDecimal(row["Amount"].ToString() == string.Empty?"0.00" : row["Amount"].ToString());
                objbillbybill.DC = row["DC"].ToString() ==null? string.Empty : row["DC"].ToString();
                objbillbybill.Duedate = Convert.ToDateTime(row["Duedate"].ToString() == null ? string.Empty : row["Duedate"].ToString());
                objbillbybill.Group = row["Group"].ToString() == null ? string.Empty : row["Group"].ToString();
                objbillbybill.Narration = row["Narration"].ToString() == null ? string.Empty : row["Narration"].ToString();
                if(Account.objAccount.AccountId!=0)
                {
                    objbillbybill.BillId = Convert.ToInt32(row["BillId"].ToString() == string.Empty ? "0": row["BillId"]);
                    objbillbybill.ParentId = Convert.ToInt32(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"]);
                }
                Account.objAccount.BillbyBillDetails.Add(objbillbybill);

            }
            this.Close();
        }

        private void MaintainBillByBillDetails_Load(object sender, EventArgs e)
        {
            dvgBillbyBill.Focus();

            dt.Columns.Add("Reference");
            dt.Columns.Add("Salesman");
            dt.Columns.Add("Dated");
            dt.Columns.Add("Amount");           
            dt.Columns.Add("DC");
            dt.Columns.Add("Duedate");
            dt.Columns.Add("Group");
            dt.Columns.Add("Narration");
            dt.Columns.Add("BillId");
            dt.Columns.Add("ParentId");
            dvgBillbyBill.DataSource = dt;
            LoadColumns();
            if (Account.objAccount.AccountId !=0)
            {
                dt.Rows.Clear();

                DataRow dr;

                foreach (MaintainBillbyBillModel objmod in Account.objAccount.BillbyBillDetails)
                {
                    dr = dt.NewRow();

                    dr["Reference"] = objmod.Reference;
                    dr["Salesman"] = objmod.Salesman;
                    dr["Dated"] = objmod.Dated;
                    dr["Amount"] = objmod.Amount;
                    dr["DC"] = objmod.DC;
                    dr["Duedate"] = objmod.Duedate;
                    dr["Group"] = objmod.Group;
                    dr["Narration"] = objmod.Narration;
                    dr["BillId"] = objmod.BillId;
                    dr["ParentId"] = objmod.ParentId;
                    dt.Rows.Add(dr);
                }

                dvgBillbyBill.DataSource = dt;
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

        private void dvgBillbyBillDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void LoadColumns()
        {
            RepositoryItemLookUpEdit SalesmanLookup = new RepositoryItemLookUpEdit();
            List<SalesManModel> lstSalesMans = objSMBL.GetAllSalesMan();
            List<string> lstSMs = new List<string>();
            foreach (SalesManModel objSales in lstSalesMans)
            {
                lstSMs.Add(objSales.SM_Name);
            }
            SalesmanLookup.DataSource = lstSMs;
            SalesmanLookup.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            SalesmanLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            SalesmanLookup.AutoSearchColumnIndex = 1;
            dvgBillbyBillDetails.Columns["Salesman"].ColumnEdit = SalesmanLookup;
            dvgBillbyBillDetails.BestFitColumns();

            RepositoryItemLookUpEdit ReferenceLookup = new RepositoryItemLookUpEdit();
            List<ReferenceGroupModel> lstReferences = objRefBL.GetAllReferenceGroups();
            List<string> lstGroups = new List<string>();
            foreach (ReferenceGroupModel objRef in lstReferences)
            {
                lstGroups.Add(objRef.Name);
            }
            ReferenceLookup.DataSource = lstGroups;
            ReferenceLookup.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            ReferenceLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            ReferenceLookup.AutoSearchColumnIndex = 1;
            dvgBillbyBillDetails.Columns["Group"].ColumnEdit = ReferenceLookup;
            dvgBillbyBillDetails.BestFitColumns();
            RepositoryItemLookUpEdit riDCLookup = new RepositoryItemLookUpEdit();
            riDCLookup.DataSource = new string[] { "D", "C" };
            dvgBillbyBillDetails.Columns["DC"].ColumnEdit = riDCLookup;
            dvgBillbyBillDetails.BestFitColumns();
            riDCLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            riDCLookup.AutoSearchColumnIndex = 1;
        }

        private void dvgBillbyBillDetails_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Salesman")
            {
                dvgBillbyBillDetails.ShowEditor();
                ((LookUpEdit)dvgBillbyBillDetails.ActiveEditor).ShowPopup();

            }
            if (e.FocusedColumn.FieldName == "Group")
            {
                dvgBillbyBillDetails.ShowEditor();
                ((LookUpEdit)dvgBillbyBillDetails.ActiveEditor).ShowPopup();

            }
            if (e.FocusedColumn.FieldName == "DC")
            {
                dvgBillbyBillDetails.ShowEditor();
                ((LookUpEdit)dvgBillbyBillDetails.ActiveEditor).ShowPopup();

            }
        }
    }
}
