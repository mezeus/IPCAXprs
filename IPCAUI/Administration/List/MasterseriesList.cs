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
    public partial class MasterseriesList : Form
    {
        public MasterseriesList()
        {
            InitializeComponent();
        }

        private void MasterseriesList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.MasterseriesList.MasterseriesListDtDataTable dt = new DataSets.MasterseriesList.MasterseriesListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.MasterseriesList.MasterseriesListDtRow dr = dt.NewMasterseriesListDtRow();

                dr[0] = "Test Name" + i;
                //dr[1] = "Alias Name" +i ;
                //dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddMasterseriesListDtRow(dr);
            }
            DataSets.MasterseriesList ds = new DataSets.MasterseriesList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            masterseriesListDtBindingSource.DataSource = src;
            
        }
    }
}
