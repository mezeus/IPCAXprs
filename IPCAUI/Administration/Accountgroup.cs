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
    public partial class Accountgroup : Form
    {
        AccountMasterBL objaccbl= new AccountMasterBL();
        public static AccountGroupModel objAccGroup = new AccountGroupModel();
        public static int groupId = 0;

        public Accountgroup()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CallFromAccountGroupList(List.AccountgroupList objGrpList,int groupid)
        {
            //this.groupId = groupid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxGroupName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Group Name can not be blank!");
                return;
            }
            objAccGroup.GroupName = tbxGroupName.Text;
            objAccGroup.AliasName = tbxAliasname.Text==null?string.Empty:tbxAliasname.Text.Trim();
            objAccGroup.Primary = Convert.ToBoolean(cbxPrimarygroup.SelectedItem.ToString()=="Y"?true:false);       
            if (cbxPrimarygroup.SelectedItem.ToString().Equals("Y"))
            {
                objAccGroup.NatureGroup = cbxNaturegroup.SelectedItem.ToString();
                AccountGroupModel objNg =objaccbl.GetNatureGroupIdByGroupName(cbxNaturegroup.SelectedItem.ToString());
                objAccGroup.NatureGroupId = objNg.NatureGroupId;
                objAccGroup.DC = objNg.DC;
                objAccGroup.UnderGroupId = 0;
            }
            else
            {
                objAccGroup.UnderGroup = cbxUndergroup.SelectedItem.ToString();
                AccountGroupModel objUG = objaccbl.GetAccountGroupIdByGroupName(objAccGroup.UnderGroup);
                objAccGroup.UnderGroupId = objUG.UnderGroupId;
                objAccGroup.DC = objUG.DC;
                objAccGroup.NatureGroupId = objUG.NatureGroupId;
            }
            //PopupScreens.MasterSeriesGroup frmMaster = new PopupScreens.MasterSeriesGroup();
            //frmMaster.StartPosition = FormStartPosition.CenterParent;
            //frmMaster.ShowDialog();
            //objAccGroup.NatureGroup = cbxNaturegroup.Text == null ? string.Empty : cbxNaturegroup.Text.Trim();
            //objAccGroup.IsAffectGrossProfit = chkGrossProfit.Checked ? true : false;

            objAccGroup.CreatedBy = "Admin";

            string message = string.Empty;
            bool isSuccess = objaccbl.SaveAccountGroup(objAccGroup);

            if (isSuccess)
                MessageBox.Show("Saved Successfully!");
            ClearControls();
        }

        private void tbxGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tbxGroupName_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void tbxGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxGroupName.Text.Trim()=="")
                {
                    MessageBox.Show("Account Group Name Can Not Be Blank!");
                    tbxGroupName.Focus();
                    return;
                }
                if (objaccbl.IsGroupExists(tbxGroupName.Text.Trim()))
                {
                    MessageBox.Show("Account Group Name already Exists!");
                    tbxGroupName.Focus();
                    return;
                }

                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);

                }
                e.Handled = true; // Mark the event as handled
            }
        }

        private void cbxPrimarygroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPrimarygroup.SelectedItem.ToString().Equals("N"))
            {
                
            }
        }

        private void ListAccountgroup_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.AccountgroupList frmList = new Administration.List.AccountgroupList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();         
            FillAccountGroupInfo();
        }

        private void FillAccountGroupInfo()
        {
            if(groupId==0)
            {
                lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                btnUpdateCtrl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                tbxGroupName.Focus();
                return;
            }
            objAccGroup = objaccbl.GetAccountGroupByGroupId(groupId);

            tbxGroupName.Text = objAccGroup.GroupName;
            tbxAliasname.Text = objAccGroup.AliasName;    
            cbxPrimarygroup.SelectedItem = objAccGroup.Primary?"Y":"N";
            cbxUndergroup.SelectedItem = objAccGroup.UnderGroup;
            //cbxNaturegroup.SelectedItem = objAccGroup.NatureGroup;

            //chkGrossProfit.Checked = objAccGroup.IsAffectGrossProfit ? true : false;
            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            btnUpdateCtrl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxGroupName.Focus();
        }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (tbxGroupName.Text.Equals(string.Empty))
        {
            MessageBox.Show("Group Name can not be blank!");
            return;
        }

        if (objaccbl.IsGroupExists(tbxGroupName.Text.Trim()))
        {
            MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            // cbxUnderGrp.Focus();
            return;
        }

            objAccGroup.GroupName = tbxGroupName.Text;
            objAccGroup.AliasName = tbxAliasname.Text == null ? string.Empty : tbxAliasname.Text.Trim();
            objAccGroup.Primary = Convert.ToBoolean(cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false);
            if (cbxPrimarygroup.SelectedItem.ToString().Equals("Y"))
            {
                objAccGroup.NatureGroup = cbxNaturegroup.SelectedItem.ToString();
                AccountGroupModel objNg = objaccbl.GetNatureGroupIdByGroupName(cbxNaturegroup.SelectedItem.ToString());
                objAccGroup.NatureGroupId = objNg.NatureGroupId;
                objAccGroup.DC = objNg.DC;
                objAccGroup.UnderGroupId = 0;
            }
            else
            {
                objAccGroup.UnderGroup = cbxUndergroup.SelectedItem.ToString();
                AccountGroupModel objUG = objaccbl.GetAccountGroupIdByGroupName(objAccGroup.UnderGroup);
                objAccGroup.UnderGroupId = objUG.UnderGroupId;
                objAccGroup.DC = objUG.DC;
                objAccGroup.NatureGroupId = objUG.NatureGroupId;
            }
            //PopupScreens.MasterSeriesGroup frmMaster = new PopupScreens.MasterSeriesGroup();
            //frmMaster.StartPosition = FormStartPosition.CenterParent;
            //frmMaster.ShowDialog();
            //objAccGroup.NatureGroup = cbxNaturegroup.Text == null ? string.Empty : cbxNaturegroup.Text.Trim();
            //objAccGroup.IsAffectGrossProfit = chkGrossProfit.Checked ? true : false;

            objAccGroup.GroupId = groupId;
            string message = string.Empty;

        bool isSuccess = objaccbl.UpdateAccountGroup(objAccGroup);
        if (isSuccess)
            MessageBox.Show("Updated Successfully!");
            ClearControls();
            groupId = 0;
            Administration.List.AccountgroupList frmList = new Administration.List.AccountgroupList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            FillAccountGroupInfo();
        }

        private void Accountgroup_Load(object sender, EventArgs e)
        {
            cbxPrimarygroup.SelectedIndex = 1;
            lactrlNatureofGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlAffectGross.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            LoadGroups();
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            emtSpaceGrossProfit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            emtSpaceGrossProfit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;

        }
        public void LoadGroups()
        {
            List<AccountGroupModel> lstUnder = objaccbl.GetListofAccountsGroups();

            foreach (AccountGroupModel objUnder in lstUnder)
            {
                cbxUndergroup.Properties.Items.Add(objUnder.GroupName);
            }
            cbxNaturegroup.Properties.Items.Clear();
            List<AccountGroupModel> objNature = objaccbl.GetListofNatureofGroups();
            foreach (AccountGroupModel objgroup in objNature)
            {
                cbxNaturegroup.Properties.Items.Add(objgroup.NatureGroup);
            }
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClearControls();
            groupId = 0;
            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            btnUpdateCtrl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void cbxPrimarygroup_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbxPrimarygroup.SelectedItem.ToString()=="Y")
            {
                lactrlUnderGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlUnderemptySpace.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlNatureofGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lactrlAffectGross.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                emtSpaceGrossProfit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                emtSpaceGrossProfit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lactrlUnderGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lactrlUnderemptySpace.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lactrlNatureofGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlAffectGross.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                emtSpaceGrossProfit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                emtSpaceGrossProfit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        { 
            AccountGroupModel objAccount = new AccountGroupModel();
            objAccount.GroupId = groupId;
            bool isDelete = objaccbl.DeleteAccountGroupById(groupId);
            if (isDelete)
            {
               MessageBox.Show("Delete Successfully!");
                ClearControls();
                groupId = 0;
                Administration.List.AccountgroupList frmList = new Administration.List.AccountgroupList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillAccountGroupInfo();
            }
        }
        private void ClearControls()
        {
            tbxGroupName.Text = string.Empty;
            tbxAliasname.Text = string.Empty;
            cbxPrimarygroup.SelectedIndex = 1;
            cbxUndergroup.Text = string.Empty;
            cbxNaturegroup.Text = string.Empty;
            chkGrossProfit.Checked = false;
            groupId = 0;
            tbxGroupName.Focus();
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

        private void tbxGroupName_TextChanged(object sender, EventArgs e)
        {
            tbxAliasname.Text = tbxGroupName.Text.Trim();
        }

        private void cbxUndergroup_Enter(object sender, EventArgs e)
        {
            cbxUndergroup.ShowPopup();
        }

        private void cbxNaturegroup_Enter(object sender, EventArgs e)
        {
            cbxNaturegroup.ShowPopup();
        }
    }
}
