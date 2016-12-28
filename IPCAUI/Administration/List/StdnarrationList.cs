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
            this.Close();
        }
    }
}
