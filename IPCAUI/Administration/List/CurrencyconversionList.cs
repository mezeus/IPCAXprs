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
    public partial class CurrencyconversionList : Form
    {
        public CurrencyconversionList()
        {
            InitializeComponent();
        }

        private void CurrencyconversionList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.CurrencyconversionList.CurrencyconversionListDtDataTable dt = new DataSets.CurrencyconversionList.CurrencyconversionListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.CurrencyconversionList.CurrencyconversionListDtRow dr = dt.NewCurrencyconversionListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                dr[2] = "Parent Group test data" +i;
                dr[3] = "12.56" +i;
                dr[4] = "10.45" +i;

                dt.AddCurrencyconversionListDtRow(dr);
            }
            DataSets.CurrencyconversionList ds = new DataSets.CurrencyconversionList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            currencyconversionListDtBindingSource.DataSource = src;
            
        }

        private void dvgCurrencyconversionList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
