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
    public partial class CurrencyList : Form
    {
        public CurrencyList()
        {
            InitializeComponent();
        }

        private void CurrencyList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.CurrencyList.CurrencyListDtDataTable dt = new DataSets.CurrencyList.CurrencyListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.CurrencyList.CurrencyListDtRow dr = dt.NewCurrencyListDtRow();

                dr[0] = "$" + i;
                dr[1] = "USD" +i ;
                dr[2] = "Cents" +i;
                dr[3] = "B.P.A" +i;
                //dr[4] = "10.45" +i;

                dt.AddCurrencyListDtRow(dr);
            }
            DataSets.CurrencyList ds = new DataSets.CurrencyList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            currencyListDtBindingSource.DataSource = src;
            
        }

        private void dvgCurrencyList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
