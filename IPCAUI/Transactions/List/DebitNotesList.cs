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

        private void DebitNotesList_Load(object sender, EventArgs e)
        {
            List<ListModel> lstDebitNotes = objBL.GetAllDebitNote();
            dvgDebitList.DataSource = lstDebitNotes;
        }

        private void gdvDebitDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                ListModel lstMasters;

                lstMasters = (ListModel)gdvDebitDetails.GetRow(gdvDebitDetails.FocusedRowHandle);
                Transactions.DebitNote.DNId = lstMasters.Id;

                this.Close();
            }           
        }

        private void gdvDebitDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ListModel lstMasters;

            lstMasters = (ListModel)gdvDebitDetails.GetRow(gdvDebitDetails.FocusedRowHandle);
            Transactions.DebitNote.DNId = lstMasters.Id;

            this.Close();
        }
    }
}
