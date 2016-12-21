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
    }
}
