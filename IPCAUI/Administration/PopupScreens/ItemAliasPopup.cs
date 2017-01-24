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
    public partial class ItemAliasPopup : Form
    {
        DataTable dt = new DataTable();
        public ItemAliasPopup()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ItemAliasModel objBarcode;
            Administration.ItemMasterNew.objModel.ItemBarcode = new List<ItemAliasModel>();
            for (int i = 0; i < dvgBarcodeDetails.DataRowCount; i++)
            {
                DataRow row = dvgBarcodeDetails.GetDataRow(i);
                objBarcode = new ItemAliasModel();
                objBarcode.Barcodes=row["Barcodes"].ToString()==null?string.Empty: row["Barcodes"].ToString();
                if(ItemMasterNew.objModel.ItemId!=0)
                {
                    objBarcode.BarcodeId = Convert.ToInt32(row["BarcodeId"].ToString() == string.Empty ? "0" : row["BarcodeId"].ToString());
                    objBarcode.ParentId = Convert.ToInt32(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());
                }
                ItemMasterNew.objModel.ItemBarcode.Add(objBarcode);
            }
            this.Close();
            }

        private void ItemAliasPopup_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Barcodes");
            dt.Columns.Add("BarcodeId");
            dt.Columns.Add("ParentId");
            dvgBarcode.DataSource = dt;
            if(ItemMasterNew.objModel.ItemId!=0)
            {
                dt.Rows.Clear();

                DataRow dr;

                foreach (ItemAliasModel objBarcodes in ItemMasterNew.objModel.ItemBarcode)
                {
                    dr = dt.NewRow();

                    dr["Barcodes"] = objBarcodes.Barcodes.ToString();
                    dr["BarcodeId"] = objBarcodes.BarcodeId;
                    dr["ParentId"] = objBarcodes.ParentId;
                    dt.Rows.Add(dr);
                }

                dvgBarcode.DataSource = dt;
            }
        }

        private void dvgBarcodeDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
