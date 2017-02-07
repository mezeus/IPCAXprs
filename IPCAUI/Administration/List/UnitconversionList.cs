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
    public partial class UnitconversionList : Form
    {
        UnitConversion objucbl = new UnitConversion();
        public UnitconversionList()
        {
            InitializeComponent();
        }

        private void UnitconversionList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.UnitConversionModel> lstunitconversion = objucbl.GetListofUnitConversions();
            dvgUnitconversionList.DataSource = lstunitconversion;
        }

        private void dvgUnitConDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                UnitConversionModel lstUnitCover;

                lstUnitCover = (UnitConversionModel)dvgUnitConDetails.GetRow(dvgUnitConDetails.FocusedRowHandle);
                Unitconversion.UCId = lstUnitCover.ID;

                this.Close();
            }
        }

        private void dvgUnitConDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            UnitConversionModel lstUnitCover;

            lstUnitCover = (UnitConversionModel)dvgUnitConDetails.GetRow(dvgUnitConDetails.FocusedRowHandle);
            Unitconversion.UCId = lstUnitCover.ID;

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
