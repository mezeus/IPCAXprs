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
    public partial class SaleType : Form
    {
        SaleTypeModel objSaleModel = new SaleTypeModel();
        SaleTypeBL objSaleBL = new SaleTypeBL();
        AccountMasterBL objAccBl = new AccountMasterBL();
        public static int SalesId = 0;
        public static string FormName = "";
        public SaleType()
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
            if(keyData==Keys.F3)
            {
                if(cbxLedgerAccount.ContainsFocus)
                {
                    FormName = "IPCAUI.Administration.Account";
                }
                if(cbxTaxAccount.ContainsFocus)
                {
                    FormName = "IPCAUI.Administration.Account";
                }
                
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            objSaleModel = new SaleTypeModel();
            if (tbxSaleType.Text.Equals(string.Empty))
            {
                MessageBox.Show("Sales Type can not be blank!");
                tbxSaleType.Focus();
                return;
            }
            objSaleModel.SalesType = tbxSaleType.Text.Trim();
            //this GroupBox for sales Account Information of RadioButton        
            objSaleModel.typeSpecifyHereSingleAccount = rbngrpSalesAcInf.SelectedIndex == 0?true:false;
            if(objSaleModel.typeSpecifyHereSingleAccount)
            {
                objSaleModel.LedgerAccountBox = cbxLedgerAccount.Text.Trim() == null ? string.Empty : cbxLedgerAccount.Text.Trim();
            }
            objSaleModel.typeDifferentTaxRate= rbngrpSalesAcInf.SelectedIndex == 1?true:false;
            objSaleModel.typeSpecifyINVoucher = rbngrpSalesAcInf.SelectedIndex == 2?true:false;               
            //TaxationType: RadioButton Group
            if (rbngrpTaxation.SelectedIndex==0)
            {
                objSaleModel.typeTaxable = true;
            }
            if (rbngrpTaxation.SelectedIndex == 1)
            {
                objSaleModel.typeAgainstSTFrom = true;
            }
            if(rbngrpTaxation.SelectedIndex==2)
            {
                objSaleModel.typeExempt = true;
            }
            if (rbngrpTaxation.SelectedIndex == 3)
            {
                objSaleModel.typeLUMSumDealer = true;
            }
            if(rbngrpTaxation.SelectedIndex==4)
            {
                objSaleModel.typeMultiTax = true;
            }
            if(rbngrpTaxation.SelectedIndex==5)
            {
                objSaleModel.typeTaxpaid = true;
            }
            if(rbngrpTaxation.SelectedIndex==6)
            {
                objSaleModel.typeTaxFree = true;
            }
            if (rbngrpTaxation.SelectedIndex == 7)
            {
                objSaleModel.typeUnRegDealer = true;
            }
            //Region Radio Button GroupBox
            if (rbngrpRegion.SelectedIndex == 0)
            {
                objSaleModel.TypeLocal = true;
            }
            if (rbngrpRegion.SelectedIndex == 1)
            {
                objSaleModel.TypeCentral = true;
            }
            //other Information Group
            if (objSaleModel.typeTaxable)
            {
                if(objSaleModel.TypeLocal)
                {
                    objSaleModel.TaxInvoice = cbxTaxInvoiceyesno.SelectedItem.ToString().Equals("Y") ? true : false;
                }
                objSaleModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
                objSaleModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
            }
            if(objSaleModel.typeMultiTax)
            {
                if (objSaleModel.TypeLocal)
                {
                    objSaleModel.TaxInvoice = cbxTaxInvoiceyesno.SelectedItem.ToString().Equals("Y") ? true : false;
                }
                objSaleModel.CalculateTaxonItemMRP = cbxTaxonItemmrp.SelectedItem.ToString().Equals("Y") ? true : false;
                objSaleModel.TaxInclusiveItemPrice = cbxTaxInclItemPrice.SelectedItem.ToString().Equals("Y") ? true : false;
                objSaleModel.CalculatedTax = Convert.ToDecimal(tbxCalculatedtax.Text.Trim() == string.Empty ? "0.00" : tbxCalculatedtax.Text.Trim());
                objSaleModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
                objSaleModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
                objSaleModel.AdjustTaxinSaleAccount = cbxAdTaxinSaleAmt.SelectedItem.ToString().Equals("Y") ? true : false;
                if(objSaleModel.typeDifferentTaxRate == false)
                {
                    objSaleModel.TaxAccount = cbxTaxAccount.SelectedItem.ToString();
                }               
            }
            if(objSaleModel.typeAgainstSTFrom)
            {
                if (objSaleModel.TypeLocal)
                {
                    objSaleModel.TaxInvoice = cbxTaxInvoiceyesno.SelectedItem.ToString().Equals("Y") ? true : false;
                }
                objSaleModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
                objSaleModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
                if (objSaleModel.typeAgainstSTFrom)
                {
                    objSaleModel.IssueSTFrom = cbxIssueSTform.SelectedItem.ToString().Equals("Y") ? true : false;
                    if (objSaleModel.IssueSTFrom)
                    {
                        objSaleModel.FromIssuable = cbxFormIssuable.SelectedItem.ToString();
                    }
                    objSaleModel.ReceiveSTForm = cbxIssueSTform.SelectedItem.ToString().Equals("Y") ? true : false;
                    if (objSaleModel.IssueSTFrom)
                    {
                        objSaleModel.FromReceivable = cbxFormIssuable.SelectedItem.ToString();
                    }
                }
                objSaleModel.TaxinPercentage = Convert.ToDecimal(tbxTaxPer.Text.Trim() == string.Empty ? "0.00" : tbxTaxPer.Text.Trim());
                objSaleModel.SurchargeInPercentage = Convert.ToDecimal(tbxSurchargePer.Text.Trim() == string.Empty ? "0.00" : tbxSurchargePer.Text.Trim());
                objSaleModel.freezeTaxinSales = cbxFreezeTaxinsale.SelectedItem.ToString().Equals("Y") ? true : false;
                objSaleModel.freezeTaxinSalesReturn = cbxFreezeTaxinSaleReturn.SelectedItem.ToString().Equals("Y") ? true : false;
            }
            if(objSaleModel.typeTaxpaid||objSaleModel.typeExempt||objSaleModel.typeTaxFree)
            {
                objSaleModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
                objSaleModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
            }
            //if Enable MultiTax Will Show on other Information Group
            
            //Tax Calculation
            objSaleModel.SingleTaxRate = rbngrpTaxcalculation.SelectedIndex == 0 ? true : false;
            objSaleModel.MultiTaxRate = rbngrpTaxcalculation.SelectedIndex == 1? true : false;
            if(objSaleModel.SingleTaxRate)
            {
                objSaleModel.TaxinPercentage = Convert.ToDecimal(tbxTaxPer.Text.Trim() == string.Empty ? "0.00" : tbxTaxPer.Text.Trim());
                objSaleModel.SurchargeInPercentage = Convert.ToDecimal(tbxSurchargePer.Text.Trim() == string.Empty ? "0.00" : tbxSurchargePer.Text.Trim());
                objSaleModel.freezeTaxinSales = cbxFreezeTaxinsale.SelectedItem.ToString().Equals("Y") ? true : false;
                objSaleModel.freezeTaxinSalesReturn = cbxFreezeTaxinSaleReturn.SelectedItem.ToString().Equals("Y") ? true : false;
            }
            if(objSaleModel.MultiTaxRate)
            {
                if(objSaleModel.typeSpecifyHereSingleAccount)
                {
                    objSaleModel.servicesLedgerBox = cbxServicesAccLedger.SelectedItem.ToString();
                }
            }
            //Type of Transaction on Region GrupBox Sub
            objSaleModel.TypeStockTransfer = rbngrpTranction.SelectedIndex == 0 ? true : false;
            objSaleModel.ExportNormal = rbngrpTranction.SelectedIndex == 1 ? true : false;
            objSaleModel.SaleinTransit = rbngrpTranction.SelectedIndex == 2 ? true : false;
            objSaleModel.TypeOther = rbngrpTranction.SelectedIndex == 3? true : false;
            objSaleModel.ExportHighsea = rbngrpTranction.SelectedIndex == 4 ? true : false;          
            objSaleModel.InvoiceHeading = tbxInvoiceHeading.Text.Trim() == null ? string.Empty : tbxInvoiceHeading.Text.Trim();
            objSaleModel.InvoiceDescription = tbxInvoiceDescription.Text.Trim() == null ? string.Empty : tbxInvoiceDescription.Text.Trim();
            bool isSuccess = objSaleBL.SaveSalesType(objSaleModel);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                tbxSaleType.Focus();
            }

        }

        private void SaleType_Load(object sender, EventArgs e)
        {          
            tbxSaleType.Focus();
            DefaultloadForm();
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            cbxLedgerAccount.Properties.Items.Clear();
            List<AccountMasterModel> lstAccounts = objAccBl.GetListofAccount();
            foreach(AccountMasterModel objAccounts in lstAccounts)
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
            Administration.List.SalestypeList frmSaleList = new Administration.List.SalestypeList();
            frmSaleList.StartPosition = FormStartPosition.CenterParent;
            frmSaleList.ShowDialog();
            FillSalesTypeInfo();
        }
        private void FillSalesTypeInfo()
        {
            if(SalesId==0)
            {
                tbxSaleType.Focus();
                laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                return;
            }
            objSaleModel = objSaleBL.GetAllSaleTypeBySaleName(SalesId);
            tbxSaleType.Text=objSaleModel.SalesType.ToString();
            if(objSaleModel.typeSpecifyHereSingleAccount)
            {
                rbngrpSalesAcInf.SelectedIndex = 0;
            }
            cbxLedgerAccount.Text=objSaleModel.LedgerAccountBox.ToString();
            if(objSaleModel.typeDifferentTaxRate)
            {
                rbngrpSalesAcInf.SelectedIndex = 1;
            }
            if(objSaleModel.typeSpecifyINVoucher)
            {
                rbngrpSalesAcInf.SelectedIndex = 2;
            }
            if(objSaleModel.typeTaxable)
            {
                rbngrpTaxation.SelectedIndex = 0;
            }
            if(objSaleModel.typeAgainstSTFrom)
            {
                rbngrpTaxation.SelectedIndex = 1;
            }
            if (objSaleModel.typeExempt)
            {
                rbngrpTaxation.SelectedIndex = 2;
            }        
            if(objSaleModel.typeTaxpaid)
            {
                rbngrpTaxation.SelectedIndex = 5;
            }
            if (objSaleModel.typeMultiTax)
            {
                rbngrpTaxation.SelectedIndex = 4;
            }
            if(objSaleModel.typeTaxFree)
            {
                rbngrpTaxation.SelectedIndex = 6;
            }
            if(objSaleModel.typeLUMSumDealer)
            {
                rbngrpTaxation.SelectedIndex = 7;
            }
            if(objSaleModel.typeUnRegDealer)
            {
                rbngrpTaxation.SelectedIndex = 3;
            }
            cbxTaxInvoiceyesno.SelectedItem= (objSaleModel.TaxInvoice)?"Y":"N";
            cbxVatreturnCategory.SelectedItem= objSaleModel.VatReturnCategory.ToString();
            cbxVatorSalesTaxReports.SelectedItem= objSaleModel.SkipVatorSaleTaxReport ? "Y" : "N";
            cbxTaxonItemmrp.SelectedItem= objSaleModel.CalculateTaxonItemMRP ? "Y" : "N";
            cbxTaxInclItemPrice.SelectedItem= objSaleModel.TaxInclusiveItemPrice ? "Y" : "N";
            tbxCalculatedtax.Text= objSaleModel.CalculateTaxonpercentofAmount.ToString();
            cbxAdTaxinSaleAmt.SelectedItem= objSaleModel.AdjustTaxinSaleAccount ? "Y" : "N";
            cbxTaxAccount.SelectedItem= objSaleModel.TaxAccount.ToString();
            if(objSaleModel.TypeLocal)
            {
                rbngrpRegion.SelectedIndex = 0;
            }
            if (objSaleModel.TypeCentral)
            {
                rbngrpRegion.SelectedIndex = 1;
            }
            if(objSaleModel.TypeStockTransfer)
            {
                rbngrpTranction.SelectedIndex = 0;
            }
            if(objSaleModel.TypeOther)
            {
                rbngrpTranction.SelectedIndex = 3;
            }
            if(objSaleModel.ExportNormal)
            {
                rbngrpTranction.SelectedIndex = 1;
            }
            if(objSaleModel.SaleinTransit)
            {
                rbngrpTranction.SelectedIndex = 2;
            }
            if(objSaleModel.ExportHighsea)
            {
                rbngrpTranction.SelectedIndex = 4;
            }
            cbxIssueSTform.SelectedItem= objSaleModel.IssueSTFrom?"Y":"N";
            cbxFormIssuable.SelectedItem= objSaleModel.FromIssuable.ToString();
            cbxRecevieSTForm.SelectedItem= objSaleModel.ReceiveSTForm?"Y":"N";
            cbxFormReceviable.SelectedItem= objSaleModel.FromReceivable.ToString();
            if(objSaleModel.SingleTaxRate)
            {
                rbngrpTaxcalculation.SelectedIndex = 0;
            }
            if(objSaleModel.MultiTaxRate)
            {
                rbngrpTaxcalculation.SelectedIndex = 1;
            }
            tbxTaxPer.Text= objSaleModel.TaxinPercentage.ToString();
            tbxSurchargePer.Text= objSaleModel.SurchargeInPercentage .ToString();
            cbxFreezeTaxinsale.SelectedItem= objSaleModel.freezeTaxinSales?"Y":"N";
            cbxFreezeTaxinSaleReturn.SelectedItem= objSaleModel.freezeTaxinSalesReturn?"Y":"N";
            tbxInvoiceHeading.Text= objSaleModel.InvoiceHeading.ToString();
            tbxInvoiceDescription.Text= objSaleModel.InvoiceDescription.ToString();
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxSaleType.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            objSaleModel = new SaleTypeModel();
            objSaleModel.SalesType = tbxSaleType.Text.Trim();
            //this GroupBox for sales Account Information of RadioButton        
            objSaleModel.typeSpecifyHereSingleAccount = rbngrpSalesAcInf.SelectedIndex == 0 ? true : false;
            if (objSaleModel.typeSpecifyHereSingleAccount)
            {
                objSaleModel.LedgerAccountBox = cbxLedgerAccount.Text.Trim() == null ? string.Empty : cbxLedgerAccount.Text.Trim();
            }
            objSaleModel.typeDifferentTaxRate = rbngrpSalesAcInf.SelectedIndex == 1 ? true : false;
            objSaleModel.typeSpecifyINVoucher = rbngrpSalesAcInf.SelectedIndex == 2 ? true : false;
            //TaxationType: RadioButton Group
            if (rbngrpTaxation.SelectedIndex == 0)
            {
                objSaleModel.typeTaxable = true;
            }
            if (rbngrpTaxation.SelectedIndex == 1)
            {
                objSaleModel.typeAgainstSTFrom = true;
            }
            if (rbngrpTaxation.SelectedIndex == 2)
            {
                objSaleModel.typeExempt = true;
            }
            if (rbngrpTaxation.SelectedIndex == 3)
            {
                objSaleModel.typeLUMSumDealer = true;
            }
            if (rbngrpTaxation.SelectedIndex == 4)
            {
                objSaleModel.typeMultiTax = true;
            }
            if (rbngrpTaxation.SelectedIndex == 5)
            {
                objSaleModel.typeTaxpaid = true;
            }
            if (rbngrpTaxation.SelectedIndex == 6)
            {
                objSaleModel.typeTaxFree = true;
            }
            if (rbngrpTaxation.SelectedIndex == 7)
            {
                objSaleModel.typeUnRegDealer = true;
            }
            //Region Radio Button GroupBox
            if (rbngrpRegion.SelectedIndex == 0)
            {
                objSaleModel.TypeLocal = true;
            }
            if (rbngrpRegion.SelectedIndex == 1)
            {
                objSaleModel.TypeCentral = true;
            }
            //other Information Group
            if (objSaleModel.typeTaxable)
            {
                if (objSaleModel.TypeLocal)
                {
                    objSaleModel.TaxInvoice = cbxTaxInvoiceyesno.SelectedItem.ToString().Equals("Y") ? true : false;
                }
                objSaleModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
                objSaleModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
            }
            if (objSaleModel.typeMultiTax)
            {
                if (objSaleModel.TypeLocal)
                {
                    objSaleModel.TaxInvoice = cbxTaxInvoiceyesno.SelectedItem.ToString().Equals("Y") ? true : false;
                }
                objSaleModel.CalculateTaxonItemMRP = cbxTaxonItemmrp.SelectedItem.ToString().Equals("Y") ? true : false;
                objSaleModel.TaxInclusiveItemPrice = cbxTaxInclItemPrice.SelectedItem.ToString().Equals("Y") ? true : false;
                objSaleModel.CalculatedTax = Convert.ToDecimal(tbxCalculatedtax.Text.Trim() == string.Empty ? "0.00" : tbxCalculatedtax.Text.Trim());
                objSaleModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
                objSaleModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
                objSaleModel.AdjustTaxinSaleAccount = cbxAdTaxinSaleAmt.SelectedItem.ToString().Equals("Y") ? true : false;
                if (objSaleModel.typeDifferentTaxRate == false)
                {
                    objSaleModel.TaxAccount = cbxTaxAccount.SelectedItem.ToString();
                }
            }
            if (objSaleModel.typeAgainstSTFrom)
            {
                if (objSaleModel.TypeLocal)
                {
                    objSaleModel.TaxInvoice = cbxTaxInvoiceyesno.SelectedItem.ToString().Equals("Y") ? true : false;
                }
                objSaleModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
                objSaleModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
                if (objSaleModel.typeAgainstSTFrom)
                {
                    objSaleModel.IssueSTFrom = cbxIssueSTform.SelectedItem.ToString().Equals("Y") ? true : false;
                    if (objSaleModel.IssueSTFrom)
                    {
                        objSaleModel.FromIssuable = cbxFormIssuable.SelectedItem.ToString();
                    }
                    objSaleModel.ReceiveSTForm = cbxIssueSTform.SelectedItem.ToString().Equals("Y") ? true : false;
                    if (objSaleModel.IssueSTFrom)
                    {
                        objSaleModel.FromReceivable = cbxFormIssuable.SelectedItem.ToString();
                    }
                }
                objSaleModel.TaxinPercentage = Convert.ToDecimal(tbxTaxPer.Text.Trim() == string.Empty ? "0.00" : tbxTaxPer.Text.Trim());
                objSaleModel.SurchargeInPercentage = Convert.ToDecimal(tbxSurchargePer.Text.Trim() == string.Empty ? "0.00" : tbxSurchargePer.Text.Trim());
                objSaleModel.freezeTaxinSales = cbxFreezeTaxinsale.SelectedItem.ToString().Equals("Y") ? true : false;
                objSaleModel.freezeTaxinSalesReturn = cbxFreezeTaxinSaleReturn.SelectedItem.ToString().Equals("Y") ? true : false;
            }
            if (objSaleModel.typeTaxpaid || objSaleModel.typeExempt || objSaleModel.typeTaxFree)
            {
                objSaleModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
                objSaleModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
            }
            //if Enable MultiTax Will Show on other Information Group

            //Tax Calculation
            objSaleModel.SingleTaxRate = rbngrpTaxcalculation.SelectedIndex == 0 ? true : false;
            objSaleModel.MultiTaxRate = rbngrpTaxcalculation.SelectedIndex == 1 ? true : false;
            if (objSaleModel.SingleTaxRate)
            {
                objSaleModel.TaxinPercentage = Convert.ToDecimal(tbxTaxPer.Text.Trim() == string.Empty ? "0.00" : tbxTaxPer.Text.Trim());
                objSaleModel.SurchargeInPercentage = Convert.ToDecimal(tbxSurchargePer.Text.Trim() == string.Empty ? "0.00" : tbxSurchargePer.Text.Trim());
                objSaleModel.freezeTaxinSales = cbxFreezeTaxinsale.SelectedItem.ToString().Equals("Y") ? true : false;
                objSaleModel.freezeTaxinSalesReturn = cbxFreezeTaxinSaleReturn.SelectedItem.ToString().Equals("Y") ? true : false;
            }
            if (objSaleModel.MultiTaxRate)
            {
                if (objSaleModel.typeSpecifyHereSingleAccount)
                {
                    objSaleModel.servicesLedgerBox = cbxServicesAccLedger.SelectedItem.ToString();
                }
            }
            //Type of Transaction on Region GrupBox Sub
            objSaleModel.TypeStockTransfer = rbngrpTranction.SelectedIndex == 0 ? true : false;
            objSaleModel.ExportNormal = rbngrpTranction.SelectedIndex == 1 ? true : false;
            objSaleModel.SaleinTransit = rbngrpTranction.SelectedIndex == 2 ? true : false;
            objSaleModel.TypeOther = rbngrpTranction.SelectedIndex == 3 ? true : false;
            objSaleModel.ExportHighsea = rbngrpTranction.SelectedIndex == 4 ? true : false;
            objSaleModel.InvoiceHeading = tbxInvoiceHeading.Text.Trim() == null ? string.Empty : tbxInvoiceHeading.Text.Trim();
            objSaleModel.InvoiceDescription = tbxInvoiceDescription.Text.Trim() == null ? string.Empty : tbxInvoiceDescription.Text.Trim();
            objSaleModel.Sale_Id = SalesId;
            bool isSuccess = objSaleBL.UpdateSalestype(objSaleModel);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                SalesId = 0;
                Administration.List.SalestypeList frmSaleList = new Administration.List.SalestypeList();
                frmSaleList.StartPosition = FormStartPosition.CenterParent;
                frmSaleList.ShowDialog();
                FillSalesTypeInfo();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objSaleBL.DeleteSaleType(SalesId);
             if(isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                SalesId = 0;
                Administration.List.SalestypeList frmSaleList = new Administration.List.SalestypeList();
                frmSaleList.StartPosition = FormStartPosition.CenterParent;
                frmSaleList.ShowDialog();
                FillSalesTypeInfo();
            }
        }

        private void rbngrpSalesAcInf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rbngrpSalesAcInf.SelectedIndex==0)
            {
                lactrlLedgerAccount.Visibility= DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                if(rbngrpTaxcalculation.SelectedIndex==1)
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
           if(rbngrpSalesAcInf.SelectedIndex==1)
            {
                btnConfiguration.Enabled = true;
                if(rbngrpTaxation.SelectedIndex==4)
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

        private void tbxSaleType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxSaleType.Text.Trim() == "")
                {
                    MessageBox.Show("Sale Type Can Not Be Blank!");
                    tbxSaleType.Focus();
                    return;
                }
                if (objSaleBL.IsSaleTypeExists(tbxSaleType.Text.Trim()))
                {
                    MessageBox.Show("Sale Type already Exists!");
                    tbxSaleType.Focus();
                    return;
                }
                e.Handled = true;
            }
        }

        private void cbxLedgerAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            cbxLedgerAccount.Properties.Items.Clear();
            List<AccountMasterModel> lstAccounts = objAccBl.GetListofAccount();
            foreach (AccountMasterModel objAccounts in lstAccounts)
            {
                cbxLedgerAccount.Properties.Items.Add(objAccounts.AccountName);
            }
        }

        private void cbxLedgerAccount_Enter(object sender, EventArgs e)
        {
            cbxLedgerAccount.ShowPopup();
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

        private void rbngrpRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbngrpRegion.SelectedIndex==0)
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

        private void rbngrpTaxcalculation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rbngrpTaxcalculation.SelectedIndex==0)
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
                if(rbngrpSalesAcInf.SelectedIndex==0)
                {
                    lactrlGoods.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lactrlServices.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lactrlServicesCombo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }             
            }
        }

        private void rbngrpTaxation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rbngrpTaxation.SelectedIndex==0)
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
                if (rbngrpRegion.SelectedIndex==1)
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
            if(rbngrpTaxation.SelectedIndex == 1)
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
            if(rbngrpTaxation.SelectedIndex == 5)
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
            if(rbngrpTaxation.SelectedIndex == 2)
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

        private void cbxIssueSTform_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbxIssueSTform.SelectedItem.ToString()=="Y")
            {
                lactrlFormIssuable.Enabled = true;
            }
            else
            {
                lactrlFormIssuable.Enabled = false;
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

        private void cbxRecevieSTForm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbxTaxAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            cbxTaxAccount.Properties.Items.Clear();
            List<AccountMasterModel> lstAccounts = objAccBl.GetListofAccount();
            foreach (AccountMasterModel objAccounts in lstAccounts)
            {
                cbxTaxAccount.Properties.Items.Add(objAccounts.AccountName);
            }
        }

        private void cbxTaxAccount_Enter(object sender, EventArgs e)
        {
            cbxTaxAccount.ShowPopup();
        }

        private void cbxServicesAccLedger_KeyPress(object sender, KeyPressEventArgs e)
        {
            cbxServicesAccLedger.Properties.Items.Clear();
            List<AccountMasterModel> lstAccounts = objAccBl.GetListofAccount();
            foreach (AccountMasterModel objAccounts in lstAccounts)
            {
                cbxServicesAccLedger.Properties.Items.Add(objAccounts.AccountName);
            }
        }
    }
}
