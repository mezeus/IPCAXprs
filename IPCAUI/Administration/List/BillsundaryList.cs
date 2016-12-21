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
    public partial class BillsundaryList : Form
    {
        public BillsundaryList()
        {
            InitializeComponent();
        }

        private void BillsundaryList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.BillsundaryList.BillsundaryListDtDataTable dt = new DataSets.BillsundaryList.BillsundaryListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.BillsundaryList.BillsundaryListDtRow dr = dt.NewBillsundaryListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                //dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddBillsundaryListDtRow(dr);
            }
            DataSets.BillsundaryList ds = new DataSets.BillsundaryList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            billsundaryListDtBindingSource.DataSource = src;
            
        }

        private void dvgBillSunadtList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
