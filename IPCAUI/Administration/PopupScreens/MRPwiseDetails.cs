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

namespace IPCAUI.Administration.PopupScreens
{
    public partial class MRPwiseDetails : Form
    {
        DataTable dt = new DataTable();
        public MRPwiseDetails()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ItemMRPWiseDetailsModel objMRPwise;
            ItemMasterNew.objModel.ItemMRPWise = new List<ItemMRPWiseDetailsModel>();
            //Loop through the grid and get the values

            for (int i = 0; i < dvgMrpwiseDetails.DataRowCount; i++)
            {
                DataRow row = dvgMrpwiseDetails.GetDataRow(i);
                objMRPwise = new ItemMRPWiseDetailsModel();
                objMRPwise.MRP = Convert.ToDecimal(row["MRP"].ToString() == null ? string.Empty : row["MRP"].ToString());
                objMRPwise.SalesPrice = Convert.ToDecimal(row["SalePrice"].ToString() == null ? string.Empty : row["SalePrice"].ToString());
                objMRPwise.Quantity = Convert.ToDecimal(row["Quantity"].ToString() == null ? string.Empty : row["Quantity"].ToString());
                objMRPwise.Amount = Convert.ToDecimal(row["Amount"].ToString() == null ? string.Empty : row["Amount"].ToString());

                ItemMasterNew.objModel.ItemMRPWise.Add(objMRPwise);

            }
            this.Close();
        }

        private void MRPwiseDetails_Load(object sender, EventArgs e)
        {
            // Administration.ItemMasterNew.objModel.Name.ToString();

            dt.Columns.Add("MRP");
            dt.Columns.Add("SalePrice");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Amount");

            dvgMrpwise.DataSource = dt;
        }

        private void dvgMrpwiseDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
    }
}
