using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;

namespace IPCAUI.Administration.List
{
    public partial class AccountgroupList : Form
    {
        AccountMaster objaccbl = new AccountMaster();
        public AccountgroupList()
        {
          
            InitializeComponent();
        }

        private void AccountgroupList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.AccountGroupModel> lstGroups = objaccbl.GetListofAccountsGroups();
            dvgAccList.DataSource = lstGroups;

            //Fill();
        }

        private void Fill()
        {
            DataSets.AccountgroupList.AccountgroupListDtDataTable dt = new DataSets.AccountgroupList.AccountgroupListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.AccountgroupList.AccountgroupListDtRow dr = dt.NewAccountgroupListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddAccountgroupListDtRow(dr);
            }
            DataSets.AccountgroupList ds = new DataSets.AccountgroupList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            accountgroupListDtBindingSource.DataSource = src;
            
        }

        private void gvdAccList_KeyDown(object sender, KeyEventArgs e)
        {
            //int id = Convert.ToInt32(dvgAccList.co[0].Cells[0].Value);
        }
    }
}
