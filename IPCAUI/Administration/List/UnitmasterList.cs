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
    public partial class UnitmasterList : Form
    {
        public UnitmasterList()
        {
            InitializeComponent();
        }

        private void UnitmasterList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.UnitmasterList.UnitmasterListDtDataTable dt = new DataSets.UnitmasterList.UnitmasterListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.UnitmasterList.UnitmasterListDtRow dr = dt.NewUnitmasterListDtRow();

                dr[0] = "Dozen" + i;
                dr[1] = "Dozen" +i ;
                //dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddUnitmasterListDtRow(dr);
            }
            DataSets.UnitmasterList ds = new DataSets.UnitmasterList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            unitmasterListDtBindingSource.DataSource = src;
            
        }

        private void dvgUnitmasterList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
