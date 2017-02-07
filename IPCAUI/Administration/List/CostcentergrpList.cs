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
    public partial class CostcentergrpList : Form
    {
        CostCentreGroupBL objCGbl = new CostCentreGroupBL();
        public CostcentergrpList()
        {
            InitializeComponent();
        }

        private void CostcentergrpList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.CostCentreGroupModel> lstGroups = objCGbl.GetAllCostCentreGroups();
            dvgCCgrpList.DataSource = lstGroups;
        }

        private void dvgCCgrpList_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dvgCCgrpList_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void dvgCCgrpDetails_KeyPress(object sender, KeyPressEventArgs e)
        {

            
        }

        private void dvgCCgrpDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                CostCentreGroupModel lstGrops;

                lstGrops = (CostCentreGroupModel)dvgCCgrpDetails.GetRow(dvgCCgrpDetails.FocusedRowHandle);
                Costcentergroup.groupId = lstGrops.CCG_ID;

                this.Close();
            }
        }

        private void dvgCCgrpDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            CostCentreGroupModel lstGrops;

            lstGrops = (CostCentreGroupModel)dvgCCgrpDetails.GetRow(dvgCCgrpDetails.FocusedRowHandle);
            Costcentergroup.groupId = lstGrops.CCG_ID;

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
