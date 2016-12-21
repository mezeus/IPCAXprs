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
    public partial class TaxcategoryList : Form
    {
        public TaxcategoryList()
        {
            InitializeComponent();
        }

        private void TaxcategoryList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.TaxcategoryList.TaxcategoryListDtDataTable dt = new DataSets.TaxcategoryList.TaxcategoryListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.TaxcategoryList.TaxcategoryListDtRow dr = dt.NewTaxcategoryListDtRow();

                dr[0] = "Test Name" + i;
                //dr[1] = "Alias Name" +i ;
                //dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddTaxcategoryListDtRow(dr);
            }
            DataSets.TaxcategoryList ds = new DataSets.TaxcategoryList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            taxcategoryListDtBindingSource.DataSource = src;
            
        }

        private void dvgTaxcategoryList_Click(object sender, EventArgs e)
        {

        }

        private void dvgTaxcategoryList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
