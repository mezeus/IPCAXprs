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

namespace IPCAUI.Administration
{
    public partial class Itemsmaster : Form
    {
        ItemMasterBL objIMBL = new ItemMasterBL();
        ItemGroupMasterBL objgrpbl = new ItemGroupMasterBL();
        public Itemsmaster()
        {
            InitializeComponent();
        }

        private void ListItemmaster_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.ItemmasterList frmList = new Administration.List.ItemmasterList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

        private void comboBoxEdit14_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Item Group Name can not be blank!");
                return;
            }

            //if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
            //{
            //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            //    cbxUnderGrp.Focus();
            //    return;
            //}

            ItemMasterModel objModel = new ItemMasterModel();

            objModel.Name = tbxName.Text.Trim();
            objModel.Alias = tbxAlias.Text.Trim();
            objModel.Group = cbxGroup.SelectedItem.ToString();
            objModel.Unit = cbxMainUnit.SelectedItem.ToString();
            objModel.OpStockQty = Convert.ToDouble(tbxOpQty.Text.Trim());
            objModel.OpStockValue = Convert.ToDouble(tbxOpValue.Text.Trim());
            objModel.AltUnit = cbxAltUnit.SelectedItem.ToString();
            objModel.Confactor = Convert.ToDouble(tbxconFactor.Text.Trim());
            objModel.ConType = tbxConType.Text.Trim();
            objModel.AltOpQty = Convert.ToDouble(tbxAltOpQty.Text.Trim());
            objModel.ApplyPurchPrice = cbxApplyPurchPrice.SelectedItem.ToString() == "Y" ? true : false;
            objModel.ApplySalesPrice = cbxApplySalesPrice.SelectedItem.ToString() == "Y" ? true : false;
            objModel.SalePrice = Convert.ToDouble(tbxSalesPrice.Text.Trim());
            objModel.Purprice = Convert.ToDouble(tbxPurcPrice.Text.Trim());
            objModel.MRP = Convert.ToDouble(tbxMRP.Text.Trim());
            objModel.MinSalePrice = Convert.ToDouble(tbxMinSalesPrice.Text.Trim());
            objModel.SelfValuePrice = Convert.ToDouble(tbxSelfValPrice.Text.Trim());
            objModel.SetCriticalLevel = cbxCreticallevel.SelectedItem.ToString() == "Y" ? true : false;
            objModel.SaleDiscount = Convert.ToDouble(tbxSaleDiscount.Text.Trim());
            objModel.PurDiscount = Convert.ToDouble(tbxPurchaseDiscount.Text.Trim());
            objModel.SaleCompoundDiscount = Convert.ToDouble(tbxSalesCompDisc.Text.Trim());
            objModel.PurCompoundDiscount = Convert.ToDouble(tbxPurchCompDisc.Text.Trim());

            objModel.SpecifySaleDiscStructure = cbxEnableSalesDiscStruct.SelectedItem.ToString() == "Y" ? true : false;
            if (objModel.SpecifySaleDiscStructure)
                //lblSalesDisAmt.Visible = true;

            objModel.SpecifyPurDiscStructure = cbxEnablePurchDiscStruct.SelectedItem.ToString() == "Y" ? true : false;
            if (objModel.SpecifySaleDiscStructure)
                //lblPurDiscAmt.Visible = true;

            objModel.SaleMarkup = tbxSalesMarkup.Text.Trim();
            objModel.PurMarkup = tbxPurchMarkup.Text.Trim();
            objModel.SaleCompMarkup = tbxSalesCompMarkup.Text.Trim();
            objModel.PurCompMarkup = tbxPurchCompMarkup.Text.Trim();

            objModel.SpecifySaleMarkupStruct = cbxEnableSalesMarkupStruct.SelectedItem.ToString() == "Y" ? true : false;
            objModel.SpecifyPurMarkupStruct = cbxEnablePurchMarkupStruct.SelectedItem.ToString() == "Y" ? true : false;
            objModel.TaxCategory = cbxTaxCat.SelectedItem.ToString();
            //objModel.TaxonMRP = tbxMRP.SelectedItem.ToString() == "Y" ? true : false;
            //objModel.TaxType = cbxTaxCat.SelectedItem.ToString();

            //objModel.ServiceTaxRate = Convert.ToDouble(tbxServiceTaxRate.Text.Trim());
            //objModel.RateofTax_Local = Convert.ToDouble(tbxLocalTax.Text.Trim());
            //objModel.RateofTax_Central = Convert.ToDouble(tbxCentralTax.Text.Trim());
            //objModel.HSNCode = tbxHSNCode.Text.Trim();

            objModel.ItemDescription1 = tbxItemdesc1.Text.Trim();
            objModel.ItemDescription2 = tbxItemdesc2.Text.Trim();
            objModel.ItemDescription3 = tbxItemdesc3.Text.Trim();

            objModel.MaintainRG23D = cbxMaintainRG.SelectedItem.ToString() == "Y" ? true : false;
            objModel.TariffHeading = cbxTariffHeading.SelectedItem.ToString();
            objModel.MRPWiseDetails = cbxMRPWiseDetails.SelectedItem.ToString() == "Y" ? true : false;
            objModel.BatchwiseDetails = cbxBatchWiseDetails.SelectedItem.ToString() == "Y" ? true : false;
            objModel.SalesAccount = cbxSalesAccount.SelectedItem.ToString();
            objModel.PurcAccount = cbxPurchAccount.SelectedItem.ToString();
            objModel.SpecifyDefaultMC = cbxSpecifyDefaultMC.SelectedItem.ToString() == "Y" ? true : false;
            objModel.FreezeMCforItem = cbxFreezeMC.SelectedItem.ToString() == "Y" ? true : false;
            objModel.SerialNumberwiseDetails = cbxSrlWiseDetails.SelectedItem.ToString() == "Y" ? true : false;
            objModel.TotalNumberofAuthors = Convert.ToInt32(tbxAuthors.Text.Trim());
            objModel.ParameterizedDetails = cbxParamDetails.SelectedItem.ToString() == "Y" ? true : false;
            objModel.SpecifyDefaultVendor = cbxSpecifyDefaultVendor.SelectedItem.ToString() == "Y" ? true : false;
            objModel.ExpDateRequired = cbxEnableExpDate.SelectedItem.ToString() == "Y" ? true : false;
            objModel.ExpiryDays = Convert.ToInt32(tbxExpDays.Text.Trim());
            objModel.PickItemSizefromDescription = cbxPickitemforsizing.SelectedItem.ToString() == "Y" ? true : false;

            objModel.CreatedBy = "Admin";


            bool isSuccess = objIMBL.SaveItemMaster(objModel);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }

        private void Itemsmaster_Load(object sender, EventArgs e)
        {
            List<ItemGroupMasterModel> lstgroupmodel = objgrpbl.GetAllItemGroup();
            foreach(ItemGroupMasterModel objgroup in lstgroupmodel)
            {
                cbxGroup.Properties.Items.Add(objgroup.ItemGroup);
            }
            LoadDefaultValues();
            
        }
        public void LoadDefaultValues()
        {
            cbxAltUnit.SelectedIndex = 0;
            cbxTaxCat.SelectedIndex = 0;
            cbxGroup.SelectedIndex = 0;
            cbxCreticallevel.SelectedIndex = 0;
            cbxApplySalesPrice.SelectedIndex = 0;
            cbxApplyPurchPrice.SelectedIndex = 0;
            cbxMaintainRG.SelectedIndex = 0;
            cbxTariffHeading.SelectedIndex = 0;
            cbxMRPWiseDetails.SelectedIndex = 0;
            cbxBatchWiseDetails.SelectedIndex = 0;
            cbxSalesAccount.SelectedIndex = 0;
            cbxPurchAccount.SelectedIndex = 0;
            cbxSpecifyDefaultMC.SelectedIndex = 0;
            cbxFreezeMC.SelectedIndex = 0;
            cbxSrlWiseDetails.SelectedIndex = 0;
            cbxParamDetails.SelectedIndex = 0;
            cbxEnableExpDate.SelectedIndex = 0;
            cbxMaintainStock.SelectedIndex = 0;
            cbxPickitemforsizing.SelectedIndex = 0;
            cbxSpecifyDefaultVendor.SelectedIndex = 0;

            tbxStockValmethod.SelectedIndex = 0;
            cbxEnablePurchDiscStruct.SelectedIndex = 0;
            cbxEnableSalesDiscStruct.SelectedIndex = 0;
            cbxEnableSalesMarkupStruct.SelectedIndex = 0;
            cbxEnablePurchMarkupStruct.SelectedIndex = 0;
        }
    }
}
