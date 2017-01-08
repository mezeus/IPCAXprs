using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSunSpeed;
using eSunSpeedDomain;
using eSunSpeed.BusinessLogic;

namespace IPCAUI.Administration
{
    public partial class Costcentergroup : Form
    {
        CostCentreGroupBL objCG = new CostCentreGroupBL();
        CostCentreMasterBL objMasterBl = new CostCentreMasterBL();
        public static int groupId = 0;
        public Costcentergroup()
        {
            InitializeComponent();
            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxGroupName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Group Name can not be blank!");
                return;
            }
            //if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
            //{
            //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            //    cbxUnderGrp.Focus();
            //    return;
            //}

            CostCentreGroupModel objModel = new CostCentreGroupModel();
            
            objModel.GroupName = tbxGroupName.Text.Trim();
            objModel.Alias = tbxAlias.Text.Trim()==null?string.Empty:tbxAlias.Text.Trim();
            objModel.PrimaryGroup = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
            if(cbxPrimarygroup.SelectedItem.ToString()=="N")
            {
                objModel.underGroup = cbxUndergroup.SelectedItem.ToString();
            }
                 
            objModel.CreatedBy = "Admin";

            bool isSuccess = objCG.SaveCCG(objModel);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearControls();
                tbxGroupName.Focus();
            }
        }

        public void ClearControls()
        {
            tbxGroupName.Text = string.Empty;
            tbxAlias.Text = string.Empty;
            cbxPrimarygroup.SelectedIndex = 1;
        }
        private void Listccgroup_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.CostcentergrpList frmList = new Administration.List.CostcentergrpList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            if(groupId!=0)
            {
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;

                btnSave.Visible = false;
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                tbxGroupName.Focus();

                FillCostCenterGroupInfo();
            }
           
        }

        private void FillCostCenterGroupInfo()
        {
            CostCentreGroupModel objMaster = objCG.GetAllCostCentreGroupsById(groupId);

            tbxGroupName.Text = objMaster.GroupName;
            tbxAlias.Text = objMaster.Alias;
            cbxPrimarygroup.SelectedItem = (objMaster.PrimaryGroup)?"Y" : "N";
            cbxUndergroup.SelectedItem = objMaster.underGroup;

        }

        private void Costcentergroup_Load(object sender, EventArgs e)
        {
            tbxGroupName.Focus();
            cbxPrimarygroup.SelectedIndex = 1;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void tbxGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxGroupName.Text.Trim() == "")
                {
                    MessageBox.Show("Cost Center Name Can Not Be Blank!");
                    tbxGroupName.Focus();
                    return;
                }
                if (objCG.IsCostCenterGroupExists(tbxGroupName.Text.Trim()))
                {
                    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
                    tbxGroupName.Focus();
                    return;
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
        private void tbxGroupName_Leave(object sender, EventArgs e)
        {
            //if (tbxGroupName.Text.Equals(string.Empty))
            //{
            //    MessageBox.Show("Group Name can not be blank!");
            //    tbxGroupName.Focus();
            //    return;
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CostCentreGroupModel objModel = new CostCentreGroupModel();

            objModel.CCG_ID = groupId;
            objModel.GroupName = tbxGroupName.Text.Trim();
            objModel.Alias = tbxAlias.Text.Trim();
            objModel.underGroup = cbxUndergroup.SelectedItem.ToString();
            objModel.PrimaryGroup = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
            objModel.CreatedBy = "Admin";

            bool isSuccess = objCG.UpdateCCGM(objModel);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                ClearControls();
                groupId = 0;
                Administration.List.CostcentergrpList frmList = new Administration.List.CostcentergrpList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillCostCenterGroupInfo();
            }
        }

        private void cbxPrimarygroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxPrimarygroup.SelectedItem.ToString()=="Y")
            {
                lblUnderGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            }
            else
            {
                lblUnderGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        private void cbxUndergroup_Enter(object sender, EventArgs e)
        {
            cbxUndergroup.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CostCentreMasterModel objmodel = objMasterBl.GetCostNameByGroupname(tbxGroupName.Text.Trim());
            if (objmodel.Name != null)
            {
                MessageBox.Show("Can Not Delete Name Under Tag With Cost Name.." + objmodel.Name);
                tbxGroupName.Focus();
            }
            if(objmodel.Name==null)
            {
                bool isDelete = objCG.DeleteCostCenterGroupById(groupId);
                if (isDelete)
                {
                    MessageBox.Show("Delete Successfully!");
                    ClearControls();
                    groupId = 0;
                    Administration.List.CostcentergrpList frmList = new Administration.List.CostcentergrpList();
                    frmList.StartPosition = FormStartPosition.CenterScreen;

                    frmList.ShowDialog();
                    FillCostCenterGroupInfo();
                }
            }
            
        }

        private void tbxGroupName_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClearControls();
            groupId = 0;
            tbxGroupName.Focus();
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void tbxGroupName_TextChanged(object sender, EventArgs e)
        {
            tbxAlias.Text = tbxGroupName.Text.Trim();
        }
    }
}
