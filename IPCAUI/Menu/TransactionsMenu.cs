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
using DevExpress.XtraBars.Ribbon;

namespace IPCAUI.Menu
{
    public partial class TransactionsMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        XtraForm1 frm;
        public TransactionsMenu(XtraForm1 frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void TransactionsMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.Visible = true;
        }
        
        private void rbCtrlTransactions_Click(object sender, EventArgs e)
        {

        }

        private void rbCtrlTransactions_SelectedPageChanged(object sender, EventArgs e)
        {
            string selectedPage = (sender as RibbonControl).SelectedPage.Name.ToString();

            //switch (selectedPage)
            //{
            //    case "Reports":
            //        this.Hide();
            //        IPCAUI.Menu.ReportMenu frmReport = new IPCAUI.Menu.ReportMenu(this);
            //        frmReport.Show();
            //        break;
            //    case "Transactions":
            //        this.Hide();
            //        IPCAUI.Menu.TransactionsMenu frmTransMenu = new IPCAUI.Menu.TransactionsMenu(this);
            //        frmTransMenu.Show();
            //        break;
            //    case "Master":
            //        this.Hide();
            //        IPCAUI.Menu.MastersMenu frmMasterMenu = new IPCAUI.Menu.MastersMenu(this);
            //        frmMasterMenu.Show();
            //        break;
            //    case "Configuration":
            //        this.Hide();
            //        IPCAUI.Menu.ConfigurationMenu frmConfigMenu = new IPCAUI.Menu.ConfigurationMenu(this);
            //        frmConfigMenu.Show();
            //        break;
            //    case "Merged Accounts":
            //        break;
            //    case "Single Column":
            //        break;
            //    case "Multiple Column":
            //        break;
            //    case "Bank Book(As per Clr.Date)":
            //        break;
            //    default:
            //        break;
            //}

        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Transactions.SalesVoucher frm;
            //if(this.ActiveMdiChild!=null)
            //{
            //    frm = new Transactions.SalesVoucher(); //generate new instance

            //    frm.Owner = this;
            //    frm.TopLevel = false;
            //    splitContainerControl1.Panel2.Controls.Add(frm);
            //    frm.Show();
            //}
        }

        private void Payment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                Transactions.PaymentVoucher frm;                       
                frm = new Transactions.PaymentVoucher(); //generate new instance
                //frm.Owner = this;
                frm.TopLevel = false;
                splitContainerControl1.Panel2.Controls.Add(frm);
                frm.Show();
           
            //if (this.ActiveMdiChild != null)
            //    //this.MdiChild.Clone();
            //    this.ActiveMdiChild.Close();

            //IPCAUI.Transactions.PaymentVoucher frmPayment = new Transactions.PaymentVoucher();
            //frmPayment.StartPosition = FormStartPosition.WindowsDefaultLocation;
            //frmPayment.MdiParent = this;
            //frmPayment.Show();
            //splitContainerControl1.Panel2.Controls.Add(frmPayment);
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
        private void SalesEntry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //MessageBox.Show("Under Progeress.........");
            Transactions.Purchaseindentvoucher frm;
            frm = new Transactions.Purchaseindentvoucher(); //generate new instance

            frm.Owner = this;
            frm.TopLevel = false;
            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
            //}
            //else
            //{
            //    frm = new Transactions.SalesVoucher(); //generate new instance

            //    frm.Owner = this;
            //    frm.TopLevel = false;
            //    splitContainerControl1.Panel2.Controls.Add(frm);
            //    frm.Show();
            //}

            //if (this.ActiveMdiChild != null)
            ////    this.ActiveMdiChild.Close();
            //{

            //    Transactions.SalesVoucher frmSales = new Transactions.SalesVoucher();
            //    frmSales.StartPosition = FormStartPosition.WindowsDefaultLocation;
            //    frmSales.MdiParent = this.ParentForm;
            //    frmSales.Show();
            //    splitContainerControl1.Panel2.Controls.Add(frmSales);
            // }
            //else
            //{ 
            //Transactions.SalesVoucher frmSales = new Transactions.SalesVoucher();
            //frmSales.StartPosition = FormStartPosition.WindowsDefaultLocation;
            //frmSales.MdiParent = this;
            //frmSales.Show();
            //splitContainerControl1.Panel2.Controls.Add(frmSales);
            //}
        }

        private void Receipt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void SalesQuotation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //MessageBox.Show("Under Progeress.........");
            Transactions.SalesQuotation frm;
            frm = new Transactions.SalesQuotation(); //generate new instance

            frm.Owner = this;
            frm.TopLevel = false;
            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void PurchaseQuotation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //MessageBox.Show("Under Progeress.........");
            Transactions.purchaseQuotation frm;
            frm = new Transactions.purchaseQuotation(); //generate new instance

            frm.Owner = this;
            frm.TopLevel = false;
            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void SalesOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //MessageBox.Show("Under Progeress.........");
            Transactions.Salesorder frm;
            frm = new Transactions.Salesorder(); //generate new instance

            frm.Owner = this;
            frm.TopLevel = false;
            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void PurchaseOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //MessageBox.Show("Under Progeress.........");
            //Transactions.Purchaseorder frm;
            //frm = new Transactions.Purchaseorder(); //generate new instance

            //frm.Owner = this;
            //frm.TopLevel = false;
            //splitContainerControl1.Panel2.Controls.Add(frm);
            //frm.Show();

            Transactions.Purchaseorder frm;
            frm = new Transactions.Purchaseorder(); //generate new instance

            frm.Owner = this;
            frm.TopLevel = false;
            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void Salesvoucher_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.SalesVoucher frm;
            frm = new Transactions.SalesVoucher(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void PurchaseVoucher_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.Purhcasevoucher frm;
            frm = new Transactions.Purhcasevoucher(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void SalesRetVoucher_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Under Progress........");
            //Transactions.Purhcasevoucher frm;
            //frm = new Transactions.Purhcasevoucher(); //generate new instance 
            //frm.Owner = this;
            //frm.TopLevel = false;

            //splitContainerControl1.Panel2.Controls.Add(frm);
            //frm.Show();
        }

        private void PurchaseretVoucher_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.PurhcaseReturnvoucher frm;
            frm = new Transactions.PurhcaseReturnvoucher(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void pPaymentVoucher_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.PaymentVoucher frm;
            frm = new Transactions.PaymentVoucher(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void ReceiptVoucher_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.ReceiptVoucher frm;
            frm = new Transactions.ReceiptVoucher(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void JournalVoucher_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.JournalVoucher frm;
            frm = new Transactions.JournalVoucher(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void ContraVoucher_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.ContraVoucher frm;
            frm = new Transactions.ContraVoucher(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void DebitNoteVech_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.DebitNote frm;
            frm = new Transactions.DebitNote(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void CreditNoteVch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.CreditNote frm;
            frm = new Transactions.CreditNote(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void StockTransferVch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.StockTransferVoucher frm;
            frm = new Transactions.StockTransferVoucher(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void ProductinVch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.Productionvoucher frm;
            frm = new Transactions.Productionvoucher(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void UnassembleVch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.Unassemblevoucher frm;
            frm = new Transactions.Unassemblevoucher(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void StockJournal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.StockJournalvoucher frm;
            frm = new Transactions.StockJournalvoucher(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void MatIssuedparty_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.Matissuedtopartyvoucher frm;
            frm = new Transactions.Matissuedtopartyvoucher(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void MatRcvdpary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.Matreceivedfromparty frm;
            frm = new Transactions.Matreceivedfromparty(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void FormsRecevied_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.formsreceivedvoucher frm;
            frm = new Transactions.formsreceivedvoucher(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void FormIssued_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.formsissuedvoucher frm;
            frm = new Transactions.formsissuedvoucher(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void VatJournal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.VATJournal frm;
            frm = new Transactions.VATJournal(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void Physicalstockvch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.PhysicalStockvoucher frm;
            frm = new Transactions.PhysicalStockvoucher(); //generate new instance

            frm.Owner = this;
            frm.TopLevel = false;
            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.Adjustexciseamounts frm;
            frm = new Transactions.Adjustexciseamounts(); //generate new instance

            frm.Owner = this;
            frm.TopLevel = false;
            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void Callallocation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Transactions.Purchaseindentvoucher frm;
            //frm = new Transactions.Purchaseindentvoucher(); //generate new instance

            //frm.Owner = this;
            //frm.TopLevel = false;
            //splitContainerControl1.Panel2.Controls.Add(frm);
            //frm.Show();
        }

        private void Callreceipt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Transactions.CallReceipt frm;
            frm = new Transactions.CallReceipt(); //generate new instance

            frm.Owner = this;
            frm.TopLevel = false;
            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }
    }
}