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
                
        private void CreditNotesList_Load(object sender, EventArgs e)
        {
            List<ListModel> lstCredits = objBL.GetAllCreditNote();
            dvgCreditList.DataSource = lstCredits;
        }

        private void gdvCreditDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                ListModel lstMasters;

                lstMasters = (ListModel)gdvCreditDetails.GetRow(gdvCreditDetails.FocusedRowHandle);
                Transactions.CreditNote.CNId = lstMasters.Id;

                this.Close();
            }          
        }

        private void gdvCreditDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ListModel lstMasters;

            lstMasters = (ListModel)gdvCreditDetails.GetRow(gdvCreditDetails.FocusedRowHandle);
            Transactions.CreditNote.CNId = lstMasters.Id;

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
