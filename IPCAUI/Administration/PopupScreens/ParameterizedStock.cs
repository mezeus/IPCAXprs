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
    public partial class ParameterizedStock : Form
    {
        DataTable dt = new DataTable();
        public ParameterizedStock()
        {
            InitializeComponent();
        }

        private void ParameterizedStock_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("S.No");
            dt.Columns.Add("ItemName");
            dt.Columns.Add("Qty");
            dt.Columns.Add("ParmId");
            dt.Columns.Add("ParentId");
            dvgParamStock.DataSource = dt;
            if(ItemMasterNew.objModel.ItemId!=0)
            {
                dt.Rows.Clear();

                DataRow dr;

                foreach (ItemParameterizedModel objParm in ItemMasterNew.objModel.ItemParameterized)
                {
                    dr = dt.NewRow();

                    dr["ItemName"] = objParm.ItemName;
                    dr["Qty"] = objParm.Qty;
                    dr["ParmId"] = objParm.Param_Id;
                    dr["ParentId"] = objParm.Parent_Id;
                    dt.Rows.Add(dr);
                }

                dvgParamStock.DataSource = dt;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ItemParameterizedModel objparam;
                ItemMasterNew.objModel.ItemParameterized = new List<ItemParameterizedModel>();
            //Loop through the grid and get the values

            for (int i = 0; i < dvgParamStockDetails.DataRowCount; i++)
            {
                DataRow row = dvgParamStockDetails.GetDataRow(i);
                objparam = new ItemParameterizedModel();
                objparam.ItemName = row["ItemName"].ToString()==null?string.Empty: row["ItemName"].ToString();
                objparam.Qty =Convert.ToInt32(row["Qty"].ToString()==null?string.Empty: row["Qty"].ToString());
                if(ItemMasterNew.objModel.ItemId!=0)
                {
                    objparam.Parent_Id = Convert.ToInt32(row["ParentId"].ToString() == string.Empty ?"0": row["ParentId"]);
                    objparam.Param_Id = Convert.ToInt32(row["ParmId"].ToString() == string.Empty ? "0" : row["ParmId"]);
                }
                ItemMasterNew.objModel.ItemParameterized.Add(objparam);

            }
            this.Close();
        }

        private void dvgParamStockDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
