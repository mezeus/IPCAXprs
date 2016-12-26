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
    public partial class AccountList : Form
    {
        public AccountList()
        {
            InitializeComponent();
        }

        private void AccountList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.AccountList.AccountListDtDataTable dt = new DataSets.AccountList.AccountListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.AccountList.AccountListDtRow dr = dt.NewAccountListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                dr[2] = "Parent Group test data" +i;
                dr[3] = "12.56" +i;
                dr[4] = "10.45" +i;

                dt.AddAccountListDtRow(dr);
            }
            DataSets.AccountList ds = new DataSets.AccountList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            accountListDtBindingSource.DataSource = src;
            
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
