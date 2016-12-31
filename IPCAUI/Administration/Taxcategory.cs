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
    public partial class Taxcategory : Form
    {
        TaxCategory objtaxbl = new TaxCategory();
        public Taxcategory()
        {
            InitializeComponent();
        }

        private void ListTaxcategory_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.TaxcategoryList frmList = new Administration.List.TaxcategoryList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO: 1. Check whether the group name exists or not
            //2. if exist then do not allow to save with the same group name
            //3. Prompt user to change the group name as it already exists

            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Name can not be blank!");
                return;
            }


            eSunSpeedDomain.TaxCategoryModel objtaxcat = new TaxCategoryModel();

            objtaxcat.Name = tbxName.Text.Trim();
            objtaxcat.Taxation_Type = cbxTaxationtype.SelectedItem.ToString();
           
            string message = string.Empty;

            bool isSuccess = objtaxbl.SaveTaxCategory(objtaxcat);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            //TODO: 1. Check whether the group name exists or not
            //2. if exist then do not allow to save with the same group name
            //3. Prompt user to change the group name as it already exists

            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Name can not be blank!");
                return;
            }


            eSunSpeedDomain.TaxCategoryModel objtaxcat = new TaxCategoryModel();

            objtaxcat.Name = tbxName.Text.Trim();
            objtaxcat.Taxation_Type = cbxtype.SelectedItem.ToString();

            string message = string.Empty;

            bool isSuccess = objtaxbl.SaveTaxCategory(objtaxcat);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }

        private void dvgTaxrates_Click(object sender, EventArgs e)
        {

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
    }
}
