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
using DevExpress.XtraEditors;

namespace IPCAUI.Administration.PopupScreens
{
    public partial class ItemSerialnoWiseDetails : Form
    {
        DataTable dt = new DataTable();
        public ItemSerialnoWiseDetails()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ItemSerialnoDetailsModel objSerial;
            ItemMasterNew.objModel.ItemSerialNo = new List<ItemSerialnoDetailsModel>();
            //Loop through the grid and get the values

            for (int i = 0; i < dvgSerialnoDetails.DataRowCount; i++)
            {
                DataRow row = dvgSerialnoDetails.GetDataRow(i);
                objSerial = new ItemSerialnoDetailsModel();

                objSerial.SerialNumber = Convert.ToInt32(row["Itemserialno"].ToString() == null ? string.Empty : row["Itemserialno"].ToString());
                objSerial.Quantity = Convert.ToDecimal(row["Quantity"].ToString() == null ? "0.00" : row["Quantity"].ToString());
                objSerial.Unit = row["Unit"].ToString() == null ? string.Empty : row["Unit"].ToString();
                objSerial.MRP = Convert.ToDecimal(row["MRP"].ToString() == string.Empty? "0.00" : row["MRP"].ToString());
                objSerial.SalePrice = Convert.ToDecimal(row["Saleprice"].ToString() == string.Empty?"0.00": row["Saleprice"].ToString());
                objSerial.Costprice = Convert.ToDecimal(row["Costprice"].ToString() == null ? string.Empty : row["Costprice"].ToString());
                objSerial.Barcode = row["Barcode"].ToString() == null ? string.Empty : row["Barcode"].ToString();

                if(ItemMasterNew.objModel.ItemId!=0)
                {
                    objSerial.SL_ID = Convert.ToInt32(row["SnId"].ToString() == String.Empty ? "0": row["SnId"]);
                    objSerial.parent_Id = Convert.ToInt32(row["ParentId"].ToString() == String.Empty ? "0" : row["ParentId"]);

                }
                ItemMasterNew.objModel.ItemSerialNo.Add(objSerial);

            }
            this.Close();
        }

        private void ItemSerialnoWiseDetails_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Itemserialno");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Unit");
            dt.Columns.Add("MRP");
            dt.Columns.Add("Saleprice");
            dt.Columns.Add("Costprice");
            dt.Columns.Add("Barcode");
            dt.Columns.Add("SnId");
            dt.Columns.Add("ParentId");
            dvgSerialno.DataSource = dt;
            RepositoryItemLookUpEdit riLookupUnit = new RepositoryItemLookUpEdit();
            riLookupUnit.DataSource = new string[] { ItemMasterNew.objModel.AltUnit, ItemMasterNew.objModel.MainUnit };

            riLookupUnit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

            //riLookup.DataSource = lstUnits;
            riLookupUnit.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            riLookupUnit.AutoSearchColumnIndex = 1;
            dvgSerialnoDetails.Columns["Unit"].ColumnEdit = riLookupUnit;
            if (ItemMasterNew.objModel.ItemId !=0)
            {
                dt.Rows.Clear();

                DataRow dr;

                foreach (ItemSerialnoDetailsModel objmod in ItemMasterNew.objModel.ItemSerialNo)
                {
                    dr = dt.NewRow();

                    dr["Itemserialno"] = objmod.SerialNumber;
                    dr["Quantity"] = objmod.Quantity;
                    dr["Unit"] = objmod.Unit;
                    dr["MRP"] = objmod.MRP;
                    dr["Saleprice"] = objmod.SalePrice;
                    dr["Costprice"] = objmod.Costprice;
                    dr["Quantity"] = objmod.Quantity;
                    dr["Barcode"] = objmod.Barcode;
                    dr["SnId"] = objmod.SL_ID;
                    dr["ParentId"] = objmod.parent_Id;
                    dt.Rows.Add(dr);
                }

                dvgSerialno.DataSource = dt;
            }
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

        private void dvgSerialno_Click(object sender, EventArgs e)
        {

        }

        private void dvgSerialnoDetails_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Unit")
            {
                dvgSerialnoDetails.ShowEditor();
                ((LookUpEdit)dvgSerialnoDetails.ActiveEditor).ShowPopup();
            }
        }
    }
}
