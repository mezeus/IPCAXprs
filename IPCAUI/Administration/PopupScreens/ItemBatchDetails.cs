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
    public partial class ItemBatchDetails : Form
    {
        DataTable dt = new DataTable();
        public ItemBatchDetails()
        {
            InitializeComponent();
        }

        private void ItemBatchDetails_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("BatchNo");
            dt.Columns.Add("Qty");
            dt.Columns.Add("MfgDate");
            dt.Columns.Add("ExpDate");
            dt.Columns.Add("BatchId");
            dt.Columns.Add("ParentId");

            dvgBatchWise.DataSource = dt;
            if(ItemMasterNew.objModel.ItemId!=0)
            {
                dt.Rows.Clear();

                DataRow dr;

                foreach (ItemBatchWiseDetailsModel objBatch in ItemMasterNew.objModel.ItemBatchWise)
                {
                    dr = dt.NewRow();

                    dr["BatchNo"] = objBatch.BatchNo.ToString();
                    dr["Qty"] = objBatch.Qty;
                    dr["MfgDate"] = objBatch.MfgDate.ToString();
                    dr["ExpDate"] = objBatch.Expdate.ToString();
                    dr["BatchId"] = objBatch.Batch_Id;
                    dr["ParentId"] = objBatch.Parent_Id;
                    dt.Rows.Add(dr);
                }

                dvgBatchWise.DataSource = dt;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ItemBatchWiseDetailsModel objBatchwise;
            ItemMasterNew.objModel.ItemBatchWise = new List<ItemBatchWiseDetailsModel>();
            //Loop through the grid and get the values

            for (int i = 0; i < dvgBatchwiseDetails.DataRowCount; i++)
            {
                DataRow row = dvgBatchwiseDetails.GetDataRow(i);
                objBatchwise = new ItemBatchWiseDetailsModel();
                objBatchwise.BatchNo =Convert.ToInt32(row["BatchNo"].ToString() == string.Empty?"0": row["BatchNo"]);
                objBatchwise.Qty = Convert.ToInt32(row["Qty"].ToString() == string.Empty?"0": row["Qty"].ToString());
                objBatchwise.MfgDate = Convert.ToDateTime(row["MfgDate"].ToString() == null ? string.Empty : row["MfgDate"].ToString());
                objBatchwise.Expdate = Convert.ToDateTime(row["Expdate"].ToString() == null ? string.Empty : row["Expdate"].ToString());
                if(ItemMasterNew.objModel.ItemId!=0)
                {
                    objBatchwise.Parent_Id= Convert.ToInt32(row["ParentId"].ToString() ==string.Empty?"0": row["ParentId"]);
                    objBatchwise.Batch_Id = Convert.ToInt32(row["BatchId"].ToString() == string.Empty ? "0" : row["BatchId"]);
                }
                ItemMasterNew.objModel.ItemBatchWise.Add(objBatchwise);

            }
            this.Close();
        }

        private void dvgBatchwiseDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
