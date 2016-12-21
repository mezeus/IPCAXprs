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
    public partial class CostcenterList : Form
    {
        public CostcenterList()
        {
            InitializeComponent();
        }

        private void CostcenterList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.CostcenterList.CostcenterListDtDataTable dt = new DataSets.CostcenterList.CostcenterListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.CostcenterList.CostcenterListDtRow dr = dt.NewCostcenterListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                dr[2] = "Parent Group test data" +i;
                dr[3] = "12.56" +i;
                dr[4] = "10.45" +i;

                dt.AddCostcenterListDtRow(dr);
            }
            DataSets.CostcenterList ds = new DataSets.CostcenterList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            costcenterListDtBindingSource.DataSource = src;
            
        }

        private void dvgCostcenter_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
