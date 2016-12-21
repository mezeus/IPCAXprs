using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace IPCAUI.Administration
{
    public partial class Billsundary : DevExpress.XtraEditors.XtraForm
    {
        public Billsundary()
        {
            InitializeComponent();
        }

        private void Billsundary_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void ListBillsundary_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.BillsundaryList frmList = new Administration.List.BillsundaryList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }
    }
}