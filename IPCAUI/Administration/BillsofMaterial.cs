using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;

namespace IPCAUI.Administration
{
    
    public partial class BillsofMaterial : Form
    {
        BillsofMaterialBL objbal = new BillsofMaterialBL();
        ItemMasterBL objItemBL = new ItemMasterBL();
        public static int BMId = 0;
        public static string FormName = "";
        DataTable dtgenerate = new DataTable();
        DataTable dtconsumed = new DataTable();
        DataTable dtItems = new DataTable();
        public BillsofMaterial()
        {
            InitializeComponent();           
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListMaterial_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.BillMaterialList frmList = new Administration.List.BillMaterialList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();

            
            tbxBomName.Focus();

            FillBOMInfo();
        }

        private void FillBOMInfo()
        {
            BillofMaterialModel objBom = objbal.GetAllBillofMaterialById(BMId);
            if(BMId==0)
            {
                tbxBomName.Focus();
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                return;
            }
            tbxBomName.Text= objBom.BOMName;
            cbxItemproduce.Text = objBom.Itemtoproduce.ToString();
            tbxQuanty.Text=Convert.ToString(objBom.Quantity);
            cbxUnit.Text = objBom.ItemUnit;
            tbxExpensespcs.Text=Convert.ToString(objBom.Expenses);
            cbxItemgenerated.SelectedItem= objBom.SpecifyMCGenerated?"Y":"N";
            cbxItemconsumed.SelectedItem=objBom.SpecifyDefaultMCforItemConsumed?"Y":"N";

            dtconsumed.Rows.Clear();
            DataRow dr;

            foreach (BillsofMaterialDetailsModel objmod in objBom.MaterialConsumed)
            {
                dr = dtconsumed.NewRow();

                dr["ItemName"] = objmod.ItemName;
                dr["Qty"] = objmod.Qty;
                dr["Unit"] = objmod.Unit;
                dr["id"] = objmod.id;
                dr["ParentId"] = objmod.ParentId;
                dtconsumed.Rows.Add(dr);
            }

            dvgMatConsumed.DataSource = dtconsumed;

            dtgenerate.Rows.Clear();
            DataRow drgen;

            foreach (BillsofMaterialDetailsModel objGen in objBom.MaterialGenerated)
            {
                drgen = dtgenerate.NewRow();

                drgen["ItemName"] = objGen.ItemName;
                drgen["Qty"] = objGen.Qty;
                drgen["Unit"] = objGen.Unit;
                drgen["id"] = objGen.id;
                drgen["ParentId"] = objGen.ParentId;
                dtgenerate.Rows.Add(drgen);
            }

            dvgProductGenerate.DataSource = dtgenerate;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            if(keyData==Keys.F3)
            {
                if(cbxItemproduce.Focused)
                {
                    FormName = "ItemMaster";
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BillofMaterialModel objBMmodl = new BillofMaterialModel();

            objBMmodl.BOMName = tbxBomName.Text.Trim();
            objBMmodl.Itemtoproduce = cbxItemproduce.Text.Trim();
            objBMmodl.Quantity = Convert.ToDecimal(tbxQuanty.Text.Trim());
            objBMmodl.ItemUnit = cbxUnit.SelectedItem.ToString();
            objBMmodl.Expenses = Convert.ToDecimal(tbxExpensespcs.Text.Trim());
            objBMmodl.SpecifyMCGenerated = Convert.ToBoolean(cbxItemgenerated.SelectedItem.ToString()=="Y"? true : false);
            objBMmodl.SpecifyDefaultMCforItemConsumed = Convert.ToBoolean(cbxItemconsumed.SelectedItem.ToString()=="Y"? true : false);
            objBMmodl.AppMc = string.Empty;
            objBMmodl.ICTotalQty = Convert.ToDecimal(colQty.SummaryItem.SummaryValue);
            objBMmodl.IGTotalQty = Convert.ToDecimal(colIgQty.SummaryItem.SummaryValue);
            //Item consumed
            List<BillsofMaterialDetailsModel> lstItemConsumed = new List<BillsofMaterialDetailsModel>();
            BillsofMaterialDetailsModel objConsumed;
            for (int i = 0; i < dvgMatConsuDetails.DataRowCount; i++)
            {
               DataRow row = dvgMatConsuDetails.GetDataRow(i);

                objConsumed = new BillsofMaterialDetailsModel();
                objConsumed.ItemName = row["ItemName"].ToString()==null?string.Empty: row["ItemName"].ToString();
                objConsumed.Qty = Convert.ToDecimal(row["Qty"].ToString()==string.Empty?"0": row["Qty"].ToString());
                objConsumed.Unit = row["Unit"].ToString()==string.Empty?string.Empty: row["Unit"].ToString();

                lstItemConsumed.Add(objConsumed);
            }
            objBMmodl.MaterialConsumed = lstItemConsumed;
            
            //Item generated
            List<BillsofMaterialDetailsModel> lstItemGenerated = new List<BillsofMaterialDetailsModel>();
            BillsofMaterialDetailsModel objGenerated;
            for (int i = 0; i < dvgProductGeneratedDet.DataRowCount; i++)
            {
                DataRow row = dvgProductGeneratedDet.GetDataRow(i);

                objGenerated = new BillsofMaterialDetailsModel();
                objGenerated.ItemName = row["ItemName"].ToString() == null ? string.Empty : row["ItemName"].ToString();
                objGenerated.Qty = Convert.ToDecimal(row["Qty"].ToString() == string.Empty ? "0" : row["Qty"].ToString());
                objGenerated.Unit = row["Unit"].ToString() == string.Empty ? string.Empty : row["Unit"].ToString();

                lstItemGenerated.Add(objGenerated);
            }
            objBMmodl.MaterialGenerated = lstItemGenerated;
            bool isSuccess = objbal.SaveBOM(objBMmodl);

            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearControls();
            }
        }
       public void ClearControls()
        {
            tbxBomName.Text = string.Empty;
            cbxItemproduce.Text = string.Empty;
            tbxQuanty.Text = "0.00";
            cbxUnit.Text = string.Empty;
            tbxExpensespcs.Text = string.Empty;
            cbxItemgenerated.SelectedIndex = 1;
            cbxItemconsumed.SelectedIndex = 1;
            dtconsumed.Rows.Clear();
            dtgenerate.Rows.Clear();
        }
        private void tbxBomName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxBomName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Master Name Can Not Be Blank!");
                    this.ActiveControl = tbxBomName;
                    return;
                }
                if(BMId==0)
                {
                    if (objbal.IsBOMExists(tbxBomName.Text.Trim()))
                    {
                        MessageBox.Show("BOM Name already Exists!");
                        tbxBomName.Focus();
                        return;
                    }
                }
                
            }
        }

        private void BillsofMaterial_Load(object sender, EventArgs e)
        {
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            cbxItemconsumed.SelectedIndex = 1;
            cbxItemgenerated.SelectedIndex = 1;
            dtgenerate.Columns.Add("ItemName");
            dtgenerate.Columns.Add("Qty");
            dtgenerate.Columns.Add("Unit");
            dtgenerate.Columns.Add("id");
            dtgenerate.Columns.Add("ParentId");
            dvgProductGenerate.DataSource = dtgenerate;

            
            dtconsumed.Columns.Add("ItemName");
            dtconsumed.Columns.Add("Qty");
            dtconsumed.Columns.Add("Unit");
            dtconsumed.Columns.Add("id");
            dtconsumed.Columns.Add("ParentId");

            dvgMatConsumed.DataSource = dtconsumed;

            dtItems.Columns.Add("Items");
            dtItems.Columns.Add("GroupName");
            dtItems.Columns.Add("Stock");
            dtItems.Columns.Add("Unit");

            dtItems.Rows.Clear();
            DataRow dr;
            List<ItemMasterModel> lstItems = objItemBL.GetAllItems();
            foreach (ItemMasterModel objItems in lstItems)
            {
                dr = dtItems.NewRow();
                dr["Items"] = objItems.Name;
                dr["GroupName"] = objItems.Group;
                dr["Stock"] = objItems.OpStockQty;
                dr["Unit"] = objItems.Unit;
                dtItems.Rows.Add(dr);
            }
            RepositoryItemLookUpEdit riLookup = new RepositoryItemLookUpEdit();
            riLookup.DataSource = dtItems;
            riLookup.ValueMember = "Items";
            riLookup.DisplayMember = "Items";
            riLookup.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            riLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            riLookup.AutoSearchColumnIndex = 1;
            dvgMatConsuDetails.Columns["ItemName"].ColumnEdit = riLookup;
            dvgMatConsuDetails.BestFitColumns();

            dvgProductGeneratedDet.Columns["ItemName"].ColumnEdit = riLookup;
            dvgProductGeneratedDet.BestFitColumns();
            //cbxItemproduce.Properties.Items.Clear();
            //List<ItemMasterModel> lstItems = objItemBL.GetAllItems();
            //foreach (ItemMasterModel objItems in lstItems)
            //{
            //    cbxItemproduce.Properties.Items.Add(objItems.Name);
            //}
        }

        private void dvgRawmatDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void dvgProductGeneratedDet_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void dvgMatConsuDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BillofMaterialModel objBMmodl = new BillofMaterialModel();
            if(BMId==0)
            {
                tbxBomName.Focus();
                return;
            }

            objBMmodl.BOMName = tbxBomName.Text.Trim();
            objBMmodl.Itemtoproduce = cbxItemproduce.Text.Trim();
            objBMmodl.Quantity = Convert.ToDecimal(tbxQuanty.Text.Trim());
            objBMmodl.ItemUnit = cbxUnit.SelectedItem.ToString();
            objBMmodl.Expenses = Convert.ToDecimal(tbxExpensespcs.Text.Trim());
            objBMmodl.SpecifyMCGenerated = Convert.ToBoolean(cbxItemgenerated.SelectedItem.ToString()=="Y"? true : false);

            // objBMmodl.SourceMC = string.Empty;
            objBMmodl.SpecifyDefaultMCforItemConsumed = Convert.ToBoolean(cbxItemconsumed.SelectedItem.ToString()=="Y"? true : false);
            objBMmodl.AppMc = string.Empty;
            objBMmodl.ICTotalQty = Convert.ToDecimal(colQty.SummaryItem.SummaryValue);
            objBMmodl.IGTotalQty = Convert.ToDecimal(colIgQty.SummaryItem.SummaryValue);
            //Item consumed
            List<BillsofMaterialDetailsModel> lstItemConsumed = new List<BillsofMaterialDetailsModel>();
            BillsofMaterialDetailsModel objConsumed;
            for (int i = 0; i < dvgMatConsuDetails.DataRowCount; i++)
            {
                DataRow row = dvgMatConsuDetails.GetDataRow(i);

                objConsumed = new BillsofMaterialDetailsModel();
                objConsumed.ItemName = row["ItemName"].ToString()==string.Empty?string.Empty: row["ItemName"].ToString();
                objConsumed.Qty = Convert.ToDecimal(row["Qty"].ToString()==string.Empty?string.Empty: row["Qty"].ToString());
                objConsumed.Unit = row["Unit"].ToString()==string.Empty?string.Empty: row["Unit"].ToString();
                objConsumed.id =Convert.ToInt32(row["id"].ToString()==string.Empty?"0": row["id"].ToString());
                objConsumed.ParentId =Convert.ToInt32(row["ParentId"].ToString()==string.Empty?"0": row["ParentId"].ToString());
                lstItemConsumed.Add(objConsumed);
            }
            objBMmodl.MaterialConsumed = lstItemConsumed;

            //Item generated
            List<BillsofMaterialDetailsModel> lstItemGenerated = new List<BillsofMaterialDetailsModel>();
            BillsofMaterialDetailsModel objGenerated;
            for (int i = 0; i < dvgProductGeneratedDet.DataRowCount; i++)
            {
                DataRow row = dvgProductGeneratedDet.GetDataRow(i);

                objGenerated = new BillsofMaterialDetailsModel();
                objGenerated.ItemName = row["ItemName"].ToString()==string.Empty?string.Empty: row["ItemName"].ToString();
                objGenerated.Qty = Convert.ToDecimal(row["Qty"].ToString()==string.Empty?string.Empty: row["Qty"].ToString());
                objGenerated.Unit = row["Unit"].ToString()==string.Empty? string.Empty: row["Unit"].ToString();
                objGenerated.id = Convert.ToInt32(row["id"].ToString() == string.Empty ? "0" : row["id"].ToString());
                objGenerated.ParentId = Convert.ToInt32(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());

                lstItemGenerated.Add(objGenerated);
            }
            objBMmodl.MaterialGenerated = lstItemGenerated;
            objBMmodl.id = BMId;
            bool isSuccess = objbal.UpdateBOM(objBMmodl);

            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                BMId = 0;
                ClearControls();
                Administration.List.BillMaterialList frmList = new Administration.List.BillMaterialList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();

                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                tbxBomName.Focus();
               
                FillBOMInfo();
            }
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClearControls();
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            BMId = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objbal.DeleteBillsOfMaterial(BMId);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                ClearControls();
                BMId = 0;
                Administration.List.BillMaterialList frmList = new Administration.List.BillMaterialList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();

                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                tbxBomName.Focus();

                FillBOMInfo();

            }
        }

        private void cbxItemproduce_KeyPress(object sender, KeyPressEventArgs e)
        {
            //cbxItemproduce.ShowPopup();
            //LookupItemPro.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            //LookupItemPro.DropDownRows = dtItems.Count;
            //cbxItemproduce.Properties.Items.Clear();
            //List<ItemMasterModel> lstItems = objItemBL.GetAllItems();
            //foreach (ItemMasterModel objItems in lstItems)
            //{
            //    cbxItemproduce.Properties.Items.Add(objItems.Name);
            //}
            //string t = cbxItemproduce.Text;
            //string typedT = t.Substring(0, cbxItemproduce.SelectionStart);
            //string newT = typedT + e.KeyChar;

            //int i = cbxItemproduce.(newT);
            //if (i == -1)
            //{
            //    e.Handled = true;
            //}
            //if (Char.IsLetter(e.KeyChar))
            //{
            //    e.KeyChar = Char.ToUpper(e.KeyChar);
            //}
            if(e.KeyChar!='\r')
            {
                cbxItemproduce.ShowPopup();
            }           
        }

        private void cbxUnit_Enter(object sender, EventArgs e)
        {
            cbxUnit.Properties.Items.Clear();
            List<ItemMasterModel> lstItems = objItemBL.GetItemsByName(cbxItemproduce.Text.Trim());
            foreach (ItemMasterModel objItems in lstItems)
            {
                cbxUnit.Properties.Items.Add(objItems.MainUnit);
                cbxUnit.Properties.Items.Add(objItems.AltUnit);
            }
            cbxUnit.ShowPopup();
        }

        private void cbxItemproduce_Enter(object sender, EventArgs e)
        {
            dtItems.Rows.Clear();
            DataRow dr;
            List<ItemMasterModel> lstItems = objItemBL.GetAllItems();
            foreach (ItemMasterModel objItems in lstItems)
            {
                dr = dtItems.NewRow();
                dr["Items"] = objItems.Name;
                dr["GroupName"] = objItems.Group;
                dr["Stock"] = objItems.OpStockQty;
                dr["Unit"] = objItems.Unit;
                dtItems.Rows.Add(dr);
            }
            cbxItemproduce.Properties.DataSource = dtItems;
            cbxItemproduce.Properties.DisplayMember = "Items";
            cbxItemproduce.Properties.BestFit();
            cbxItemproduce.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            cbxItemproduce.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            cbxItemproduce.ShowPopup();
        }

        private void dvgMatConsuDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void dvgMatConsuDetails_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "ItemName")
            {
                dvgMatConsuDetails.ShowEditor();
                ((LookUpEdit)dvgMatConsuDetails.ActiveEditor).ShowPopup();
                
            }
        }

        private void dvgProductGeneratedDet_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "ItemName")
            {
                dvgProductGeneratedDet.ShowEditor();
                ((LookUpEdit)dvgProductGeneratedDet.ActiveEditor).ShowPopup();

            }
        }

        private void cbxItemgenerated_KeyPress(object sender, KeyPressEventArgs e)
        {
            //string t = cbxItemgenerated.Text;
            //string typedT = t.Substring(0, cbxItemgenerated.SelectionStart);
            //string newT = typedT + e.KeyChar;

            //int i = cbxItemgenerated.Properties.TextEditStyle(newT);
            //if (i == -1)
            //{
            //    e.Handled = true;
            //}
            //if (Char.IsLetter(e.KeyChar))
            //{
            //    e.KeyChar = Char.ToUpper(e.KeyChar);
            //}
        }

        private void dvgMatConsumed_Click(object sender, EventArgs e)
        {

        }

        private void cbxUnit_Leave(object sender, EventArgs e)
        {
            if(cbxUnit.Text.Trim()=="")
            {
                cbxUnit.SelectedIndex = 0;
            }
        }
    }
}
