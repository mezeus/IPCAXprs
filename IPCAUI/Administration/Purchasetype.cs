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
using System.IO;
using System.Configuration;

namespace IPCAUI.Administration
{
    public partial class PurchaseType : Form
    {
        PurchaseTypeModel objPurcModel = new PurchaseTypeModel();
        PurchaseTypeBL objPurcBL = new PurchaseTypeBL();
        public static int PurcId = 0;
        public PurchaseType()
        {
            InitializeComponent();
        }

        private void tbxQuit_Click(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void navbtnAccount_ItemChanged(object sender, EventArgs e)
        {

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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxPurcahseType.Text.Equals(string.Empty))
            {
                MessageBox.Show("Sales Type can not be blank!");
                tbxPurcahseType.Focus();
                return;
            }
            objPurcModel.PurchType = tbxPurcahseType.Text.Trim();
            //this GroupBox for sales Account Information of RadioButton
          
                objPurcModel.typeSpecifyHereSingleAccount = rbngrpSalesAcInf.SelectedIndex == 0?true:false;
                objPurcModel.typeDifferentTaxRate= rbngrpSalesAcInf.SelectedIndex == 1?true:false;
                objPurcModel.typeSpecifyINVoucher = rbngrpSalesAcInf.SelectedIndex == 2?true:false;
                objPurcModel.LedgerAccountBox = tbxLedgerAccount.Text.Trim() == null ? string.Empty : tbxLedgerAccount.Text.Trim();
            //TaxationType: RadioButton Group
            if (rbngrpTaxation.SelectedIndex==0)
            {
                objPurcModel.typeTaxable = true;
            }
            if (rbngrpTaxation.SelectedIndex == 1)
            {
                objPurcModel.typeAgainstSTFrom = true;
            }
            if(rbngrpTaxation.SelectedIndex==2)
            {
                objPurcModel.typeExempt = true;
            }
            if (rbngrpTaxation.SelectedIndex == 3)
            {
                objPurcModel.typeLUMSumDealer = true;
            }
            if(rbngrpTaxation.SelectedIndex==4)
            {
                objPurcModel.typeMultiTax = true;
            }
            if(rbngrpTaxation.SelectedIndex==5)
            {
                objPurcModel.typeTaxpaid = true;
            }
            if(rbngrpTaxation.SelectedIndex==6)
            {
                objPurcModel.typeTaxFree = true;
            }
            if (rbngrpTaxation.SelectedIndex == 7)
            {
                objPurcModel.typeUnRegDealer = true;
            }
            // other Information Group
            objPurcModel.TaxInvoice = cbxTaxInvoiceyesno.SelectedItem.ToString().Equals("Y") ? true : false;
            objPurcModel.CalculateTaxonItemMRP = cbxTaxonItemmrp.SelectedItem.ToString().Equals("Y") ? true : false;
            objPurcModel.TaxInclusiveItemPrice = cbxTaxInclItemPrice.SelectedItem.ToString().Equals("Y") ? true : false;
            objPurcModel.CalculatedTax = Convert.ToDecimal(tbxCalculatedtax.Text.Trim() == string.Empty ? "0.00" : tbxCalculatedtax.Text.Trim());
            objPurcModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
            objPurcModel.AdjustTaxinSaleAccount = cbxAdTaxinSaleAmt.SelectedItem.ToString().Equals("Y") ? true : false;
            objPurcModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
            objPurcModel.TaxAccount = cbxTaxAccount.SelectedItem.ToString();
            //if Enable MultiTax Will Show on other Information Group
            //Region Radio Button GroupBox
            if(rbngrpRegion.SelectedIndex==0)
            {
                objPurcModel.TypeLocal = true;
            }
            if (rbngrpRegion.SelectedIndex == 1)
            {
                objPurcModel.TypeCentral = true;
            }
            //Tax Calculation
            objPurcModel.SingleTaxRate = rbngrpTaxcalculation.SelectedIndex == 0 ? true : false;
            objPurcModel.MultiTaxRate = rbngrpTaxcalculation.SelectedIndex == 1? true : false;
            objPurcModel.TaxinPercentage = Convert.ToDecimal(tbxTaxPer.Text.Trim() == string.Empty ? "0.00" : tbxTaxPer.Text.Trim());
            objPurcModel.SurchargeInPercentage = Convert.ToDecimal(tbxSurchargePer.Text.Trim() == string.Empty ? "0.00" : tbxSurchargePer.Text.Trim());
            objPurcModel.freezeTaxinSales = cbxFreezeTaxinsale.SelectedItem.ToString().Equals("Y") ? true : false;
            objPurcModel.freezeTaxinSalesReturn = cbxFreezeTaxinSaleReturn.SelectedItem.ToString().Equals("Y") ? true : false;
            //Type of Transaction on Region GrupBox Sub
            objPurcModel.TypeStockTransfer = rbngrpTranction.SelectedIndex == 0 ? true : false;
            objPurcModel.ExportNormal = rbngrpTranction.SelectedIndex == 1 ? true : false;
            objPurcModel.SaleinTransit = rbngrpTranction.SelectedIndex == 2 ? true : false;
            objPurcModel.TypeOther = rbngrpTranction.SelectedIndex == 3? true : false;
            objPurcModel.ExportHighsea = rbngrpTranction.SelectedIndex == 4 ? true : false;
            // Form Information:if Enabl typeAgainstSTFrom
            objPurcModel.IssueSTFrom = cbxIssueSTform.SelectedItem.ToString().Equals("Y") ? true : false;
            objPurcModel.FromIssuable = cbxFormIssuable.SelectedItem.ToString();
            objPurcModel.ReceiveSTForm = cbxIssueSTform.SelectedItem.ToString().Equals("Y") ? true : false;
            objPurcModel.FromReceivable = cbxFormIssuable.SelectedItem.ToString();

            objPurcModel.InvoiceHeading = tbxInvoiceHeading.Text.Trim() == null ? string.Empty : tbxInvoiceHeading.Text.Trim();
            objPurcModel.InvoiceDescription = tbxInvoiceDescription.Text.Trim() == null ? string.Empty : tbxInvoiceDescription.Text.Trim();
            bool isSuccess = objPurcBL.SavePurchaseType(objPurcModel);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }

        }

        private void PurchaseType_Load(object sender, EventArgs e)
        {
            tbxPurcahseType.Focus();
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }
        
        private void cbxGroupname_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        

        private byte[] ReadFile(string fileName)
        {
            byte[] data = null;
            try
            {
                FileInfo fInfo = new FileInfo(fileName);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                data = br.ReadBytes((int)numBytes);
            }
            catch (Exception ex)
            {
                //formMDI.infoError.ErrorString = "CR4:" + ex.Message;
            }
            return data;
        }

        private void cbxLedgertype_Leave(object sender, EventArgs e)
        {
           
        }

        private void cbxGroupname_Leave(object sender, EventArgs e)
        {
            
        }

        private void radioGroup4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListSaleType_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }
        private void FillPurchaseTypeInfo()
        {
            if(PurcId == 0)
            {
                tbxPurcahseType.Focus();
                laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                return;
            }
            objPurcModel = objPurcBL.GetAllPurchTypeByPurchId(PurcId);
            tbxPurcahseType.Text=objPurcModel.PurchType.ToString();
            if(objPurcModel.typeSpecifyHereSingleAccount)
            {
                rbngrpSalesAcInf.SelectedIndex = 0;
            }
            tbxLedgerAccount.Text=objPurcModel.LedgerAccountBox.ToString();
            if(objPurcModel.typeDifferentTaxRate)
            {
                rbngrpSalesAcInf.SelectedIndex = 1;
            }
            if(objPurcModel.typeSpecifyINVoucher)
            {
                rbngrpSalesAcInf.SelectedIndex = 2;
            }
            if(objPurcModel.typeTaxable)
            {
                rbngrpTaxation.SelectedIndex = 0;
            }
            if(objPurcModel.typeAgainstSTFrom)
            {
                rbngrpTaxation.SelectedIndex = 1;
            }
            if (objPurcModel.typeExempt)
            {
                rbngrpTaxation.SelectedIndex = 2;
            }        
            if(objPurcModel.typeTaxpaid)
            {
                rbngrpTaxation.SelectedIndex = 5;
            }
            if (objPurcModel.typeMultiTax)
            {
                rbngrpTaxation.SelectedIndex = 4;
            }
            if(objPurcModel.typeTaxFree)
            {
                rbngrpTaxation.SelectedIndex = 6;
            }
            if(objPurcModel.typeLUMSumDealer)
            {
                rbngrpTaxation.SelectedIndex = 7;
            }
            if(objPurcModel.typeUnRegDealer)
            {
                rbngrpTaxation.SelectedIndex = 3;
            }
            cbxTaxInvoiceyesno.SelectedItem= (objPurcModel.TaxInvoice)?"Y":"N";
            cbxVatreturnCategory.SelectedItem= objPurcModel.VatReturnCategory.ToString();
            cbxVatorSalesTaxReports.SelectedItem= objPurcModel.SkipVatorSaleTaxReport ? "Y" : "N";
            cbxTaxonItemmrp.SelectedItem= objPurcModel.CalculateTaxonItemMRP ? "Y" : "N";
            cbxTaxInclItemPrice.SelectedItem= objPurcModel.TaxInclusiveItemPrice ? "Y" : "N";
            tbxCalculatedtax.Text= objPurcModel.CalculateTaxonpercentofAmount.ToString();
            cbxAdTaxinSaleAmt.SelectedItem= objPurcModel.AdjustTaxinSaleAccount ? "Y" : "N";
            cbxTaxAccount.SelectedItem= objPurcModel.TaxAccount.ToString();
            if(objPurcModel.TypeLocal)
            {
                rbngrpRegion.SelectedIndex = 0;
            }
            if (objPurcModel.TypeCentral)
            {
                rbngrpRegion.SelectedIndex = 1;
            }
            if(objPurcModel.TypeStockTransfer)
            {
                rbngrpTranction.SelectedIndex = 0;
            }
            if(objPurcModel.TypeOther)
            {
                rbngrpTranction.SelectedIndex = 3;
            }
            if(objPurcModel.ExportNormal)
            {
                rbngrpTranction.SelectedIndex = 1;
            }
            if(objPurcModel.SaleinTransit)
            {
                rbngrpTranction.SelectedIndex = 2;
            }
            if(objPurcModel.ExportHighsea)
            {
                rbngrpTranction.SelectedIndex = 4;
            }
            cbxIssueSTform.SelectedItem= objPurcModel.IssueSTFrom?"Y":"N";
            cbxFormIssuable.SelectedItem= objPurcModel.FromIssuable.ToString();
            cbxRecevieSTForm.SelectedItem= objPurcModel.ReceiveSTForm?"Y":"N";
            cbxFormReceviable.SelectedItem= objPurcModel.FromReceivable.ToString();
            if(objPurcModel.SingleTaxRate)
            {
                rbngrpTaxcalculation.SelectedIndex = 0;
            }
            if(objPurcModel.MultiTaxRate)
            {
                rbngrpTaxcalculation.SelectedIndex = 1;
            }
            tbxTaxPer.Text= objPurcModel.TaxinPercentage.ToString();
            tbxSurchargePer.Text= objPurcModel.SurchargeInPercentage .ToString();
            cbxFreezeTaxinsale.SelectedItem= objPurcModel.freezeTaxinSales?"Y":"N";
            cbxFreezeTaxinSaleReturn.SelectedItem= objPurcModel.freezeTaxinSalesReturn?"Y":"N";
            tbxInvoiceHeading.Text= objPurcModel.InvoiceHeading.ToString();
            tbxInvoiceDescription.Text= objPurcModel.InvoiceDescription.ToString();
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxPurcahseType.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            objPurcModel = new PurchaseTypeModel();
            objPurcModel.PurchType = tbxPurcahseType.Text.Trim();
            
            //this GroupBox for sales Account Information of RadioButton
            objPurcModel.typeSpecifyHereSingleAccount = rbngrpSalesAcInf.SelectedIndex == 0 ? true : false;
            objPurcModel.typeDifferentTaxRate = rbngrpSalesAcInf.SelectedIndex == 1 ? true : false;
            objPurcModel.typeSpecifyINVoucher = rbngrpSalesAcInf.SelectedIndex == 2 ? true : false;
            objPurcModel.LedgerAccountBox = tbxLedgerAccount.Text.Trim() == null ? string.Empty : tbxLedgerAccount.Text.Trim();
            //TaxationType: RadioButton Group
            if (rbngrpTaxation.SelectedIndex == 0)
            {
                objPurcModel.typeTaxable = true;
            }
            if (rbngrpTaxation.SelectedIndex == 1)
            {
                objPurcModel.typeAgainstSTFrom = true;
            }
            if (rbngrpTaxation.SelectedIndex == 2)
            {
                objPurcModel.typeExempt = true;
            }
            if (rbngrpTaxation.SelectedIndex == 3)
            {
                objPurcModel.typeLUMSumDealer = true;
            }
            if (rbngrpTaxation.SelectedIndex == 4)
            {
                objPurcModel.typeMultiTax = true;
            }
            if (rbngrpTaxation.SelectedIndex == 5)
            {
                objPurcModel.typeTaxpaid = true;
            }
            if (rbngrpTaxation.SelectedIndex == 6)
            {
                objPurcModel.typeTaxFree = true;
            }
            if (rbngrpTaxation.SelectedIndex == 7)
            {
                objPurcModel.typeUnRegDealer = true;
            }
            // other Information Group
            objPurcModel.TaxInvoice = cbxTaxInvoiceyesno.SelectedItem.ToString().Equals("Y") ? true : false;
            objPurcModel.CalculateTaxonItemMRP = cbxTaxonItemmrp.SelectedItem.ToString().Equals("Y") ? true : false;
            objPurcModel.TaxInclusiveItemPrice = cbxTaxInclItemPrice.SelectedItem.ToString().Equals("Y") ? true : false;
            objPurcModel.CalculatedTax = Convert.ToDecimal(tbxCalculatedtax.Text.Trim() == string.Empty ? "0.00" : tbxCalculatedtax.Text.Trim());
            objPurcModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
            objPurcModel.AdjustTaxinSaleAccount = cbxAdTaxinSaleAmt.SelectedItem.ToString().Equals("Y") ? true : false;
            objPurcModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
            objPurcModel.TaxAccount = cbxTaxAccount.SelectedItem.ToString();
            //if Enable MultiTax Will Show on other Information Group
            //Region Radio Button GroupBox
            if (rbngrpRegion.SelectedIndex == 0)
            {
                objPurcModel.TypeLocal = true;
            }
            if (rbngrpRegion.SelectedIndex == 1)
            {
                objPurcModel.TypeCentral = true;
            }
            //Tax Calculation
            objPurcModel.SingleTaxRate = rbngrpTaxcalculation.SelectedIndex == 0 ? true : false;
            objPurcModel.MultiTaxRate = rbngrpTaxcalculation.SelectedIndex == 1 ? true : false;
            objPurcModel.TaxinPercentage = Convert.ToDecimal(tbxTaxPer.Text.Trim() == string.Empty ? "0.00" : tbxTaxPer.Text.Trim());
            objPurcModel.SurchargeInPercentage = Convert.ToDecimal(tbxSurchargePer.Text.Trim() == string.Empty ? "0.00" : tbxSurchargePer.Text.Trim());
            objPurcModel.freezeTaxinSales = cbxFreezeTaxinsale.SelectedItem.ToString().Equals("Y") ? true : false;
            objPurcModel.freezeTaxinSalesReturn = cbxFreezeTaxinSaleReturn.SelectedItem.ToString().Equals("Y") ? true : false;
            //Type of Transaction on Region GrupBox Sub
            objPurcModel.TypeStockTransfer = rbngrpTranction.SelectedIndex == 0 ? true : false;
            objPurcModel.ExportNormal = rbngrpTranction.SelectedIndex == 1 ? true : false;
            objPurcModel.SaleinTransit = rbngrpTranction.SelectedIndex == 2 ? true : false;
            objPurcModel.TypeOther = rbngrpTranction.SelectedIndex == 3 ? true : false;
            objPurcModel.ExportHighsea = rbngrpTranction.SelectedIndex == 4 ? true : false;
            // Form Information:if Enabl typeAgainstSTFrom
            objPurcModel.IssueSTFrom = cbxIssueSTform.SelectedItem.ToString().Equals("Y") ? true : false;
            objPurcModel.FromIssuable = cbxFormIssuable.SelectedItem.ToString();
            objPurcModel.ReceiveSTForm = cbxIssueSTform.SelectedItem.ToString().Equals("Y") ? true : false;
            objPurcModel.FromReceivable = cbxFormIssuable.SelectedItem.ToString();

            objPurcModel.InvoiceHeading = tbxInvoiceHeading.Text.Trim() == null ? string.Empty : tbxInvoiceHeading.Text.Trim();
            objPurcModel.InvoiceDescription = tbxInvoiceDescription.Text.Trim() == null ? string.Empty : tbxInvoiceDescription.Text.Trim();
            objPurcModel.Purch_Id = PurcId;
            bool isSuccess = objPurcBL.UpdatePurchasetype(objPurcModel);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                PurcId = 0;
                Administration.List.PurchaseList frmPurcList = new Administration.List.PurchaseList();
                frmPurcList.StartPosition = FormStartPosition.CenterParent;
                frmPurcList.ShowDialog();
                FillPurchaseTypeInfo();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objPurcBL.DeletePurchaseType(PurcId);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                PurcId = 0;
                Administration.List.PurchaseList frmPurcList = new Administration.List.PurchaseList();
                frmPurcList.StartPosition = FormStartPosition.CenterParent;
                frmPurcList.ShowDialog();
                FillPurchaseTypeInfo();
            }
        }

        private void ListPurcType_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.PurchaseList frmPurcList = new Administration.List.PurchaseList();
            frmPurcList.StartPosition = FormStartPosition.CenterParent;
            frmPurcList.ShowDialog();
            FillPurchaseTypeInfo();
        }
    }
}
