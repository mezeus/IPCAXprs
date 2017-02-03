using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;

namespace eSunSpeed.BusinessLogic
{
    public class PurchaseTypeBL
    {
        private DBHelper _dbHelper = new DBHelper();
        public bool SavePurchaseType(PurchaseTypeModel objPtype)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@PurchaseType", objPtype.PurchType));
                paramCollection.Add(new DBParameter("@typeSpecifyHereSingleAccount", objPtype.typeSpecifyHereSingleAccount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@LedgerAccountBox", objPtype.LedgerAccountBox));
                paramCollection.Add(new DBParameter("@typeDifferentTaxRate", objPtype.typeDifferentTaxRate, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeSpecifyINVoucher", objPtype.typeSpecifyINVoucher, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeTaxable", objPtype.typeTaxable, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@tyypeMultiTax", objPtype.typeMultiTax, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeAgainstSTFrom", objPtype.typeAgainstSTFrom, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeTaxpaid", objPtype.typeTaxpaid, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeExempt", objPtype.typeExempt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeTaxFree", objPtype.typeTaxFree, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeLUMSumDealer", objPtype.typeLUMSumDealer, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeUnRegDealer", objPtype.typeUnRegDealer, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TaxInvoice", objPtype.TaxInvoice, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@VatReturnCategory", objPtype.VatReturnCategory));
                paramCollection.Add(new DBParameter("@VatSaleTaxReport", objPtype.VatSaleTaxReport, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CalculateTaxonItemMRP", objPtype.CalculateTaxonItemMRP, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TaxInclusiveItemPrice", objPtype.TaxInclusiveItemPrice, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CalculateTaxonpercentofAmount", objPtype.CalculatedTax));
                paramCollection.Add(new DBParameter("@AdjustTaxinSaleAccount", objPtype.AdjustTaxinSaleAccount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TaxAccount", objPtype.TaxAccount));
                paramCollection.Add(new DBParameter("@SkipVatorSaleTaxReport", objPtype.SkipVatorSaleTaxReport, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TypeLocal", objPtype.TypeLocal, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TypeCentral", objPtype.TypeCentral, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TypeStockTransfer", objPtype.TypeStockTransfer, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TypeOther", objPtype.TypeOther, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ExportNormal", objPtype.ExportNormal, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SaleinTransit", objPtype.SaleinTransit, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ExportHighsea", objPtype.ExportHighsea, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SingleTaxRate", objPtype.SingleTaxRate, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@MultiTaxRate", objPtype.MultiTaxRate, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TaxinPercentage", objPtype.TaxinPercentage, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@SurchargeInPercentage", objPtype.SurchargeInPercentage, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@freezeTaxinSales", objPtype.freezeTaxinSales, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@freezeTaxinSalesReturn", objPtype.freezeTaxinSalesReturn, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@IssueSTFrom", objPtype.IssueSTFrom, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@FromIssuable", objPtype.FromIssuable));
                paramCollection.Add(new DBParameter("@ReceiveSTForm", objPtype.ReceiveSTForm, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@FormReceivable", objPtype.FromReceivable));
                paramCollection.Add(new DBParameter("@InvoiceHeading", objPtype.InvoiceHeading));
                paramCollection.Add(new DBParameter("@InvoiceDescription", objPtype.InvoiceDescription));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                System.Data.IDataReader dr =
                             _dbHelper.ExecuteDataReader("spInsertPurchaseTypeMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                isSaved = true;
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }
        //List Of Purcchase Type By Id
        public PurchaseTypeModel GetAllPurchTypeByPurchId(int Purcid)
        {
            PurchaseTypeModel objPurcModel = new PurchaseTypeModel();
            string Query = "SELECT * FROM purchasetypemaster WHERE Purch_Id='" + Purcid + "'";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objPurcModel = new PurchaseTypeModel();
                objPurcModel.Purch_Id = Convert.ToInt32(dr["Purch_Id"]);
                objPurcModel.PurchType = dr["PurchaseType"].ToString();
                objPurcModel.typeSpecifyHereSingleAccount = Convert.ToBoolean(dr["typeSpecifyHereSingleAccount"]);
                objPurcModel.LedgerAccountBox = dr["LedgerAccountBox"].ToString();
                objPurcModel.typeDifferentTaxRate = Convert.ToBoolean(dr["typeDifferentTaxRate"]);
                objPurcModel.typeSpecifyINVoucher = Convert.ToBoolean(dr["typeSpecifyINVoucher"]);
                objPurcModel.typeTaxable = Convert.ToBoolean(dr["typeTaxable"]);
                objPurcModel.typeMultiTax = Convert.ToBoolean(dr["tyypeMultiTax"]);
                objPurcModel.typeAgainstSTFrom = Convert.ToBoolean(dr["typeAgainstSTFrom"]);
                objPurcModel.typeTaxpaid = Convert.ToBoolean(dr["typeTaxpaid"]);
                objPurcModel.typeExempt = Convert.ToBoolean(dr["typeExempt"]);
                objPurcModel.typeTaxFree = Convert.ToBoolean(dr["typeTaxFree"]);
                objPurcModel.typeLUMSumDealer = Convert.ToBoolean(dr["typeLUMSumDealer"]);
                objPurcModel.typeUnRegDealer = Convert.ToBoolean(dr["typeUnRegDealer"]);
                objPurcModel.TaxInvoice = Convert.ToBoolean(dr["TaxInvoice"]);
                objPurcModel.VatReturnCategory = dr["VatReturnCategory"].ToString();
                objPurcModel.VatSaleTaxReport = Convert.ToBoolean(dr["VatSaleTaxReport"]);
                objPurcModel.CalculateTaxonItemMRP = Convert.ToBoolean(dr["CalculateTaxonItemMRP"]);
                objPurcModel.TaxInclusiveItemPrice = Convert.ToBoolean(dr["TaxInclusiveItemPrice"]);
                objPurcModel.CalculateTaxonpercentofAmount = Convert.ToDecimal(dr["CalculateTaxonpercentofAmount"]);
                objPurcModel.AdjustTaxinSaleAccount = Convert.ToBoolean(dr["AdjustTaxinSaleAccount"]);
                objPurcModel.TaxAccount = dr["TaxAccount"].ToString();
                objPurcModel.TypeLocal = Convert.ToBoolean(dr["TypeLocal"]);
                objPurcModel.TypeCentral = Convert.ToBoolean(dr["TypeCentral"]);
                objPurcModel.TypeStockTransfer = Convert.ToBoolean(dr["TypeStockTransfer"]);
                objPurcModel.TypeOther = Convert.ToBoolean(dr["TypeOther"]);
                objPurcModel.ExportNormal = Convert.ToBoolean(dr["ExportNormal"]);
                objPurcModel.SaleinTransit = Convert.ToBoolean(dr["SaleinTransit"]);
                objPurcModel.ExportHighsea = Convert.ToBoolean(dr["ExportHighsea"]);
                objPurcModel.IssueSTFrom = Convert.ToBoolean(dr["IssueSTFrom"]);
                objPurcModel.FromIssuable = dr["FromIssuable"].ToString();
                objPurcModel.ReceiveSTForm = Convert.ToBoolean(dr["ReceiveSTForm"]);
                objPurcModel.FromReceivable = dr["FormReceivable"].ToString();
                objPurcModel.SingleTaxRate = Convert.ToBoolean(dr["SingleTaxRate"]);
                objPurcModel.MultiTaxRate = Convert.ToBoolean(dr["MultiTaxRate"]);
                objPurcModel.TaxinPercentage = Convert.ToDecimal(dr["TaxinPercentage"]);
                objPurcModel.SurchargeInPercentage = Convert.ToDecimal(dr["SurchargeInPercentage"]);
                objPurcModel.freezeTaxinSales = Convert.ToBoolean(dr["freezeTaxinSales"]);
                objPurcModel.freezeTaxinSalesReturn = Convert.ToBoolean(dr["freezeTaxinSalesReturn"]);
                objPurcModel.InvoiceHeading = dr["InvoiceHeading"].ToString();
                objPurcModel.InvoiceDescription = dr["InvoiceDescription"].ToString();
                objPurcModel.SkipVatorSaleTaxReport = Convert.ToBoolean(dr["SkipVatorSaleTaxReport"]);
            }
            return objPurcModel;
        }
        //List Of All Purchase Types
        public List<PurchaseTypeModel> GetAllPurchaseType()
        {
            List<eSunSpeedDomain.PurchaseTypeModel> lstPurcType = new List<PurchaseTypeModel>();
            eSunSpeedDomain.PurchaseTypeModel objPurcType;

            string Query = "SELECT * FROM purchasetypemaster";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objPurcType = new PurchaseTypeModel();

                objPurcType.Purch_Id = Convert.ToInt32(dr["Purch_Id"]);
                objPurcType.PurchType = dr["PurchaseType"].ToString();
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

                lstPurcType.Add(objPurcType);

            }
            return lstPurcType;
        }
        
        //update Purchase Type Master
        public bool UpdatePurchasetype(eSunSpeedDomain.PurchaseTypeModel objPtype)
        {
            string Query = string.Empty;
            bool isUpdate = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@PurchaseType", objPtype.PurchType));
                paramCollection.Add(new DBParameter("@typeSpecifyHereSingleAccount", objPtype.typeSpecifyHereSingleAccount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@LedgerAccountBox", objPtype.LedgerAccountBox));
                paramCollection.Add(new DBParameter("@typeDifferentTaxRate", objPtype.typeDifferentTaxRate, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeSpecifyINVoucher", objPtype.typeSpecifyINVoucher, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeTaxable", objPtype.typeTaxable, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@tyypeMultiTax", objPtype.typeMultiTax, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeAgainstSTFrom", objPtype.typeAgainstSTFrom, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeTaxpaid", objPtype.typeTaxpaid, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeExempt", objPtype.typeExempt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeTaxFree", objPtype.typeTaxFree, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeLUMSumDealer", objPtype.typeLUMSumDealer, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeUnRegDealer", objPtype.typeUnRegDealer, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TaxInvoice", objPtype.TaxInvoice, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@VatReturnCategory", objPtype.VatReturnCategory));
                paramCollection.Add(new DBParameter("@VatSaleTaxReport", objPtype.VatSaleTaxReport, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CalculateTaxonItemMRP", objPtype.CalculateTaxonItemMRP, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TaxInclusiveItemPrice", objPtype.TaxInclusiveItemPrice, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CalculateTaxonpercentofAmount", objPtype.CalculatedTax));
                paramCollection.Add(new DBParameter("@AdjustTaxinSaleAccount", objPtype.AdjustTaxinSaleAccount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TaxAccount", objPtype.TaxAccount));
                paramCollection.Add(new DBParameter("@SkipVatorSaleTaxReport", objPtype.SkipVatorSaleTaxReport, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TypeLocal", objPtype.TypeLocal, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TypeCentral", objPtype.TypeCentral, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TypeStockTransfer", objPtype.TypeStockTransfer, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TypeOther", objPtype.TypeOther, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ExportNormal", objPtype.ExportNormal, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SaleinTransit", objPtype.SaleinTransit, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ExportHighsea", objPtype.ExportHighsea, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SingleTaxRate", objPtype.SingleTaxRate, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@MultiTaxRate", objPtype.MultiTaxRate, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TaxinPercentage", objPtype.TaxinPercentage, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@SurchargeInPercentage", objPtype.SurchargeInPercentage, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@freezeTaxinSales", objPtype.freezeTaxinSales, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@freezeTaxinSalesReturn", objPtype.freezeTaxinSalesReturn, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@IssueSTFrom", objPtype.IssueSTFrom, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@FromIssuable", objPtype.FromIssuable));
                paramCollection.Add(new DBParameter("@ReceiveSTForm", objPtype.ReceiveSTForm, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@FormReceivable", objPtype.FromReceivable));
                paramCollection.Add(new DBParameter("@InvoiceHeading", objPtype.InvoiceHeading));
                paramCollection.Add(new DBParameter("@InvoiceDescription", objPtype.InvoiceDescription));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@PurchaseTypeId", objPtype.Purch_Id));

                System.Data.IDataReader dr =
                             _dbHelper.ExecuteDataReader("spUpdatePurchaseTypeMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                isUpdate = true;
            }
            catch (Exception ex)
            {
                isUpdate = false;
                throw ex;
            }

            return isUpdate;
        }

        //Delete PurchaseType By Id
        public bool DeletePurchaseType(int id)
        {
            bool isDeleted = true;
            try
            {
                string Query = "DELETE FROM purchasetypemaster WHERE Purch_Id=" + id;
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
        //Is Purchase Type Exists
        public bool IsPurchaseTypeExists(string TypeName)
        {
            StringBuilder _sbQuery = new StringBuilder();
            _sbQuery.AppendFormat("SELECT COUNT(*) FROM purchasetypemaster WHERE PurchaseType='{0}'", TypeName);

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(_sbQuery.ToString(), _dbHelper.GetConnObject());
            dr.Read();
            if (Convert.ToInt32(dr[0]) > 0)
                return true;
            else
                return false;

        }
    }

}
