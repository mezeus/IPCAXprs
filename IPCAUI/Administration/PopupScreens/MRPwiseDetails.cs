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
                objMRPwise.Quantity = Convert.ToDecimal(row["Quantity"].ToString() == null ? string.Empty : row["Quantity"].ToString());
                objMRPwise.Unit = row["Unit"].ToString() == null ? string.Empty : row["Unit"].ToString();
                objMRPwise.MRP = Convert.ToDecimal(row["MRP"].ToString() == null ? string.Empty : row["MRP"].ToString());
                objMRPwise.SalesPrice = Convert.ToDecimal(row["SalePrice"].ToString() == null ? string.Empty : row["SalePrice"].ToString());
                objMRPwise.Costprice = Convert.ToDecimal(row["Costprice"].ToString() == null ? string.Empty : row["Costprice"].ToString());
                objMRPwise.Barcode = row["Barcode"].ToString() == null ? string.Empty : row["Barcode"].ToString();
                if(ItemMasterNew.objModel.ItemId!=0)
                {
                    objMRPwise.MRP_Id = Convert.ToInt32(row["MRPId"].ToString() == String.Empty ? "0": row["MRPId"]);
                    objMRPwise.ParentId = Convert.ToInt32(row["ParentId"].ToString() == String.Empty ? "0" : row["ParentId"]);

                }
                ItemMasterNew.objModel.ItemMRPWise.Add(objMRPwise);

            }
            this.Close();
        }

        private void MRPwiseDetails_Load(object sender, EventArgs e)
        {
            // Administration.ItemMasterNew.objModel.Name.ToString();

            dt.Columns.Add("Quantity");
            dt.Columns.Add("Unit");
            dt.Columns.Add("MRP");
            dt.Columns.Add("SalePrice");           
            dt.Columns.Add("Costprice");
            dt.Columns.Add("Barcode");
            dt.Columns.Add("MRPId");
            dt.Columns.Add("ParentId");
            dvgMrpwise.DataSource = dt;
            RepositoryItemLookUpEdit riLookupUnit = new RepositoryItemLookUpEdit();
            riLookupUnit.DataSource = new string[] { ItemMasterNew.objModel.AltUnit, ItemMasterNew.objModel.MainUnit };
            //riLookup.DataSource = lstUnits;
            riLookupUnit.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            riLookupUnit.AutoSearchColumnIndex = 1;
            dvgMrpwiseDetails.Columns["Unit"].ColumnEdit = riLookupUnit;
            dvgMrpwiseDetails.BestFitColumns();
            if (ItemMasterNew.objModel.ItemId !=0)
            {
                dt.Rows.Clear();

                DataRow dr;

                foreach (ItemMRPWiseDetailsModel objmod in ItemMasterNew.objModel.ItemMRPWise)
                {
                    dr = dt.NewRow();

                    dr["Quantity"] = objmod.Quantity;
                    dr["Unit"] = objmod.Unit;
                    dr["MRP"] = objmod.MRP;
                    dr["SalePrice"] = objmod.SalesPrice;
                    dr["Costprice"] = objmod.Costprice;
                    dr["Barcode"] = objmod.Barcode;
                    dr["MRPId"] = objmod.MRP_Id;
                    dr["ParentId"] = objmod.ParentId;
                    dt.Rows.Add(dr);
                }

                dvgMrpwise.DataSource = dt;
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

        private void dvgMrpwiseDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }

        private void dvgMrpwiseDetails_ColumnChanged(object sender, EventArgs e)
        {
            //if (dvgMrpwiseDetails.Columns["Quantity"] == null)
            //{
            //    btnOk.Focus();
            //}
        }

        private void dvgMrpwiseDetails_RowClick(object sender, RowClickEventArgs e)
        {
            
        }

        private void dvgMrpwiseDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (dvgMrpwiseDetails.Columns["Quantity"] == null)
            //{
            //    btnOk.Focus();
            //}
        }
    }
}
