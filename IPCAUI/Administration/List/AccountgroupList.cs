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
        AccountMasterBL objaccbl = new AccountMasterBL();
        public AccountgroupList()
        {
          
            InitializeComponent();
        }

        private void AccountgroupList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.AccountGroupModel> lstGroups = objaccbl.GetListofAccountsGroups();
            dvgAccList.DataSource = lstGroups;

        }
                
        private void gdvAccGroupDetails_DoubleClick(object sender, EventArgs e)
        {

        }
    
        private void gdvAccGroupDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
                 
        }

        private void gdvAccGroupDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                AccountGroupModel lstItems;

                lstItems = (AccountGroupModel)gdvAccGroupDetails.GetRow(gdvAccGroupDetails.FocusedRowHandle);
                Accountgroup.groupId = lstItems.GroupId;

                this.Close();
            }      
        }

        private void gdvAccGroupDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            AccountGroupModel lstItems;

            lstItems = (AccountGroupModel)gdvAccGroupDetails.GetRow(gdvAccGroupDetails.FocusedRowHandle);
            Accountgroup.groupId = lstItems.GroupId;

            this.Close();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
