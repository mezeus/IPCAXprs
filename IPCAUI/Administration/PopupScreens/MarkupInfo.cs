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
            Administration.ItemMasterNew.objModel.SpecifySaleMarkupStruct = (tbxSpSaleStru.SelectedItem.ToString() == "Y" ? true : false);
            Administration.ItemMasterNew.objModel.SpecifyPurDiscStructure = (tbxSpPurcStru.SelectedItem.ToString() == "Y" ? true : false);
            this.Close();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
