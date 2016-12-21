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
    public partial class MaterialcenterList : Form
    {
        public MaterialcenterList()
        {
            InitializeComponent();
        }

        private void MaterialcenterList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.MaterialcenterList.MaterialcenterListDataTable dt = new DataSets.MaterialcenterList.MaterialcenterListDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.MaterialcenterList.MaterialcenterListRow dr = dt.NewMaterialcenterListRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddMaterialcenterListRow(dr);
            }
            DataSets.MaterialcenterList ds = new DataSets.MaterialcenterList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            materialcenterListBindingSource.DataSource = src;
            
        }

        private void dvgMaterialcentList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }

        private void dvgMaterialcentList_KeyDown_1(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
