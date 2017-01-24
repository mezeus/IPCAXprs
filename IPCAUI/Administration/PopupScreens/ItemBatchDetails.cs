using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
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
            dt.Columns.Add("Unit");
            dt.Columns.Add("MRP");
            dt.Columns.Add("SalePrice");
            dt.Columns.Add("CostPrice");
            dt.Columns.Add("MfgDate");
            dt.Columns.Add("ExpDate");
            dt.Columns.Add("Barcode");
            dt.Columns.Add("Narration");
            dt.Columns.Add("BatchId");
            dt.Columns.Add("ParentId");
           
            dt.Rows.Clear();

            DataRow Newdr;
            Newdr = dt.NewRow();          
            dt.Rows.Add(Newdr);

            dvgBatchWise.DataSource = dt;


            RepositoryItemLookUpEdit riLookupUnit = new RepositoryItemLookUpEdit();
            riLookupUnit.DataSource = new string[] { ItemMasterNew.objModel.AltUnit, ItemMasterNew.objModel.MainUnit };

            riLookupUnit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

            riLookupUnit.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            riLookupUnit.AutoSearchColumnIndex = 1;
            dvgBatchwiseDetails.Columns["Unit"].ColumnEdit = riLookupUnit;
          
            if (ItemMasterNew.objModel.ItemId!=0)
            {
                dt.Rows.Clear();

                DataRow dr;

                foreach (ItemBatchWiseDetailsModel objBatch in ItemMasterNew.objModel.ItemBatchWise)
                {
                    dr = dt.NewRow();

                    dr["BatchNo"] = objBatch.BatchNo.ToString();
                    dr["Qty"] = objBatch.Qty;
                    dr["Unit"] = objBatch.Unit;
                    dr["MRP"] = objBatch.MRP;
                    dr["SalePrice"] = objBatch.SalePrice;
                    dr["CostPrice"] = objBatch.CostPrice;
                    dr["Narration"] = objBatch.Narration;
                    dr["MfgDate"] = objBatch.MfgDate.ToString();
                    dr["ExpDate"] = objBatch.Expdate.ToString();
                    dr["Barcode"] = objBatch.Barcode;
                    dr["BatchId"] = objBatch.Batch_Id;
                    dr["ParentId"] = objBatch.Parent_Id;
                    dt.Rows.Add(dr);
                }

                dvgBatchWise.DataSource = dt;
            }
        }
        private void LoadItems()
        {
           
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
                objBatchwise.Unit = row["Unit"].ToString() == string.Empty ? string.Empty : row["Unit"].ToString();
                objBatchwise.MRP = Convert.ToDecimal(row["MRP"].ToString() == string.Empty ? string.Empty : row["MRP"].ToString());
                objBatchwise.SalePrice = Convert.ToDecimal(row["SalePrice"].ToString() == string.Empty ? string.Empty : row["SalePrice"].ToString());
                objBatchwise.CostPrice = Convert.ToDecimal(row["CostPrice"].ToString() == null? string.Empty : row["CostPrice"].ToString());
                objBatchwise.MfgDate = Convert.ToDateTime(row["MfgDate"].ToString() == null ? string.Empty : row["MfgDate"].ToString());
                objBatchwise.Expdate = Convert.ToDateTime(row["Expdate"].ToString() == null ? string.Empty : row["Expdate"].ToString());
                objBatchwise.Barcode = row["Barcode"].ToString() == null ? String.Empty : row["Barcode"].ToString();
                objBatchwise.Narration = row["Narration"].ToString() == null ? String.Empty : row["Narration"].ToString();
                if (ItemMasterNew.objModel.ItemId!=0)
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

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void dvgBatchwiseDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)

        {
            
            DataRow row = dvgBatchwiseDetails.GetDataRow(0);
            row["Qty"] = ItemMasterNew.objModel.OpStockQty.ToString();
            int i =
           i = Convert.ToInt32(colQty.SummaryItem.SummaryValue);
            if(i==Convert.ToInt32(ItemMasterNew.objModel.OpStockQty.ToString()))
            {
                MessageBox.Show("You Do Not Have Stock Of This Item");
            }
        }

        private void dvgBatchwiseDetails_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Unit")
            {
                dvgBatchwiseDetails.ShowEditor();
                ((LookUpEdit)dvgBatchwiseDetails.ActiveEditor).ShowPopup();
            }
            //dvgBatchWise

            //if (e.FocusedColumn.FieldName == "Qty" && ItemMasterNew.objModel.BatchwiseDetails && ItemMasterNew.objModel.ItemId == 0)
            //{

            //    DataRow row = dvgBatchwiseDetails.GetDataRow(0);
            //    row["Qty"] = ItemMasterNew.objModel.OpStockValue.ToString();

            //}


        }
    }
}
