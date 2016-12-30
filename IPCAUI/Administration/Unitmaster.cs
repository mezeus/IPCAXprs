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
    public partial class Unitmaster : Form
    {
        UnitMaster objunm = new UnitMaster();
        public static int UMId = 0;
        public Unitmaster()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxUnitName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Unit Name can not be blank!");
                return;
            }

            //if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
            //{
            //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            //    cbxUnderGrp.Focus();
            //    return;
            //}

            UnitMasterModel objModel = new UnitMasterModel();

            objModel.UnitName = tbxUnitName.Text.Trim();
            objModel.PrintName = tbxPrintname.Text.Trim();
            objModel.ExciseReturn = tbxUnitName.Text.Trim();
            objModel.CreatedBy = "Admin";

            bool isSuccess = objunm.SaveUM(objModel);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfuly!");
            }

            //List<UnitMasterModel> lstUnits = objunm.GetListofUnits();
            //dgvList.DataSource = lstUnits;

            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();
        }

        private void dvgUnitmaster_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.UnitmasterList frmList = new Administration.List.UnitmasterList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            btnSave.Visible = false;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;

            FillAccountInfo();
        }

        private void FillAccountInfo()
        {
            UnitMasterModel objunit = objunm.GetListofUnitsById(UMId);

            tbxUnitName.Text = objunit.UnitName;
            tbxPrintname.Text = objunit.PrintName;
            tbxUnitnameExcise.Text = objunit.ExciseReturn;
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
        private void tbxUnitName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                //if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
                //{
                //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
                //    tbxGroupName.Focus();
                //    return;
                //}
                if (tbxUnitName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Unit Name Can Not Be Blank!");
                    this.ActiveControl = tbxUnitName;
                    return;
                }
                //e.Handled = true; // Mark the event as handled
            }
        }

        private void Unitmaster_Load(object sender, EventArgs e)
        {
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbxUnitName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Unit Name can not be blank!");
                return;
            }

            //if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
            //{
            //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            //    cbxUnderGrp.Focus();
            //    return;
            //}

            UnitMasterModel objModel = new UnitMasterModel();

            objModel.UnitName = tbxUnitName.Text.Trim();
            objModel.PrintName = tbxPrintname.Text.Trim();
            objModel.ExciseReturn = tbxUnitName.Text.Trim();
            objModel.UM_ID = UMId;
            objModel.CreatedBy = "Admin";

            bool isSuccess = objunm.UpdateUM(objModel);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfuly!");
            }
        }
    }
}
