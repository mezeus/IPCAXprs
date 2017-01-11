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
            Administration.ItemMasterNew.objModel.BarCodes = new List<string>();
            //Loop through the grid and get the values

            for (int i = 0; i < dvgBarcodeDetails.DataRowCount; i++)
            {
                DataRow row = dvgBarcodeDetails.GetDataRow(i);

                Administration.ItemMasterNew.objModel.BarCodes.Add(row["Barcode"].ToString()==null?string.Empty: row["Barcode"].ToString());
            }
            this.Close();
            }

        private void ItemAliasPopup_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Barcode");
            dvgBarcode.DataSource = dt;
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
