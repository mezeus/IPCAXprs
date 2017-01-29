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
    public partial class Referencegroup : Form
    {
        ReferenceGroupBL objrefbl = new ReferenceGroupBL();
        public static int RefId = 0;
        public Referencegroup()
        {
            InitializeComponent();
        }

        private void ListReference_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.ReferencegroupList frmList = new Administration.List.ReferencegroupList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            FillReferenceGroup();
        }
        private void FillReferenceGroup()
        {
            if(RefId==0)
            {
                tbxName.Focus();
                laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            }
            ReferenceGroupModel objReference = objrefbl.GetReferenceDetailsById(RefId);
            tbxName.Text = objReference.Name;
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ReferenceGroupModel objmodel = new ReferenceGroupModel();
            objmodel.Name = tbxName.Text.Trim();
            bool IsSaved = objrefbl.SaveReferenceGroup(objmodel);
            if(IsSaved)
            {
                MessageBox.Show("Saved Succufully!");
                tbxName.Text = string.Empty;
                tbxName.Focus();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ReferenceGroupModel objmodel = new ReferenceGroupModel();
            objmodel.Name = tbxName.Text.Trim();
            objmodel.ReferenceId = RefId;
            bool IsUpdate = objrefbl.UpdateReferenceGroup(objmodel);
            if (IsUpdate)
            {
                MessageBox.Show("Update Succufully!");
                tbxName.Text = string.Empty;
                RefId = 0;
                tbxName.Focus();
                Administration.List.ReferencegroupList frmList = new Administration.List.ReferencegroupList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillReferenceGroup();
            }
        }

        private void Referencegroup_Load(object sender, EventArgs e)
        {
            tbxName.Focus();
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objrefbl.DeleteReferenceGroup(RefId);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                tbxName.Text = string.Empty;
                RefId = 0;
                tbxName.Focus();
                Administration.List.ReferencegroupList frmList = new Administration.List.ReferencegroupList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillReferenceGroup();
            }
        }

        private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxName.Text.Trim() == "")
                {
                    MessageBox.Show("Reference Group Can Not Be Blank!");
                    tbxName.Focus();
                    return;
                }
                if (objrefbl.IsReferenceExists(tbxName.Text.Trim()))
                {
                    MessageBox.Show("Reference Group Name already Exists!");
                    tbxName.Focus();
                    return;
                }

                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);

                }
                e.Handled = true; // Mark the event as handled
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
