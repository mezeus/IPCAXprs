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
        public static int BMId = 0;

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

            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;

            btnSave.Visible = false;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            tbxBomName.Focus();

            FillAccountInfo();
        }

        private void FillAccountInfo()
        {
            BillofMaterialModel objBom = objbal.GetAllBillofMaterialById(BMId);

            tbxBomName.Text= objBom.BOMName;
            cbxItemproduce.SelectedItem = objBom.Itemtoproduce;
            tbxQuanty.Text=Convert.ToString(objBom.Quantity);
            cbxUnit.SelectedItem = objBom.ItemUnit;
            tbxExpensespcs.Text=Convert.ToString(objBom.Expenses);
            cbxItemgenerated.SelectedItem= objBom.SpecifyMCGenerated;
            cbxItemconsumed.SelectedItem=objBom.SpecifyDefaultMCforItemConsumed;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            BillofMaterialModel objBMmodl = new BillofMaterialModel();

            objBMmodl.BOMName = tbxBomName.Text.Trim();
            objBMmodl.Itemtoproduce = cbxItemproduce.Text.Trim();
            objBMmodl.Quantity = Convert.ToInt32(tbxQuanty.Text.Trim());
            objBMmodl.ItemUnit = cbxUnit.SelectedItem.ToString();
            objBMmodl.Expenses = Convert.ToDecimal(tbxExpensespcs.Text.Trim());
            objBMmodl.SpecifyMCGenerated = Convert.ToBoolean(cbxItemgenerated.SelectedItem.ToString().Equals("Yes") ? true : false);
         //   objBMmodl.SourceMC = string.Empty;
            objBMmodl.SpecifyDefaultMCforItemConsumed = Convert.ToBoolean(cbxItemconsumed.SelectedItem.ToString().Equals("Yes") ? true : false);
            objBMmodl.AppMc = string.Empty;

            bool isSuccess = objbal.SaveBOM(objBMmodl);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }
   
        private void tbxBomName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxBomName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Master Name Can Not Be Blank!");
                    this.ActiveControl = tbxBomName;
                    return;


                }
            }
        }

        private void BillsofMaterial_Load(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            dt.Columns.Add("ItemName");
            dt.Columns.Add("Qty");
            dt.Columns.Add("Unit");

            dvgRawmat.DataSource = dt;

           // tbxUnit.SelectedIndex = 0;
            //cbxItemgenerated.SelectedIndex = 0;
            //cbxItemconsumed.SelectedIndex= 0;
            cbxItemproduce.SelectedIndex = 0;
        }
    }
}
