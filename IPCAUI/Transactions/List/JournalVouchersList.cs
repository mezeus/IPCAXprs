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
    public partial class JournalVouchersList : Form
    {
        JournalVoucherModelBL objJournalBl = new JournalVoucherModelBL();
        public JournalVouchersList()
        {
          
            InitializeComponent();
        }

        private void JournalVouchersList_Load(object sender, EventArgs e)
        {
            List<ListModel> lstJournal = objJournalBl.GetAllJournalVoucher();
            dvgJournalList.DataSource = lstJournal;

        }
                
        private void gdvAccGroupDetails_DoubleClick(object sender, EventArgs e)
        {
            AccountGroupModel lstItems;

            lstItems = (AccountGroupModel)dvgJournalListDetails.GetRow(dvgJournalListDetails.FocusedRowHandle);
            string cellValue = lstItems.GroupId.ToString();
        }
    
        private void gdvAccGroupDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            AccountGroupModel lstItems;

            lstItems = (AccountGroupModel)dvgJournalListDetails.GetRow(dvgJournalListDetails.FocusedRowHandle);
          //  Accountgroup.groupId = lstItems.GroupId;

              this.Close();            
        }        
    }
}
