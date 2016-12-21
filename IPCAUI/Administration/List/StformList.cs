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
    public partial class StformList : Form
    {
        public StformList()
        {
            InitializeComponent();
        }

        private void StformList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.StformList.StformListDtDataTable dt = new DataSets.StformList.StformListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.StformList.StformListDtRow dr = dt.NewStformListDtRow();

                dr[0] = "C" + i;
                dr[1] = "C" +i ;
                //dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddStformListDtRow(dr);
            }
            DataSets.StformList ds = new DataSets.StformList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            stformListDtBindingSource.DataSource = src;
            
        }

        private void dvgStformList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
