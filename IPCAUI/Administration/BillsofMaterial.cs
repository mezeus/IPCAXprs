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
    public partial class BillsofMaterial : Form
    {
        BillsofMaterialBL objbal = new BillsofMaterialBL();
        public BillsofMaterial()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListMaterial_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.BillMaterialList frmList = new Administration.List.BillMaterialList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BillofMaterialModel objBMmodl = new BillofMaterialModel();

            objBMmodl.BOMName = tbxBomName.Text.Trim();
            objBMmodl.ItemProduct = cbxItemproduce.Text.Trim();
            objBMmodl.Quantity = Convert.ToInt32(tbxQuanty.Text.Trim());
            objBMmodl.ItemUnit = cbxUnit.SelectedItem.ToString();
            objBMmodl.Expenses = Convert.ToDecimal(tbxExpensespcs.Text.Trim());
            objBMmodl.SpecifyMCGenerated = Convert.ToBoolean(cbxItemgenerated.SelectedItem.ToString().Equals("Yes") ? true : false);
            objBMmodl.SourceMC = string.Empty;
            objBMmodl.SpecifyDefaultMCforItemConsumed = Convert.ToBoolean(cbxItemconsumed.SelectedItem.ToString().Equals("Yes") ? true : false);
            objBMmodl.AppMc = string.Empty;
            //objBMmodl.ItemName = cbxRawItemName.Text.Trim();
            //objBMmodl.Qty = Convert.ToInt32(tbxRawQty.Text.Trim());
            //objBMmodl.Unit = Convert.ToDecimal(tbxRawUnit.Text.Trim());

            bool isSuccess = objbal.SaveBOM(objBMmodl);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                //List<BillofMaterialModel> lstBillMat = objBillmat.GetAllBillofMaterial();
                //dgvList.DataSource = lstBillMat;
                //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
                //d.ShowDialog();
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
        private void tbxBomName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                //if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
                //{
                //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
                //    tbxGroupName.Focus();
                //    return;
                //}
                if (tbxBomName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Master Name Can Not Be Blank!");
                    this.ActiveControl = tbxBomName;
                    return;


                }
                //e.Handled = true; // Mark the event as handled
            }
        }

        private void BillsofMaterial_Load(object sender, EventArgs e)
        {
            cbxUnit.SelectedIndex = 0;
            cbxItemgenerated.SelectedIndex = 0;
            cbxItemconsumed.SelectedIndex= 0;
            cbxItemproduce.SelectedIndex = 0;
        }
    }
}
