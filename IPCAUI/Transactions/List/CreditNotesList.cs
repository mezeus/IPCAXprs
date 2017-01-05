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
    public partial class CreditNotesList : Form
    {
        CreditNoteBL objBL = new CreditNoteBL();
        public CreditNotesList()
        {
          
            InitializeComponent();
        }

        private void CreditNotes_Load(object sender, EventArgs e)
        {
         

        }
                
        private void CreditNotesList_Load(object sender, EventArgs e)
        {
            List<ListModel> lstCredits = objBL.GetAllCreditNote();
            dvgCreditList.DataSource = lstCredits;
        }

        private void gdvCreditDetails_DoubleClick(object sender, EventArgs e)
        {
            //AccountGroupModel lstItems;

            //lstItems = (AccountGroupModel)gdvCreditDetails.GetRow(gdvCreditDetails.FocusedRowHandle);
            //string cellValue = lstItems.GroupId.ToString();
        }

        private void gdvCreditDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            ListModel lstMasters;

            lstMasters = (ListModel)gdvCreditDetails.GetRow(gdvCreditDetails.FocusedRowHandle);
            Transactions.CreditNote.CNId = lstMasters.Id;

            this.Close();
        }
    }
}
