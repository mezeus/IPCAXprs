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
    public partial class ContactmasterList : Form
    {
        public ContactmasterList()
        {
            InitializeComponent();
        }

        private void ContactmasterList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.ContactmasterList.ContactmasterListDtDataTable dt = new DataSets.ContactmasterList.ContactmasterListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.ContactmasterList.ContactmasterListDtRow dr = dt.NewContactmasterListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddContactmasterListDtRow(dr);
            }
            DataSets.AccountList ds = new DataSets.AccountList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            contactmasterListDtBindingSource.DataSource = src;
            
        }
    }
}
