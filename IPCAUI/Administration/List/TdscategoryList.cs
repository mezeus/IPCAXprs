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
    public partial class TdscategoryList : Form
    {
        public TdscategoryList()
        {
            InitializeComponent();
        }

        private void TdscategoryList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.TdscategoryList.TdscategoryListDtDataTable dt = new DataSets.TdscategoryList.TdscategoryListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.TdscategoryList.TdscategoryListDtRow dr = dt.NewTdscategoryListDtRow();

                dr[0] = "TDS Catogary" + i;
                dr[1] = "Alias Name" +i ;
                //dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddTdscategoryListDtRow(dr);
            }
            DataSets.TdscategoryList ds = new DataSets.TdscategoryList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            tdscategoryListDtBindingSource.DataSource = src;
            
        }

        private void dvgTaxcategoryList_Click(object sender, EventArgs e)
        {

        }

        private void dvgTaxcategoryList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }

        private void dvgTdscategoryList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
