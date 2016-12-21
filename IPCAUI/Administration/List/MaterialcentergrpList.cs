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
    public partial class MaterialcentergrpList : Form
    {
        public MaterialcentergrpList()
        {
            InitializeComponent();
        }

        private void MaterialcentergrpList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.MaterialcentergrpList.MaterialcentergrpListDtDataTable dt = new DataSets.MaterialcentergrpList.MaterialcentergrpListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.MaterialcentergrpList.MaterialcentergrpListDtRow dr = dt.NewMaterialcentergrpListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                dr[2] = "Material center";
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddMaterialcentergrpListDtRow(dr);
            }
            DataSets.MaterialcentergrpList ds = new DataSets.MaterialcentergrpList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            materialcentergrpListDtBindingSource.DataSource = src;
            
        }

        private void dvgMCgrpList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
