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

        
        private void dvgUnitconversionList_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dvgUnitConDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dvgUnitConDetails_KeyDown(object sender, KeyEventArgs e)
        {
            UnitConversionModel lstUnitCover;

            lstUnitCover = (UnitConversionModel)dvgUnitConDetails.GetRow(dvgUnitConDetails.FocusedRowHandle);
            Unitconversion.UCId = lstUnitCover.ID;

            this.Close();
        }
    }
}
