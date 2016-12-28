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
    public partial class MaterialcentergrpList : Form
    {
        MaterialCentreGroupMaster objgroupbl = new MaterialCentreGroupMaster();
        public MaterialcentergrpList()
        {
            InitializeComponent();
        }

        private void MaterialcentergrpList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.MaterialCentreGroupMasterModel> lstGroups = objgroupbl.GetAllMaterialGroups();
            dvgMCgrpList.DataSource = lstGroups;
        }


        private void dvgMCgrpList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
