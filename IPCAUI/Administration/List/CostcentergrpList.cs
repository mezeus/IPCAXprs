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
    public partial class CostcentergrpList : Form
    {
        public CostcentergrpList()
        {
            InitializeComponent();
        }

        private void CostcentergrpList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.CostcentergrpList.CostcentergrpListDtDataTable dt = new DataSets.CostcentergrpList.CostcentergrpListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.CostcentergrpList.CostcentergrpListDtRow dr = dt.NewCostcentergrpListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddCostcentergrpListDtRow(dr);
            }
            DataSets.CostcentergrpList ds = new DataSets.CostcentergrpList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            costcentergrpListDtBindingSource.DataSource = src;
            
        }

        private void dvgCCgrpList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
