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
        public static int SalesId = 0;
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
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxSaleType.Text.Equals(string.Empty))
            {
                MessageBox.Show("Sales Type can not be blank!");
                tbxSaleType.Focus();
                return;
            }
            objSaleModel.SalesType = tbxSaleType.Text.Trim();
            //this GroupBox for sales Account Information of RadioButton
          
                objSaleModel.typeSpecifyHereSingleAccount = rbngrpSalesAcInf.SelectedIndex == 0?true:false;
                objSaleModel.typeDifferentTaxRate= rbngrpSalesAcInf.SelectedIndex == 1?true:false;
                objSaleModel.typeSpecifyINVoucher = rbngrpSalesAcInf.SelectedIndex == 2?true:false;
                objSaleModel.LedgerAccountBox = cbxLedgerAccount.Text.Trim() == null ? string.Empty : cbxLedgerAccount.Text.Trim();
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
            // other Information Group
            objSaleModel.TaxInvoice = cbxTaxInvoiceyesno.SelectedItem.ToString().Equals("Y") ? true : false;
            objSaleModel.CalculateTaxonItemMRP = cbxTaxonItemmrp.SelectedItem.ToString().Equals("Y") ? true : false;
            objSaleModel.TaxInclusiveItemPrice = cbxTaxInclItemPrice.SelectedItem.ToString().Equals("Y") ? true : false;
            objSaleModel.CalculatedTax = Convert.ToDecimal(tbxCalculatedtax.Text.Trim() == string.Empty ? "0.00" : tbxCalculatedtax.Text.Trim());
            objSaleModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
            objSaleModel.AdjustTaxinSaleAccount = cbxAdTaxinSaleAmt.SelectedItem.ToString().Equals("Y") ? true : false;
            objSaleModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
            objSaleModel.TaxAccount = cbxTaxAccount.SelectedItem.ToString();
            //if Enable MultiTax Will Show on other Information Group
            //Region Radio Button GroupBox
            if(rbngrpRegion.SelectedIndex==0)
            {
                objSaleModel.TypeLocal = true;
            }
            if (rbngrpRegion.SelectedIndex == 1)
            {
                objSaleModel.TypeCentral = true;
            }
            //Tax Calculation
            objSaleModel.SingleTaxRate = rbngrpTaxcalculation.SelectedIndex == 0 ? true : false;
            objSaleModel.MultiTaxRate = rbngrpTaxcalculation.SelectedIndex == 1? true : false;
            objSaleModel.TaxinPercentage = Convert.ToDecimal(tbxTaxPer.Text.Trim() == string.Empty ? "0.00" : tbxTaxPer.Text.Trim());
            objSaleModel.SurchargeInPercentage = Convert.ToDecimal(tbxSurchargePer.Text.Trim() == string.Empty ? "0.00" : tbxSurchargePer.Text.Trim());
            objSaleModel.freezeTaxinSales = cbxFreezeTaxinsale.SelectedItem.ToString().Equals("Y") ? true : false;
            objSaleModel.freezeTaxinSalesReturn = cbxFreezeTaxinSaleReturn.SelectedItem.ToString().Equals("Y") ? true : false;
            //Type of Transaction on Region GrupBox Sub
            objSaleModel.TypeStockTransfer = rbngrpTranction.SelectedIndex == 0 ? true : false;
            objSaleModel.ExportNormal = rbngrpTranction.SelectedIndex == 1 ? true : false;
            objSaleModel.SaleinTransit = rbngrpTranction.SelectedIndex == 2 ? true : false;
            objSaleModel.TypeOther = rbngrpTranction.SelectedIndex == 3? true : false;
            objSaleModel.ExportHighsea = rbngrpTranction.SelectedIndex == 4 ? true : false;
            // Form Information:if Enabl typeAgainstSTFrom
            objSaleModel.IssueSTFrom = cbxIssueSTform.SelectedItem.ToString().Equals("Y") ? true : false;
            objSaleModel.FromIssuable = cbxFormIssuable.SelectedItem.ToString();
            objSaleModel.ReceiveSTForm = cbxIssueSTform.SelectedItem.ToString().Equals("Y") ? true : false;
            objSaleModel.FromReceivable = cbxFormIssuable.SelectedItem.ToString();

            objSaleModel.InvoiceHeading = tbxInvoiceHeading.Text.Trim() == null ? string.Empty : tbxInvoiceHeading.Text.Trim();
            objSaleModel.InvoiceDescription = tbxInvoiceDescription.Text.Trim() == null ? string.Empty : tbxInvoiceDescription.Text.Trim();
            bool isSuccess = objSaleBL.SaveSalesType(objSaleModel);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }

        }

        private void SaleType_Load(object sender, EventArgs e)
        {
            tbxSaleType.Focus();
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
            objSaleModel.typeDifferentTaxRate = rbngrpSalesAcInf.SelectedIndex == 1 ? true : false;
            objSaleModel.typeSpecifyINVoucher = rbngrpSalesAcInf.SelectedIndex == 2 ? true : false;
            objSaleModel.LedgerAccountBox = cbxLedgerAccount.Text.Trim() == null ? string.Empty : cbxLedgerAccount.Text.Trim();
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
            // other Information Group
            objSaleModel.TaxInvoice = cbxTaxInvoiceyesno.SelectedItem.ToString().Equals("Y") ? true : false;
            objSaleModel.CalculateTaxonItemMRP = cbxTaxonItemmrp.SelectedItem.ToString().Equals("Y") ? true : false;
            objSaleModel.TaxInclusiveItemPrice = cbxTaxInclItemPrice.SelectedItem.ToString().Equals("Y") ? true : false;
            objSaleModel.CalculatedTax = Convert.ToDecimal(tbxCalculatedtax.Text.Trim() == string.Empty ? "0.00" : tbxCalculatedtax.Text.Trim());
            objSaleModel.VatReturnCategory = cbxVatreturnCategory.SelectedItem.ToString();
            objSaleModel.AdjustTaxinSaleAccount = cbxAdTaxinSaleAmt.SelectedItem.ToString().Equals("Y") ? true : false;
            objSaleModel.SkipVatorSaleTaxReport = cbxVatorSalesTaxReports.SelectedItem.ToString().Equals("Y") ? true : false;
            objSaleModel.TaxAccount = cbxTaxAccount.SelectedItem.ToString();
            //if Enable MultiTax Will Show on other Information Group
            //Region Radio Button GroupBox
            if (rbngrpRegion.SelectedIndex == 0)
            {
                objSaleModel.TypeLocal = true;
            }
            if (rbngrpRegion.SelectedIndex == 1)
            {
                objSaleModel.TypeCentral = true;
            }
            //Tax Calculation
            objSaleModel.SingleTaxRate = rbngrpTaxcalculation.SelectedIndex == 0 ? true : false;
            objSaleModel.MultiTaxRate = rbngrpTaxcalculation.SelectedIndex == 1 ? true : false;
            objSaleModel.TaxinPercentage = Convert.ToDecimal(tbxTaxPer.Text.Trim() == string.Empty ? "0.00" : tbxTaxPer.Text.Trim());
            objSaleModel.SurchargeInPercentage = Convert.ToDecimal(tbxSurchargePer.Text.Trim() == string.Empty ? "0.00" : tbxSurchargePer.Text.Trim());
            objSaleModel.freezeTaxinSales = cbxFreezeTaxinsale.SelectedItem.ToString().Equals("Y") ? true : false;
            objSaleModel.freezeTaxinSalesReturn = cbxFreezeTaxinSaleReturn.SelectedItem.ToString().Equals("Y") ? true : false;
            //Type of Transaction on Region GrupBox Sub
            objSaleModel.TypeStockTransfer = rbngrpTranction.SelectedIndex == 0 ? true : false;
            objSaleModel.ExportNormal = rbngrpTranction.SelectedIndex == 1 ? true : false;
            objSaleModel.SaleinTransit = rbngrpTranction.SelectedIndex == 2 ? true : false;
            objSaleModel.TypeOther = rbngrpTranction.SelectedIndex == 3 ? true : false;
            objSaleModel.ExportHighsea = rbngrpTranction.SelectedIndex == 4 ? true : false;
            // Form Information:if Enabl typeAgainstSTFrom
            objSaleModel.IssueSTFrom = cbxIssueSTform.SelectedItem.ToString().Equals("Y") ? true : false;
            objSaleModel.FromIssuable = cbxFormIssuable.SelectedItem.ToString();
            objSaleModel.ReceiveSTForm = cbxIssueSTform.SelectedItem.ToString().Equals("Y") ? true : false;
            objSaleModel.FromReceivable = cbxFormIssuable.SelectedItem.ToString();

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
    }
}
