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
        public DefineCriticalLevels()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DefineCriticalLevelModel objCritical;
            ItemMasterNew.objModel.ItemCriticalLevel = new List<DefineCriticalLevelModel>();
            //Loop through the grid and get the values

                objCritical = new DefineCriticalLevelModel();
             objCritical.MinimumLevelQty = Convert.ToDecimal(tbxMinLvlQty.Text.Trim() == null ? string.Empty : tbxMinLvlQty.Text.Trim());
                objCritical.RecordLevelQty = Convert.ToDecimal(tbxRecordLvlQty.Text.Trim() == null ? string.Empty : tbxRecordLvlQty.Text.Trim());
                objCritical.MinimumLevelQty = Convert.ToDecimal(tbxMinLvlQty.Text.Trim() == null ? string.Empty : tbxMinLvlQty.Text.Trim());
                objCritical.MinimumLevelDays = Convert.ToDecimal(tbxMinLvlDays.Text.Trim() == null ? string.Empty : tbxMinLvlDays.Text.Trim());
            objCritical.RecordLevelDays = Convert.ToDecimal(tbxRecordLvlDays.Text.Trim() == null ? string.Empty : tbxRecordLvlDays.Text.Trim());
            objCritical.MaximumLevelDays = Convert.ToDecimal(tbxMaxLvlDays.Text.Trim() == null ? string.Empty : tbxMaxLvlDays.Text.Trim());
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
