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
    public partial class SerialnoWiseDetails : Form
    {
        public SerialnoWiseDetails()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ItemMasterNew.objModel.ManualNuber = false;
            ItemMasterNew.objModel.AutoNumber = false;
            if (rbnSerialNumber.SelectedIndex == 0)
            {
                Administration.ItemMasterNew.objModel.ManualNuber = true;
            }
            if (rbnSerialNumber.SelectedIndex == 1)
            {
                Administration.ItemMasterNew.objModel.AutoNumber = true;
            }
            ItemMasterNew.objModel.StaringAutoNo = Convert.ToInt32(tbxStartingNumber.Text.Trim() == null ? string.Empty : tbxStartingNumber.Text);
            ItemMasterNew.objModel.StructureName = tbxStructureName.Text.Trim() == null ? string.Empty : tbxStructureName.Text;
            ItemMasterNew.objModel.NumberingFreq = tbxrenumberingFreq.Text.Trim() == null ? string.Empty : tbxrenumberingFreq.Text;
            ItemMasterNew.objModel.RegenarateAutoNo = Convert.ToBoolean(chkGenerateAutoNo.Checked == true ? true : false);
            ItemMasterNew.objModel.TrackSaleWaranty =Convert.ToBoolean(chkSaleWarranty.Checked == true?true : false);
            ItemMasterNew.objModel.TrackPurcWaranty = Convert.ToBoolean(chkPurchaseWarranty.Checked == true ? true : false);
            ItemMasterNew.objModel.TrackInstallationWaranty = Convert.ToBoolean(chkTrackInstallWaranty.Checked == true ? true : false);
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

        private void SerialnoWiseDetails_Load(object sender, EventArgs e)
        {
            if(ItemMasterNew.objModel.ItemId!=0)
            {
                if(ItemMasterNew.objModel.ManualNuber)
                {
                    rbnSerialNumber.SelectedIndex= 0;
                }
                if (ItemMasterNew.objModel.AutoNumber)
                {
                    rbnSerialNumber.SelectedIndex = 1;
                }
                tbxStartingNumber.Text = ItemMasterNew.objModel.StaringAutoNo.ToString();
                tbxStructureName.Text = ItemMasterNew.objModel.StructureName.ToString();
                tbxrenumberingFreq.Text = ItemMasterNew.objModel.NumberingFreq.ToString();
                chkGenerateAutoNo.Checked = ItemMasterNew.objModel.RegenarateAutoNo;
                chkSaleWarranty.Checked = ItemMasterNew.objModel.TrackSaleWaranty;
                chkPurchaseWarranty.Checked = ItemMasterNew.objModel.TrackPurcWaranty;
                chkTrackInstallWaranty.Checked = ItemMasterNew.objModel.TrackInstallationWaranty;
            }
        }
    }
}
