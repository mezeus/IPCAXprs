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

namespace IPCAUI.Administration.PopupScreens
{
    public partial class CostcenterPopup : Form
    {
        DataTable dt = new DataTable();
        public CostcenterPopup()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CostcenterPopupModel objCostcenter;
            Account.objAccount.CostcenterDetails = new List<CostcenterPopupModel>();
            //Loop through the grid and get the values

            for (int i = 0; i < dvgCostCenterDetails.DataRowCount; i++)
            {
                DataRow row = dvgCostCenterDetails.GetDataRow(i);
                objCostcenter = new CostcenterPopupModel();
                objCostcenter.Costcenter = row["Costcenter"].ToString() == null? string.Empty : row["Costcenter"].ToString();
                objCostcenter.Amount = Convert.ToDecimal(row["Balance"].ToString() == string.Empty?"0.00": row["Balance"].ToString());
                objCostcenter.DC = row["DC"].ToString() == null ? string.Empty : row["DC"].ToString();
                objCostcenter.Shortnarration = row["Shortnarration"].ToString() == null ? string.Empty : row["Shortnarration"].ToString();
               
                if (Account.objAccount.AccountId != 0)
                {
                    objCostcenter.CCId = Convert.ToInt32(row["CCId"].ToString() == string.Empty ? "0" : row["CCId"]);
                    objCostcenter.ParentId = Convert.ToInt32(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"]);
                }
                Account.objAccount.CostcenterDetails.Add(objCostcenter);
            }
            this.Close();
        }

        private void CostcenterPopup_Load(object sender, EventArgs e)
        {
            dvgCostCenter.Focus();
            dt.Columns.Add("Costcenter");
            dt.Columns.Add("Balance");
            dt.Columns.Add("DC");
            dt.Columns.Add("Shortnarration");
            dt.Columns.Add("CCId");
            dt.Columns.Add("ParentId");
            dvgCostCenter.DataSource = dt;
        }

        private void dvgCostCenterDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
