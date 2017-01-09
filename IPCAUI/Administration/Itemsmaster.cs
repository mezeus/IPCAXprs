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
        TaxCategory objTaxBl = new TaxCategory();
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
