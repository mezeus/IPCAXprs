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


namespace IPCAUI.Administration
{
    public partial class Taxcategory : Form
    {
        TaxCategory objtaxbl = new TaxCategory();
        ItemMasterBL objItemMasterBl = new ItemMasterBL();
        public static int Tax_Id = 0;
        public Taxcategory()
        {
            InitializeComponent();
           
        }

        private void ListTaxcategory_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.TaxcategoryList frmList = new Administration.List.TaxcategoryList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            if (Tax_Id!=0)
            {
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                tbxName.Focus();
                FillTaxCategoryInfo();
            }            
   
        }

        private void FillTaxCategoryInfo()
        {
            List<TaxCategoryModel> objTaxCategory = objtaxbl.GetTaxCategoryRatesbyId(Tax_Id);

            tbxName.Text = objTaxCategory.FirstOrDefault().Name;
            cbxtype.SelectedItem = objTaxCategory.FirstOrDefault().TaxCat_Type;
            tbxServiceTax.Text = objTaxCategory.FirstOrDefault().ServiceTax.ToString();
            tbxRateoftaxLocal.Text = objTaxCategory.FirstOrDefault().Local_Tax.ToString();
            cbxTaxationtype.SelectedItem = objTaxCategory.FirstOrDefault().ToString();
            tbxRateofCenteral.Text = objTaxCategory.FirstOrDefault().CentralTax.ToString();
            cbxTaxonmrp.SelectedItem = objTaxCategory.FirstOrDefault().TaxonMRP.ToString();
            tbxcalculatedtaxon.Text = objTaxCategory.FirstOrDefault().CalculatedTaxon.ToString();
            cbxtaxonmrpmode.SelectedItem = objTaxCategory.FirstOrDefault().TaxonMRPMode.ToString();
            tbxHsn.Text = objTaxCategory.FirstOrDefault().HSNCode.ToString();
            tbxDescription.Text = objTaxCategory.FirstOrDefault().Tax_Desc.ToString();
          
            dvgTaxratesList.DataSource = objTaxCategory.FirstOrDefault().TaxRates;
        }

    
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Name can not be blank!");
                return;
            }
            eSunSpeedDomain.TaxCategoryModel objtaxcat = new TaxCategoryModel();

            objtaxcat.Name = tbxName.Text.Trim();
            objtaxcat.TaxCat_Type = cbxtype.SelectedItem.ToString();
            if (cbxtype.SelectedIndex == 0)
            {
                objtaxcat.Local_Tax = Convert.ToDecimal(tbxRateoftaxLocal.Text.ToString());
                objtaxcat.CentralTax = Convert.ToDecimal(tbxRateofCenteral.Text.ToString());
                objtaxcat.TaxonMRP = Convert.ToBoolean(cbxTaxonmrp.SelectedItem.ToString() == "Y" ? true : false);
                if (cbxTaxonmrp.SelectedItem.ToString() == "Y")
                {
                    objtaxcat.CalculatedTaxon = Convert.ToDecimal(tbxcalculatedtaxon.Text.ToString());
                    objtaxcat.TaxonMRPMode = cbxtaxonmrpmode.SelectedItem.ToString();
                }

                objtaxcat.Taxation_Type = cbxTaxationtype.Text == null ? string.Empty : cbxTaxationtype.Text.Trim();
                objtaxcat.HSNCode = tbxHsn.Text == null ? string.Empty : tbxHsn.Text.Trim();
                objtaxcat.Tax_Desc = tbxDescription.Text == null ? string.Empty : tbxDescription.Text.Trim();
            }
            if(cbxtype.SelectedIndex==1)
            {
                objtaxcat.ServiceTax = Convert.ToDecimal(tbxServiceTax.Text.Trim());
            }
            
            //Tax Rates Grid
            TaxRatesModel objTaxRates;
            List<TaxRatesModel> lstTaxRates = new List<TaxRatesModel>();

            for (int i = 0; i < dvgTaxrateDetails.DataRowCount; i++)
            {
                DataRow row = dvgTaxrateDetails.GetDataRow(i);

                objTaxRates = new TaxRatesModel();
                objTaxRates.wef = Convert.ToDateTime(row["wef"].ToString());
                objTaxRates.Local_Tax = Convert.ToDecimal(row["Local_Tax"].ToString());
                objTaxRates.Local_Schg = Convert.ToDecimal(row["Local_Schg"].ToString());
                objTaxRates.Tax_Type = row["Tax_Type"].ToString();
                objTaxRates.Tax_Central = Convert.ToDecimal(row["Tax_Central"].ToString());
                objTaxRates.Schg_Central = Convert.ToDecimal(row["Schg_Central"].ToString());
                objTaxRates.Entry_Tax = Convert.ToDecimal(row["Entry_Tax"].ToString());
                objTaxRates.Service_Tax = Convert.ToDecimal(row["Service_Tax"].ToString());

                lstTaxRates.Add(objTaxRates);
            }

            objtaxcat.TaxRates = lstTaxRates;

            string message = string.Empty;

            bool isSuccess = objtaxbl.SaveTaxCategory(objtaxcat);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                tbxName.Text = string.Empty;
                tbxRateoftaxLocal.Text = string.Empty;
                tbxRateofCenteral.Text = string.Empty;
                tbxHsn.Text = string.Empty;
                tbxDescription.Text = string.Empty;
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

        private void Taxcategory_Load(object sender, EventArgs e)
        {
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            cbxTaxonmrp.SelectedIndex = 1;
            DataTable dt = new DataTable();
            dt.Columns.Add("wef");
            dt.Columns.Add("Local_Tax");
            dt.Columns.Add("Local_Schg");
            dt.Columns.Add("Tax_Type");
            dt.Columns.Add("Tax_Central");
            dt.Columns.Add("Schg_Central");
            dt.Columns.Add("Entry_Tax");
            dt.Columns.Add("Service_Tax");
            dt.Columns.Add("TaxCat_Id");
            dt.Columns.Add("TaxRate_Id");
            dvgTaxratesList.DataSource = dt;
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

        private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxName.Text.Trim() == "")
                {
                    MessageBox.Show("Tax Name Can Not Be Blank!");
                    tbxName.Focus();
                    return;
                }
                if (objtaxbl.IsTaxCategoryExists(tbxName.Text.Trim()))
                {
                    MessageBox.Show("Tax Name already Exists!");
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
            eSunSpeedDomain.TaxCategoryModel objtaxcat = new TaxCategoryModel();

            objtaxcat.Name = tbxName.Text.Trim();
            objtaxcat.TaxCat_Type = cbxtype.SelectedItem.ToString();
            if (cbxtype.SelectedIndex == 0)
            {
                objtaxcat.Local_Tax = Convert.ToDecimal(tbxRateoftaxLocal.Text.ToString());
                objtaxcat.CentralTax = Convert.ToDecimal(tbxRateofCenteral.Text.ToString());
                objtaxcat.TaxonMRP = Convert.ToBoolean(cbxTaxonmrp.SelectedItem.ToString() == "Y" ? true : false);
                if (cbxTaxonmrp.SelectedItem.ToString() == "Y")
                {
                    objtaxcat.CalculatedTaxon = Convert.ToDecimal(tbxcalculatedtaxon.Text.ToString());
                    objtaxcat.TaxonMRPMode = cbxtaxonmrpmode.SelectedItem.ToString();
                }

                objtaxcat.Taxation_Type = cbxTaxationtype.Text == null ? string.Empty : cbxTaxationtype.Text.Trim();
                objtaxcat.HSNCode = tbxHsn.Text == null ? string.Empty : tbxHsn.Text.Trim();
                objtaxcat.Tax_Desc = tbxDescription.Text == null ? string.Empty : tbxDescription.Text.Trim();
            }
            if (cbxtype.SelectedIndex == 1)
            {
                objtaxcat.ServiceTax = Convert.ToDecimal(tbxServiceTax.Text.Trim());
            }

            //Tax Rates Grid
            TaxRatesModel objTaxRates;
            List<TaxRatesModel> lstTaxRates = new List<TaxRatesModel>();

            for (int i = 0; i < dvgTaxrateDetails.DataRowCount; i++)
            {
                DataRow row = dvgTaxrateDetails.GetDataRow(i);

                objTaxRates = new TaxRatesModel();

                objTaxRates.wef = Convert.ToDateTime(row["wef"].ToString());
                objTaxRates.Local_Tax = Convert.ToDecimal(row["Local_Tax"].ToString());
                objTaxRates.Local_Schg = Convert.ToDecimal(row["Local_Schg"].ToString());
                objTaxRates.Tax_Type = row["Tax_Type"].ToString();
                objTaxRates.Tax_Central = Convert.ToDecimal(row["Tax_Central"].ToString());
                objTaxRates.Schg_Central = Convert.ToDecimal(row["Schg_Central"].ToString());
                objTaxRates.Entry_Tax = Convert.ToDecimal(row["Entry_Tax"].ToString());
                objTaxRates.Service_Tax = Convert.ToDecimal(row["Service_Tax"].ToString());
                objTaxRates.TaxCat_Id = Convert.ToInt32(row["TaxCat_Id"]);
                objTaxRates.TaxRate_Id = Convert.ToInt32(row["TaxRate_Id"]);

                lstTaxRates.Add(objTaxRates);
            }

            objtaxcat.TaxRates = lstTaxRates;

            string message = string.Empty;

            bool isSuccess = objtaxbl.UpdateTaxCategory(objtaxcat);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                tbxName.Text = string.Empty;
                tbxRateoftaxLocal.Text = string.Empty;
                tbxRateofCenteral.Text = string.Empty;
                tbxHsn.Text = string.Empty;
                tbxDescription.Text = string.Empty;
            }
        }

        public void ClearFormValues()
        {
            tbxName.Text = string.Empty;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ItemMasterModel objmodel = objItemMasterBl.GetItemNameByTaxCategoryname(tbxName.Text.Trim());
            if (objmodel.Name != null)
            {
                MessageBox.Show("Can Not Delete Tax Name Under Tag With Item Name.." + objmodel.Name);
                tbxName.Focus();
            }
            if (objmodel.Name == null)
            {
                bool isDelete = objtaxbl.DeleteTaxCategorById(Tax_Id);
                if (isDelete)
                {
                    MessageBox.Show("Delete Successfully!");
                    ClearFormValues();
                    Tax_Id = 0;

                }
            }
        }
    }
}
