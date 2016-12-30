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
    public partial class MaterialCenter : Form
    {
        MaterialCentreMasterBL objmatcenbl = new MaterialCentreMasterBL();
        public static int MCId = 0;
        public MaterialCenter()
        {
            InitializeComponent();
        }

        private void ListMaterialcenter_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.MaterialcenterList frmList = new Administration.List.MaterialcenterList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            btnSave.Visible = false;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            FillAccountInfo();
        }

        private void FillAccountInfo()
        {
            MaterialCentreMasterModel objMaterial = objmatcenbl.GetAllMaterialsById(MCId);

            //tbxName.Text = objAuthor.Name;
            //tbxAlias.Text = objAuthor.Alias;
            //tbxPrintname.Text = objAuthor.PrintName;
            //cbxContactwithAccount.SelectedItem = Convert.ToString((objAuthor.ConnectAcc) ? "Y" : "N");
            //tbxAddress.Text = objAuthor.Address;
            //cbxState.SelectedItem = objAuthor.State;
            //tbxTelnumber.Text = objAuthor.Telephone;
            //tbxMobileno.Text = objAuthor.MobileNo;
            //tbxEmail.Text = objAuthor.Email;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            MaterialCentreMasterModel objGroup = new MaterialCentreMasterModel();

            objGroup.GroupName = tbxGroupName.Text.TrimEnd();
            objGroup.Alias = tbxAliasname.Text.Trim();
            objGroup.PrintName = tbxPrintname.Text.Trim();
            objGroup.Group = cbxGroup.Text.Trim();
            objGroup.StockAccount = cbxStockaccount.Text.Trim();
            objGroup.EnableStockinBal =cbxreflectstockinbalancesheet.SelectedItem.ToString() == "Y" ? true : false;
            objGroup.SalesAccount = cbxSaleAccount.Text.Trim();
            objGroup.PurchaseAccount = cbxPurchaseAccount.Text.Trim();
            objGroup.EnableAccinTransfer = tbxAccStocktransfer.Text.Trim() == "Y" ? true : false;
            objGroup.Address = tbxAddress.Text.Trim();
            

           // objGroup.PrimaryGroup = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
           // objGroup.UnderGroup = cbxUndergroup.SelectedItem.ToString();
            objGroup.CreatedBy = "Admin";

            bool isSuccess = objmatcenbl.SaveMaterialMaster(objGroup);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }

        private void MaterialCenter_Load(object sender, EventArgs e)
        {
            
        }
    }
}
