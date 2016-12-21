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
    public partial class ContactgroupList : Form
    {
        public ContactgroupList()
        {
            InitializeComponent();
        }

        private void ContactgroupList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.ContactgroupList.ContactgroupListDtDataTable dt = new DataSets.ContactgroupList.ContactgroupListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.ContactgroupList.ContactgroupListDtRow dr = dt.NewContactgroupListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddContactgroupListDtRow(dr);
            }
            DataSets.ContactgroupList ds = new DataSets.ContactgroupList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            contactgroupListDtBindingSource.DataSource = src;
            
        }
    }
}
