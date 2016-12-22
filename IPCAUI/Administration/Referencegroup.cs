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
        public Referencegroup()
        {
            InitializeComponent();
        }

        private void ListReference_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.ReferencegroupList frmList = new Administration.List.ReferencegroupList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ReferenceGroupModel objmodel = new ReferenceGroupModel();
            objmodel.Name = tbxName.Text.Trim();
            bool issaved = objrefbl.SaveReferenceGroup(objmodel);
            if(issaved)
            {
                MessageBox.Show("Saved Succufully!");
            }
        }
    }
}
