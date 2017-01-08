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
    public partial class ItemCompany : Form
    {
        ItemGroupMasterBL objItemBL = new ItemGroupMasterBL();
        ItemMasterBL objItemMasterBl = new ItemMasterBL();
        public static int ItemgrpId = 0;
        public ItemCompany()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (tbxCompanyName.Text.Equals(string.Empty))
            //{
            //    MessageBox.Show("Group Name can not be blank!");
            //    return;
            //}

            //ItemGroupMasterModel objModel = new ItemGroupMasterModel();
            //objModel.ItemGroup = tbxCompanyName.Text.Trim();

            //objModel.Alias = tbxAliasname.Text.Trim()==null?string.Empty:tbxAliasname.Text.Trim();
            //objModel.PrimaryGroup = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
            //if (cbxPrimarygroup.SelectedItem.ToString() == "N")
            //{
            //    objModel.UnderGroup = cbxUndergroup.SelectedItem.ToString();
            //}
            ////objModel.StockAccount = cbxStockaccount.SelectedItem.ToString();
            ////objModel.SalesAccount = cbxSalesaccount.SelectedItem.ToString();
            ////objModel.PurchaseAccount = cbxPurchaseAccount.SelectedItem.ToString();
            //objModel.SeparateConfig =false;
            //objModel.DefaultConfig =false;
            //if(rbnDefaultConfig.SelectedIndex==0)
            //{
            //    objModel.DefaultConfig = true;
            //}
            //if (rbnDefaultConfig.SelectedIndex == 1)
            //{
            //    objModel.SeparateConfig = true;
            //}
            ////objModel.Parameters = Convert.ToInt32(tbxParameters.Text.Trim()==null?"0":tbxParameters.Text.Trim());
            //objModel.CreatedBy = "Admin";

            //bool isSuccess = objItemBL.SaveIGM(objModel);
            //if(isSuccess)
            //{
            //    MessageBox.Show("Saved Successfully!");
            //    ClearControls();
                
            //}
        }
        public void ClearControls()
        {
            //tbxCompanyName.Text = string.Empty;
            //tbxAliasname.Text = string.Empty;
            //cbxPrimarygroup.SelectedIndex = 1;
        }
        private void ListItemgroup_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.ItemgroupList frmList = new Administration.List.ItemgroupList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            if(ItemgrpId!=0)
            {
                layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                btnSave.Visible = false;
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                tbxCompanyName.Focus();
                FillItemGroupInfo();
            }
            

        }

        private void FillItemGroupInfo()
        {
            ItemGroupMasterModel objIGM = objItemBL.GetAllItemGroupById(ItemgrpId);

            //tbxCompanyName.Text = objIGM.ItemGroup;
            //tbxAliasname.Text = objIGM.Alias;
            //cbxPrimarygroup.SelectedItem =Convert.ToString((objIGM.PrimaryGroup)?"Y":"N");
            //cbxUndergroup.SelectedItem=objIGM.UnderGroup;
            //cbxStockaccount.SelectedItem= objIGM.StockAccount;
            //cbxSalesaccount.SelectedItem= objIGM.SalesAccount;
            //cbxPurchaseAccount.SelectedItem= objIGM.PurchaseAccount;
            //if(objIGM.DefaultConfig)
            //{
            //    rbnDefaultConfig.SelectedIndex = 0;
            //}
            //if(objIGM.SeparateConfig)
            //{
            //    rbnDefaultConfig.SelectedIndex = 1;
            //}
            ////rbnDefaultconfig.Checked =Convert.ToBoolean(objIGM.DefaultConfig?true:false);
            ////rbnSeparteConfig.Checked = Convert.ToBoolean(objIGM.SeparateConfig ? true : false);
            //tbxParameters.Text=Convert.ToString(objIGM.Parameters);
        }


        private void ItemCompany_Load(object sender, EventArgs e)
        {
            //cbxPrimarygroup.SelectedIndex = 1;
            //lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tbxGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxCompanyName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Item Group Can Not Be Blank!");
                    tbxCompanyName.Focus();
                    return;
                }
                if (objItemBL.IsItemGroupExists(tbxCompanyName.Text.Trim()))
                {
                    MessageBox.Show("Group Name already Exists!");
                    tbxCompanyName.Focus();
                    return;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ItemGroupMasterModel objModel = new ItemGroupMasterModel();

            //objModel.ItemGroup = tbxCompanyName.Text.Trim();
            //objModel.Alias = tbxAliasname.Text.Trim()==null?string.Empty:tbxAliasname.Text.Trim();
            //objModel.PrimaryGroup = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
            //if(cbxPrimarygroup.SelectedItem.ToString() =="N")
            //{
            //    objModel.UnderGroup = cbxUndergroup.SelectedItem.ToString();
            //}           
            ////objModel.StockAccount = cbxStockaccount.SelectedItem.ToString();
            ////objModel.SalesAccount = cbxSalesaccount.SelectedItem.ToString();
            ////objModel.PurchaseAccount = cbxPurchaseAccount.SelectedItem.ToString();
            //objModel.SeparateConfig = false;
            //objModel.DefaultConfig = false;
            //if (rbnDefaultConfig.SelectedIndex == 0)
            //{
            //    objModel.DefaultConfig = true;
            //}
            //if (rbnDefaultConfig.SelectedIndex == 1)
            //{
            //    objModel.SeparateConfig = true;
            //}
            ////objModel.Parameters = Convert.ToInt32(tbxParameters.Text.Trim());
            //objModel.IGM_id = ItemgrpId;
            //objModel.ModifiedBy = "Admin";

            //bool isSuccess = objItemBL.UpdateIGM(objModel);
            //if (isSuccess)
            //{
            //    MessageBox.Show("Update Successfully!");
            //    ItemgrpId = 0;
            //    ClearControls();
                
            //    lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //    lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //    lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //    tbxCompanyName.Focus();
            //    FillItemGroupInfo();
            //}
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void tbxGroupName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbxUndergroup_Enter(object sender, EventArgs e)
        {
           
        }

        private void cbxSalesaccount_Enter(object sender, EventArgs e)
        {
            cbxSalesaccount.SelectedIndex = 0;
        }

        private void cbxPurchaseAccount_Enter(object sender, EventArgs e)
        {
            cbxPurchaseAccount.SelectedIndex = 0;
        }

        private void cbxStockaccount_Enter(object sender, EventArgs e)
        {
            cbxStockaccount.SelectedIndex = 0;
        }
        public void ClearFormValues()
        {
            //tbxCompanyName.Text = string.Empty;
            //tbxAliasname.Text = string.Empty;
            //tbxParameters.Text = string.Empty;
            //cbxPrimarygroup.SelectedIndex = 1;
            //cbxStockaccount.SelectedItem = "";
            //cbxSalesaccount.SelectedItem = "";
            //cbxPurchaseAccount.SelectedItem = "";

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ItemMasterModel objmodel = objItemMasterBl.GetItemNameByGroupname(tbxCompanyName.Text.Trim());
            if (objmodel.Name != null)
            {
                MessageBox.Show("Can Not Delete Group Name Under Tag With Item Name.." + objmodel.Name);
                tbxCompanyName.Focus();
            }          
            if(objmodel.Name==null)
            {
                bool isDelete = objItemBL.DeleteItemGroupById(ItemgrpId);
                if (isDelete)
                {
                    MessageBox.Show("Delete Successfully!");
                    ClearFormValues();
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

        private void tbxGroupName_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void tbxGroupName_Leave(object sender, EventArgs e)
        {
           
            //{
            //    MessageBox.Show("Group Name already Exists!");
            //    tbxGroupName.Focus();
            //    return;
            //}
        }

        private void cbxPrimarygroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
