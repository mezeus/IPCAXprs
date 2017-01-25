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
    public partial class Masterseriesgroup : Form
    {
        MasterseriesBL objmasbl = new MasterseriesBL();
        public static int MsGId = 0;
        public Masterseriesgroup()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Name can not be blank!");
                return;
            }

            MasterseriesModel objmaster = new MasterseriesModel();

            objmaster.MasterName = tbxName.Text.Trim();

            bool isSuccess = objmasbl.SaveMasterSeries(objmaster);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                tbxName.Text = string.Empty;
                MsGId = 0;
            }
        }

        private void ListItemmaster_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.MasterseriesList frmList = new Administration.List.MasterseriesList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();

            tbxName.Focus();

            FillMasterSeriesInfo();

        }

        private void FillMasterSeriesInfo()
        {
            if(MsGId==0)
            {
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                tbxName.Focus();
                return;
            }
            MasterseriesModel objMaster = objmasbl.GetListofMasterSeriesById(MsGId);
            tbxName.Text = objMaster.MasterName;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void tbxName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Masterseriesgroup_Load(object sender, EventArgs e)
        {
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Name can not be blank!");
                return;
            }

            MasterseriesModel objmaster = new MasterseriesModel();

            objmaster.MasterName = tbxName.Text.Trim();
            objmaster.MasterId = MsGId;
            bool isSuccess = objmasbl.UpdateMasterSeries(objmaster);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                tbxName.Text = string.Empty;
                MsGId = 0;
                Administration.List.MasterseriesList frmList = new Administration.List.MasterseriesList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                tbxName.Focus();
                FillMasterSeriesInfo();
            }
        }

        private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxName.Text.Trim() == "")
                {
                    MessageBox.Show("MasterSeries Group Can Not Be Blank!");
                    tbxName.Focus();
                    return;
                }
                if (MsGId == 0)
                {
                    if (objmasbl.IsMaterialSeriesExists(tbxName.Text.Trim()))
                    {
                        MessageBox.Show("MasterSeries Group already Exists!");
                        tbxName.Focus();
                        return;
                    }
                }
            }
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            tbxName.Text = string.Empty;
            MsGId = 0;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objmasbl.DeleteMasterSeriesGroup(MsGId);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                tbxName.Text = string.Empty;
                MsGId = 0;
                Administration.List.MasterseriesList frmList = new Administration.List.MasterseriesList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillMasterSeriesInfo();
                tbxName.Focus();
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
    }
}
