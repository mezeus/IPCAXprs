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

namespace IPCAUI.Administration.PopupScreens
{
    public partial class MarkupInfo : Form
    {
        MarkupStructureBL objMarkupBL = new MarkupStructureBL();
        public MarkupInfo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Administration.ItemMasterNew.objModel.SaleMarkup = Convert.ToDecimal(tbxSaleMarkup.Text.Trim()==null?"0.00":tbxSaleMarkup.Text.Trim());
            Administration.ItemMasterNew.objModel.PurMarkup = Convert.ToDecimal(tbxPurcMarkup.Text.Trim()==null?"0.00":tbxPurcMarkup.Text.Trim());
            Administration.ItemMasterNew.objModel.SaleCompMarkup = Convert.ToDecimal(tbxSaleCompMarkup.Text.Trim() == null?"0.00":tbxSaleCompMarkup.Text.Trim());
            Administration.ItemMasterNew.objModel.PurCompMarkup = Convert.ToDecimal(tbxPurcCompMarkup.Text.Trim()==null?string.Empty:tbxPurcCompMarkup.Text.Trim());
            Administration.ItemMasterNew.objModel.SpecifySaleMarkupStruct = (tbxSpSaleMarkupStru.SelectedItem.ToString() == "Y" ? true : false);
            ItemMasterNew.objModel.SaleMarkupStructure = string.Empty;
            ItemMasterNew.objModel.PurcMarkupStructure = string.Empty;
            if (ItemMasterNew.objModel.SpecifySaleMarkupStruct)
            {
                ItemMasterNew.objModel.SaleMarkupStructure = tbxSpSaleStru.SelectedItem.ToString();
            }

            Administration.ItemMasterNew.objModel.SpecifyPurMarkupStruct = (tbxSpPurcMarkupStru.SelectedItem.ToString() == "Y" ? true : false);
            if(ItemMasterNew.objModel.SpecifyPurMarkupStruct)
            {
                ItemMasterNew.objModel.PurcMarkupStructure = tbxSpPurcStru.SelectedItem.ToString();
            }
            this.Close();
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

        private void MarkupInfo_Load(object sender, EventArgs e)
        {
            tbxSpSaleMarkupStru.SelectedIndex = 1;
            tbxSpPurcMarkupStru.SelectedIndex = 1;
            tbxSpSaleStru.Properties.Items.Clear();
            List<MarkupStructureMasterModel> lstMarkStr = objMarkupBL.GetAllMarkupStructure();
            foreach (MarkupStructureMasterModel objmaster in lstMarkStr)
            {
                tbxSpSaleStru.Properties.Items.Add(objmaster.StructureName);
                tbxSpPurcStru.Properties.Items.Add(objmaster.StructureName);
            }
            if (ItemMasterNew.objModel.ItemId!=0 && ItemMasterNew.objModel.MarkupInfo)
            {
                tbxSaleMarkup.Text = ItemMasterNew.objModel.SaleMarkup.ToString();
                tbxSaleCompMarkup.Text = ItemMasterNew.objModel.SaleCompMarkup.ToString();
                tbxPurcMarkup.Text = ItemMasterNew.objModel.PurMarkup.ToString();
                tbxPurcCompMarkup.Text = ItemMasterNew.objModel.PurCompMarkup.ToString();
                tbxSpSaleMarkupStru.SelectedItem = (ItemMasterNew.objModel.SpecifySaleMarkupStruct) ? "Y" : "N";
                tbxSpPurcMarkupStru.SelectedItem = (ItemMasterNew.objModel.SpecifyPurMarkupStruct) ? "Y" : "N";
                if(ItemMasterNew.objModel.SpecifySaleMarkupStruct)
                {
                    tbxSpSaleStru.SelectedItem = ItemMasterNew.objModel.SaleMarkupStructure.ToString();
                }
                if (ItemMasterNew.objModel.SpecifyPurMarkupStruct)
                {
                    tbxSpPurcStru.SelectedItem = ItemMasterNew.objModel.PurcMarkupStructure.ToString();
                }               
            }
        }

        private void tbxSpSaleMarkupStru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbxSpSaleMarkupStru.SelectedItem.ToString() == "N")
            {
                lblSaleMarkup.Enabled = false;
                lblSaleMarkupAdd.Enabled = false;
            }
            else
            {
                lblSaleMarkup.Enabled = true;
                lblSaleMarkupAdd.Enabled = true;
            }
        }

        private void tbxSpPurcMarkupStru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbxSpPurcMarkupStru.SelectedItem.ToString() == "N")
            {
                lblPurcMarkup.Enabled = false;
                lblPurcMarkupAdd.Enabled = false;
            }
            else
            {
                lblPurcMarkup.Enabled = true;
                lblPurcMarkupAdd.Enabled = true;
            }
        }

        private void btnSaleMarkupAdd_Click(object sender, EventArgs e)
        {
            Administration.MarkupStructureMaster frmMarkup = new MarkupStructureMaster();
            frmMarkup.StartPosition = FormStartPosition.CenterParent;
            frmMarkup.ShowDialog();
        }

        private void btnPurcMarkupAdd_Click(object sender, EventArgs e)
        {
            Administration.MarkupStructureMaster frmMarkup = new MarkupStructureMaster();
            frmMarkup.StartPosition = FormStartPosition.CenterParent;
            frmMarkup.ShowDialog();
        }

        private void tbxSpSaleStru_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbxSpSaleStru.Properties.Items.Clear();
            List<MarkupStructureMasterModel> lstMarkStr = objMarkupBL.GetAllMarkupStructure();
            foreach (MarkupStructureMasterModel objmaster in lstMarkStr)
            {
                tbxSpSaleStru.Properties.Items.Add(objmaster.StructureName);
            }
        }

        private void tbxSpPurcStru_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbxSpPurcStru.Properties.Items.Clear();
            List<MarkupStructureMasterModel> lstMarkStr = objMarkupBL.GetAllMarkupStructure();
            foreach (MarkupStructureMasterModel objmaster in lstMarkStr)
            {
                tbxSpPurcStru.Properties.Items.Add(objmaster.StructureName);
            }
        }
    }
}
