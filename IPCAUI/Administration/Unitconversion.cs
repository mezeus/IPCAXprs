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
        }

        private void Unitconversion_Load(object sender, EventArgs e)
        {
            cbxMainunit.SelectedIndex = 0;
            cbxSubunit.SelectedIndex = 1;
        }
    }
}
