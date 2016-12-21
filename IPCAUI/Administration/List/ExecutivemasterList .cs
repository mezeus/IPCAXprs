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
    public partial class ExecutivemasterList : Form
    {
        public ExecutivemasterList()
        {
            InitializeComponent();
        }

        private void ExecutivemasterList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.ExecutivemasterList.ExecutivemasterListDtDataTable dt = new DataSets.ExecutivemasterList.ExecutivemasterListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.ExecutivemasterList.ExecutivemasterListDtRow dr = dt.NewExecutivemasterListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                //dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddExecutivemasterListDtRow(dr);
            }
            DataSets.ExecutivemasterList ds = new DataSets.ExecutivemasterList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            executivemasterListDtBindingSource.DataSource = src;
            
        }

        private void dvgExecutivemasterList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
