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
        AccountMasterBL objAccBl = new AccountMasterBL();
        public static int PurcId = 0;
        public static string FormName = "";
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
            if (keyData == Keys.F3)
            {
                if (cbxLedgerAccount.ContainsFocus)
                {
                    FormName = "IPCAUI.Administration.Account";
                }
                if (cbxTaxAccount.ContainsFocus)
                {
                    FormName = "IPCAUI.Administration.Account";
                }

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            objPurcModel = new PurchaseTypeModel();
            if (tbxPurcahseType.Text.Equals(string.Empty))
            {
                MessageBox.Show("Sales Type can not be blank!");
                tbxPurcahseType.Focus();
                return;
            }
            objPurcModel.PurchType = tbxPurcahseType.Text.Trim();
            //this GroupBox for sales Account Information of RadioButton        
            objPurcModel.typeSpecifyHereSingleAccount = rbngrpSalesAcInf.SelectedIndex == 0 ? true : false;
            if (objPurcModel.typeSpecifyHereSingleAccount)
            {
                objPurcModel.LedgerAccountBox = cbxLedgerAccount.Text.Trim() == null ? string.Empty : cbxLedgerAccount.Text.Trim();
            }
            objPurcModel.typeDifferentTaxRate = rbngrpSalesAcInf.SelectedIndex == 1 ? true : false;
            objPurcModel.typeSpecifyINVoucher = rbngrpSalesAcInf.SelectedIndex == 2 ? true : false;
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
            //Region Radio Button GroupBox
            if (rbngrpRegion.SelectedIndex == 0)
            {
                objPurcModel.TypeLocal = true;
            }
            if (rbngrpRegion.SelectedIndex == 1)
            {
                objPurcModel.TypeCentral = true;
            }
            //other Information Group
            if (objPurcModel.typeTaxable)
            {
                if (objPurcModel.TypeLocal)
                {
                    objPurcModel.TaxInvoice = cbxTaxInvoiceyesno.SelectedItem.ToString().Equals("Y") ? true : false;
                }
                objPurcModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
                objPurcModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
            }
            if (objPurcModel.typeMultiTax)
            {
                if (objPurcModel.TypeLocal)
                {
                    objPurcModel.TaxInvoice = cbxTaxInvoiceyesno.SelectedItem.ToString().Equals("Y") ? true : false;
                }
                objPurcModel.CalculateTaxonItemMRP = cbxTaxonItemmrp.SelectedItem.ToString().Equals("Y") ? true : false;
                objPurcModel.TaxInclusiveItemPrice = cbxTaxInclItemPrice.SelectedItem.ToString().Equals("Y") ? true : false;
                objPurcModel.CalculatedTax = Convert.ToDecimal(tbxCalculatedtax.Text.Trim() == string.Empty ? "0.00" : tbxCalculatedtax.Text.Trim());
                objPurcModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
                objPurcModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
                objPurcModel.AdjustTaxinSaleAccount = cbxAdTaxinSaleAmt.SelectedItem.ToString().Equals("Y") ? true : false;
                if (objPurcModel.typeDifferentTaxRate == false)
                {
                    objPurcModel.TaxAccount = cbxTaxAccount.SelectedItem.ToString();
                }
            }
            if (objPurcModel.typeAgainstSTFrom)
            {
                if (objPurcModel.TypeLocal)
                {
                    objPurcModel.TaxInvoice = cbxTaxInvoiceyesno.SelectedItem.ToString().Equals("Y") ? true : false;
                }
                objPurcModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
                objPurcModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
                if (objPurcModel.typeAgainstSTFrom)
                {
                    objPurcModel.IssueSTFrom = cbxIssueSTform.SelectedItem.ToString().Equals("Y") ? true : false;
                    if (objPurcModel.IssueSTFrom)
                    {
                        objPurcModel.FromIssuable = cbxFormIssuable.SelectedItem.ToString();
                    }
                    objPurcModel.ReceiveSTForm = cbxIssueSTform.SelectedItem.ToString().Equals("Y") ? true : false;
                    if (objPurcModel.IssueSTFrom)
                    {
                        objPurcModel.FromReceivable = cbxFormIssuable.SelectedItem.ToString();
                    }
                }
                objPurcModel.TaxinPercentage = Convert.ToDecimal(tbxTaxPer.Text.Trim() == string.Empty ? "0.00" : tbxTaxPer.Text.Trim());
                objPurcModel.SurchargeInPercentage = Convert.ToDecimal(tbxSurchargePer.Text.Trim() == string.Empty ? "0.00" : tbxSurchargePer.Text.Trim());
                objPurcModel.freezeTaxinSales = cbxFreezeTaxinsale.SelectedItem.ToString().Equals("Y") ? true : false;
                objPurcModel.freezeTaxinSalesReturn = cbxFreezeTaxinSaleReturn.SelectedItem.ToString().Equals("Y") ? true : false;
            }
            if (objPurcModel.typeTaxpaid || objPurcModel.typeExempt || objPurcModel.typeTaxFree)
            {
                objPurcModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
                objPurcModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
            }
            //if Enable MultiTax Will Show on other Information Group

            //Tax Calculation
            objPurcModel.SingleTaxRate = rbngrpTaxcalculation.SelectedIndex == 0 ? true : false;
            objPurcModel.MultiTaxRate = rbngrpTaxcalculation.SelectedIndex == 1 ? true : false;
            if (objPurcModel.SingleTaxRate)
            {
                objPurcModel.TaxinPercentage = Convert.ToDecimal(tbxTaxPer.Text.Trim() == string.Empty ? "0.00" : tbxTaxPer.Text.Trim());
                objPurcModel.SurchargeInPercentage = Convert.ToDecimal(tbxSurchargePer.Text.Trim() == string.Empty ? "0.00" : tbxSurchargePer.Text.Trim());
                objPurcModel.freezeTaxinSales = cbxFreezeTaxinsale.SelectedItem.ToString().Equals("Y") ? true : false;
                objPurcModel.freezeTaxinSalesReturn = cbxFreezeTaxinSaleReturn.SelectedItem.ToString().Equals("Y") ? true : false;
            }
            if (objPurcModel.MultiTaxRate)
            {
                if (objPurcModel.typeSpecifyHereSingleAccount)
                {
                    objPurcModel.servicesLedgerBox = cbxServicesAccLedger.SelectedItem.ToString();
                }
            }
            //Type of Transaction on Region GrupBox Sub
            objPurcModel.TypeStockTransfer = rbngrpTranction.SelectedIndex == 0 ? true : false;
            objPurcModel.ExportNormal = rbngrpTranction.SelectedIndex == 1 ? true : false;
            objPurcModel.SaleinTransit = rbngrpTranction.SelectedIndex == 2 ? true : false;
            objPurcModel.TypeOther = rbngrpTranction.SelectedIndex == 3 ? true : false;
            objPurcModel.ExportHighsea = rbngrpTranction.SelectedIndex == 4 ? true : false;
            objPurcModel.InvoiceHeading = tbxInvoiceHeading.Text.Trim() == null ? string.Empty : tbxInvoiceHeading.Text.Trim();
            objPurcModel.InvoiceDescription = tbxInvoiceDescription.Text.Trim() == null ? string.Empty : tbxInvoiceDescription.Text.Trim();
            bool isSuccess = objPurcBL.SavePurchaseType(objPurcModel);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                tbxPurcahseType.Focus();
            }

        }

        private void PurchaseType_Load(object sender, EventArgs e)
        {
            tbxPurcahseType.Focus();
            DefaultloadForm();
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            cbxLedgerAccount.Properties.Items.Clear();
            List<AccountMasterModel> lstAccounts = objAccBl.GetListofAccount();
            foreach (AccountMasterModel objAccounts in lstAccounts)
            {
                cbxLedgerAccount.Properties.Items.Add(objAccounts.AccountName);
            }
            if (rbngrpRegion.SelectedIndex == 0)
            {
                rbngrpTranction.Properties.Items[1].Enabled = false;
                rbngrpTranction.Properties.Items[2].Enabled = false;
                rbngrpTranction.Properties.Items[4].Enabled = false;
            }
            else
            {
                rbngrpTranction.Properties.Items[1].Enabled = true;
                rbngrpTranction.Properties.Items[2].Enabled = true;
                rbngrpTranction.Properties.Items[4].Enabled = true;
            }
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
            cbxLedgerAccount.Text=objPurcModel.LedgerAccountBox.ToString();
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
            if (objPurcModel.typeSpecifyHereSingleAccount)
            {
                objPurcModel.LedgerAccountBox = cbxLedgerAccount.Text.Trim() == null ? string.Empty : cbxLedgerAccount.Text.Trim();
            }
            objPurcModel.typeDifferentTaxRate = rbngrpSalesAcInf.SelectedIndex == 1 ? true : false;
            objPurcModel.typeSpecifyINVoucher = rbngrpSalesAcInf.SelectedIndex == 2 ? true : false;
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
            //Region Radio Button GroupBox
            if (rbngrpRegion.SelectedIndex == 0)
            {
                objPurcModel.TypeLocal = true;
            }
            if (rbngrpRegion.SelectedIndex == 1)
            {
                objPurcModel.TypeCentral = true;
            }
            //other Information Group
            if (objPurcModel.typeTaxable)
            {
                if (objPurcModel.TypeLocal)
                {
                    objPurcModel.TaxInvoice = cbxTaxInvoiceyesno.SelectedItem.ToString().Equals("Y") ? true : false;
                }
                objPurcModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
                objPurcModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
            }
            if (objPurcModel.typeMultiTax)
            {
                if (objPurcModel.TypeLocal)
                {
                    objPurcModel.TaxInvoice = cbxTaxInvoiceyesno.SelectedItem.ToString().Equals("Y") ? true : false;
                }
                objPurcModel.CalculateTaxonItemMRP = cbxTaxonItemmrp.SelectedItem.ToString().Equals("Y") ? true : false;
                objPurcModel.TaxInclusiveItemPrice = cbxTaxInclItemPrice.SelectedItem.ToString().Equals("Y") ? true : false;
                objPurcModel.CalculatedTax = Convert.ToDecimal(tbxCalculatedtax.Text.Trim() == string.Empty ? "0.00" : tbxCalculatedtax.Text.Trim());
                objPurcModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
                objPurcModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
                objPurcModel.AdjustTaxinSaleAccount = cbxAdTaxinSaleAmt.SelectedItem.ToString().Equals("Y") ? true : false;
                if (objPurcModel.typeDifferentTaxRate == false)
                {
                    objPurcModel.TaxAccount = cbxTaxAccount.SelectedItem.ToString();
                }
            }
            if (objPurcModel.typeAgainstSTFrom)
            {
                if (objPurcModel.TypeLocal)
                {
                    objPurcModel.TaxInvoice = cbxTaxInvoiceyesno.SelectedItem.ToString().Equals("Y") ? true : false;
                }
                objPurcModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
                objPurcModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
                if (objPurcModel.typeAgainstSTFrom)
                {
                    objPurcModel.IssueSTFrom = cbxIssueSTform.SelectedItem.ToString().Equals("Y") ? true : false;
                    if (objPurcModel.IssueSTFrom)
                    {
                        objPurcModel.FromIssuable = cbxFormIssuable.SelectedItem.ToString();
                    }
                    objPurcModel.ReceiveSTForm = cbxIssueSTform.SelectedItem.ToString().Equals("Y") ? true : false;
                    if (objPurcModel.IssueSTFrom)
                    {
                        objPurcModel.FromReceivable = cbxFormIssuable.SelectedItem.ToString();
                    }
                }
                objPurcModel.TaxinPercentage = Convert.ToDecimal(tbxTaxPer.Text.Trim() == string.Empty ? "0.00" : tbxTaxPer.Text.Trim());
                objPurcModel.SurchargeInPercentage = Convert.ToDecimal(tbxSurchargePer.Text.Trim() == string.Empty ? "0.00" : tbxSurchargePer.Text.Trim());
                objPurcModel.freezeTaxinSales = cbxFreezeTaxinsale.SelectedItem.ToString().Equals("Y") ? true : false;
                objPurcModel.freezeTaxinSalesReturn = cbxFreezeTaxinSaleReturn.SelectedItem.ToString().Equals("Y") ? true : false;
            }
            if (objPurcModel.typeTaxpaid || objPurcModel.typeExempt || objPurcModel.typeTaxFree)
            {
                objPurcModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
                objPurcModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
            }
            //if Enable MultiTax Will Show on other Information Group

            //Tax Calculation
            objPurcModel.SingleTaxRate = rbngrpTaxcalculation.SelectedIndex == 0 ? true : false;
            objPurcModel.MultiTaxRate = rbngrpTaxcalculation.SelectedIndex == 1 ? true : false;
            if (objPurcModel.SingleTaxRate)
            {
                objPurcModel.TaxinPercentage = Convert.ToDecimal(tbxTaxPer.Text.Trim() == string.Empty ? "0.00" : tbxTaxPer.Text.Trim());
                objPurcModel.SurchargeInPercentage = Convert.ToDecimal(tbxSurchargePer.Text.Trim() == string.Empty ? "0.00" : tbxSurchargePer.Text.Trim());
                objPurcModel.freezeTaxinSales = cbxFreezeTaxinsale.SelectedItem.ToString().Equals("Y") ? true : false;
                objPurcModel.freezeTaxinSalesReturn = cbxFreezeTaxinSaleReturn.SelectedItem.ToString().Equals("Y") ? true : false;
            }
            if (objPurcModel.MultiTaxRate)
            {
                if (objPurcModel.typeSpecifyHereSingleAccount)
                {
                    objPurcModel.servicesLedgerBox = cbxServicesAccLedger.SelectedItem.ToString();
                }
            }
            //Type of Transaction on Region GrupBox Sub
            objPurcModel.TypeStockTransfer = rbngrpTranction.SelectedIndex == 0 ? true : false;
            objPurcModel.ExportNormal = rbngrpTranction.SelectedIndex == 1 ? true : false;
            objPurcModel.SaleinTransit = rbngrpTranction.SelectedIndex == 2 ? true : false;
            objPurcModel.TypeOther = rbngrpTranction.SelectedIndex == 3 ? true : false;
            objPurcModel.ExportHighsea = rbngrpTranction.SelectedIndex == 4 ? true : false;
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

        private void rbngrpSalesAcInf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbngrpSalesAcInf.SelectedIndex == 0)
            {
                lactrlLedgerAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                if (rbngrpTaxcalculation.SelectedIndex == 1)
                {
                    lactrlGoods.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lactrlServices.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lactrlServicesCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
            }
            else
            {
                lactrlLedgerAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlGoods.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlServices.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlServicesCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            }
            if (rbngrpSalesAcInf.SelectedIndex == 1)
            {
                btnConfiguration.Enabled = true;
                if (rbngrpTaxation.SelectedIndex == 4)
                {
                    lactrlTaxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                }
            }
            else
            {
                btnConfiguration.Enabled = false;
                lactrlTaxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        private void rbngrpTaxation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbngrpTaxation.SelectedIndex == 0)
            {
                lactrlCaluclatTaxonMRP.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlTaxInclItemPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlCalculatedTaxOn.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlTaxinSaleAmount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlTaxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlgrpTaxcalculation.Enabled = true;
                lactrlTaxInvoice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                rbngrpSalesAcInf.Properties.Items[1].Enabled = false;
                lactrlGrpFormInfo.Enabled = false;
                rbngrpTaxcalculation.Properties.Items[0].Enabled = true;
                rbngrpTaxcalculation.Properties.Items[1].Enabled = true;
                rbngrpSalesAcInf.Properties.Items[1].Enabled = false;
                if (rbngrpRegion.SelectedIndex == 1)
                {
                    lactrlTaxInvoice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                }
            }
            if (rbngrpTaxation.SelectedIndex == 4)
            {
                rbngrpSalesAcInf.Properties.Items[1].Enabled = true;
                lactrlTaxInvoice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lactrlCaluclatTaxonMRP.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lactrlTaxInclItemPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lactrlCalculatedTaxOn.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lactrlTaxinSaleAmount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lactrlTaxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                rbngrpTaxcalculation.SelectedIndex = -1;
                lactrlgrpTaxcalculation.Enabled = false;
                lactrlGrpFormInfo.Enabled = false;
                if (rbngrpRegion.SelectedIndex == 1)
                {
                    lactrlTaxInvoice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                }
            }
            if (rbngrpTaxation.SelectedIndex == 1)
            {
                rbngrpSalesAcInf.Properties.Items[1].Enabled = false;
                lactrlTaxInvoice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lactrlCaluclatTaxonMRP.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlTaxInclItemPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlCalculatedTaxOn.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlTaxinSaleAmount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlTaxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlGrpFormInfo.Enabled = true;
                rbngrpTaxcalculation.SelectedIndex = -1;
                lactrlgrpTaxcalculation.Enabled = true;
                rbngrpTaxcalculation.Properties.Items[0].Enabled = false;
                rbngrpTaxcalculation.Properties.Items[1].Enabled = false;
                lactrlTaxPer.Enabled = true;
                lactrlSurchargePer.Enabled = false;
                lactrlFreezeTaxSales.Enabled = true;
                lactrlFreezeTaxSalesReturn.Enabled = true;
                if (rbngrpRegion.SelectedIndex == 1)
                {
                    lactrlTaxInvoice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                }
            }
            if (rbngrpTaxation.SelectedIndex == 5)
            {
                rbngrpSalesAcInf.Properties.Items[1].Enabled = false;
                lactrlTaxInvoice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlCaluclatTaxonMRP.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlTaxInclItemPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlCalculatedTaxOn.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlTaxinSaleAmount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlTaxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlGrpFormInfo.Enabled = false;
                rbngrpTaxcalculation.SelectedIndex = -1;
                lactrlgrpTaxcalculation.Enabled = false;
            }
            if (rbngrpTaxation.SelectedIndex == 2)
            {
                rbngrpSalesAcInf.Properties.Items[1].Enabled = false;
                lactrlTaxInvoice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlCaluclatTaxonMRP.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlTaxInclItemPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlCalculatedTaxOn.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlTaxinSaleAmount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlTaxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlGrpFormInfo.Enabled = false;
                rbngrpTaxcalculation.SelectedIndex = -1;
                lactrlgrpTaxcalculation.Enabled = false;
            }
            if (rbngrpTaxation.SelectedIndex == 6)
            {
                rbngrpSalesAcInf.Properties.Items[1].Enabled = false;
                lactrlTaxInvoice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlCaluclatTaxonMRP.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlTaxInclItemPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlCalculatedTaxOn.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlTaxinSaleAmount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlTaxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                rbngrpTaxcalculation.SelectedIndex = -1;
                lactrlGrpFormInfo.Enabled = false;
                lactrlgrpTaxcalculation.Enabled = false;
            }
        }

        private void rbngrpRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbngrpRegion.SelectedIndex == 0)
            {
                rbngrpTranction.Properties.Items[1].Enabled = false;
                rbngrpTranction.Properties.Items[2].Enabled = false;
                rbngrpTranction.Properties.Items[4].Enabled = false;
                if (rbngrpTaxation.SelectedIndex == 0 || rbngrpTaxation.SelectedIndex == 1 || rbngrpTaxation.SelectedIndex == 4)
                {
                    lactrlTaxInvoice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
            }
            else
            {
                rbngrpTranction.Properties.Items[1].Enabled = true;
                rbngrpTranction.Properties.Items[2].Enabled = true;
                rbngrpTranction.Properties.Items[4].Enabled = true;
                if (rbngrpTaxation.SelectedIndex == 0 || rbngrpTaxation.SelectedIndex == 1 || rbngrpTaxation.SelectedIndex == 4)
                {
                    lactrlTaxInvoice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                }
            }
        }

        private void cbxIssueSTform_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxIssueSTform.SelectedItem.ToString() == "Y")
            {
                lactrlFormIssuable.Enabled = true;
            }
            else
            {
                lactrlFormIssuable.Enabled = false;
            }
        }

        private void cbxRecevieSTForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRecevieSTForm.SelectedItem.ToString() == "Y")
            {
                lactrlFormReceviable.Enabled = true;
            }
            else
            {
                lactrlFormReceviable.Enabled = false;
            }
        }
        private void DefaultloadForm()
        {
            rbngrpSalesAcInf.Properties.Items[1].Enabled = false;
            cbxTaxInvoiceyesno.SelectedIndex = 0;
            cbxTaxonItemmrp.SelectedIndex = 1;
            cbxTaxInclItemPrice.SelectedIndex = 1;
            cbxAdTaxinSaleAmt.SelectedIndex = 1;
            cbxVatorSalesTaxReports.SelectedIndex = 1;
            cbxIssueSTform.SelectedIndex = 1;
            cbxRecevieSTForm.SelectedIndex = 1;
            cbxFreezeTaxinsale.SelectedItem = 1;
            cbxFreezeTaxinSaleReturn.SelectedItem = 1;
            btnConfiguration.Enabled = false;
            rbngrpTaxation.Properties.Items[3].Enabled = false;
            rbngrpTaxation.Properties.Items[7].Enabled = false;
            lactrlCaluclatTaxonMRP.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlCalculatedTaxOn.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlTaxInclItemPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlTaxinSaleAmount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlTaxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlGrpFormInfo.Enabled = false;
            lactrlGoods.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlServices.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlServicesCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            if (rbngrpTaxcalculation.SelectedIndex == 0)
            {
                lactrlTaxPer.Enabled = true;
                lactrlSurchargePer.Enabled = false;
                lactrlFreezeTaxSales.Enabled = true;
                lactrlFreezeTaxSalesReturn.Enabled = true;
            }
            else
            {
                lactrlTaxPer.Enabled = false;
                lactrlSurchargePer.Enabled = false;
                lactrlFreezeTaxSales.Enabled = false;
                lactrlFreezeTaxSalesReturn.Enabled = false;
            }
            cbxTaxAccount.Properties.Items.Clear();
            cbxServicesAccLedger.Properties.Items.Clear();
            List<AccountMasterModel> lstAccounts = objAccBl.GetListofAccount();
            foreach (AccountMasterModel objAccounts in lstAccounts)
            {
                cbxTaxAccount.Properties.Items.Add(objAccounts.AccountName);
                cbxServicesAccLedger.Properties.Items.Add(objAccounts.AccountName);
            }
        }

        private void rbngrpTaxcalculation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbngrpTaxcalculation.SelectedIndex == 0)
            {
                lactrlTaxPer.Enabled = true;
                lactrlSurchargePer.Enabled = false;
                lactrlFreezeTaxSales.Enabled = true;
                lactrlFreezeTaxSalesReturn.Enabled = true;
                rbngrpSalesAcInf.Properties.Items[1].Enabled = true;
                lactrlGoods.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlServices.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlServicesCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            }
            else
            {
                lactrlTaxPer.Enabled = false;
                lactrlSurchargePer.Enabled = false;
                lactrlFreezeTaxSales.Enabled = false;
                lactrlFreezeTaxSalesReturn.Enabled = false;
                if (rbngrpSalesAcInf.SelectedIndex == 0)
                {
                    lactrlGoods.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lactrlServices.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lactrlServicesCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
            }
        }

        private void tbxPurcahseType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxPurcahseType.Text.Trim() == "")
                {
                    MessageBox.Show("Purchase Type Can Not Be Blank!");
                    tbxPurcahseType.Focus();
                    return;
                }
                if (objPurcBL.IsPurchaseTypeExists(tbxPurcahseType.Text.Trim()))
                {
                    MessageBox.Show("Purchase Type already Exists!");
                    tbxPurcahseType.Focus();
                    return;
                }
                e.Handled = true;
            }
        }
    }
}
