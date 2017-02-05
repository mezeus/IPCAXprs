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
using eSunSpeed.BusinessLogic;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;

namespace IPCAUI.Administration
{
    public partial class GSTDetails : Form
    {
        TaxCategory objtaxbl = new TaxCategory();
        ItemMasterBL objItemMasterBl = new ItemMasterBL();
        DataTable dtGST = new DataTable();
        public static long GST_Id = 0;
        public GSTDetails()
        {
            InitializeComponent();
           
        }

        private void ListTaxcategory_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.GSTcategoryList frmList = new Administration.List.GSTcategoryList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            FillGSTCategoryInfo();
        }

        private void FillGSTCategoryInfo()
        {
            if(GST_Id==0)
            {
                ClearFormValues();
                tbxName.Focus();
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                return;
            }
            List<TaxCategoryModel> objTaxCategory = objtaxbl.GetGSTCategoryRatesbyId(GST_Id);

            tbxName.Text = objTaxCategory.FirstOrDefault().GSTName;
            cbxType.SelectedItem = objTaxCategory.FirstOrDefault().TaxCat_Type;
            tbxCgstTax.Text = objTaxCategory.FirstOrDefault().CGST_Tax.ToString();
            tbxSgstTax.Text = objTaxCategory.FirstOrDefault().SGST_Tax.ToString();
            tbxIgstTax.Text = objTaxCategory.FirstOrDefault().IGST_Tax.ToString();
            cbxTaxonmrp.SelectedItem = (objTaxCategory.FirstOrDefault().TaxonMRP)?"Y":"N";
            tbxCalculatedtaxon.Text = objTaxCategory.FirstOrDefault().CalculatedTaxon.ToString();
            cbxTaxonmrpmode.SelectedItem = objTaxCategory.FirstOrDefault().TaxonMRPMode.ToString();

            dtGST.Rows.Clear();
            DataRow drTax;
            foreach(TaxRatesModel objRate in objTaxCategory.FirstOrDefault().TaxRates)
            {
                drTax = dtGST.NewRow();
                drTax["wef"]=objRate.wef ;
                drTax["CGST_Tax"] = objRate.CGST_Tax;
                drTax["SGST_Tax"] = objRate.SGST_Tax;
                drTax["Tax_Type"]= objRate.Tax_Type;
                drTax["IGST_Tax"] = objRate.IGST_Tax;
                drTax["Cess"] =objRate.Cess;
                drTax["GSTID"] = objRate.GSTID;
                drTax["TaxRate_Id"]=objRate.TaxRate_Id;
                dtGST.Rows.Add(drTax);
            }
            dvgGSTTaxratesList.DataSource = dtGST;
            tbxName.Focus();
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

    
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("GST Name can not be blank!");
                return;
            }
            eSunSpeedDomain.TaxCategoryModel objGsttax = new TaxCategoryModel();

            objGsttax.GSTName = tbxName.Text.Trim();
            objGsttax.TaxCat_Type = cbxType.SelectedItem.ToString()==""?string.Empty: cbxType.SelectedItem.ToString();
            if (cbxType.SelectedIndex == 0)
            {
                objGsttax.TaxonMRP = Convert.ToBoolean(cbxTaxonmrp.SelectedItem.ToString() == "Y" ? true : false);
                objGsttax.TaxonMRPMode = cbxTaxonmrpmode.SelectedItem.ToString()==""?string.Empty : cbxTaxonmrpmode.SelectedItem.ToString();          
            }
            objGsttax.SGST_Tax = Convert.ToDecimal(tbxSgstTax.Text.ToString() == string.Empty ? "0.00" : tbxSgstTax.Text.ToString());
            objGsttax.IGST_Tax = Convert.ToDecimal(tbxIgstTax.Text.ToString() == string.Empty ? "0.00" : tbxIgstTax.Text.ToString());
            objGsttax.CGST_Tax = Convert.ToDecimal(tbxCgstTax.Text.Trim()==string.Empty?"0.00": tbxCgstTax.Text.Trim());
            objGsttax.CalculatedTaxon = Convert.ToDecimal(tbxCalculatedtaxon.Text.ToString()==string.Empty?"0.00": tbxCalculatedtaxon.Text.ToString());
            
            //GST Tax Rates Grid
            TaxRatesModel objGSTTaxRates;
            List<TaxRatesModel> lstTaxRates = new List<TaxRatesModel>();

            for (int i = 0; i < dvgGSTTaxrateDetails.DataRowCount; i++)
            {
                DataRow row = dvgGSTTaxrateDetails.GetDataRow(i);

                objGSTTaxRates = new TaxRatesModel();
                objGSTTaxRates.wef = Convert.ToDateTime(row["wef"].ToString());
                objGSTTaxRates.CGST_Tax = Convert.ToDecimal(row["CGST_Tax"].ToString()==string.Empty?"0.00":row["CGST_Tax"].ToString());
                objGSTTaxRates.SGST_Tax = Convert.ToDecimal(row["SGST_Tax"].ToString()==string.Empty?"0.00": row["SGST_Tax"].ToString());
                objGSTTaxRates.Tax_Type = row["Tax_Type"].ToString();
                objGSTTaxRates.IGST_Tax = Convert.ToDecimal(row["IGST_Tax"].ToString()==string.Empty?"0.00": row["IGST_Tax"].ToString());
                objGSTTaxRates.Cess = Convert.ToDecimal(row["Cess"].ToString() == string.Empty ? "0.00" : row["Cess"].ToString());

                lstTaxRates.Add(objGSTTaxRates);
            }

            objGsttax.GSTTaxRates = lstTaxRates;

            bool isSuccess = objtaxbl.SaveGSTDetails(objGsttax);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearFormValues();
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

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GSTDetails_Load(object sender, EventArgs e)
        {
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            cbxTaxonmrp.SelectedIndex = 1;

            dtGST.Columns.Add("wef");
            dtGST.Columns.Add("CGST_Tax");
            dtGST.Columns.Add("SGST_Tax");
            dtGST.Columns.Add("IGST_Tax");
            dtGST.Columns.Add("Tax_Type");
            dtGST.Columns.Add("Cess");
            dtGST.Columns.Add("GSTID");
            dtGST.Columns.Add("TaxRate_Id");
            dvgGSTTaxratesList.DataSource = dtGST;

            RepositoryItemLookUpEdit TaxTypeLookup = new RepositoryItemLookUpEdit();
            TaxTypeLookup.DataSource = new string[] { "Exempt", "Zero Rated" };
            dvgGSTTaxrateDetails.Columns["Tax_Type"].ColumnEdit = TaxTypeLookup;

            TaxTypeLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            TaxTypeLookup.AutoSearchColumnIndex = 1;
        }

        private void cbxTaxonmrp_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbxTaxonmrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxTaxonmrp.SelectedItem.ToString() == "Y")
            {
                lblCalculatedtax.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblPerAmt.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblTaxonMrpmode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lblCalculatedtax.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblPerAmt.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblTaxonMrpmode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            }
        }

        private void dvgTaxrateDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
           
        }

        private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxName.Text.Trim() == "")
                {
                    MessageBox.Show("Taxcategory Name Can Not Be Blank!");
                    tbxName.Focus();
                    return;
                }
                if (objtaxbl.IsTaxCategoryExists(tbxName.Text.Trim()))
                {
                    MessageBox.Show("Taxcategory Name already Exists!");
                    tbxName.Focus();
                    return;
                }

                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);

                }
                e.Handled = true; // Mark the event as handled
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            eSunSpeedDomain.TaxCategoryModel objGsttax = new TaxCategoryModel();

            objGsttax.GSTName = tbxName.Text.Trim();
            objGsttax.TaxCat_Type = cbxType.SelectedItem.ToString() == "" ? string.Empty : cbxType.SelectedItem.ToString();
            //if (cbxType.SelectedIndex == 0)
            //{
            objGsttax.TaxonMRP = Convert.ToBoolean(cbxTaxonmrp.SelectedItem.ToString() == "Y" ? true : false);
            objGsttax.TaxonMRPMode = cbxTaxonmrpmode.SelectedItem.ToString() == "" ? string.Empty : cbxTaxonmrpmode.SelectedItem.ToString();
            //}
            objGsttax.SGST_Tax = Convert.ToDecimal(tbxSgstTax.Text.ToString() == string.Empty ? "0.00" : tbxSgstTax.Text.ToString());
            objGsttax.IGST_Tax = Convert.ToDecimal(tbxIgstTax.Text.ToString() == string.Empty ? "0.00" : tbxIgstTax.Text.ToString());
            objGsttax.CGST_Tax = Convert.ToDecimal(tbxCgstTax.Text.Trim() == string.Empty ? "0.00" : tbxCgstTax.Text.Trim());
            objGsttax.CalculatedTaxon = Convert.ToDecimal(tbxCalculatedtaxon.Text.ToString() == string.Empty ? "0.00" : tbxCalculatedtaxon.Text.ToString());

            //GST Tax Rates Grid
            TaxRatesModel objGSTTaxRates;
            List<TaxRatesModel> lstTaxRates = new List<TaxRatesModel>();

            for (int i = 0; i < dvgGSTTaxrateDetails.DataRowCount; i++)
            {
                DataRow row = dvgGSTTaxrateDetails.GetDataRow(i);

                objGSTTaxRates = new TaxRatesModel();
                objGSTTaxRates.wef = Convert.ToDateTime(row["wef"].ToString());
                objGSTTaxRates.CGST_Tax = Convert.ToDecimal(row["CGST_Tax"].ToString() == string.Empty ? "0.00" : row["CGST_Tax"].ToString());
                objGSTTaxRates.SGST_Tax = Convert.ToDecimal(row["SGST_Tax"].ToString() == string.Empty ? "0.00" : row["SGST_Tax"].ToString());
                objGSTTaxRates.Tax_Type = row["Tax_Type"].ToString();
                objGSTTaxRates.IGST_Tax = Convert.ToDecimal(row["IGST_Tax"].ToString() == string.Empty ? "0.00" : row["IGST_Tax"].ToString());
                objGSTTaxRates.Cess = Convert.ToDecimal(row["Cess"].ToString() == string.Empty ? "0.00" : row["Cess"].ToString());
                objGSTTaxRates.TaxRate_Id = Convert.ToInt32(row["TaxRate_Id"].ToString() == string.Empty ? "0" : row["TaxRate_Id"].ToString());
                objGSTTaxRates.GSTID = Convert.ToInt32(row["GSTID"].ToString() == string.Empty ? "0" : row["GSTID"].ToString());
                lstTaxRates.Add(objGSTTaxRates);
            }

            objGsttax.GSTTaxRates = lstTaxRates;
            objGsttax.GST_ID =Convert.ToInt32(GST_Id);

            bool isSuccess = objtaxbl.UpdateGSTDetails(objGsttax);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                ClearFormValues();
                GST_Id = 0;
                Administration.List.GSTcategoryList frmList = new Administration.List.GSTcategoryList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillGSTCategoryInfo();
            }
        }

        public void ClearFormValues()
        {
            tbxName.Text = string.Empty;
            cbxType.Text = string.Empty;
            tbxCgstTax.Text = "0.00";
            tbxSgstTax.Text = "0.00";
            tbxIgstTax.Text = "0.00";
            cbxTaxonmrp.Text = string.Empty;
            cbxTaxonmrpmode.Text = string.Empty;
            tbxCalculatedtaxon.Text = "0.00";
            dtGST.Rows.Clear();        
           
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //ItemMasterModel objmodel = objItemMasterBl.GetItemNameByTaxCategoryname(tbxName.Text.Trim());
            //if (objmodel.Name != null)
            //{
            //    MessageBox.Show("Can Not Delete Tax Name Under Tag With Item Name.." + objmodel.Name);
            //    tbxName.Focus();
            //}
            //if (objmodel.Name == null)
            //{
                bool isDelete = objtaxbl.DeleteGSTCategorById(GST_Id);
                if (isDelete)
                {
                    MessageBox.Show("Delete Successfully!");
                    ClearFormValues();
                    GST_Id = 0;
                    Administration.List.GSTcategoryList frmList = new Administration.List.GSTcategoryList();
                    frmList.StartPosition = FormStartPosition.CenterScreen;

                    frmList.ShowDialog();
                    FillGSTCategoryInfo();
                }
            //}
        }

        private void dvgGSTTaxrateDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void dvgGSTTaxrateDetails_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Tax_Type")
            {
                dvgGSTTaxrateDetails.ShowEditor();
                ((LookUpEdit)dvgGSTTaxrateDetails.ActiveEditor).ShowPopup();
            }
        }

        private void cbxType_Leave(object sender, EventArgs e)
        {
            if(cbxType.Text=="")
            {
                cbxType.SelectedIndex = 0;
            }
        }

        private void cbxtaxonmrpmode_Leave(object sender, EventArgs e)
        {
            if(cbxTaxonmrpmode.Text=="")
            {
                cbxTaxonmrpmode.SelectedIndex = 0;
            }
        }
    }
}
