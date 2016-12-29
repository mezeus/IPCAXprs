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
    public partial class UnitmasterList : Form
    {
        UnitMaster objunitbl = new UnitMaster();
        public UnitmasterList()
        {
            InitializeComponent();
        }

        private void UnitmasterList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.UnitMasterModel> lstUnits = objunitbl.GetListofUnits();
            dvgUnitmasterList.DataSource = lstUnits;
        }

        
        private void dvgUnitmasterList_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dvgUnitMasterDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            UnitMasterModel lstUnitmaster;

            lstUnitmaster = (UnitMasterModel)dvgUnitMasterDetails.GetRow(dvgUnitMasterDetails.FocusedRowHandle);
            Unitmaster.UMId = lstUnitmaster.UM_ID;

            this.Close();
        }
    }
}
