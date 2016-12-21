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
    public partial class SchememasterList : Form
    {
        public SchememasterList()
        {
            InitializeComponent();
        }

        private void SchememasterList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.SchememasterList.SchememasterListDtDataTable dt = new DataSets.SchememasterList.SchememasterListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.SchememasterList.SchememasterListDtRow dr = dt.NewSchememasterListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Scheme Master";
                //dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddSchememasterListDtRow(dr);
            }
            DataSets.SchememasterList ds = new DataSets.SchememasterList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            schememasterListDtBindingSource.DataSource = src;
            
        }

        private void dvgSchemList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
