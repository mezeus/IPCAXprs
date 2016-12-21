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
    public partial class SalesmanList : Form
    {
        public SalesmanList()
        {
            InitializeComponent();
        }

        private void SalesmanList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.SalesmanList.SalesmanListDtDataTable dt = new DataSets.SalesmanList.SalesmanListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.SalesmanList.SalesmanListDtRow dr = dt.NewSalesmanListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Sales Man";
                //dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddSalesmanListDtRow(dr);
            }
            DataSets.SalesmanList ds = new DataSets.SalesmanList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            salesmanListDtBindingSource.DataSource = src;
            
        }

        private void dvgSalesmanList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
