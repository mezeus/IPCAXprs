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
        AccountMasterBL objaccbl = new AccountMasterBL();

        public static ItemMasterModel objModel=new ItemMasterModel();
        public static int Item_Id = 0;
        public static bool isGroupF3 = false;

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

            objModel.Name = tbxName.Text.Trim();
            objModel.PrintName = tbxPrintname.Text == null ? string.Empty : tbxPrintname.Text;
            objModel.Alias = tbxAlias.Text == null?string.Empty:tbxAlias.Text.Trim();
            objModel.Group = cbxGroup.SelectedItem.ToString();
            objModel.Company = cbxGroup.SelectedItem.ToString();

            objModel.MainUnit = cbxMainUnit.SelectedItem.ToString();
            objModel.AltUnit = cbxAltUnit.SelectedItem.ToString();
            //objModel.Confactor = Convert.ToDouble(tbxconFactor.Text.Trim());
          
            objModel.Unit = cbxUnit.SelectedItem.ToString();
            objModel.OpStockValue = Convert.ToDouble(tbxOpStock.Text.Trim());
            objModel.Rate = Convert.ToDouble(tbxRate.Text.Trim());
            objModel.Per = tbxPer.SelectedItem.ToString();
            objModel.Value = Convert.ToDouble(tbxValue.Text.Trim());

            objModel.ApplyPurchPrice = cbxApplyPurchPrice.SelectedItem.ToString();
            objModel.ApplySalesPrice = cbxApplySalesPrice.SelectedItem.ToString();
            objModel.MainSalePrice = Convert.ToDecimal(tbxMainSalesPrice.Text.Trim());
            objModel.MainPurprice = Convert.ToDecimal(tbxMainPurcPrice.Text.Trim());
            objModel.MainMRP = Convert.ToDecimal(tbxMainMRP.Text.Trim());
            objModel.MainMinSalePrice = Convert.ToDecimal(tbxMainMinSalesPrice.Text.Trim());
            objModel.SelfValuePrice = Convert.ToDecimal(tbxSelfValPrice.Text.Trim() == null ? "0" : tbxSelfValPrice.Text.Trim());

            objModel.AltSalePrice = Convert.ToDecimal(tbxAltSalesPrice.Text.Trim());
            objModel.AltPurprice = Convert.ToDecimal(tbxAltPurcPrice.Text.Trim()==null?"0": tbxAltPurcPrice.Text.Trim());
            objModel.AltMinSalePrice = Convert.ToDecimal(tbxAltMinSalesPrice.Text.Trim() == null ? "0.00" : tbxAltMinSalesPrice.Text.Trim());
            objModel.AltMRP = Convert.ToDecimal(tbxAltMRP.Text.Trim() == null ? "0" : tbxAltMRP.Text.Trim());

            objModel.DiscountInfo = cbxDiscountInfo.SelectedItem.ToString() == "Y" ? true : false;
            if(objModel.DiscountInfo)
            {
                Convert.ToDecimal(objModel.SaleDiscount);
                Convert.ToDecimal(objModel.PurDiscount);
                Convert.ToDecimal(objModel.SaleCompoundDiscount);
                Convert.ToDecimal(objModel.PurCompoundDiscount);
                Convert.ToBoolean(objModel.SpecifySaleDiscStructure);
                Convert.ToBoolean(objModel.SpecifyPurDiscStructure);
            }
            objModel.MarkupInfo = cbxMarkupInfo.SelectedItem.ToString() == "Y" ? true : false;
            if(objModel.MarkupInfo)
            {
                Convert.ToString(objModel.SaleMarkup);
                Convert.ToString(objModel.PurMarkup);
                Convert.ToString(objModel.SaleCompMarkup);
                Convert.ToString(objModel.PurCompMarkup);
                Convert.ToBoolean(objModel.SpecifySaleMarkupStruct);
                Convert.ToBoolean(objModel.SpecifyPurMarkupStruct);
            }
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
            if (cbxSrlWiseDetails.SelectedItem.ToString() == "Y" && (tbxOpStock.Text.Trim() !="0.00"))
            {
                PopupScreens.SerialnoWiseDetails frmserial = new PopupScreens.SerialnoWiseDetails();
                frmserial.StartPosition = FormStartPosition.CenterScreen;
                frmserial.ShowDialog();

                //Convert.ToBoolean(ItemMasterNew.objModel.ManualNuber);
                //Convert.ToBoolean(ItemMasterNew.objModel.AutoNumber);
                //Convert.ToInt32(ItemMasterNew.objModel.StaringAutoNo);
                //Convert.ToString(ItemMasterNew.objModel.StructureName);
                //Convert.ToBoolean(ItemMasterNew.objModel.TrackSaleWaranty);
                //Convert.ToBoolean(ItemMasterNew.objModel.TrackPurcWaranty);
                //Convert.ToBoolean(ItemMasterNew.objModel.ItemSerialNumber.FirstOrDefau.TrackInstallationWaranty);
            }
            objModel.ParameterizedDetails = cbxParamDetails.SelectedItem.ToString() == "Y" ? true : false;
            if (cbxParamDetails.SelectedItem.ToString() == "Y" && (tbxValue.Text.Trim() != "0"))
            {
                PopupScreens.ParameterizedStock frmserial = new PopupScreens.ParameterizedStock();
                frmserial.StartPosition = FormStartPosition.CenterScreen;
                frmserial.ShowDialog();
            }
            objModel.MRPWiseDetails = cbxMRPWiseDetails.SelectedItem.ToString() == "Y" ? true : false;
            if (cbxMRPWiseDetails.SelectedItem.ToString() == "Y" && (tbxValue.Text.Trim() != "0"))
            {
                PopupScreens.MRPwiseDetails frmserial = new PopupScreens.MRPwiseDetails();
                frmserial.StartPosition = FormStartPosition.CenterScreen;
                frmserial.ShowDialog();
            }
            objModel.BatchwiseDetails = cbxBatchWiseDetails.SelectedItem.ToString() == "Y" ? true : false;
            if (cbxBatchWiseDetails.SelectedItem.ToString() == "Y" && (tbxValue.Text.Trim() != "0"))
            {
                PopupScreens.ItemBatchDetails frmserial = new PopupScreens.ItemBatchDetails();
                frmserial.StartPosition = FormStartPosition.CenterScreen;
                frmserial.ShowDialog();
            }
            objModel.ExpDateRequired = cbxEnableExpDate.SelectedItem.ToString() == "Y" ? true : false;
            objModel.ExpiryDays = Convert.ToInt32(tbxExpDays.Text.Trim()==null?"0":tbxExpDays.Text.Trim());
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

            objModel.CreatedBy = "Admin";

            bool isSaved = objIMBL.SaveItemMaster(objModel);
            if (isSaved)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }

        private void tbxSaleDiscount_EditValueChanged(object sender, EventArgs e)
        {

        }
        public void LoadDefaultValues()
        {
            tbxName.Focus();
            cbxAltUnit.SelectedIndex = 0;
            cbxTaxCat.SelectedIndex = 0;
           
            cbxCreticallevel.SelectedIndex = 0;
            cbxApplySalesPrice.SelectedIndex = 0;
            cbxApplyPurchPrice.SelectedIndex = 0;
            cbxMaintainRG.SelectedIndex = 0;
            cbxMRPWiseDetails.SelectedIndex = 1;
            cbxBatchWiseDetails.SelectedIndex = 1;
            cbxSalesAccount.SelectedIndex = 0;
            cbxPurchAccount.SelectedIndex = 0;
            cbxSpecifyDefaultMC.SelectedIndex = 0;
            cbxFreezeMC.SelectedIndex = 0;
            cbxSrlWiseDetails.SelectedIndex = 1;
            cbxParamDetails.SelectedIndex = 1;
            cbxEnableExpDate.SelectedIndex = 0;
            cbxMaintainStock.SelectedIndex = 0;
            cbxPickitemforsizing.SelectedIndex = 0;
            cbxSpecifyDefaultVendor.SelectedIndex = 0;
            
            cbxDiscountInfo.SelectedIndex = 1;
            cbxMarkupInfo.SelectedIndex = 1;
            //cbxEnableSalesMarkupStruct.SelectedIndex = 0;
            tbxStockValMethod.SelectedIndex = 0;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;

            //Unit Combobox Load
            List<UnitMasterModel> lstUnits = objUnitBl.GetListofUnits();
            foreach (UnitMasterModel objunit in lstUnits)
            {
                cbxMainUnit.Properties.Items.Add(objunit.UnitName);
                //cbxUnit.Properties.Items.Add(objunit.UnitName);
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
            //Sale Account& Purchase Account Comboboxs
            List<AccountMasterModel> lstAccounts = objaccbl.GetListofAccount();
            foreach(AccountMasterModel objAccMast in lstAccounts)
            {
                cbxSalesAccount.Properties.Items.Add(objAccMast.AccountName);
                cbxPurchAccount.Properties.Items.Add(objAccMast.AccountName);
            }
            cbxSalesAccount.SelectedIndex = 0;
            cbxPurchAccount.SelectedIndex = 0;

        }
        private void ItemMasterNew_Load(object sender, EventArgs e)
        {            
            LoadDefaultValues();
        }
        public void ClearControls()
        {
            tbxName.Text = string.Empty;
            tbxPrintname.Text = string.Empty;
            tbxAlias.Text = string.Empty;
            //tbxconFactor.Text = string.Empty;
            tbxOpStock.Text = "0.00";
            tbxRate.Text = "0.00";
            tbxValue.Text = "0.00";
            tbxMainSalesPrice.Text = "0.00";

            
        }
      
        private void ItemList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.ItemmasterList frmList = new Administration.List.ItemmasterList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            if(Item_Id!=0)
            {
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                tbxName.Focus();

                FillItemMasterInfo();
            }
            
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
            //tbxconFactor.Text=objItem.Confactor.ToString();
            tbxOpStock.Text= objItem.OpStockQty.ToString();
            cbxUnit.SelectedItem = objItem.Unit;
            tbxRate.Text = objItem.Rate.ToString();
            tbxPer.Text = objItem.Per.ToString();
            tbxValue.Text = objItem.Value.ToString();
            cbxApplySalesPrice.SelectedItem = objItem.ApplySalesPrice;
            cbxApplyPurchPrice.SelectedItem = objItem.ApplyPurchPrice;

            tbxMainSalesPrice.Text = objItem.MainSalePrice.ToString();
            tbxMainPurcPrice.Text= objItem.MainPurprice.ToString();
            tbxMainMRP.Text = objItem.MainMRP.ToString();
            tbxMainMinSalesPrice.Text= objItem.MainMinSalePrice.ToString();
            tbxSelfValPrice.Text = objItem.SelfValuePrice.ToString();
            //tbxSaleDiscount.Text = objItem.SaleDiscount. ToString();
            //tbxPurcDiscount.Text = objItem.PurDiscount.ToString();

            //cbxEnableSalesDiscStruct.SelectedItem = (objItem.SpecifySaleDiscStructure) ? "Y" : "N";
            //cbxEnablePurcDiscStruct.SelectedItem = (objItem.SpecifyPurDiscStructure) ? "Y" : "N";
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

            // cbxMainUnit.SelectedIndex = 0;

            CalculateOpStockValue();

            //if (cbxUnit.SelectedItem.ToString().Equals(tbxPer.SelectedItem.ToString()))
            //{
            //    tbxValue.Text = (Convert.ToDecimal(tbxOpStock.Text) * Convert.ToDecimal(tbxRate.Text)).ToString();
            //}
            ////Find the matching unit to calculate op stock value
            //else if (cbxUnit.SelectedItem.ToString().Equals(lblMainUnit.Text))
            //{
            //    decimal cal = Convert.ToDecimal(tbxOpStock.Text) / Convert.ToDecimal(tbxConTo.Text);

            //    tbxValue.Text = (cal * (Convert.ToDecimal(tbxConFrom.Text) * Convert.ToDecimal(tbxRate.Text))).ToString();
            //}

            //else if (cbxUnit.SelectedItem.ToString().Equals(lblAltunit.Text))
            //{
            //    decimal cal = Convert.ToDecimal(tbxOpStock.Text) / Convert.ToDecimal(tbxConFrom.Text);

            //    tbxValue.Text = (cal * (Convert.ToDecimal(tbxConTo.Text) * Convert.ToDecimal(tbxRate.Text))).ToString();
            //}

        }

        private void cbxAltUnit_Enter(object sender, EventArgs e)
        {
            tbxConFrom.Enabled = true;
            tbxConTo.Enabled = true;

            if (cbxAltUnit.SelectedItem.ToString().Equals("None"))
            {
                tbxConFrom.Enabled = false;
                tbxConTo.Enabled = false;
            }

         //   cbxAltUnit.SelectedIndex = 0;

            if (cbxUnit.SelectedItem.ToString().Equals(tbxPer.SelectedItem.ToString()))
            {
                tbxValue.Text = (Convert.ToDecimal(tbxOpStock.Text) * Convert.ToDecimal(tbxRate.Text)).ToString();
            }
            //Find the matching unit to calculate op stock value
            else if (cbxUnit.SelectedItem.ToString().Equals(lblMainUnit.Text))
            {
                decimal cal = Convert.ToDecimal(tbxOpStock.Text) / Convert.ToDecimal(tbxConTo.Text);

                tbxValue.Text = (cal * (Convert.ToDecimal(tbxConFrom.Text) * Convert.ToDecimal(tbxRate.Text))).ToString();
            }

            else if (cbxUnit.SelectedItem.ToString().Equals(lblAltunit.Text))
            {
                decimal cal = Convert.ToDecimal(tbxOpStock.Text) / Convert.ToDecimal(tbxConFrom.Text);

                tbxValue.Text = (cal * (Convert.ToDecimal(tbxConTo.Text) * Convert.ToDecimal(tbxRate.Text))).ToString();
            }

        }

        private void cbxUnit_Enter(object sender, EventArgs e)
        {
            cbxUnit.Properties.Items.Clear();

            cbxUnit.Properties.Items.Add(cbxMainUnit.SelectedItem.ToString().Trim());
            cbxUnit.Properties.Items.Add(cbxAltUnit.SelectedItem.ToString().Trim());
                        
            cbxUnit.Properties.Items.Remove("None");

            cbxUnit.SelectedIndex = 0;
        }

        private void tbxPer_Enter(object sender, EventArgs e)
        {
            tbxPer.Properties.Items.Clear();

            tbxPer.Properties.Items.Add(cbxMainUnit.SelectedItem.ToString().Trim());            
            tbxPer.Properties.Items.Add(cbxAltUnit.SelectedItem.ToString().Trim());

            tbxPer.Properties.Items.Remove("None");
            cbxUnit.Properties.Items.Remove("None");

            tbxPer.SelectedIndex = 0;
        }

        private void cbxTaxCat_Enter(object sender, EventArgs e)
        {
           
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
            //objModel.Confactor = Convert.ToDouble(tbxconFactor.Text.Trim());

            objModel.Unit = cbxUnit.SelectedItem.ToString();
            objModel.OpStockValue = Convert.ToDouble(tbxOpStock.Text.Trim());
            objModel.Rate = Convert.ToDouble(tbxRate.Text.Trim());
            objModel.Per = tbxPer.SelectedItem.ToString();
            objModel.Value = Convert.ToDouble(tbxValue.Text.Trim());

            objModel.ApplyPurchPrice = cbxApplyPurchPrice.SelectedItem.ToString();
            objModel.ApplySalesPrice = cbxApplySalesPrice.SelectedItem.ToString();
            objModel.MainSalePrice = Convert.ToDecimal(tbxMainSalesPrice.Text.Trim());
            objModel.MainPurprice = Convert.ToDecimal(tbxMainPurcPrice.Text.Trim());
            objModel.MainMRP = Convert.ToDecimal(tbxMainMRP.Text.Trim());
            objModel.MainMinSalePrice = Convert.ToDecimal(tbxMainMinSalesPrice.Text.Trim());
            objModel.SelfValuePrice = Convert.ToDecimal(tbxSelfValPrice.Text.Trim());
            //objModel.SaleDiscount = Convert.ToDecimal(tbxSaleDiscount.Text.Trim());
            //objModel.PurDiscount = Convert.ToDecimal(tbxPurcDiscount.Text.Trim());
            //objModel.SpecifySaleDiscStructure = cbxEnableSalesDiscStruct.SelectedItem.ToString() == "Y" ? true : false;
            //objModel.SpecifyPurDiscStructure = cbxEnablePurcDiscStruct.SelectedItem.ToString() == "Y" ? true : false;
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
                ClearControls();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
       {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            if (keyData == Keys.F3 && cbxGroup.Focused)
            {
                isGroupF3 = true;
            }
            else
            {
                isGroupF3 = false;
            }
                //    this.Close();

                //    Transactions.Accountgroup frmgrp = new Transactions.Accountgroup();

                //    frmgrp.Owner = this;
                //    frmgrp.TopLevel = false;

                //    //sptCtrlMastermenu.Panel2.Controls.Add(frmgrp);
                //    frmgrp.Show();

                //    return true;
                //}

                return base.ProcessCmdKey(ref msg, keyData);
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            tbxAlias.Text = tbxName.Text.Trim();
            tbxPrintname.Text = tbxName.Text.Trim();
        }

        private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxName.Text.Trim() == "")
                {
                    MessageBox.Show("Item Name Can Not Be Blank!");
                    tbxName.Focus();
                    return;
                }
                if (objIMBL.IsItemMasterExists(tbxName.Text.Trim()))
                {
                    MessageBox.Show("Group Name already Exists!");
                    tbxName.Focus();
                    return;
                }
               
            }
        }

        private void tbxName_Leave(object sender, EventArgs e)
        {
            //if (objIMBL.IsItemMasterExists(tbxName.Text.Trim()))
            //{
            //    MessageBox.Show("Group Name already Exists!");
            //    tbxName.Focus();
            //    return;
            //}
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void cbxGroup_Enter(object sender, EventArgs e)
        {
            //Group&Company Combobox
            //List<ItemGroupMasterModel> lstItemGroups = objgrpbl.GetAllItemGroup();
            //foreach (ItemGroupMasterModel objgroup in lstItemGroups)
            //{
            //    cbxGroup.Properties.Items.Add(objgroup.ItemGroup);
            //}
            //cbxGroup.SelectedIndex = 0;
        }

        private void cbxCompany_Enter(object sender, EventArgs e)
        {
            //Group&Company Combobox
            //List<ItemGroupMasterModel> lstItemGroups = objgrpbl.GetAllItemGroup();
            //foreach (ItemGroupMasterModel objgroup in lstItemGroups)
            //{
            //    cbxGroup.Properties.Items.Add(objgroup.ItemGroup);
            //    cbxCompany.Properties.Items.Add(objgroup.ItemGroup);
            //}
            cbxCompany.SelectedIndex = 0;
        }

        private void tbxValue_TextChanged(object sender, EventArgs e)
        {
            CalculateRate();
        }

        private void CalculateRate()
        {
            if (cbxUnit.SelectedItem == null)
                return;

            if (tbxPer.SelectedItem.ToString().Equals(cbxUnit.SelectedItem.ToString()))
            {
                if (Convert.ToDecimal(tbxValue.Text)>0 && Convert.ToDecimal(tbxOpStock.Text)>0)
                tbxRate.Text = (Convert.ToDecimal(tbxValue.Text) / Convert.ToDecimal(tbxOpStock.Text)).ToString();
            }

            else if (tbxPer.SelectedItem.ToString().Equals(lblMainUnit.Text))
            {
                decimal cal = Convert.ToDecimal(tbxValue.Text) / Convert.ToDecimal(tbxConTo.Text);

                tbxRate.Text = (cal / (Convert.ToDecimal(tbxOpStock.Text)) * Convert.ToDecimal(tbxConFrom.Text)).ToString();
            }

            else if (tbxPer.SelectedItem.ToString().Equals(lblAltunit.Text))
            {
                decimal cal = Convert.ToDecimal(tbxValue.Text) / Convert.ToDecimal(tbxConFrom.Text);

                tbxRate.Text = (cal / (Convert.ToDecimal(tbxOpStock.Text)) * Convert.ToDecimal(tbxConTo.Text)).ToString();
            }
        }
        private void tbxPer_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateOpStockValue();
           
        }

        private void CalculateOpStockValue()
        {
            if (cbxUnit.SelectedItem == null)
                return;

            if (cbxUnit.SelectedItem.ToString().Equals(tbxPer.SelectedItem.ToString()))
            {
                tbxValue.Text = (Convert.ToDecimal(tbxOpStock.Text) * Convert.ToDecimal(tbxRate.Text)).ToString();
            }
            //Find the matching unit to calculate op stock value
            else if (cbxUnit.SelectedItem.ToString().Equals(lblMainUnit.Text))
            {
                decimal cal = Convert.ToDecimal(tbxOpStock.Text) / Convert.ToDecimal(tbxConTo.Text);
                tbxValue.Text = (cal * (Convert.ToDecimal(tbxConFrom.Text) * Convert.ToDecimal(tbxRate.Text))).ToString();
            }

            else if (cbxUnit.SelectedItem.ToString().Equals(lblAltunit.Text))
            {
                decimal cal = Convert.ToDecimal(tbxOpStock.Text) / Convert.ToDecimal(tbxConFrom.Text);

                tbxValue.Text = (cal * (Convert.ToDecimal(tbxConTo.Text) * Convert.ToDecimal(tbxRate.Text))).ToString();
            }
        }

        private void cbxMainUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

            cbxAltUnit.Properties.Items.Clear();
            cbxAltUnit.Properties.Items.Add("None");
            cbxAltUnit.Properties.Items.AddRange(cbxMainUnit.Properties.Items);

            cbxAltUnit.Properties.Items.Remove(cbxMainUnit.SelectedItem);

            //Change lables for sales/purch

            lblSalesPriceMain.Text = "Sales Price(" + cbxMainUnit.SelectedItem.ToString() + ")";
            lblPurchPriceMain.Text = "Purch. Price(" + cbxMainUnit.SelectedItem.ToString() + ")";
            lblMRPMain.Text = "M.R.P(" + cbxMainUnit.SelectedItem.ToString() + ")";
            lblMinSaleMain.Text = "Min. Sales Price(" + cbxMainUnit.SelectedItem.ToString() + ")";

            if (cbxAltUnit.SelectedItem == null)
                return;

            lblSalesPriceAlt.Text = "Sales Price(" + cbxAltUnit.SelectedItem.ToString() + ")";
            lblPurchPriceAlt.Text = "Purch. Price(" + cbxAltUnit.SelectedItem.ToString() + ")";
            lblMrpAlt.Text = "(M.R.P(" + cbxAltUnit.SelectedItem.ToString() + ")";
            lblMinSaleAlt.Text = "(Min. Sales Price(" + cbxAltUnit.SelectedItem.ToString() + ")";

        }

        private void cbxAltUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxConFrom.Enabled = true;
            tbxConTo.Enabled = true;

            if (cbxAltUnit.SelectedItem.ToString().Equals("None"))
            {
                tbxConFrom.Enabled = false;
                tbxConTo.Enabled = false;

                tbxConTo.Text = string.Empty;
                tbxConFrom.Text = string.Empty;

                lblMainUnit.Text = string.Empty;
                lblAltunit.Text = string.Empty;
            }

            //Change lables for sales/purch

            lblSalesPriceMain.Text = "Sales Price(" + cbxMainUnit.SelectedItem.ToString() + ")";
            lblPurchPriceMain.Text = "Purch. Price(" + cbxMainUnit.SelectedItem.ToString() + ")";

            lblMRPMain.Text = "M.R.P(" + cbxMainUnit.SelectedItem.ToString() + ")";
            lblMinSaleMain.Text = "Min. Sales Price("+ cbxMainUnit.SelectedItem.ToString() + ")";
            if (cbxAltUnit.SelectedItem == null)
                return;

            lblSalesPriceAlt.Text = "Sales Price(" + cbxAltUnit.SelectedItem.ToString() + ")";
            lblPurchPriceAlt.Text = "Purch. Price(" + cbxAltUnit.SelectedItem.ToString() + ")";
            lblMrpAlt.Text = "(M.R.P(" + cbxAltUnit.SelectedItem.ToString() + ")";
            lblMinSaleAlt.Text= "(Min. Sales Price(" + cbxAltUnit.SelectedItem.ToString() + ")";
        }

        private void tbxconFactor_TextChanged(object sender, EventArgs e)
        {
            CalculateOpStockValue();
        }

        private void tbxRate_TextChanged(object sender, EventArgs e)
        {
            CalculateOpStockValue();
        }

        private void tbxOpStock_TextChanged(object sender, EventArgs e)
        {
            CalculateOpStockValue();
        }

        private void tbxConFrom_Enter(object sender, EventArgs e)
        {         

            lblAltunit.Text = cbxAltUnit.SelectedItem.ToString();
            lblMainUnit.Text = cbxMainUnit.SelectedItem.ToString();
            
            CalculateOpStockValue();
        }

        private void tbxConTo_Enter(object sender, EventArgs e)
        {
            if (cbxUnit.SelectedItem == null)
                return;

            if (cbxUnit.SelectedItem.ToString().Equals(tbxPer.SelectedItem.ToString()))
            {
                tbxValue.Text = (Convert.ToDecimal(tbxOpStock.Text) * Convert.ToDecimal(tbxRate.Text)).ToString();
            }
            //Find the matching unit to calculate op stock value
            else if (cbxUnit.SelectedItem.ToString().Equals(lblMainUnit.Text))
            {
                decimal cal = Convert.ToDecimal(tbxOpStock.Text) / Convert.ToDecimal(tbxConTo.Text);

                tbxValue.Text = (cal * (Convert.ToDecimal(tbxConFrom.Text) * Convert.ToDecimal(tbxRate.Text))).ToString();
            }

            else if (cbxUnit.SelectedItem.ToString().Equals(lblAltunit.Text))
            {
                decimal cal = Convert.ToDecimal(tbxOpStock.Text) / Convert.ToDecimal(tbxConFrom.Text);

                tbxValue.Text = (cal * (Convert.ToDecimal(tbxConTo.Text) * Convert.ToDecimal(tbxRate.Text))).ToString();
            }
        }

        private void tbxOpStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxUnit.SelectedItem == null)
                return;

            if (cbxUnit.SelectedItem.ToString().Equals(tbxPer.SelectedItem.ToString()))
            {
                tbxValue.Text = (Convert.ToDecimal(tbxOpStock.Text) * Convert.ToDecimal(tbxRate.Text)).ToString();
            }
            //Find the matching unit to calculate op stock value
            else if (cbxUnit.SelectedItem.ToString().Equals(lblMainUnit.Text))
            {
                decimal cal = Convert.ToDecimal(tbxOpStock.Text) / Convert.ToDecimal(tbxConTo.Text);

                tbxValue.Text = (cal * (Convert.ToDecimal(tbxConFrom.Text) * Convert.ToDecimal(tbxRate.Text))).ToString();
            }

            else if (cbxUnit.SelectedItem.ToString().Equals(lblAltunit.Text))
            {
                decimal cal = Convert.ToDecimal(tbxOpStock.Text) / Convert.ToDecimal(tbxConFrom.Text);

                tbxValue.Text = (cal * (Convert.ToDecimal(tbxConTo.Text) * Convert.ToDecimal(tbxRate.Text))).ToString();
            }
        }

        private void cbxUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxUnit.SelectedItem == null)
                return;

            if (cbxUnit.SelectedItem.ToString().Equals(tbxPer.SelectedItem.ToString()))
            {
                tbxValue.Text = (Convert.ToDecimal(tbxOpStock.Text) * Convert.ToDecimal(tbxRate.Text)).ToString();
            }
            //Find the matching unit to calculate op stock value
            else if (cbxUnit.SelectedItem.ToString().Equals(lblMainUnit.Text))
            {
                decimal cal = Convert.ToDecimal(tbxOpStock.Text) / Convert.ToDecimal(tbxConTo.Text);

                tbxValue.Text = (cal * (Convert.ToDecimal(tbxConFrom.Text) * Convert.ToDecimal(tbxRate.Text))).ToString();
            }

            else if (cbxUnit.SelectedItem.ToString().Equals(lblAltunit.Text))
            {
                decimal cal = Convert.ToDecimal(tbxOpStock.Text) / Convert.ToDecimal(tbxConFrom.Text);

                tbxValue.Text = (cal * (Convert.ToDecimal(tbxConTo.Text) * Convert.ToDecimal(tbxRate.Text))).ToString();
            }
        }

        private void tbxRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxUnit.SelectedItem == null)
                return;

            if (cbxUnit.SelectedItem.ToString().Equals(tbxPer.SelectedItem.ToString()))
            {
                tbxValue.Text = (Convert.ToDecimal(tbxOpStock.Text) * Convert.ToDecimal(tbxRate.Text)).ToString();
            }
            //Find the matching unit to calculate op stock value
            else if (cbxUnit.SelectedItem.ToString().Equals(lblMainUnit.Text))
            {
                decimal cal = Convert.ToDecimal(tbxOpStock.Text) / Convert.ToDecimal(tbxConTo.Text);

                tbxValue.Text = (cal * (Convert.ToDecimal(tbxConFrom.Text) * Convert.ToDecimal(tbxRate.Text))).ToString();
            }

            else if (cbxUnit.SelectedItem.ToString().Equals(lblAltunit.Text))
            {
                decimal cal = Convert.ToDecimal(tbxOpStock.Text) / Convert.ToDecimal(tbxConFrom.Text);

                tbxValue.Text = (cal * (Convert.ToDecimal(tbxConTo.Text) * Convert.ToDecimal(tbxRate.Text))).ToString();
            }
        }

        private void cbxAltUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbxConFrom.Enabled = true;
            tbxConTo.Enabled = true;

            if (cbxAltUnit.SelectedItem == null || cbxMainUnit.SelectedItem==null || cbxUnit.SelectedItem==null)
                return;

            if (cbxAltUnit.SelectedItem.ToString().Equals("None"))
            {
                tbxConFrom.Enabled = false;
                tbxConTo.Enabled = false;

                tbxConTo.Text = string.Empty;
                tbxConFrom.Text = string.Empty;

                lblMainUnit.Text = string.Empty;
                lblAltunit.Text = string.Empty;
            }

            //   cbxAltUnit.SelectedIndex = 0;

            if (cbxUnit.SelectedItem.ToString().Equals(tbxPer.SelectedItem.ToString()))
            {
                tbxValue.Text = (Convert.ToDecimal(tbxOpStock.Text) * Convert.ToDecimal(tbxRate.Text)).ToString();
            }
            //Find the matching unit to calculate op stock value
            else if (cbxUnit.SelectedItem.ToString().Equals(lblMainUnit.Text))
            {
                decimal cal = Convert.ToDecimal(tbxOpStock.Text) / Convert.ToDecimal(tbxConTo.Text);

                tbxValue.Text = (cal * (Convert.ToDecimal(tbxConFrom.Text) * Convert.ToDecimal(tbxRate.Text))).ToString();
            }

            else if (cbxUnit.SelectedItem.ToString().Equals(lblAltunit.Text))
            {
                decimal cal = Convert.ToDecimal(tbxOpStock.Text) / Convert.ToDecimal(tbxConFrom.Text);

                tbxValue.Text = (cal * (Convert.ToDecimal(tbxConTo.Text) * Convert.ToDecimal(tbxRate.Text))).ToString();
            }
        }

        private void cbxApplySalesPrice_SelectedIndexChanged(object sender, EventArgs e)
        {

        //            Main Unit
        //Alt Unit
        //Both Unit
        //Date - Wise Price Info

        }

        private void cbxGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (keyData == Keys.F3)
            //{
            //    this.Close();
            //    return true;
            //}
            //return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cbxDiscountInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDiscountInfo.SelectedItem.ToString()=="Y")
            {
                PopupScreens.DiscountInfo frmdiscount = new PopupScreens.DiscountInfo();
                frmdiscount.StartPosition = FormStartPosition.CenterScreen;
                frmdiscount.ShowDialog();
            }
            else
            {
                PopupScreens.DiscountInfo frmdiscount = new PopupScreens.DiscountInfo();
                frmdiscount.Close();
            }
        }

        private void cbxMarkupInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMarkupInfo.SelectedItem.ToString() == "Y")
            {
                PopupScreens.MarkupInfo frmdiscount = new PopupScreens.MarkupInfo();
                frmdiscount.StartPosition = FormStartPosition.CenterScreen;
                frmdiscount.ShowDialog();
            }
        }

        private void cbxSrlWiseDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCritical_Click(object sender, EventArgs e)
        {
            if(cbxCreticallevel.SelectedItem.ToString()=="Y")
            {
                PopupScreens.DefineCriticalLevels frmCritical = new PopupScreens.DefineCriticalLevels();
                frmCritical.StartPosition = FormStartPosition.CenterScreen;
                frmCritical.ShowDialog();
            }
        }
    }
}
