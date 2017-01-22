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
    public partial class ItemDefaultMaterialCenter : Form
    {
        DataTable dt = new DataTable();
        public ItemDefaultMaterialCenter()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ItemMaterialCenterModel objMC;
            ItemMasterNew.objModel.ItemMC = new List<ItemMaterialCenterModel>();
            //Loop through the grid and get the values

            for (int i = 0; i < dvgMCDetails.DataRowCount; i++)
            {
                DataRow row = dvgMCDetails.GetDataRow(i);
                objMC = new ItemMaterialCenterModel();
                objMC.Materialcenter = row["Materialcenter"].ToString() == null ? string.Empty : row["Materialcenter"].ToString();
                objMC.Qty = Convert.ToDecimal(row["Qty"].ToString() == string.Empty? "0": row["Qty"].ToString());

                if(ItemMasterNew.objModel.ItemId!=0)
                {
                    objMC.MCId = Convert.ToInt32(row["MCId"].ToString() == String.Empty ? "0": row["MCId"]);
                    objMC.ParentId = Convert.ToInt32(row["ParentId"].ToString() == String.Empty ? "0" : row["ParentId"]);

                }
                ItemMasterNew.objModel.ItemMC.Add(objMC);
            }
            this.Close();
        }

        private void ItemDefaultMaterialCenter_Load(object sender, EventArgs e)
        {
            // Administration.ItemMasterNew.objModel.Name.ToString();

            dt.Columns.Add("Materialcenter");
            dt.Columns.Add("Qty");
            dt.Columns.Add("MCId");
            dt.Columns.Add("ParentId");
            dvgMaterialCenter.DataSource = dt;
            if (ItemMasterNew.objModel.ItemId !=0)
            {
                dt.Rows.Clear();

                DataRow dr;

                foreach (ItemMaterialCenterModel objmod in ItemMasterNew.objModel.ItemMC)
                {
                    dr = dt.NewRow();

                    dr["Materialcenter"] = objmod.Materialcenter;
                    dr["Qty"] = objmod.Qty;
                    dr["MCId"] = objmod.MCId;
                    dr["ParentId"] = objmod.ParentId;
                    dt.Rows.Add(dr);
                }

                dvgMaterialCenter.DataSource = dt;
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

        private void dvgMCDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
