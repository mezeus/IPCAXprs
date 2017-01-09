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

namespace IPCAUI.Administration.PopupScreens
{
    public partial class DiscountInfo : Form
    {
        
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
    }
}
