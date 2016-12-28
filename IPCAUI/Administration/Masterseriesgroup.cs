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
            }
        }

        private void ListItemmaster_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.MasterseriesList frmList = new Administration.List.MasterseriesList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

        private void tbxName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
