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

namespace IPCAUI.Administration.PopupScreens
{
    public partial class MaintainBillByBillDetails : Form
    {
        DataTable dt = new DataTable();
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
            // Administration.ItemMasterNew.objModel.Name.ToString();

            dt.Columns.Add("Reference");
            dt.Columns.Add("Dated");
            dt.Columns.Add("Amount");           
            dt.Columns.Add("DC");
            dt.Columns.Add("Duedate");
            dt.Columns.Add("Group");
            dt.Columns.Add("Narration");
            dt.Columns.Add("BillId");
            dt.Columns.Add("ParentId");
            dvgBillbyBill.DataSource = dt;
            RepositoryItemLookUpEdit riLookupUnit = new RepositoryItemLookUpEdit();
            riLookupUnit.DataSource = new string[] { ItemMasterNew.objModel.AltUnit, ItemMasterNew.objModel.MainUnit };
            //riLookup.DataSource = lstUnits;
            riLookupUnit.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            riLookupUnit.AutoSearchColumnIndex = 1;
            dvgBillbyBillDetails.Columns["Unit"].ColumnEdit = riLookupUnit;
            dvgBillbyBillDetails.BestFitColumns();
            if (Account.objAccount.AccountId !=0)
            {
                dt.Rows.Clear();

                DataRow dr;

                foreach (MaintainBillbyBillModel objmod in Account.objAccount.BillbyBillDetails)
                {
                    dr = dt.NewRow();

                    dr["Reference"] = objmod.Reference;
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
    }
}
