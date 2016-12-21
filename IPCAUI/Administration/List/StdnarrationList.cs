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
    public partial class StdnarrationList : Form
    {
        public StdnarrationList()
        {
            InitializeComponent();
        }

        private void StdnarrationList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.StdnarrationList.StdnarrationListDtDataTable dt = new DataSets.StdnarrationList.StdnarrationListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.StdnarrationList.StdnarrationListDtRow dr = dt.NewStdnarrationListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                dr[2] = "Std Narration" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddStdnarrationListDtRow(dr);
            }
            DataSets.StdnarrationList ds = new DataSets.StdnarrationList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            stdnarrationListDtBindingSource.DataSource = src;
            
        }

        private void dvgStdnarration_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
