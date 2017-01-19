using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCAUI.Administration.PopupScreens
{
    public partial class MarkupInfo : Form
    {
        public MarkupInfo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Administration.ItemMasterNew.objModel.SaleMarkup = tbxSaleMarkup.Text.Trim()==null?string.Empty:tbxSaleMarkup.Text.Trim();
            Administration.ItemMasterNew.objModel.PurMarkup = tbxPurcMarkup.Text.Trim()==null?string.Empty:tbxPurcMarkup.Text.Trim();
            Administration.ItemMasterNew.objModel.SaleCompMarkup = tbxSaleCompMarkup.Text.Trim() == null?string.Empty:tbxSaleCompMarkup.Text.Trim();
            Administration.ItemMasterNew.objModel.PurCompMarkup = tbxPurcCompMarkup.Text.Trim()==null?string.Empty:tbxPurcCompMarkup.Text.Trim();
            Administration.ItemMasterNew.objModel.SpecifySaleMarkupStruct = (tbxSpSaleMarkupStru.SelectedItem.ToString() == "Y" ? true : false);
            Administration.ItemMasterNew.objModel.SpecifyPurDiscStructure = (tbxSpPurcMarkupStru.SelectedItem.ToString() == "Y" ? true : false);
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
            if(ItemMasterNew.objModel.ItemId!=0 || ItemMasterNew.objModel.MarkupInfo)
            {
                tbxSaleMarkup.Text = ItemMasterNew.objModel.SaleMarkup.ToString();
                tbxSaleCompMarkup.Text = ItemMasterNew.objModel.SaleCompMarkup.ToString();
                tbxPurcMarkup.Text = ItemMasterNew.objModel.PurMarkup.ToString();
                tbxPurcCompMarkup.Text = ItemMasterNew.objModel.PurCompMarkup.ToString();
                tbxSpSaleMarkupStru.SelectedItem = (ItemMasterNew.objModel.SpecifySaleDiscStructure) ? "Y" : "N";
                tbxSpPurcMarkupStru.SelectedItem = (ItemMasterNew.objModel.SpecifyPurDiscStructure) ? "Y" : "N";
                //cbxPurcStrc.SelectedItem=
                //cbxSaleStrc.SelectedItem=
            }
        }
    }
}
