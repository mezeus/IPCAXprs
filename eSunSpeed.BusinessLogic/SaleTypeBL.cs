using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;

namespace eSunSpeed.BusinessLogic
{

    public class SaleTypeBL
    {
        private DBHelper _dbHelper = new DBHelper();
        public bool SaveSalesType(SaleTypeModel objStype)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@SalesType", objStype.SalesType));
                paramCollection.Add(new DBParameter("@typeSpecifyHereSingleAccount", objStype.typeSpecifyHereSingleAccount,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@LedgerAccountBox", objStype.LedgerAccountBox));
                paramCollection.Add(new DBParameter("@typeDifferentTaxRate", objStype.typeDifferentTaxRate, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeSpecifyINVoucher", objStype.typeSpecifyINVoucher, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeTaxable", objStype.typeTaxable, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@tyypeMultiTax", objStype.typeMultiTax, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeAgainstSTFrom", objStype.typeAgainstSTFrom, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeTaxpaid", objStype.typeTaxpaid, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeExempt", objStype.typeExempt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeTaxFree", objStype.typeTaxFree, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeLUMSumDealer", objStype.typeLUMSumDealer, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeUnRegDealer", objStype.typeUnRegDealer, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TaxInvoice", objStype.TaxInvoice, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@VatReturnCategory", objStype.VatReturnCategory));
                paramCollection.Add(new DBParameter("@VatSaleTaxReport", objStype.VatSaleTaxReport, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CalculateTaxonItemMRP", objStype.CalculateTaxonItemMRP, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TaxInclusiveItemPrice", objStype.TaxInclusiveItemPrice, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CalculateTaxonpercentofAmount", objStype.CalculatedTax));
                paramCollection.Add(new DBParameter("@AdjustTaxinSaleAccount", objStype.AdjustTaxinSaleAccount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TaxAccount", objStype.TaxAccount));
                paramCollection.Add(new DBParameter("@SkipVatorSaleTaxReport", objStype.SkipVatorSaleTaxReport, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TypeLocal", objStype.TypeLocal, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TypeCentral", objStype.TypeCentral, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TypeStockTransfer", objStype.TypeStockTransfer, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TypeOther", objStype.TypeOther, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ExportNormal", objStype.ExportNormal, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SaleinTransit", objStype.SaleinTransit, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ExportHighsea", objStype.ExportHighsea, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SingleTaxRate", objStype.SingleTaxRate, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@MultiTaxRate", objStype.MultiTaxRate, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TaxinPercentage", objStype.TaxinPercentage, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@SurchargeInPercentage", objStype.SurchargeInPercentage, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@freezeTaxinSales", objStype.freezeTaxinSales, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@freezeTaxinSalesReturn", objStype.freezeTaxinSalesReturn, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@IssueSTFrom", objStype.IssueSTFrom, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@FromIssuable", objStype.FromIssuable));
                paramCollection.Add(new DBParameter("@ReceiveSTForm", objStype.ReceiveSTForm, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@FormReceivable", objStype.FromReceivable));
                paramCollection.Add(new DBParameter("@InvoiceHeading", objStype.InvoiceHeading));
                paramCollection.Add(new DBParameter("@InvoiceDescription", objStype.InvoiceDescription));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                System.Data.IDataReader dr =
                             _dbHelper.ExecuteDataReader("spInsertSaleTypeMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                isSaved = true;
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        //update Sale Type Master
        public bool UpdateSalestype(eSunSpeedDomain.SaleTypeModel objStype)
        {
            string Query = string.Empty;
            bool isUpdate = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@SalesType", objStype.SalesType));
                paramCollection.Add(new DBParameter("@typeSpecifyHereSingleAccount", objStype.typeSpecifyHereSingleAccount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@LedgerAccountBox", objStype.LedgerAccountBox));
                paramCollection.Add(new DBParameter("@typeDifferentTaxRate", objStype.typeDifferentTaxRate, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeSpecifyINVoucher", objStype.typeSpecifyINVoucher, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeTaxable", objStype.typeTaxable, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@tyypeMultiTax", objStype.typeMultiTax, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeAgainstSTFrom", objStype.typeAgainstSTFrom, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeTaxpaid", objStype.typeTaxpaid, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeExempt", objStype.typeExempt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeTaxFree", objStype.typeTaxFree, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeLUMSumDealer", objStype.typeLUMSumDealer, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeUnRegDealer", objStype.typeUnRegDealer, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TaxInvoice", objStype.TaxInvoice, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@VatReturnCategory", objStype.VatReturnCategory));
                paramCollection.Add(new DBParameter("@VatSaleTaxReport", objStype.VatSaleTaxReport, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CalculateTaxonItemMRP", objStype.CalculateTaxonItemMRP, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TaxInclusiveItemPrice", objStype.TaxInclusiveItemPrice, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CalculateTaxonpercentofAmount", objStype.CalculatedTax));
                paramCollection.Add(new DBParameter("@AdjustTaxinSaleAccount", objStype.AdjustTaxinSaleAccount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TaxAccount", objStype.TaxAccount));
                paramCollection.Add(new DBParameter("@SkipVatorSaleTaxReport", objStype.SkipVatorSaleTaxReport, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TypeLocal", objStype.TypeLocal, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TypeCentral", objStype.TypeCentral, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TypeStockTransfer", objStype.TypeStockTransfer, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TypeOther", objStype.TypeOther, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ExportNormal", objStype.ExportNormal, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SaleinTransit", objStype.SaleinTransit, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ExportHighsea", objStype.ExportHighsea, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SingleTaxRate", objStype.SingleTaxRate, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@MultiTaxRate", objStype.MultiTaxRate, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TaxinPercentage", objStype.TaxinPercentage, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@SurchargeInPercentage", objStype.SurchargeInPercentage, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@freezeTaxinSales", objStype.freezeTaxinSales, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@freezeTaxinSalesReturn", objStype.freezeTaxinSalesReturn, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@IssueSTFrom", objStype.IssueSTFrom, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@FromIssuable", objStype.FromIssuable));
                paramCollection.Add(new DBParameter("@ReceiveSTForm", objStype.ReceiveSTForm, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@FormReceivable", objStype.FromReceivable));
                paramCollection.Add(new DBParameter("@InvoiceHeading", objStype.InvoiceHeading));
                paramCollection.Add(new DBParameter("@InvoiceDescription", objStype.InvoiceDescription));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@SalesTypeId", objStype.Sale_Id));

                System.Data.IDataReader dr =
                             _dbHelper.ExecuteDataReader("spUpdateSaleTypeMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                isUpdate = true;
            }
            catch (Exception ex)
            {
                isUpdate = false;
                throw ex;
            }

            return isUpdate;
        }

        public List<SaleTypeModel> GetAllSaleType()
        {
            List<eSunSpeedDomain.SaleTypeModel> lstSaleType = new List<SaleTypeModel>();
            eSunSpeedDomain.SaleTypeModel objSaleType;

            string Query = "SELECT * FROM saletypemaster";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objSaleType = new SaleTypeModel();

                objSaleType.Sale_Id = Convert.ToInt32(dr["Sales_Id"]);
                objSaleType.SalesType = dr["SalesType"].ToString();
                //objSaleType.typeSpecifyHereSingleAccount = Convert.ToBoolean(dr["typeSpecifyHereSingleAccount"]);
                //objSaleType.LedgerAccountBox = dr["LedgerAccountBox"].ToString();
                //objSaleType.typeDifferentTaxRate = Convert.ToBoolean(dr["typeDifferentTaxRate"]);
                //objSaleType.typeSpecifyINVoucher = Convert.ToBoolean(dr["typeSpecifyINVoucher"]);
                //objSaleType.typeTaxable = Convert.ToBoolean(dr["typeTaxable"]);
                //objSaleType.typeMultiTax = Convert.ToBoolean(dr["tyypeMultiTax"]);
                //objSaleType.typeAgainstSTFrom = Convert.ToBoolean(dr["typeAgainstSTFrom"]);
                //objSaleType.typeTaxpaid = Convert.ToBoolean(dr["typeTaxpaid"]);
                //objSaleType.typeExempt = Convert.ToBoolean(dr["typeExempt"]);
                //objSaleType.typeTaxFree = Convert.ToBoolean(dr["typeTaxFree"]);
                //objSaleType.typeLUMSumDealer = Convert.ToBoolean(dr["typeLUMSumDealer"]);
                //objSaleType.typeUnRegDealer = Convert.ToBoolean(dr["typeUnRegDealer"]);
                //objSaleType.TaxInvoice = Convert.ToBoolean(dr["TaxInvoice"]);
                //objSaleType.VatReturnCategory = dr["VatReturnCategory"].ToString();
                //objSaleType.VatSaleTaxReport = Convert.ToBoolean(dr["VatSaleTaxReport"]);
                //objSaleType.CalculateTaxonItemMRP = Convert.ToBoolean(dr["CalculateTaxonItemMRP"]);
                //objSaleType.TaxInclusiveItemPrice = Convert.ToBoolean(dr["TaxInclusiveItemPrice"]);
                //objSaleType.CalculateTaxonpercentofAmount = Convert.ToDecimal(dr["CalculateTaxonpercentofAmount"]);
                //objSaleType.AdjustTaxinSaleAccount = Convert.ToBoolean(dr["AdjustTaxinSaleAccount"]);
                //objSaleType.TaxAccount = dr["VatSaleTaxReport"].ToString();
                //objSaleType.TypeLocal = Convert.ToBoolean(dr["TypeLocal"]);
                //objSaleType.TypeCentral = Convert.ToBoolean(dr["TypeCentral"]);

                lstSaleType.Add(objSaleType);

            }
            return lstSaleType;
        }

        //List Of Sale Type By Id
        public SaleTypeModel GetAllSaleTypeBySaleName(int Salesid)
        {
          SaleTypeModel objSaleModel = new SaleTypeModel();
        string Query = "SELECT * FROM saletypemaster WHERE Sales_Id='" + Salesid + "'";
        System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

         while (dr.Read())
        {

                objSaleModel = new SaleTypeModel();
                objSaleModel.Sale_Id = Convert.ToInt32(dr["Sales_Id"]);
                objSaleModel.SalesType = dr["SalesType"].ToString();
                objSaleModel.typeSpecifyHereSingleAccount = Convert.ToBoolean(dr["typeSpecifyHereSingleAccount"]);
                objSaleModel.LedgerAccountBox = dr["LedgerAccountBox"].ToString();
                objSaleModel.typeDifferentTaxRate = Convert.ToBoolean(dr["typeDifferentTaxRate"]);
                objSaleModel.typeSpecifyINVoucher = Convert.ToBoolean(dr["typeSpecifyINVoucher"]);
                objSaleModel.typeTaxable = Convert.ToBoolean(dr["typeTaxable"]);
                objSaleModel.typeMultiTax = Convert.ToBoolean(dr["tyypeMultiTax"]);
                objSaleModel.typeAgainstSTFrom = Convert.ToBoolean(dr["typeAgainstSTFrom"]);
                objSaleModel.typeTaxpaid = Convert.ToBoolean(dr["typeTaxpaid"]);
                objSaleModel.typeExempt = Convert.ToBoolean(dr["typeExempt"]);
                objSaleModel.typeTaxFree = Convert.ToBoolean(dr["typeTaxFree"]);
                objSaleModel.typeLUMSumDealer = Convert.ToBoolean(dr["typeLUMSumDealer"]);
                objSaleModel.typeUnRegDealer = Convert.ToBoolean(dr["typeUnRegDealer"]);
                objSaleModel.TaxInvoice = Convert.ToBoolean(dr["TaxInvoice"]);
                objSaleModel.VatReturnCategory = dr["VatReturnCategory"].ToString();
                objSaleModel.VatSaleTaxReport = Convert.ToBoolean(dr["VatSaleTaxReport"]);
                objSaleModel.CalculateTaxonItemMRP = Convert.ToBoolean(dr["CalculateTaxonItemMRP"]);
                objSaleModel.TaxInclusiveItemPrice = Convert.ToBoolean(dr["TaxInclusiveItemPrice"]);
                objSaleModel.CalculateTaxonpercentofAmount = Convert.ToDecimal(dr["CalculateTaxonpercentofAmount"]);
                objSaleModel.AdjustTaxinSaleAccount = Convert.ToBoolean(dr["AdjustTaxinSaleAccount"]);
                objSaleModel.TaxAccount = dr["TaxAccount"].ToString();
                objSaleModel.TypeLocal = Convert.ToBoolean(dr["TypeLocal"]);
                objSaleModel.TypeCentral = Convert.ToBoolean(dr["TypeCentral"]);
                objSaleModel.TypeStockTransfer = Convert.ToBoolean(dr["TypeStockTransfer"]);
                objSaleModel.TypeOther = Convert.ToBoolean(dr["TypeOther"]);
                objSaleModel.ExportNormal = Convert.ToBoolean(dr["ExportNormal"]);
                objSaleModel.SaleinTransit = Convert.ToBoolean(dr["SaleinTransit"]);
                objSaleModel.ExportHighsea = Convert.ToBoolean(dr["ExportHighsea"]);
                objSaleModel.IssueSTFrom = Convert.ToBoolean(dr["IssueSTFrom"]);
                objSaleModel.FromIssuable = dr["FromIssuable"].ToString();
                objSaleModel.ReceiveSTForm = Convert.ToBoolean(dr["ReceiveSTForm"]);
                objSaleModel.FromReceivable = dr["FormReceivable"].ToString();
                objSaleModel.SingleTaxRate = Convert.ToBoolean(dr["SingleTaxRate"]);
                objSaleModel.MultiTaxRate = Convert.ToBoolean(dr["MultiTaxRate"]);
                objSaleModel.TaxinPercentage = Convert.ToDecimal(dr["TaxinPercentage"]);
                objSaleModel.SurchargeInPercentage = Convert.ToDecimal(dr["SurchargeInPercentage"]);
                objSaleModel.freezeTaxinSales = Convert.ToBoolean(dr["freezeTaxinSales"]);
                objSaleModel.freezeTaxinSalesReturn = Convert.ToBoolean(dr["freezeTaxinSalesReturn"]);
                objSaleModel.InvoiceHeading = dr["InvoiceHeading"].ToString();
                objSaleModel.InvoiceDescription = dr["InvoiceDescription"].ToString();
                objSaleModel.SkipVatorSaleTaxReport= Convert.ToBoolean(dr["SkipVatorSaleTaxReport"]);
            }
            return objSaleModel;
        }
        //Delete SalesType By Id
        public bool DeleteSaleType(int id)
        {
            bool isDeleted = true;
            try
            {
                string Query = "DELETE FROM saletypemaster WHERE Sales_Id=" + id;
                int rowes = _dbHelper.ExecuteNonQuery(Query);
                if (rowes > 0)
                    isDeleted = true;
            }
            catch (Exception ex)
            {
                isDeleted = false;
                throw ex;
            }
            return isDeleted;
        }
    }
}








