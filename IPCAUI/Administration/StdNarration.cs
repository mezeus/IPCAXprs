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
    public partial class StdNarration : Form
    {
        StdNarrationMasterBL objstdNrr = new StdNarrationMasterBL();
        public static int StdId = 0;
        public StdNarration()
        {
            InitializeComponent();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxNarration.Text.Equals(string.Empty))
            {
                MessageBox.Show("Std.Narration can not be blank!");
                return;
            }
            StdNarrationMasterModel objModel = new StdNarrationMasterModel();

            objModel.Vouchertype = cbxVouchertype.SelectedItem.ToString();
            objModel.Narration = tbxNarration.Text.Trim();
            objModel.Narration2 = tbxNarration2.Text.Trim() == string.Empty ? string.Empty : tbxNarration2.Text.Trim();

            bool isSuccess = objstdNrr.SaveStdNarration(objModel);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearControls();
            }
        }
        private void ClearControls()
        {
            cbxVouchertype.Text = string.Empty;
            tbxNarration.Text = string.Empty;
            tbxNarration2.Text = string.Empty;
        }
        private void ListStdnarration_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.StdnarrationList frmList = new Administration.List.StdnarrationList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            FillStdNarrationInfo();
            cbxVouchertype.Focus();
        }

        private void FillStdNarrationInfo()
        {
            if(StdId==0)
            {
                cbxVouchertype.Focus();
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                return;
            }
            StdNarrationMasterModel objNarration = objstdNrr.GetAllStdNarrationById(StdId);
            cbxVouchertype.SelectedItem = objNarration.Vouchertype;   
            tbxNarration.Text = objNarration.Narration;
            tbxNarration2.Text = objNarration.Narration2;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void StdNarration_Load(object sender, EventArgs e)
        {
            StdId = 0;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            cbxVouchertype.SelectedIndex = 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbxNarration.Text.Equals(string.Empty))
            {
                MessageBox.Show("Narration can not be blank!");
                return;
            }
            StdNarrationMasterModel objModel = new StdNarrationMasterModel();

            objModel.Narration = tbxNarration.Text.Trim();
            objModel.Vouchertype = cbxVouchertype.SelectedItem.ToString();
            objModel.Narration2 = tbxNarration2.Text.Trim() == string.Empty ? string.Empty : tbxNarration2.Text.Trim();
            objModel.SN_Id = StdId;

            bool isSuccess = objstdNrr.UpdateStdNarration(objModel);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                ClearControls();
                StdId = 0;
                Administration.List.StdnarrationList frmList = new Administration.List.StdnarrationList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                cbxVouchertype.Focus();
                FillStdNarrationInfo();
            }
        }

        private void cbxVouchertype_Enter(object sender, EventArgs e)
        {
            cbxVouchertype.ShowPopup();
        }

        private void cbxVouchertype_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objstdNrr.DeletStdNarration(StdId);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                ClearControls();
                StdId = 0;
                Administration.List.StdnarrationList frmList = new Administration.List.StdnarrationList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillStdNarrationInfo();
                cbxVouchertype.Focus();
            }
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClearControls();
            StdId = 0;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }
    }
}
