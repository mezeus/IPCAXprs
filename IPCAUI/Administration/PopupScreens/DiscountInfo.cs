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

namespace IPCAUI.Administration.PopupScreens
{
    public partial class DiscountInfo : Form
    {
       DiscountStructure objDisStrBl = new DiscountStructure();
        public DiscountInfo()
        {        
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Administration.ItemMasterNew.objModel.SaleDiscount = Convert.ToDecimal(tbxSaleDiscount.Text.Trim());
            Administration.ItemMasterNew.objModel.PurDiscount = Convert.ToDecimal(tbxPurcCompDisc.Text.Trim());
            Administration.ItemMasterNew.objModel.SaleCompoundDiscount = Convert.ToDecimal(tbxSaleCompDisc.Text.Trim());
            Administration.ItemMasterNew.objModel.PurCompoundDiscount = Convert.ToDecimal(tbxPurcCompDisc.Text.Trim());
            Administration.ItemMasterNew.objModel.SpecifySaleDiscStructure = (cbxSpSaleDiscStr.SelectedItem.ToString() == "Y" ? true : false);
            Administration.ItemMasterNew.objModel.SpecifyPurDiscStructure = (cbxSpPurcDiscStr.SelectedItem.ToString() == "Y" ? true : false);
            this.Close();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DiscountInfo_Load(object sender, EventArgs e)
        {
            cbxSpSaleDiscStr.SelectedIndex = 1;
            cbxSpPurcDiscStr.SelectedIndex = 1;
            if(ItemMasterNew.objModel.DiscountInfo)
            {
                tbxSaleDiscount.Text = ItemMasterNew.objModel.SaleDiscount.ToString();
                tbxSaleCompDisc.Text = ItemMasterNew.objModel.SaleCompoundDiscount.ToString();
                tbxPurcDiscount.Text = ItemMasterNew.objModel.PurDiscount.ToString();
                tbxPurcCompDisc.Text = ItemMasterNew.objModel.PurCompoundDiscount.ToString();
                cbxSpSaleDiscStr.SelectedItem = (ItemMasterNew.objModel.SpecifySaleDiscStructure)?"Y":"N";
                cbxSpPurcDiscStr.SelectedItem = (ItemMasterNew.objModel.SpecifyPurDiscStructure) ? "Y" : "N";
                //cbxPurcStrc.SelectedItem=
                //cbxSaleStrc.SelectedItem=
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

        private void cbxSaleStrc_KeyPress(object sender, KeyPressEventArgs e)
        {
            cbxSaleStrc.Properties.Items.Clear();
            //Need To Load Values From Discount Structure
            List<DiscountStructureMasterModel> lstDisStr = objDisStrBl.GetAllDiscountStructure();
            foreach(DiscountStructureMasterModel objmaster in lstDisStr)
            {
                cbxSaleStrc.Properties.Items.Add(objmaster.StructureName);
            }
        }

        private void btnSpeciifySales_Click(object sender, EventArgs e)
        {
            Administration.DiscountStructureMaster frmdisstr = new DiscountStructureMaster();
            frmdisstr.StartPosition = FormStartPosition.CenterParent;
            frmdisstr.ShowDialog();
        }

        private void btnSpeciifyPurc_Click(object sender, EventArgs e)
        {
            Administration.DiscountStructureMaster frmdisstr = new DiscountStructureMaster();
            frmdisstr.StartPosition = FormStartPosition.CenterParent;
            frmdisstr.ShowDialog();
        }
    }
}
