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
    public partial class DebitNotesList : Form
    {
        DebitNoteBL objBL = new DebitNoteBL();

        public DebitNotesList()
        {
          
            InitializeComponent();
        }

        private void DebitNotes_Load(object sender, EventArgs e)
        {
            List<ListModel> lstDebitNotes = objBL.GetAllDebitNote();
            dvgDebitList.DataSource = lstDebitNotes;

        }
                        
        private void dvgDebitList_KeyPress(object sender, KeyPressEventArgs e)
        {
            ListModel lstMasters;

            lstMasters = (ListModel)gdvDebitDetails.GetRow(gdvDebitDetails.FocusedRowHandle);
            Transactions.DebitNote.DNId= lstMasters.Id;

            this.Close();
        }
    }
}
