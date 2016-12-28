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
    public partial class AccountList : Form
    {
        AccountMasterBL objaccbl = new AccountMasterBL();
        public AccountList()
        {
            InitializeComponent();
        }

        private void AccountList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.AccountMasterModel> lstaccounts = objaccbl.GetListofAccount();
            dvgAccountList.DataSource = lstaccounts;
        }

        

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
