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

namespace IPCAUI.Transaction.List
{
    public partial class PurchaseQuotationVouchers : Form
    {
        AccountMasterBL objaccbl = new AccountMasterBL();
        public PurchaseQuotationVouchers()
        {
          
            InitializeComponent();
        }

        private void PurchaseQuotationVouchers_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.AccountGroupModel> lstGroups = objaccbl.GetListofAccountsGroups();
            dvgAccList.DataSource = lstGroups;

        }
                
        private void gdvAccGroupDetails_DoubleClick(object sender, EventArgs e)
        {
            AccountGroupModel lstItems;

            lstItems = (AccountGroupModel)gdvAccGroupDetails.GetRow(gdvAccGroupDetails.FocusedRowHandle);
            string cellValue = lstItems.GroupId.ToString();
        }
    
        private void gdvAccGroupDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            AccountGroupModel lstItems;

            lstItems = (AccountGroupModel)gdvAccGroupDetails.GetRow(gdvAccGroupDetails.FocusedRowHandle);
          //  Accountgroup.groupId = lstItems.GroupId;

              this.Close();            
        }        
    }
}
