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
    public partial class Unitconversion : Form
    {
        UnitConversion objunc = new UnitConversion();
        public static int UCId = 0;
        public Unitconversion()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbxMainunit.Text.Equals(string.Empty))
            {
                MessageBox.Show("MainUnit Name can not be blank!");
                return;
            }
            UnitConversionModel objUnitCon = new UnitConversionModel();
            //if (objUnitCon.IsGroupExists(tbxGroupName.Text.Trim()))
            //{
            //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            //    cbxUnderGrp.Focus();
            //    return;
            //}
            objUnitCon.MainUnit = cbxMainunit.Text.Trim();
            objUnitCon.SubUnit = cbxSubunit.Text.Trim();
            objUnitCon.ConFactor = Convert.ToDecimal(cbxConfactor.Text.Trim());

            bool isSuccess = objunc.SaveUC(objUnitCon);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
            //List<eSunSpeedDomain.UnitConversionModel> lstGroups = objunc.GetListofUnitConversions();
            //dgvList.DataSource = lstGroups;

            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();
        }

        private void ListUnitmaster_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.UnitconversionList frmList = new Administration.List.UnitconversionList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();

            btnSave.Visible = false;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            cbxMainunit.Focus();

            FillAccountInfo();

        }

        private void FillAccountInfo()
        {
            UnitConversionModel objMaster = objunc.GetListofUnitConversionsById(UCId);

            cbxMainunit.SelectedItem = objMaster.MainUnit;
            cbxSubunit.SelectedItem = objMaster.SubUnit;
            cbxConfactor.Text =Convert.ToString(objMaster.ConFactor);

        }


        private void Unitconversion_Load(object sender, EventArgs e)
        {
            cbxMainunit.SelectedIndex = 0;
            cbxSubunit.SelectedIndex = 1;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbxMainunit.Text.Equals(string.Empty))
            {
                MessageBox.Show("MainUnit Name can not be blank!");
                return;
            }
            UnitConversionModel objUnitCon = new UnitConversionModel();
            //if (objUnitCon.IsGroupExists(tbxGroupName.Text.Trim()))
            //{
            //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            //    cbxUnderGrp.Focus();
            //    return;
            //}
            objUnitCon.MainUnit = cbxMainunit.Text.Trim();
            objUnitCon.SubUnit = cbxSubunit.Text.Trim();
            objUnitCon.ConFactor = Convert.ToDecimal(cbxConfactor.Text.Trim());
            objUnitCon.ID = UCId;

            bool isSuccess = objunc.UpdateUC(objUnitCon);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }
    }
}
