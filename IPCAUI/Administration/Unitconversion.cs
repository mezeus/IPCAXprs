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
        UnitMaster objUnitBl = new UnitMaster();
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

            objUnitCon.MainUnit = cbxMainunit.SelectedItem.ToString();
            objUnitCon.SubUnit = cbxSubunit.SelectedItem.ToString();
            objUnitCon.ConFactor = Convert.ToDecimal(cbxConfactor.Text.Trim());

            bool isSuccess = objunc.SaveUC(objUnitCon);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearControls();
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
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            cbxMainunit.Focus();

            FillUnitConversionInfo();

        }

        private void FillUnitConversionInfo()
        {
            UnitConversionModel objMaster = objunc.GetListofUnitConversionsById(UCId);

            cbxMainunit.SelectedItem = objMaster.MainUnit;
            cbxSubunit.SelectedItem = objMaster.SubUnit;
            cbxConfactor.Text =Convert.ToString(objMaster.ConFactor);

        }
        public void ClearControls()
        {
            cbxSubunit.Text = string.Empty;
            cbxMainunit.Text = string.Empty;
        }

        private void Unitconversion_Load(object sender, EventArgs e)
        {
            LodaUnits();
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }
        public void LodaUnits()
        {
            List<UnitMasterModel> lstUnits = objUnitBl.GetListofUnits();
            foreach (UnitMasterModel objunit in lstUnits)
            {
                cbxMainunit.Properties.Items.Add(objunit.UnitName);
                cbxSubunit.Properties.Items.Add(objunit.UnitName);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbxMainunit.Text.Equals(string.Empty))
            {
                MessageBox.Show("MainUnit Name can not be blank!");
                return;
            }
            UnitConversionModel objUnitCon = new UnitConversionModel();
            objUnitCon.MainUnit = cbxMainunit.SelectedItem.ToString();
            objUnitCon.SubUnit = cbxSubunit.SelectedItem.ToString();
            objUnitCon.ConFactor = Convert.ToDecimal(cbxConfactor.Text.Trim());
            objUnitCon.ID = UCId;

            bool isSuccess = objunc.UpdateUC(objUnitCon);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }

        private void cbxMainunit_Enter(object sender, EventArgs e)
        {
            cbxMainunit.SelectedIndex = 0;
        }

        private void cbxSubunit_Enter(object sender, EventArgs e)
        {
            cbxSubunit.SelectedIndex = 0;
        }

        private void cbxSubunit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxSubunit.SelectedItem == cbxMainunit.SelectedItem)
            {
                MessageBox.Show("Main Unit & Sub Unit Are Not Same");
                cbxSubunit.Focus();
            }
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClearControls();
            UCId = 0;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objunc.DeleteUnitConversionById(UCId);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                ClearControls();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void cbxMainunit_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
