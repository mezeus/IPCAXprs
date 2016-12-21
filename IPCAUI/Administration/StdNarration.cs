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
                MessageBox.Show("Narration can not be blank!");
                return;
            }

            //if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
            //{
            //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            //    cbxUnderGrp.Focus();
            //    return;
            //}

            StdNarrationMasterModel objModel = new StdNarrationMasterModel();

            objModel.Narration = tbxNarration.Text.Trim();
            objModel.Vouchertype = cbxVouchertype.SelectedItem.ToString();

            bool isSuccess = objstdNrr.SaveStdNarration(objModel);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
            //List<StdNarrationMasterModel> lstNarr = accObj.GetAllStdNarration();
            //dgvList.DataSource = lstNarr;

            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();
        }

        private void ListStdnarration_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.StdnarrationList frmList = new Administration.List.StdnarrationList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }
    }
}
