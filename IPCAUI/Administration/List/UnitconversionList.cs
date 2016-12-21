using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCAUI.Administration.List
{
    public partial class UnitconversionList : Form
    {
        public UnitconversionList()
        {
            InitializeComponent();
        }

        private void UnitconversionList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.UnitconversionList.UnitconversionListDtDataTable dt = new DataSets.UnitconversionList.UnitconversionListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.UnitconversionList.UnitconversionListDtRow dr = dt.NewUnitconversionListDtRow();

                dr[0] = "Dozen" + i;
                dr[1] = "Pics" +i ;
                dr[2] = "12000" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddUnitconversionListDtRow(dr);
            }
            DataSets.UnitconversionList ds = new DataSets.UnitconversionList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            unitconversionListDtBindingSource.DataSource = src;
            
        }

        
        private void dvgUnitconversionList_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
