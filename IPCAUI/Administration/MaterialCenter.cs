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
    public partial class MaterialCenter : Form
    {
        MaterialCentreMasterBL objmatcenbl = new MaterialCentreMasterBL();
        MaterialCentreGroupMaster objMatGrpBal = new MaterialCentreGroupMaster();
        public static int MCId = 0;
        public MaterialCenter()
        {
            InitializeComponent();
        }

        private void ListMaterialcenter_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.MaterialcenterList frmList = new Administration.List.MaterialcenterList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            btnSave.Visible = false;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            FillMaterialCenterInfo();
        }

        private void FillMaterialCenterInfo()
        {
            MaterialCentreMasterModel objMaterial = objmatcenbl.GetAllMaterialsById(MCId);

            tbxGroupName.Text = objMaterial.GroupName;
            tbxAliasname.Text = objMaterial.Alias;
            tbxPrintname.Text = objMaterial.PrintName;
            cbxGroup.SelectedItem = objMaterial.Group;
            cbxStockaccount.SelectedItem = objMaterial.StockAccount;
            cbxreflectstockinbalancesheet.SelectedItem = Convert.ToString(objMaterial.EnableStockinBal ?"Y":"N");
            cbxSaleAccount.SelectedItem=objMaterial.SalesAccount;
            cbxPurchaseAccount.SelectedItem = objMaterial.PurchaseAccount;
            cbxStockaccount.SelectedItem = objMaterial.SalesAccount;
            tbxAccStocktransfer.SelectedItem = Convert.ToString(objMaterial.EnableAccinTransfer ?"Y":"N");
            tbxAddress.Text = objMaterial.Address;
            tbxAddress1.Text = objMaterial.Address1;
            tbxAddress2.Text = objMaterial.Address2;
            tbxAddress3.Text = objMaterial.Address3;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxGroupName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Master Name can not be blank!");
                return;
            }
            MaterialCentreMasterModel objGroup = new MaterialCentreMasterModel();
            objGroup.GroupName = tbxGroupName.Text.Trim();
            objGroup.Alias = tbxAliasname.Text.Trim()==null?string.Empty:tbxAliasname.Text.Trim();
            objGroup.PrintName = tbxPrintname.Text.Trim()==null? string.Empty : tbxAliasname.Text.Trim(); ;
            objGroup.Group = cbxGroup.SelectedItem.ToString();
            objGroup.StockAccount = cbxStockaccount.SelectedItem.ToString();
            objGroup.EnableStockinBal =cbxreflectstockinbalancesheet.SelectedItem.ToString() == "Y" ? true : false;
            
            //In Settings Check Check box This fiels Are Enable
            //objGroup.SalesAccount = cbxSaleAccount.SelectedItem.ToString();
            //objGroup.PurchaseAccount = cbxPurchaseAccount.SelectedItem.ToString();
            //objGroup.EnableAccinTransfer = tbxAccStocktransfer.Text.Trim() == "Y" ? true : false;
            objGroup.Address = tbxAddress.Text == null ? string.Empty : tbxAddress.Text.Trim();
            objGroup.Address1 = tbxAddress1.Text == null ? string.Empty : tbxAddress1.Text.Trim();
            objGroup.Address2 = tbxAddress2.Text == null ? string.Empty : tbxAddress2.Text.Trim();
            objGroup.Address3 = tbxAddress3.Text == null ? string.Empty : tbxAddress3.Text.Trim();

            objGroup.CreatedBy = "Admin";

            bool isSuccess = objmatcenbl.SaveMaterialMaster(objGroup);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearControls();
            }
        }
         public void ClearControls()
        {
            tbxGroupName.Text = string.Empty;
            tbxAliasname.Text = string.Empty;
            tbxPrintname.Text = string.Empty;
            tbxAddress.Text = string.Empty;
            tbxAddress1.Text = string.Empty;
            tbxAddress2.Text = string.Empty;
            tbxAddress3.Text = string.Empty;
        }

        private void MaterialCenter_Load(object sender, EventArgs e)
        {
            cbxreflectstockinbalancesheet.SelectedIndex = 0;
            LoadMaterialGroup();
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }
        public void LoadMaterialGroup()
        {
            List<MaterialCentreGroupMasterModel> objMatGroup = objMatGrpBal.GetAllMaterialGroups();
            foreach (MaterialCentreGroupMasterModel objgroup in objMatGroup)
            {
                cbxGroup.Properties.Items.Add(objgroup.Group);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MaterialCentreMasterModel objGroup = new MaterialCentreMasterModel();

            objGroup.GroupName = tbxGroupName.Text.Trim();
            objGroup.Alias = tbxAliasname.Text.Trim() == null ? string.Empty : tbxAliasname.Text.Trim();
            objGroup.PrintName = tbxPrintname.Text.Trim() == null ? string.Empty : tbxAliasname.Text.Trim(); ;
            objGroup.Group = cbxGroup.SelectedItem.ToString();
            objGroup.StockAccount = cbxStockaccount.SelectedItem.ToString();
            objGroup.EnableStockinBal = cbxreflectstockinbalancesheet.SelectedItem.ToString() == "Y" ? true : false;

            //In Settings Check Check box This fiels Are Enable
            //objGroup.SalesAccount = cbxSaleAccount.SelectedItem.ToString();
            //objGroup.PurchaseAccount = cbxPurchaseAccount.SelectedItem.ToString();
            //objGroup.EnableAccinTransfer = tbxAccStocktransfer.Text.Trim() == "Y" ? true : false;
            objGroup.Address = tbxAddress.Text == null ? string.Empty : tbxAddress.Text.Trim();
            objGroup.Address1 = tbxAddress1.Text == null ? string.Empty : tbxAddress1.Text.Trim();
            objGroup.Address2 = tbxAddress2.Text == null ? string.Empty : tbxAddress2.Text.Trim();
            objGroup.Address3 = tbxAddress3.Text == null ? string.Empty : tbxAddress3.Text.Trim();

            objGroup.MC_Id = MCId;

            objGroup.CreatedBy = "Admin";

            bool isSuccess = objmatcenbl.UpdateMaterialMaster(objGroup);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
            }
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            tbxGroupName.Text = string.Empty;
            tbxPrintname.Text = string.Empty;
            tbxAliasname.Text = string.Empty;
            tbxAddress.Text = string.Empty;
        }

        private void tbxGroupName_TextChanged(object sender, EventArgs e)
        {
            tbxAliasname.Text = tbxGroupName.Text;
            tbxPrintname.Text = tbxGroupName.Text;
        }

        private void cbxGroup_Enter(object sender, EventArgs e)
        {
            cbxGroup.SelectedIndex = 0;
        }

        private void cbxStockaccount_Properties_Enter(object sender, EventArgs e)
        {
            cbxStockaccount.SelectedIndex = 0;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxGroupName.Text.Trim() == "")
                {
                    MessageBox.Show("Name Can Not Be Blank!");
                    tbxGroupName.Focus();
                    return;
                }
                //if (objmatcenbl.GetAllMaterialsById(tbxGroupName.Text.Trim()))
                //{
                //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
                //    tbxGroupName.Focus();
                //    return;
                //}
                //e.Handled = true; // Mark the event as handled
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bool isDelete = objmatcenbl.DeleteMaterialCenterById(MCId);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                ClearControls();
            }
        }
    }
}
