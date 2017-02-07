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
    public partial class Itemgroup : Form
    {
        ItemGroupMasterBL objItemBL = new ItemGroupMasterBL();
        ItemMasterBL objItemMasterBl = new ItemMasterBL();
        public static ItemGroupMasterModel objModel = new ItemGroupMasterModel();
        ReferenceGroupBL objRefBL = new ReferenceGroupBL();
        public static int ItemgrpId = 0;
        public Itemgroup()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxGroupName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Group Name can not be blank!");
                return;
            }
            objModel.ItemGroup = tbxGroupName.Text.Trim();

            objModel.Alias = tbxAliasname.Text.Trim()==null?string.Empty:tbxAliasname.Text.Trim();
            objModel.PrimaryGroup = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
            if (cbxPrimarygroup.SelectedItem.ToString() == "N")
            {
                objModel.UnderGroup = cbxUndergroup.SelectedItem.ToString();
            }
            //objModel.StockAccount = cbxStockaccount.SelectedItem.ToString();
            //objModel.SalesAccount = cbxSalesaccount.SelectedItem.ToString();
            //objModel.PurchaseAccount = cbxPurchaseAccount.SelectedItem.ToString();
            objModel.SeparateConfig =false;
            objModel.DefaultConfig =false;
            if(rbnDefaultConfig.SelectedIndex==0)
            {
                objModel.DefaultConfig = true;
            }
            if (rbnDefaultConfig.SelectedIndex == 1)
            {
                objModel.SeparateConfig = true;
            }
            objModel.Parameters = Convert.ToInt32(tbxParameters.Text.Trim()==string.Empty?"0":tbxParameters.Text.Trim());
            objModel.SpecifyBillReferencegrp= cbxTagBillReference.SelectedItem.ToString() == "Y" ? true : false;
            objModel.BillReferencegrp = cbxBillReferenceGroup.Text.Trim() == null? string.Empty : cbxBillReferenceGroup.Text.Trim();
            objModel.CrDaysforSale = Convert.ToInt32(tbxCrDaysforSale.Text.Trim() == string.Empty ? "0" : tbxCrDaysforSale.Text.Trim());
            objModel.CrDaysforPurc = Convert.ToInt32(tbxCrDaysforPurc.Text.Trim() == string.Empty ? "0" : tbxCrDaysforPurc.Text.Trim());
            objModel.CreatedBy = "Admin";
            PopupScreens.MasterSeriesGroup frmMaster = new PopupScreens.MasterSeriesGroup();
            frmMaster.StartPosition = FormStartPosition.CenterParent;
            frmMaster.ShowDialog();
            bool isSuccess = objItemBL.SaveIGM(objModel);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearControls();
                
            }
        }
        public void ClearControls()
        {
            tbxGroupName.Text = string.Empty;
            tbxAliasname.Text = string.Empty;
            cbxPrimarygroup.SelectedIndex = 1;
        }
        private void ListItemgroup_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.ItemgroupList frmList = new Administration.List.ItemgroupList();
            frmList.StartPosition = FormStartPosition.CenterScreen;
            ItemgrpId = 0;
            frmList.ShowDialog();      
            FillItemGroupInfo();        
        }

        private void FillItemGroupInfo()
        {
            if(ItemgrpId==0)
            {
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                ClearControls();
                tbxGroupName.Focus();
                return;
            }
            objModel = objItemBL.GetAllItemGroupById(ItemgrpId);

            tbxGroupName.Text = objModel.ItemGroup;
            tbxAliasname.Text = objModel.Alias;
            cbxPrimarygroup.SelectedItem =Convert.ToString((objModel.PrimaryGroup)?"Y":"N");
            cbxUndergroup.SelectedItem=objModel.UnderGroup;
            cbxStockaccount.SelectedItem= objModel.StockAccount;
            cbxSalesaccount.SelectedItem= objModel.SalesAccount;
            cbxPurchaseAccount.SelectedItem= objModel.PurchaseAccount;
            if(objModel.DefaultConfig)
            {
                rbnDefaultConfig.SelectedIndex = 0;
            }
            if(objModel.SeparateConfig)
            {
                rbnDefaultConfig.SelectedIndex = 1;
            }
            cbxTagBillReference.SelectedItem = objModel.SpecifyBillReferencegrp ? "Y" : "N";
            cbxBillReferenceGroup.Text = objModel.BillReferencegrp.ToString();
            tbxCrDaysforSale.Text = objModel.CrDaysforSale.ToString();
            tbxCrDaysforPurc.Text = objModel.CrDaysforPurc.ToString();
            tbxParameters.Text=Convert.ToString(objModel.Parameters);
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxGroupName.Focus();
        }


        private void Itemgroup_Load(object sender, EventArgs e)
        {
            cbxPrimarygroup.SelectedIndex = 1;
            cbxTagBillReference.SelectedIndex = 0;
            cbxBillReferenceGroup.Properties.Items.Clear();
            List<ReferenceGroupModel> lstRef = objRefBL.GetAllReferenceGroups();
            foreach (ReferenceGroupModel objref in lstRef)
            {
                cbxBillReferenceGroup.Properties.Items.Add(objref.Name);
            }
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
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
                if (tbxGroupName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Item Group Can Not Be Blank!");
                    tbxGroupName.Focus();
                    return;
                }
                if (objItemBL.IsItemGroupExists(tbxGroupName.Text.Trim()))
                {
                    MessageBox.Show("Group Name already Exists!");
                    tbxGroupName.Focus();
                    return;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            objModel.ItemGroup = tbxGroupName.Text.Trim();
            objModel.Alias = tbxAliasname.Text.Trim()==null?string.Empty:tbxAliasname.Text.Trim();
            objModel.PrimaryGroup = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
            if(cbxPrimarygroup.SelectedItem.ToString() =="N")
            {
                objModel.UnderGroup = cbxUndergroup.SelectedItem.ToString();
            }           
            //objModel.StockAccount = cbxStockaccount.SelectedItem.ToString();
            //objModel.SalesAccount = cbxSalesaccount.SelectedItem.ToString();
            //objModel.PurchaseAccount = cbxPurchaseAccount.SelectedItem.ToString();
            objModel.SeparateConfig = false;
            objModel.DefaultConfig = false;
            if (rbnDefaultConfig.SelectedIndex == 0)
            {
                objModel.DefaultConfig = true;
            }
            if (rbnDefaultConfig.SelectedIndex == 1)
            {
                objModel.SeparateConfig = true;
            }
            objModel.Parameters = Convert.ToInt32(tbxParameters.Text.Trim()==string.Empty?"0": tbxParameters.Text.Trim());
            objModel.SpecifyBillReferencegrp = cbxTagBillReference.SelectedItem.ToString() == "Y" ? true : false;
            objModel.BillReferencegrp = cbxBillReferenceGroup.Text.Trim() == null ? string.Empty : cbxBillReferenceGroup.Text.Trim();
            objModel.CrDaysforSale = Convert.ToInt32(tbxCrDaysforSale.Text.Trim() == string.Empty ? "0" : tbxCrDaysforSale.Text.Trim());
            objModel.CrDaysforPurc = Convert.ToInt32(tbxCrDaysforPurc.Text.Trim() == string.Empty ? "0" : tbxCrDaysforPurc.Text.Trim());
            PopupScreens.MasterSeriesGroup frmMaster = new PopupScreens.MasterSeriesGroup();
            frmMaster.StartPosition = FormStartPosition.CenterParent;
            frmMaster.ShowDialog();
            objModel.IGM_id = ItemgrpId;
            objModel.ModifiedBy = "Admin";

            bool isSuccess = objItemBL.UpdateIGM(objModel);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                ClearControls();
                ItemgrpId = 0;
                Administration.List.ItemgroupList frmList = new Administration.List.ItemgroupList();
                frmList.StartPosition = FormStartPosition.CenterScreen;
                
                frmList.ShowDialog();
                FillItemGroupInfo();
            }
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            tbxAliasname.Text = string.Empty;
            tbxGroupName.Text = string.Empty;
            cbxPrimarygroup.SelectedIndex = 1;
            cbxPurchaseAccount.SelectedItem = "";
            cbxStockaccount.SelectedItem = "";
            cbxUndergroup.SelectedItem = "";
            cbxSalesaccount.SelectedText = "";
            //rbnDefaultconfig.Checked = false;
            //rbnSeparteConfig.Checked = false;
            tbxParameters.Text = string.Empty;
        }

        private void tbxGroupName_TextChanged(object sender, EventArgs e)
        {
            tbxAliasname.Text = tbxGroupName.Text.Trim();
        }

        private void cbxUndergroup_Enter(object sender, EventArgs e)
        {
            cbxUndergroup.SelectedIndex = 0;
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
            tbxGroupName.Text = string.Empty;
            tbxAliasname.Text = string.Empty;
            tbxParameters.Text = string.Empty;
            cbxPrimarygroup.SelectedIndex = 1;
            cbxStockaccount.SelectedItem = "";
            cbxSalesaccount.SelectedItem = "";
            cbxPurchaseAccount.SelectedItem = "";

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ItemMasterModel objmodel = objItemMasterBl.GetItemNameByGroupname(tbxGroupName.Text.Trim());
            if (objmodel.Name != null)
            {
                MessageBox.Show("Can Not Delete Group Name Under Tag With Item Name.." + objmodel.Name);
                tbxGroupName.Focus();
            }          
            if(objmodel.Name==null)
            {
                bool isDelete = objItemBL.DeleteItemGroupById(ItemgrpId);
                if (isDelete)
                {
                    MessageBox.Show("Delete Successfully!");
                    ClearControls();
                    ItemgrpId = 0;
                    Administration.List.ItemgroupList frmList = new Administration.List.ItemgroupList();
                    frmList.StartPosition = FormStartPosition.CenterScreen;

                    frmList.ShowDialog();
                    FillItemGroupInfo();
                    tbxGroupName.Focus();
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
            if(cbxPrimarygroup.SelectedItem.ToString() =="Y")
            {
                lblUndergroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            }
            else
            {
                lblUndergroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        private void cbxBillReferenceGroup_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void cbxBillReferenceGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if(e.KeyChar!='\r')
            {           
                cbxBillReferenceGroup.ShowPopup();
                if (Char.IsLetter(e.KeyChar))
                {
                    e.KeyChar = Char.ToUpper(e.KeyChar);
                }
            }
        }

        private void cbxBillReferenceGroup_Leave(object sender, EventArgs e)
        {
            if(cbxBillReferenceGroup.Text=="")
            {
                cbxBillReferenceGroup.SelectedIndex = 0;
            }
        }
    }
}
