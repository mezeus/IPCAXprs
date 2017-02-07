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
    public partial class ItemCompany : Form
    {
        ItemCompanyMasterBL objICBL = new ItemCompanyMasterBL();
        ItemMasterBL objItemMasterBl = new ItemMasterBL();
        public static int ItemcompId = 0;
        public ItemCompany()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxCompanyName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Company Name can not be blank!");
                return;
            }

            ItemCompanyMasterModel objCompany = new ItemCompanyMasterModel();
            objCompany.ItemCompany = tbxCompanyName.Text.Trim();
            objCompany.StockAccount = cbxStockaccount.Text.Trim()==null?string.Empty:cbxStockaccount.Text.Trim();
            objCompany.SalesAccount = cbxSalesaccount.Text.Trim() == null ? string.Empty : cbxSalesaccount.Text.Trim();
            objCompany.PurchaseAccount = cbxPurchaseAccount.Text.Trim() == null ? string.Empty : cbxPurchaseAccount.Text.Trim();
            objCompany.CreatedBy = "Admin";

            bool isSuccess = objICBL.SaveItemCompany(objCompany);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearControls();
                tbxCompanyName.Focus();
            }
        }
        public void ClearControls()
        {
            tbxCompanyName.Text = string.Empty;
            cbxStockaccount.Text = string.Empty;
            cbxSalesaccount.Text = string.Empty;
            cbxPurchaseAccount.Text = string.Empty;
        }
        private void FillItemCompanyInfo()
        {
            if(ItemcompId==0)
            {
                tbxCompanyName.Focus();
                ClearControls();
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                return;
            }
            ItemCompanyMasterModel objICM = objICBL.GetAllItemCompanyById(ItemcompId);

            tbxCompanyName.Text = objICM.ItemCompany;
            cbxStockaccount.SelectedItem= objICM.StockAccount;
            cbxSalesaccount.SelectedItem= objICM.SalesAccount;
            cbxPurchaseAccount.SelectedItem= objICM.PurchaseAccount;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxCompanyName.Focus();
        }


        private void ItemCompany_Load(object sender, EventArgs e)
        {
            tbxCompanyName.Focus();
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
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
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(ItemcompId==0)
            {
                tbxCompanyName.Focus();
                return;
            }
            ItemCompanyMasterModel objCompany = new ItemCompanyMasterModel();
            objCompany.ItemCompany = tbxCompanyName.Text.Trim();
            objCompany.StockAccount = cbxStockaccount.Text.Trim() == null ? string.Empty : cbxStockaccount.Text.Trim();
            objCompany.SalesAccount = cbxSalesaccount.Text.Trim() == null ? string.Empty : cbxSalesaccount.Text.Trim();
            objCompany.PurchaseAccount = cbxPurchaseAccount.Text.Trim() == null ? string.Empty : cbxPurchaseAccount.Text.Trim();
            objCompany.ModifiedBy = "Admin";
            objCompany.ICM_id = ItemcompId;
            bool isSuccess = objICBL.UpdateItemCompany(objCompany);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                ItemcompId = 0;
                ClearControls();
                Administration.List.ItemcompanyList frmList = new Administration.List.ItemcompanyList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillItemCompanyInfo();

            }
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClearControls();
            ItemcompId = 0;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            tbxCompanyName.Focus();
        }

        private void tbxGroupName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbxUndergroup_Enter(object sender, EventArgs e)
        {
           
        }

        private void cbxSalesaccount_Enter(object sender, EventArgs e)
        {
            cbxSalesaccount.SelectedIndex = 0;
        }

        private void cbxPurchaseAccount_Enter(object sender, EventArgs e)
        {
            cbxPurchaseAccount.SelectedIndex = 0;
        }

        private void cbxStockaccount_Enter(object sender, EventArgs e)
        {
            cbxStockaccount.SelectedIndex = 0;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ItemMasterModel objmodel = objItemMasterBl.GetItemNameByCompanyname(tbxCompanyName.Text.Trim());
            if (objmodel.Name != null)
            {
                MessageBox.Show("Can Not Delete Company Name Under Tag With Item Name.." + objmodel.Name);
                tbxCompanyName.Focus();
            }
            if (objmodel.Name==null)
            {
                if(ItemcompId!=0)
                {
                    bool isDelete = objICBL.DeleteItemCompanyById(ItemcompId);
                    if (isDelete)
                    {
                        MessageBox.Show("Delete Successfully!");
                        ClearControls();
                        ItemcompId = 0;
                        Administration.List.ItemcompanyList frmList = new Administration.List.ItemcompanyList();
                        frmList.StartPosition = FormStartPosition.CenterScreen;

                        frmList.ShowDialog();
                        FillItemCompanyInfo();
                    }
                }
               
            }

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
        private void ListItemCompany_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.ItemcompanyList frmList = new Administration.List.ItemcompanyList();
            frmList.StartPosition = FormStartPosition.CenterScreen;
            ItemcompId = 0;
            frmList.ShowDialog();
            FillItemCompanyInfo();
        }

        private void tbxCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxCompanyName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Item Company Can Not Be Blank!");
                    tbxCompanyName.Focus();
                    return;
                }
                if(ItemcompId==0)
                {
                    if (objICBL.IsItemCompanyExists(tbxCompanyName.Text.Trim()))
                    {
                        MessageBox.Show("Item Company already Exists!");
                        tbxCompanyName.Focus();
                        return;
                    }
                } 
            }
        }
    }
}
