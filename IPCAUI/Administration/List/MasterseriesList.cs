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
    public partial class MasterseriesList : Form
    {
        eSunSpeed.BusinessLogic.MasterseriesBL objmastbl = new MasterseriesBL();
        public MasterseriesList()
        {
            InitializeComponent();
        }

        private void MasterseriesList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.MasterseriesModel> lstmaster = objmastbl.GetListofMasterSeries();
            dvgMasterSeriesList.DataSource = lstmaster;
        }

        private void dvgMasterseries_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void dvgMasterseries_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                MasterseriesModel lstmasters;

                lstmasters = (MasterseriesModel)dvgMasterseries.GetRow(dvgMasterseries.FocusedRowHandle);
                Masterseriesgroup.MsGId = lstmasters.MasterId;

                this.Close();
            }          
        }

        private void dvgMasterseries_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            MasterseriesModel lstmasters;

            lstmasters = (MasterseriesModel)dvgMasterseries.GetRow(dvgMasterseries.FocusedRowHandle);
            Masterseriesgroup.MsGId = lstmasters.MasterId;

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
