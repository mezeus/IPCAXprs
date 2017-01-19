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
    public partial class DefineCriticalLevels : Form
    {
        public int id = 0;
        public DefineCriticalLevels()
        {
            InitializeComponent();
            
            if (ItemMasterNew.objModel.ItemId != 0 && ItemMasterNew.objModel.SetCriticalLevel)
            {
                tbxMinLvlQty.Text = ItemMasterNew.objModel.ItemCriticalLevel.FirstOrDefault().MinimumLevelQty.ToString()==null?"0.00": ItemMasterNew.objModel.ItemCriticalLevel.FirstOrDefault().MinimumLevelQty.ToString();
                tbxRecordLvlQty.Text = ItemMasterNew.objModel.ItemCriticalLevel.FirstOrDefault().RecordLevelQty.ToString()==string.Empty?"0.00": ItemMasterNew.objModel.ItemCriticalLevel.FirstOrDefault().RecordLevelQty.ToString();
                tbxMaxLvlQty.Text = ItemMasterNew.objModel.ItemCriticalLevel.FirstOrDefault().MaximumLevelQty.ToString()==string.Empty?"0.00": ItemMasterNew.objModel.ItemCriticalLevel.FirstOrDefault().MaximumLevelQty.ToString();
                tbxMinLvlDays.Text = ItemMasterNew.objModel.ItemCriticalLevel.FirstOrDefault().MinimumLevelDays.ToString() == string.Empty ? "0.00" : ItemMasterNew.objModel.ItemCriticalLevel.FirstOrDefault().MinimumLevelDays.ToString();
                tbxRecordLvlDays.Text = ItemMasterNew.objModel.ItemCriticalLevel.FirstOrDefault().RecordLevelDays.ToString() == string.Empty ? "0.00" : ItemMasterNew.objModel.ItemCriticalLevel.FirstOrDefault().RecordLevelDays.ToString();
                tbxMaxLvlDays.Text = ItemMasterNew.objModel.ItemCriticalLevel.FirstOrDefault().MaximumLevelDays.ToString() == string.Empty ? "0.00" : ItemMasterNew.objModel.ItemCriticalLevel.FirstOrDefault().MaximumLevelDays.ToString();
                id = (ItemMasterNew.objModel.ItemCriticalLevel.FirstOrDefault().DC_Id);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DefineCriticalLevelModel objCritical;
            ItemMasterNew.objModel.ItemCriticalLevel = new List<DefineCriticalLevelModel>();

            objCritical = new DefineCriticalLevelModel();
            objCritical.MinimumLevelQty = Convert.ToDecimal(tbxMinLvlQty.Text.Trim() == null ? string.Empty : tbxMinLvlQty.Text.Trim());
            objCritical.RecordLevelQty = Convert.ToDecimal(tbxRecordLvlQty.Text.Trim() == null ? string.Empty : tbxRecordLvlQty.Text.Trim());
            objCritical.MaximumLevelQty = Convert.ToDecimal(tbxMaxLvlQty.Text.Trim() == null ? string.Empty : tbxMaxLvlQty.Text.Trim());
            objCritical.MinimumLevelDays = Convert.ToDecimal(tbxMinLvlDays.Text.Trim() == null ? string.Empty : tbxMinLvlDays.Text.Trim());
            objCritical.RecordLevelDays = Convert.ToDecimal(tbxRecordLvlDays.Text.Trim() == null ? string.Empty : tbxRecordLvlDays.Text.Trim());
            objCritical.MaximumLevelDays = Convert.ToDecimal(tbxMaxLvlDays.Text.Trim() == null ? string.Empty : tbxMaxLvlDays.Text.Trim());
            objCritical.DC_Id = id;
            ItemMasterNew.objModel.ItemCriticalLevel.Add(objCritical);

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
    }
}
