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

namespace IPCAUI.Administration
{
    public partial class ItemMasterNew : DevExpress.XtraEditors.XtraForm
    {
        ItemMasterBL objIMBL = new ItemMasterBL();
        ItemGroupMasterBL objgrpbl = new ItemGroupMasterBL();
        UnitMaster objUnitBl = new UnitMaster();
        TaxCategory objTaxBl = new TaxCategory();
        public static int Item_Id = 0;
        public ItemMasterNew()
        {
            InitializeComponent();
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
            objModel.PrintName = tbxPrintname.Text == null ? string.Empty : tbxPrintname.Text;
            objModel.Alias = tbxAlias.Text == null?string.Empty:tbxAlias.Text.Trim();
            objModel.Group = cbxGroup.SelectedItem.ToString();
            objModel.Company = cbxGroup.SelectedItem.ToString();

            objModel.MainUnit = cbxMainUnit.SelectedItem.ToString();
            objModel.AltUnit = cbxAltUnit.SelectedItem.ToString();
            objModel.Confactor = Convert.ToDouble(tbxconFactor.Text.Trim());
          
            objModel.Unit = cbxUnit.SelectedItem.ToString();
            objModel.OpStockValue = Convert.ToDouble(tbxOpStock.Text.Trim());
            objModel.Rate = Convert.ToDouble(tbxRate.Text.Trim());
            objModel.Per = tbxPer.SelectedItem.ToString();
            objModel.Value = Convert.ToDouble(tbxValue.Text.Trim());

            objModel.ApplyPurchPrice = cbxApplyPurchPrice.SelectedItem.ToString() == "Y" ? true : false;
            objModel.ApplySalesPrice = cbxApplySalesPrice.SelectedItem.ToString() == "Y" ? true : false;
            objModel.SalePrice = Convert.ToDouble(tbxSalesPrice.Text.Trim());
            objModel.Purprice = Convert.ToDouble(tbxPurcPrice.Text.Trim());
            objModel.MRP = Convert.ToDouble(tbxMRP.Text.Trim());
            objModel.MinSalePrice = Convert.ToDouble(tbxMinSalesPrice.Text.Trim());
            objModel.SelfValuePrice = Convert.ToDouble(tbxSelfValPrice.Text.Trim());
            objModel.SaleDiscount = Convert.ToDouble(tbxSaleDiscount.Text.Trim());
            objModel.PurDiscount = Convert.ToDouble(tbxPurcDiscount.Text.Trim());
            objModel.SpecifySaleDiscStructure = cbxEnableSalesDiscStruct.SelectedItem.ToString() == "Y" ? true : false;
            objModel.SpecifyPurDiscStructure = cbxEnablePurcDiscStruct.SelectedItem.ToString() == "Y" ? true : false;
            objModel.StockValMethod = tbxStockValMethod.SelectedItem.ToString();

            objModel.TaxCategory = cbxTaxCat.SelectedItem.ToString();
            objModel.ItemDescription1 = tbxItemdesc1.Text==null?string.Empty:tbxItemdesc1.Text.Trim();
            objModel.ItemDescription2 = tbxItemdesc2.Text.Trim() == null ? string.Empty : tbxItemdesc2.Text.Trim();
            objModel.ItemDescription3 = tbxItemdesc3.Text.Trim() == null ? string.Empty : tbxItemdesc3.Text.Trim();
            objModel.ItemDescription4 = tbxItemdesc4.Text.Trim() == null ? string.Empty : tbxItemdesc4.Text.Trim();

            objModel.SetCriticalLevel = cbxCreticallevel.SelectedItem.ToString() == "Y" ? true : false;
            objModel.MaintainRG23D = cbxMaintainRG.SelectedItem.ToString() == "Y" ? true : false;
            objModel.TariffHeading = tbxTariffHeading.Text == null ? string.Empty : tbxTariffHeading.Text.Trim();
            objModel.SerialNumberwiseDetails = cbxSrlWiseDetails.SelectedItem.ToString() == "Y" ? true : false;
            objModel.ParameterizedDetails = cbxParamDetails.SelectedItem.ToString() == "Y" ? true : false;
            objModel.MRPWiseDetails = cbxMRPWiseDetails.SelectedItem.ToString() == "Y" ? true : false;
            objModel.BatchwiseDetails = cbxBatchWiseDetails.SelectedItem.ToString() == "Y" ? true : false;
            objModel.ExpDateRequired = cbxEnableExpDate.SelectedItem.ToString() == "Y" ? true : false;
            objModel.ExpiryDays = Convert.ToInt32(tbxExpDays.Text.Trim());
            objModel.SalesAccount = cbxSalesAccount.SelectedItem.ToString();
            objModel.PurcAccount = cbxPurchAccount.SelectedItem.ToString();
            objModel.DontMaintainStockBal = cbxMaintainStock.SelectedItem.ToString() == "Y" ? true : false;
            objModel.SpecifyDefaultMC = cbxSpecifyDefaultMC.SelectedItem.ToString() == "Y" ? true : false;
            objModel.FreezeMCforItem = cbxFreezeMC.SelectedItem.ToString() == "Y" ? true : false;
            objModel.TotalNumberofAuthors = Convert.ToInt32(tbxAuthors.Text.Trim());
            objModel.PickItemSizefromDescription = cbxPickitemforsizing.SelectedItem.ToString() == "Y" ? true : false;
            objModel.SpecifyDefaultVendor = cbxSpecifyDefaultVendor.SelectedItem.ToString() == "Y" ? true : false;

            //objModel.SaleCompoundDiscount = Convert.ToDouble(tbxSalesCompDisc.Text.Trim());
            //objModel.DontMaintainStockBal = Convert.ToDouble(tbxPurcDiscount.Text.Trim());

            
            if (objModel.SpecifySaleDiscStructure)
                //lblSalesDisAmt.Visible = true;

                
            if (objModel.SpecifySaleDiscStructure)
                //lblPurDiscAmt.Visible = true;

            //objModel.SaleMarkup = tbxSalesMarkup.Text.Trim();
            //objModel.PurMarkup = tbxPurchMarkup.Text.Trim();
            //objModel.SaleCompMarkup = tbxSalesCompMarkup.Text.Trim();
            //objModel.PurCompMarkup = tbxPurchCompMarkup.Text.Trim();

            //objModel.SpecifySaleMarkupStruct = cbxEnableSalesMarkupStruct.SelectedItem.ToString() == "Y" ? true : false;
            //objModel.SpecifyPurMarkupStruct = cbxEnablePurchMarkupStruct.SelectedItem.ToString() == "Y" ? true : false;
            //objModel.TaxCategory = cbxTaxCat.SelectedItem.ToString();
            //objModel.TaxonMRP = tbxMRP.SelectedItem.ToString() == "Y" ? true : false;
            //objModel.TaxType = cbxTaxCat.SelectedItem.ToString();

            //objModel.ServiceTaxRate = Convert.ToDouble(tbxServiceTaxRate.Text.Trim());
            //objModel.RateofTax_Local = Convert.ToDouble(tbxLocalTax.Text.Trim());
            //objModel.RateofTax_Central = Convert.ToDouble(tbxCentralTax.Text.Trim());
            //objModel.HSNCode = tbxHSNCode.Text.Trim();

            objModel.CreatedBy = "Admin";

            bool isSuccess = objIMBL.SaveItemMaster(objModel);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }

        private void tbxSaleDiscount_EditValueChanged(object sender, EventArgs e)
        {

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
            
            cbxEnablePurcDiscStruct.SelectedIndex = 0;
            cbxEnableSalesDiscStruct.SelectedIndex = 0;
            cbxEnableSalesMarkupStruct.SelectedIndex = 0;
            tbxStockValMethod.SelectedIndex = 0;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;

            //Unit Combobox Load
            List<UnitMasterModel> lstUnits = objUnitBl.GetListofUnits();
            foreach (UnitMasterModel objunit in lstUnits)
            {
                cbxMainUnit.Properties.Items.Add(objunit.UnitName);
                cbxUnit.Properties.Items.Add(objunit.UnitName);
                cbxAltUnit.Properties.Items.Add(objunit.UnitName);
                tbxPer.Properties.Items.Add(objunit.UnitName);
            }
            //Group&Company Combobox
            List<ItemGroupMasterModel> lstItemGroups = objgrpbl.GetAllItemGroup();
            foreach (ItemGroupMasterModel objgroup in lstItemGroups)
            {
                cbxGroup.Properties.Items.Add(objgroup.ItemGroup);
                cbxCompany.Properties.Items.Add(objgroup.ItemGroup);
            }
            //TaxCategory Combobox
            List<TaxCategoryModel> lstTaxCategeory = objTaxBl.GetAllTaxCategories();
            foreach (TaxCategoryModel objTax in lstTaxCategeory)
            {
                cbxTaxCat.Properties.Items.Add(objTax.Name);
            }
        }
        private void ItemMasterNew_Load(object sender, EventArgs e)
        {
            
            LoadDefaultValues();
        }
        public void ClearFormValues()
        {
            tbxName.Text = string.Empty;
            tbxPrintname.Text = string.Empty;
            tbxAlias.Text = string.Empty;

        }
        private void ItemList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.ItemmasterList frmList = new Administration.List.ItemmasterList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxName.Focus();

            FillItemMasterInfo();
        }

        private void FillItemMasterInfo()
        {
            ItemMasterModel objItem = objIMBL.GetAllItemsById(Item_Id);
            tbxName.Text= objItem.Name;
            tbxPrintname.Text = objItem.PrintName;
            tbxAlias.Text= objItem.Alias;
            cbxGroup.SelectedItem = objItem.Group;
            cbxCompany.SelectedItem= objItem.Company;
            cbxMainUnit.SelectedItem = objItem.MainUnit;
            cbxAltUnit.SelectedItem = objItem.AltUnit;
            tbxconFactor.Text=objItem.Confactor.ToString();
            tbxOpStock.Text= objItem.OpStockQty.ToString();
            cbxUnit.SelectedItem = objItem.Unit;
            tbxRate.Text = objItem.Rate.ToString();
            tbxPer.Text = objItem.Per.ToString();
            tbxValue.Text = objItem.Value.ToString();
            cbxApplySalesPrice.SelectedItem = objItem.ApplySalesPrice?"Y":"N";
            cbxApplyPurchPrice.SelectedItem = objItem.ApplyPurchPrice?"Y":"N";

            tbxSalesPrice.Text = objItem.SalePrice.ToString();
            tbxPurcPrice.Text= objItem.Purprice.ToString();
            tbxMRP.Text = objItem.MRP.ToString();
            tbxMinSalesPrice.Text= objItem.MinSalePrice.ToString();
            tbxSelfValPrice.Text = objItem.SelfValuePrice.ToString();
            tbxSaleDiscount.Text = objItem.SaleDiscount. ToString();
            tbxPurcDiscount.Text = objItem.PurDiscount.ToString();

            //objItem.SpecifySaleDiscStructure = Convert.ToBoolean(dr["ITEM_SPECIFYSALEDISCSTRUCT"].ToString() == "1" ? true : false);
            //objItem.SpecifyPurDiscStructure = Convert.ToBoolean(dr["ITEM_SPECIFYPURDISCSTRUCT"].ToString() == "1" ? true : false);
            tbxStockValMethod.Text =objItem.StockValMethod.ToString();

            cbxTaxCat.SelectedItem = objItem.TaxCategory;
            tbxItemdesc1.Text = objItem.ItemDescription1;
            tbxItemdesc2.Text = objItem.ItemDescription2;
            tbxItemdesc3.Text = objItem.ItemDescription3;
            tbxItemdesc4.Text = objItem.ItemDescription4;

            cbxCreticallevel.SelectedItem = (objItem.SetCriticalLevel)? "Y" : "N";

            cbxMaintainRG.SelectedItem = (objItem.MaintainRG23D)?"Y":"N";
            tbxTariffHeading.Text = objItem.TariffHeading;
            cbxSrlWiseDetails.SelectedItem = (objItem.SerialNumberwiseDetails)?"Y":"N";
            cbxMRPWiseDetails.SelectedItem =(objItem.MRPWiseDetails) ? "Y" : "N";
            cbxParamDetails.SelectedItem = (objItem.ParameterizedDetails) ?"Y" : "N";
            cbxBatchWiseDetails.SelectedItem= (objItem.BatchwiseDetails) ? "Y" : "N";
            cbxEnableExpDate.SelectedItem = (objItem.ExpDateRequired)?"Y":"N";
            tbxExpDays.Text = objItem.ExpiryDays.ToString();
            cbxSalesAccount.SelectedItem = objItem.SalesAccount.ToString();
            cbxPurchAccount.SelectedItem = objItem.PurcAccount.ToString();
            cbxSpecifyDefaultMC.SelectedItem = (objItem.SpecifyDefaultMC)?"Y":"N";
            cbxFreezeMC.SelectedItem = (objItem.FreezeMCforItem)?"Y":"N";
            tbxAuthors.Text = objItem.TotalNumberofAuthors.ToString();
            cbxMaintainStock.SelectedItem = (objItem.DontMaintainStockBal)?"Y":"N";
            cbxPickitemforsizing.SelectedItem =(objItem.PickItemSizefromDescription)?"Y":"N";
            cbxSpecifyDefaultVendor.SelectedItem = (objItem.SpecifyDefaultVendor)?"Y":"N";
        }


        private void tbxAlias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                PopupScreens.ItemAliasPopup frmAlias = new PopupScreens.ItemAliasPopup();
                frmAlias.StartPosition = FormStartPosition.CenterParent;
                frmAlias.ShowDialog();
            }
        }

        private void cbxMainUnit_Enter(object sender, EventArgs e)
        {
            cbxMainUnit.SelectedIndex = 0;
        }

        private void cbxAltUnit_Enter(object sender, EventArgs e)
        {
            cbxAltUnit.SelectedIndex = 0;
        }

        private void cbxUnit_Enter(object sender, EventArgs e)
        {
            cbxUnit.SelectedIndex = 0;
        }

        private void tbxPer_Enter(object sender, EventArgs e)
        {
            tbxPer.SelectedIndex = 0;
        }

        private void cbxTaxCat_Enter(object sender, EventArgs e)
        {
            cbxTaxCat.SelectedIndex = 0;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ItemMasterModel objModel = new ItemMasterModel();

            objModel.Name = tbxName.Text.Trim();
            objModel.PrintName = tbxPrintname.Text == null ? string.Empty : tbxPrintname.Text;
            objModel.Alias = tbxAlias.Text == null ? string.Empty : tbxAlias.Text.Trim();
            objModel.Group = cbxGroup.SelectedItem.ToString();
            objModel.Company = cbxGroup.SelectedItem.ToString();

            objModel.MainUnit = cbxMainUnit.SelectedItem.ToString();
            objModel.AltUnit = cbxAltUnit.SelectedItem.ToString();
            objModel.Confactor = Convert.ToDouble(tbxconFactor.Text.Trim());

            objModel.Unit = cbxUnit.SelectedItem.ToString();
            objModel.OpStockValue = Convert.ToDouble(tbxOpStock.Text.Trim());
            objModel.Rate = Convert.ToDouble(tbxRate.Text.Trim());
            objModel.Per = tbxPer.SelectedItem.ToString();
            objModel.Value = Convert.ToDouble(tbxValue.Text.Trim());

            objModel.ApplyPurchPrice = cbxApplyPurchPrice.SelectedItem.ToString() == "Y" ? true : false;
            objModel.ApplySalesPrice = cbxApplySalesPrice.SelectedItem.ToString() == "Y" ? true : false;
            objModel.SalePrice = Convert.ToDouble(tbxSalesPrice.Text.Trim());
            objModel.Purprice = Convert.ToDouble(tbxPurcPrice.Text.Trim());
            objModel.MRP = Convert.ToDouble(tbxMRP.Text.Trim());
            objModel.MinSalePrice = Convert.ToDouble(tbxMinSalesPrice.Text.Trim());
            objModel.SelfValuePrice = Convert.ToDouble(tbxSelfValPrice.Text.Trim());
            objModel.SaleDiscount = Convert.ToDouble(tbxSaleDiscount.Text.Trim());
            objModel.PurDiscount = Convert.ToDouble(tbxPurcDiscount.Text.Trim());
            objModel.SpecifySaleDiscStructure = cbxEnableSalesDiscStruct.SelectedItem.ToString() == "Y" ? true : false;
            objModel.SpecifyPurDiscStructure = cbxEnablePurcDiscStruct.SelectedItem.ToString() == "Y" ? true : false;
            objModel.StockValMethod = tbxStockValMethod.SelectedItem.ToString();

            objModel.TaxCategory = cbxTaxCat.SelectedItem.ToString();
            objModel.ItemDescription1 = tbxItemdesc1.Text == null ? string.Empty : tbxItemdesc1.Text.Trim();
            objModel.ItemDescription2 = tbxItemdesc2.Text.Trim() == null ? string.Empty : tbxItemdesc2.Text.Trim();
            objModel.ItemDescription3 = tbxItemdesc3.Text.Trim() == null ? string.Empty : tbxItemdesc3.Text.Trim();
            objModel.ItemDescription4 = tbxItemdesc4.Text.Trim() == null ? string.Empty : tbxItemdesc4.Text.Trim();

            objModel.SetCriticalLevel = cbxCreticallevel.SelectedItem.ToString() == "Y" ? true : false;
            objModel.MaintainRG23D = cbxMaintainRG.SelectedItem.ToString() == "Y" ? true : false;
            objModel.TariffHeading = tbxTariffHeading.Text == null ? string.Empty : tbxTariffHeading.Text.Trim();
            objModel.SerialNumberwiseDetails = cbxSrlWiseDetails.SelectedItem.ToString() == "Y" ? true : false;
            objModel.ParameterizedDetails = cbxParamDetails.SelectedItem.ToString() == "Y" ? true : false;
            objModel.MRPWiseDetails = cbxMRPWiseDetails.SelectedItem.ToString() == "Y" ? true : false;
            objModel.BatchwiseDetails = cbxBatchWiseDetails.SelectedItem.ToString() == "Y" ? true : false;
            objModel.ExpDateRequired = cbxEnableExpDate.SelectedItem.ToString() == "Y" ? true : false;
            objModel.ExpiryDays = Convert.ToInt32(tbxExpDays.Text.Trim());
            objModel.SalesAccount = cbxSalesAccount.SelectedItem.ToString();
            objModel.PurcAccount = cbxPurchAccount.SelectedItem.ToString();
            objModel.DontMaintainStockBal = cbxMaintainStock.SelectedItem.ToString() == "Y" ? true : false;
            objModel.SpecifyDefaultMC = cbxSpecifyDefaultMC.SelectedItem.ToString() == "Y" ? true : false;
            objModel.FreezeMCforItem = cbxFreezeMC.SelectedItem.ToString() == "Y" ? true : false;
            objModel.TotalNumberofAuthors = Convert.ToInt32(tbxAuthors.Text.Trim());
            objModel.PickItemSizefromDescription = cbxPickitemforsizing.SelectedItem.ToString() == "Y" ? true : false;
            objModel.SpecifyDefaultVendor = cbxSpecifyDefaultVendor.SelectedItem.ToString() == "Y" ? true : false;

            //objModel.SaleCompoundDiscount = Convert.ToDouble(tbxSalesCompDisc.Text.Trim());
            //objModel.DontMaintainStockBal = Convert.ToDouble(tbxPurcDiscount.Text.Trim());


            if (objModel.SpecifySaleDiscStructure)
                //lblSalesDisAmt.Visible = true;


                if (objModel.SpecifySaleDiscStructure)
                    //lblPurDiscAmt.Visible = true;

                    //objModel.SaleMarkup = tbxSalesMarkup.Text.Trim();
                    //objModel.PurMarkup = tbxPurchMarkup.Text.Trim();
                    //objModel.SaleCompMarkup = tbxSalesCompMarkup.Text.Trim();
                    //objModel.PurCompMarkup = tbxPurchCompMarkup.Text.Trim();

                    //objModel.SpecifySaleMarkupStruct = cbxEnableSalesMarkupStruct.SelectedItem.ToString() == "Y" ? true : false;
                    //objModel.SpecifyPurMarkupStruct = cbxEnablePurchMarkupStruct.SelectedItem.ToString() == "Y" ? true : false;
                    //objModel.TaxCategory = cbxTaxCat.SelectedItem.ToString();
                    //objModel.TaxonMRP = tbxMRP.SelectedItem.ToString() == "Y" ? true : false;
                    //objModel.TaxType = cbxTaxCat.SelectedItem.ToString();

                    //objModel.ServiceTaxRate = Convert.ToDouble(tbxServiceTaxRate.Text.Trim());
                    //objModel.RateofTax_Local = Convert.ToDouble(tbxLocalTax.Text.Trim());
                    //objModel.RateofTax_Central = Convert.ToDouble(tbxCentralTax.Text.Trim());
                    //objModel.HSNCode = tbxHSNCode.Text.Trim();
                    objModel.ItemId = Item_Id;
                    objModel.CreatedBy = "Admin";

            bool isSuccess = objIMBL.UpdateItemMaster(objModel);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objIMBL.DeleteItemMasterById(Item_Id);
            if(isDelete)
            {
                MessageBox.Show("Delete Successfully!");
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
    }
}
