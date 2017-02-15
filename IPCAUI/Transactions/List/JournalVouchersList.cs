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

        private void dvgJournalListDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                ListModel lstJournal;

                lstJournal = (ListModel)dvgJournalListDetails.GetRow(dvgJournalListDetails.FocusedRowHandle);
                Transactions.JournalVoucher.Journl_Id = lstJournal.Id;

                this.Close();
            }
        }

        private void dvgJournalListDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ListModel lstJournal;

            lstJournal = (ListModel)dvgJournalListDetails.GetRow(dvgJournalListDetails.FocusedRowHandle);
            Transactions.JournalVoucher.Journl_Id = lstJournal.Id;

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
