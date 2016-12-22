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
    public partial class Itemgroup : Form
    {
        ItemGroupMasterBL objItemBL = new ItemGroupMasterBL();
        public Itemgroup()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ItemGroupMasterModel objModel = new ItemGroupMasterModel();
            objModel.ItemGroup = tbxGroupName.Text.Trim();
            objModel.Alias = tbxAliasname.Text.Trim();
            objModel.PrimaryGroup = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
            objModel.UnderGroup = cbxUndergroup.SelectedItem.ToString();
            objModel.StockAccount = cbxStockaccount.SelectedItem.ToString();
            objModel.SalesAccount = cbxSalesaccount.SelectedItem.ToString();
            objModel.PurchaseAccount = cbxPurchaseAccount.SelectedItem.ToString();
            objModel.CreatedBy = "Admin";

            bool isSuccess = objItemBL.SaveIGM(objModel);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
            //List<ItemGroupMasterModel> lstItems = objItemBL.GetAllItemGroup();
            //dgvList.DataSource = lstItems;

            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();
        }

        private void ListItemgroup_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.ItemgroupList frmList = new Administration.List.ItemgroupList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

        private void Itemgroup_Load(object sender, EventArgs e)
        {
            cbxPrimarygroup.SelectedIndex = 0;
            cbxPurchaseAccount.SelectedIndex = 0;
            cbxSalesaccount.SelectedIndex = 0;
            cbxStockaccount.SelectedIndex = 0;
            cbxUndergroup.SelectedIndex = 0;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tbxGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                //if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
                //{
                //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
                //    tbxGroupName.Focus();
                //    return;
                //}
                if (tbxGroupName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Item Group Can Not Be Blank!");
                    this.ActiveControl = tbxGroupName;
                    return;
                    

                }
                //e.Handled = true; // Mark the event as handled
            }
        }
    }
}
