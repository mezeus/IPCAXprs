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
    public partial class Costcenter : Form
    {
        CostCentreMasterBL objccm = new CostCentreMasterBL();
        public Costcenter()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void navBarList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Administration.Accountgroup frm;
            //frm = new Administration.Accountgroup(); //generate new instance 
            //frm.Owner = this;
            //frm.TopLevel = false;

            //sptCtrlMastermenu.Panel2.Controls.Add(frm);
            //frm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Name can not be blank!");
                return;
            }

            CostCentreMasterModel objModel = new CostCentreMasterModel();

            objModel.Name = tbxName.Text.Trim();
            objModel.Alias = tbxAliasname.Text.Trim();
            objModel.Group = cbxPrimarygroup.SelectedItem.ToString();
            objModel.opBal = Convert.ToDecimal(tbxOpbal.Text.Trim());
            objModel.DrCr = cbxDrCr.SelectedItem.ToString();
            objModel.CreatedBy = "Admin";

            bool isSuccess = objccm.SaveCCM(objModel);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
            //List<CostCentreMasterModel> lstCenter = objccm.GetAllCostCentreMaster();
            //dgvList.DataSource = lstCenter;

            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();
        }

        private void ListCostcenter_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.CostcenterList frmList = new Administration.List.CostcenterList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }
    }
}
