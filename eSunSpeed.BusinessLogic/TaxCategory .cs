using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeed.DataAccess;
using eSunSpeedDomain;
using eSunSpeed.Formatting;

namespace eSunSpeed.BusinessLogic
{
    public class TaxCategory
    {
        TaxCategoryModel objtaxmod = new TaxCategoryModel();
        private DBHelper _dbHelper = new DBHelper();
        
        public bool SaveTaxCategory(eSunSpeedDomain.TaxCategoryModel objTaxCat)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Name", objTaxCat.Name));
                paramCollection.Add(new DBParameter("@TaxCat_Type", objTaxCat.TaxCat_Type));
                paramCollection.Add(new DBParameter("@ServiceTax", objTaxCat.ServiceTax));
                paramCollection.Add(new DBParameter("@RateofTaxLocal",objTaxCat.Local_Tax,System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@RateofCentral", objTaxCat.CentralTax, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TaxonMRP", objTaxCat.TaxonMRP,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CalculatedTaxon", objTaxCat.CalculatedTaxon, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TaxonMRPMode", objTaxCat.TaxonMRPMode));
                paramCollection.Add(new DBParameter("@Taxation_Type", objTaxCat.Taxation_Type));
                paramCollection.Add(new DBParameter("@HSNCode", objTaxCat.HSNCode));
                paramCollection.Add(new DBParameter("@Tax_Desc", objTaxCat.Tax_Desc));
                paramCollection.Add(new DBParameter("@CreatedBy", objTaxCat.CreatedBy));

                Query = "INSERT INTO taxcategory(`Name`,`TaxCat_Type`,`Service_Tax`,`Local_Tax`,`Central_Tax`,`TaxonMRP`,`CalculatedTaxon`,`TaxonMRPMode`,`Taxation_Type`," +
                        "`HSNCode`,`Tax_Desc`,`CreatedBy`) VALUES " +
                        "(@Name,@TaxCat_Type,@ServiceTax,@RateofTaxLocal,@RateofCentral,@TaxonMRP,@CalculatedTaxon,@TaxonMRPMode,@Taxation_Type,@HSNCode,@Tax_Desc,@CreatedBy)";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    SaveTaxRates(objTaxCat.TaxRates);
                    isSaved = true;
                }
                    
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        public bool SaveTaxRates(List<TaxRatesModel> lstaxRate)
        {
            string Query = string.Empty;
            bool isSaved = true;
            int ParentId = GetTaxCategoryId();
            foreach (TaxRatesModel objTaxRate in lstaxRate)
            {
                try
                {
                    objTaxRate.TaxRate_Id = ParentId;

                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@TaxCat_Id", objTaxRate.TaxRate_Id));
                    paramCollection.Add(new DBParameter("@wef", objTaxRate.wef,System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@Tax_Local", objTaxRate.Local_Tax));
                    paramCollection.Add(new DBParameter("@Tax_Schg", objTaxRate.Local_Schg));
                    paramCollection.Add(new DBParameter("@Tax_Type", objTaxRate.Tax_Type));
                    paramCollection.Add(new DBParameter("@Tax_Central", objTaxRate.Tax_Central));
                    paramCollection.Add(new DBParameter("@Schg_Central", objTaxRate.Schg_Central));

                    paramCollection.Add(new DBParameter("@Entry_Tax", objTaxRate.Entry_Tax));
                    paramCollection.Add(new DBParameter("@Serivce_Tax", objTaxRate.Service_Tax));

                    paramCollection.Add(new DBParameter("@CreatedBy", objTaxRate.CreatedBy));

                    Query = "INSERT INTO taxrate(`TaxCat_Id`,`wef`,`Tax_Local`,`Tax_Schg`,`Tax_Type`,`Tax_Central`,`Schg_Central`,`Entry_Tax`," +
                            "`Service_Tax`,`CreatedBy`) VALUES " +
                            "(@TaxCat_Id,@wef,@Tax_Local,@Tax_Schg,@Tax_Type,@Tax_Central,@Schg_Central,@Entry_Tax,@Serivce_Tax,@CreatedBy)";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                        isSaved = true;
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        public TaxCategoryModel GetTaxDetailsById(int TaxId)
        {
            TaxCategoryModel objTax = new TaxCategoryModel();

            string Query = "SELECT * FROM TaxCategory WHERE TaxCat_Id=" + TaxId;

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            dr.Read();

            objTax.TaxCat_Id = DataFormat.GetInteger(dr["TaxCat_Id"]);

            objTax.Name = dr["Name"].ToString();
            objTax.CentralTax = Convert.ToDecimal(dr["CentralTax"]);
            objTax.Local_Tax = Convert.ToDecimal(dr["Local_Tax"]);
            objTax.Tax_Desc = dr["Tax_Desc"].ToString();
            objTax.Taxation_Type = dr["Taxation_Type"].ToString();
            objTax.TaxCat_Type = dr["TaxCat_Type"].ToString();
            objTax.TaxonMRP = Convert.ToBoolean(dr["TaxonMRP"]);
            objTax.TaxonMRPMode = dr["TaxonMRPMode"].ToString();

            objTax.HSNCode = dr["HSNCode"].ToString();
            objTax.CalculatedTaxon = Convert.ToDecimal(dr["CalculatedTaxon"]);

            return objTax;
        }

        public List<TaxRatesModel> GetTaxRatesByTaxId(int TaxId)
        {
            TaxRatesModel objRate = new TaxRatesModel();
            List<TaxRatesModel> lstRates = new List<TaxRatesModel>();

            string Query = "SELECT * FROM TaxRate WHERE TaxCat_Id=" + TaxId;

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objRate = new TaxRatesModel();

                objRate.TaxCat_Id = DataFormat.GetInteger(dr["TaxCat_Id"]);
                objRate.TaxRate_Id = DataFormat.GetInteger(dr["TaxRate_Id"]);
                objRate.wef = Convert.ToDateTime(dr["wef"]);
                objRate.Local_Tax = Convert.ToDecimal(dr["Tax_Local"]);
                objRate.Tax_Central = Convert.ToDecimal(dr["Tax_Central"]);
                objRate.Local_Schg = Convert.ToDecimal(dr["Tax_Schg"]);
                objRate.Schg_Central = Convert.ToDecimal(dr["Schg_Central"]);
                objRate.Service_Tax = Convert.ToDecimal(dr["Service_Tax"]);
                objRate.Entry_Tax = Convert.ToDecimal(dr["Entry_Tax"]);
                objRate.Tax_Type = dr["Tax_Type"].ToString();

                lstRates.Add(objRate);
            }
            return lstRates;
        }

        public int GetTaxCategoryId()
        {
            string Query = "SELECT MAX(TaxCat_Id) FROM TAXCATEGORY";

            int id= Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }

        public bool UpdateTaxRates(TaxRatesModel objTaxRate)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@wef", objTaxRate.wef));
                paramCollection.Add(new DBParameter("@Tax_Local", objTaxRate.Local_Tax));
                paramCollection.Add(new DBParameter("@Tax_Schg", objTaxRate.Local_Schg));
                paramCollection.Add(new DBParameter("@Tax_Type", objTaxRate.Tax_Type));
                paramCollection.Add(new DBParameter("@Tax_Central", objTaxRate.Tax_Central));
                paramCollection.Add(new DBParameter("@Schg_Central", objTaxRate.Schg_Central));

                paramCollection.Add(new DBParameter("@Entry_Tax", objTaxRate.Entry_Tax));
                paramCollection.Add(new DBParameter("@Serivce_Tax", objTaxRate.Service_Tax));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                
                paramCollection.Add(new DBParameter("@TaxRate_Id", objTaxRate.TaxRate_Id));
                paramCollection.Add(new DBParameter("@TaxCat_Id", objTaxRate.TaxCat_Id));


                Query = "UPDATE TaxRate SET [wef]=@wef,[Tax_Local]=@Tax_Local,[Tax_Schg]=@Tax_Schg,[Tax_Type]=@Tax_Type," +
                        "[Tax_Central]=@Tax_Central,[Schg_Central]=@Schg_Central,[Entry_Tax]=@Entry_Tax,[Service_Tax]=@Serivce_Tax," +
                        "[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                        "WHERE  TaxRate_Id=@TaxRate_Id AND TaxCat_Id=@TaxCat_Id";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    isUpdated = true;
            }
            catch (Exception ex)
            {
                isUpdated = false;
                throw ex;
            }

            return isUpdated;
        }

        public bool UpdateTaxCategory(eSunSpeedDomain.TaxCategoryModel objTaxCat)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Name", objTaxCat.Name));
                paramCollection.Add(new DBParameter("@TaxCat_Type", objTaxCat.TaxCat_Type));
                paramCollection.Add(new DBParameter("@Taxation_Type", objTaxCat.Taxation_Type));
                paramCollection.Add(new DBParameter("@RateofTaxLocal", objTaxCat.Local_Tax));
                paramCollection.Add(new DBParameter("@RateofCentral", objTaxCat.CentralTax));
                paramCollection.Add(new DBParameter("@TaxonMRP", objTaxCat.TaxonMRP, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CalculatedTaxon", objTaxCat.CalculatedTaxon));

                paramCollection.Add(new DBParameter("@TaxonMRPMode", objTaxCat.TaxonMRPMode));
                paramCollection.Add(new DBParameter("@HSNCode", objTaxCat.HSNCode));
                paramCollection.Add(new DBParameter("@Tax_Desc", objTaxCat.Tax_Desc));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                paramCollection.Add(new DBParameter("@Id", objTaxCat.TaxCat_Id));


                Query = "UPDATE TaxCategory SET [Name]=@Name,[TaxCat_Type]=@TaxCat_Type,[Taxation_Type]=@Taxation_Type,[Local_Tax]=@RateofTaxLocal," +
                        "[CentralTax]=@RateofCentral,[TaxonMRP]=@TaxonMRP,[CalculatedTaxon]=@CalculatedTaxon,[TaxonMRPMode]=@TaxonMRPMode," +
                        "[HSNCode]=@HSNCode,[Tax_Desc]=@Tax_Desc,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                        "WHERE TaxCat_Id=@Id;";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    isUpdated = true;
            }
            catch (Exception ex)
            {
                isUpdated = false;
                throw ex;
            }

            return isUpdated;
        }

        public List<TaxCategoryModel> GetAllTaxCategories()
        {
            List<TaxCategoryModel> lstTaxCategories = new List<TaxCategoryModel>();
            TaxCategoryModel objTax;

            string Query = "SELECT DISTINCT TaxCat_Id,Name FROM TaxCategory";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objTax = new  TaxCategoryModel();

                objTax.TaxCat_Id = DataFormat.GetInteger(dr["TaxCat_Id"]);              
                objTax.Name =  dr["Name"].ToString();

                lstTaxCategories.Add(objTax);
            }
            return lstTaxCategories;
        }

        public TaxCategoryModel GetTaxCategoryByTaxId(int id)
        {
            TaxCategoryModel objTaxCategory = new TaxCategoryModel();

            string Query = "SELECT * FROM `taxcategory` where TaxCat_Id=" +id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objTaxCategory.TaxCat_Id = Convert.ToInt32(dr["TaxCat_Id"]);
                objTaxCategory.Name = dr["Name"].ToString();
                objTaxCategory.TaxCat_Type = dr["Taxation_Type"].ToString();
                objTaxCategory.Local_Tax =Convert.ToDecimal(dr["Local_Tax"].ToString());
                objTaxCategory.CentralTax = Convert.ToDecimal(dr["Central_Tax"].ToString());
                objTaxCategory.TaxonMRP = Convert.ToBoolean(dr["TaxonMRP"].ToString()=="1"?true:false);
                objTaxCategory.CalculatedTaxon = Convert.ToDecimal(dr["CalculatedTaxon"].ToString());
                objTaxCategory.TaxonMRPMode =dr["TaxonMRPMode"].ToString();
                objTaxCategory.HSNCode = dr["HSNCode"].ToString();
                objTaxCategory.Tax_Desc = dr["Tax_Desc"].ToString();
            }

            return objTaxCategory;

        }

        public bool DeleteTaxCategory(List<int> TaxCategoryid)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int taxid in TaxCategoryid)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Tax_id", taxid));
                    Query = "Delete from TaxCategory WHERE [TaxCat_Id]=@Tax_id";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                        isUpdated = true;
                }

            }
            catch (Exception ex)
            {
                isUpdated = false;
                throw ex;
            }

            return isUpdated;
        }
    }
}
