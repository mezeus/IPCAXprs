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

namespace IPCAUI.Administration.List
{
    public partial class StdnarrationList : Form
    {
        StdNarrationMasterBL objstdbl = new StdNarrationMasterBL();
        public StdnarrationList()
        {
            InitializeComponent();
        }

        private void StdnarrationList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.StdNarrationMasterModel> lstNarration = objstdbl.GetAllStdNarration();
            dvgStdnarration.DataSource = lstNarration;
        }

        private void dvgStdnarration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == '\r')
            {
                StdNarrationMasterModel lstStdnarr;

                lstStdnarr = (StdNarrationMasterModel)dvgStdnarrationDetails.GetRow(dvgStdnarrationDetails.FocusedRowHandle);
                StdNarration.StdId = lstStdnarr.SN_Id;

                this.Close();
            }
        }

        private void dvgStdnarrationDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
           
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
