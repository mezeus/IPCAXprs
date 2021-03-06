﻿using System;
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
        //This BL Used For Tax Category & GST Details    

        TaxCategoryModel objtaxmod = new TaxCategoryModel();
        private DBHelper _dbHelper = new DBHelper();
        //Save TaxCategory
        public bool SaveTaxCategory(eSunSpeedDomain.TaxCategoryModel objTaxCat)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Name", objTaxCat.Name));
                paramCollection.Add(new DBParameter("@TaxCat_Type", objTaxCat.TaxCat_Type));
                paramCollection.Add(new DBParameter("@ServiceTax", objTaxCat.ServiceTax, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@RateofTaxLocal",objTaxCat.Local_Tax,System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@RateofCentral", objTaxCat.CentralTax, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TaxonMRP", objTaxCat.TaxonMRP,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CalculatedTaxon", objTaxCat.CalculatedTaxon, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TaxonMRPMode", objTaxCat.TaxonMRPMode));
                paramCollection.Add(new DBParameter("@Taxation_Type", objTaxCat.Taxation_Type));
                paramCollection.Add(new DBParameter("@HSNCode", objTaxCat.HSNCode));
                paramCollection.Add(new DBParameter("@Tax_Desc", objTaxCat.Tax_Desc));
                paramCollection.Add(new DBParameter("@CreatedBy", objTaxCat.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate",DateTime.Now,System.Data.DbType.DateTime));

                Query = "INSERT INTO taxcategory(`Name`,`TaxCat_Type`,`Service_Tax`,`Local_Tax`,`Central_Tax`,`TaxonMRP`,`CalculatedTaxon`,`TaxonMRPMode`,`Taxation_Type`," +
                        "`HSNCode`,`Tax_Desc`,`CreatedBy`,`CreatedDate`) VALUES " +
                        "(@Name,@TaxCat_Type,@ServiceTax,@RateofTaxLocal,@RateofCentral,@TaxonMRP,@CalculatedTaxon,@TaxonMRPMode,@Taxation_Type,@HSNCode,@Tax_Desc,@CreatedBy,@CreatedDate)";

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

        //Save Tax Rates Grid
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
                    paramCollection.Add(new DBParameter("@Tax_Local", objTaxRate.Local_Tax, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@Tax_Schg", objTaxRate.Local_Schg, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@Tax_Type", objTaxRate.Tax_Type));
                    paramCollection.Add(new DBParameter("@Tax_Central", objTaxRate.Tax_Central, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@Schg_Central", objTaxRate.Schg_Central, System.Data.DbType.Decimal));

                    paramCollection.Add(new DBParameter("@Entry_Tax", objTaxRate.Entry_Tax, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@Serivce_Tax", objTaxRate.Service_Tax, System.Data.DbType.Decimal));

                    paramCollection.Add(new DBParameter("@CreatedBy","Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate",DateTime.Now,System.Data.DbType.DateTime));

                    Query = "INSERT INTO taxrate(`TaxCat_Id`,`wef`,`Tax_Local`,`Tax_Schg`,`Tax_Type`,`Tax_Central`,`Schg_Central`,`Entry_Tax`," +
                            "`Service_Tax`,`CreatedBy`,`CreatedDate`) VALUES " +
                            "(@TaxCat_Id,@wef,@Tax_Local,@Tax_Schg,@Tax_Type,@Tax_Central,@Schg_Central,@Entry_Tax,@Serivce_Tax,@CreatedBy,@CreatedDate)";

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
                paramCollection.Add(new DBParameter("@ServiceTax", objTaxCat.ServiceTax, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@RateofTaxLocal", objTaxCat.Local_Tax, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@RateofCentral", objTaxCat.CentralTax, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TaxonMRP", objTaxCat.TaxonMRP, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CalculatedTaxon", objTaxCat.CalculatedTaxon, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TaxonMRPMode", objTaxCat.TaxonMRPMode));
                paramCollection.Add(new DBParameter("@Taxation_Type", objTaxCat.Taxation_Type));
                paramCollection.Add(new DBParameter("@HSNCode", objTaxCat.HSNCode));
                paramCollection.Add(new DBParameter("@Tax_Desc", objTaxCat.Tax_Desc));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now,System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Id", objTaxCat.TaxCat_Id));

                Query = "UPDATE taxcategory SET `Name`=@Name,`TaxCat_Type`=@TaxCat_Type,`Service_Tax`=@ServiceTax,`Local_Tax`=@RateofTaxLocal," +
                        "`Central_Tax`=@RateofCentral,`TaxonMRP`=@TaxonMRP,`CalculatedTaxon`=@CalculatedTaxon,`TaxonMRPMode`=@TaxonMRPMode," +
                        "`Taxation_Type`=@Taxation_Type,`HSNCode`=@HSNCode,`Tax_Desc`=@Tax_Desc,`ModifiedBy`=@ModifiedBy,`ModifiedDate`=@ModifiedDate " +
                        "WHERE TaxCat_Id=@Id;";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    List<TaxRatesModel> lstTaxRates = new List<TaxRatesModel>();

                    //UPDATE Tax Rates Table
                    foreach (TaxRatesModel objTaxRate in objTaxCat.TaxRates)
                    {
                        objTaxRate.TaxCat_Id = objTaxCat.TaxCat_Id;
                        if (objTaxRate.TaxRate_Id > 0)
                        {
                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@wef", objTaxRate.wef, System.Data.DbType.DateTime));
                            paramCollection.Add(new DBParameter("@Tax_Local", objTaxRate.Local_Tax, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Tax_Schg", objTaxRate.Local_Schg, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Tax_Type", objTaxRate.Tax_Type));
                            paramCollection.Add(new DBParameter("@Tax_Central", objTaxRate.Tax_Central, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Schg_Central", objTaxRate.Schg_Central, System.Data.DbType.Decimal));

                            paramCollection.Add(new DBParameter("@Entry_Tax", objTaxRate.Entry_Tax, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Serivce_Tax", objTaxRate.Service_Tax, System.Data.DbType.Decimal));

                            paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now,System.Data.DbType.DateTime));

                            paramCollection.Add(new DBParameter("@TaxRate_Id", objTaxRate.TaxRate_Id));
                            paramCollection.Add(new DBParameter("@TaxCat_Id", objTaxRate.TaxCat_Id));
                          
                            Query = "UPDATE taxrate SET `wef`=@wef,`Tax_Local`=@Tax_Local,`Tax_Schg`=@Tax_Schg,`Tax_Type`=@Tax_Type," +
                                    "`Tax_Central`=@Tax_Central,`Schg_Central`=@Schg_Central,`Entry_Tax`=@Entry_Tax,`Service_Tax`=@Serivce_Tax," +
                                    "`ModifiedBy`=@ModifiedBy,`ModifiedDate`=@ModifiedDate " +
                                    "WHERE  TaxRate_Id=@TaxRate_Id AND TaxCat_Id=@TaxCat_Id";

                            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                            {
                                isUpdated = true;
                            }
                        }
                        else
                        {
                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@TaxCat_Id", objTaxRate.TaxCat_Id));
                            paramCollection.Add(new DBParameter("@wef", objTaxRate.wef, System.Data.DbType.DateTime));
                            paramCollection.Add(new DBParameter("@Tax_Local", objTaxRate.Local_Tax, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Tax_Schg", objTaxRate.Local_Schg, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Tax_Type", objTaxRate.Tax_Type));
                            paramCollection.Add(new DBParameter("@Tax_Central", objTaxRate.Tax_Central, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Schg_Central", objTaxRate.Schg_Central, System.Data.DbType.Decimal));

                            paramCollection.Add(new DBParameter("@Entry_Tax", objTaxRate.Entry_Tax, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Serivce_Tax", objTaxRate.Service_Tax, System.Data.DbType.Decimal));

                            paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));

                            Query = "INSERT INTO taxrate(`TaxCat_Id`,`wef`,`Tax_Local`,`Tax_Schg`,`Tax_Type`,`Tax_Central`,`Schg_Central`,`Entry_Tax`," +
                                    "`Service_Tax`,`CreatedBy`,`CreatedDate`) VALUES " +
                                    "(@TaxCat_Id,@wef,@Tax_Local,@Tax_Schg,@Tax_Type,@Tax_Central,@Schg_Central,@Entry_Tax,@Serivce_Tax,@CreatedBy,@CreatedDate)";

                            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                                isUpdated = true;
                        }
                    }
                }   
            }
            catch (Exception ex)
            {
                isUpdated = false;
                //throw ex;
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

        //Delete Single Tax Category
        public bool DeleteTaxCategorById(int id)
        {
            bool isDelete = false;
            try
            {
                if(DeleteTaxrates(id))
                {
                    string Query = "DELETE  FROM taxcategory WHERE TaxCat_Id=" + id;
                    int rowes = _dbHelper.ExecuteNonQuery(Query);
                    if (rowes > 0)
                        isDelete = true;
                }
                
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }
        public bool DeleteTaxrates(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE  FROM taxrate WHERE TaxCat_Id=" + id;
                int rowes = _dbHelper.ExecuteNonQuery(Query);
                if (rowes > 0)
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
            }
            return isDelete;
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

        //Is TaxCategory Exists or Not
        public bool IsTaxCategoryExists(string TaxName)
        {
            StringBuilder _sbQuery = new StringBuilder();
            _sbQuery.AppendFormat("SELECT COUNT(*) FROM taxcategory WHERE Name='{0}'", TaxName);

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(_sbQuery.ToString(), _dbHelper.GetConnObject());
            dr.Read();
            if (Convert.ToInt32(dr[0]) > 0)
                return true;
            else
                return false;

        }
        //Get Tax category List With Grid
        public List<TaxCategoryModel> GetTaxCategoryRatesbyId(int id)
        {
            List<TaxCategoryModel> lsttaxcate = new List<TaxCategoryModel>();
            TaxCategoryModel objTax;

            string Query = "SELECT * FROM taxcategory WHERE TaxCat_Id=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objTax = new TaxCategoryModel();

                objTax.TaxCat_Id = DataFormat.GetInteger(dr["TaxCat_Id"]);

                objTax.Name = dr["Name"].ToString();
                objTax.TaxCat_Type = dr["TaxCat_Type"].ToString();
                objTax.ServiceTax = Convert.ToDecimal(dr["Service_Tax"].ToString()==string.Empty?"0":dr["Service_Tax"]);
                objTax.CentralTax = Convert.ToDecimal(dr["Central_Tax"]);
                objTax.Local_Tax = Convert.ToDecimal(dr["Local_Tax"]);
                objTax.Taxation_Type = dr["Taxation_Type"].ToString();
                objTax.TaxonMRP = Convert.ToBoolean(dr["TaxonMRP"]);
                objTax.CalculatedTaxon = Convert.ToDecimal(dr["CalculatedTaxon"]);
                objTax.TaxonMRPMode = dr["TaxonMRPMode"].ToString();
                objTax.HSNCode = dr["HSNCode"].ToString();
                objTax.Tax_Desc = dr["Tax_Desc"].ToString();
                                                          
                //SELECT Tax Rates

                string itemQuery = "SELECT * FROM taxrate WHERE TaxCat_Id=" + objTax.TaxCat_Id;
                System.Data.IDataReader drTax = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objTax.TaxRates = new List<TaxRatesModel>();
                TaxRatesModel objRate;

                while (drTax.Read())
                {
                    objRate = new TaxRatesModel();

                    objRate.TaxCat_Id = DataFormat.GetInteger(drTax["TaxCat_Id"]);
                    objRate.TaxRate_Id = DataFormat.GetInteger(drTax["TaxRate_Id"]);
                    objRate.wef = Convert.ToDateTime(drTax["wef"]);
                    objRate.Local_Tax = Convert.ToDecimal(drTax["Tax_Local"]);
                    objRate.Tax_Central = Convert.ToDecimal(drTax["Tax_Central"]);
                    objRate.Local_Schg = Convert.ToDecimal(drTax["Tax_Schg"]);
                    objRate.Schg_Central = Convert.ToDecimal(drTax["Schg_Central"]);
                    objRate.Service_Tax = Convert.ToDecimal(drTax["Service_Tax"]);
                    objRate.Entry_Tax = Convert.ToDecimal(drTax["Entry_Tax"]);
                    objRate.Tax_Type = drTax["Tax_Type"].ToString();

                    objTax.TaxRates.Add(objRate);

                }

                lsttaxcate.Add(objTax);

            }
            return lsttaxcate;
        }

        //Save GST Details
        public bool SaveGSTDetails(eSunSpeedDomain.TaxCategoryModel objTaxCat)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@GSTName", objTaxCat.GSTName));
                paramCollection.Add(new DBParameter("@TaxCat_Type", objTaxCat.TaxCat_Type));
                paramCollection.Add(new DBParameter("@CGST_Tax", objTaxCat.CGST_Tax, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@SGST_Tax", objTaxCat.SGST_Tax, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@IGST_Tax", objTaxCat.IGST_Tax, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TaxonMRP", objTaxCat.TaxonMRP, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CalculatedTaxon", objTaxCat.CalculatedTaxon, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TaxonMRPMode", objTaxCat.TaxonMRPMode));            
                paramCollection.Add(new DBParameter("@CreatedBy","Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy","Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertGSTDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                long id = 0;
                dr.Read();
                id = Convert.ToInt64(dr[0]);
                SaveGSTTaxRatesDetails(objTaxCat.GSTTaxRates, id);
            }
            catch (Exception ex)
            {
                isSaved = false;
                //throw ex;
            }

            return isSaved;
        }
        //Save GST Tax Rate Details
        public bool SaveGSTTaxRatesDetails(List<TaxRatesModel> lstaxRate,long id)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (TaxRatesModel objGTaxRate in lstaxRate)
            {
                objGTaxRate.GSTID = id;
                try
                {

                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@GSTID", objGTaxRate.GSTID));
                    paramCollection.Add(new DBParameter("@wef", objGTaxRate.wef, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@CGST_Tax", objGTaxRate.CGST_Tax, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@SGST_Tax", objGTaxRate.SGST_Tax, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@Tax_Type", objGTaxRate.Tax_Type));
                    paramCollection.Add(new DBParameter("@IGST_Tax", objGTaxRate.IGST_Tax, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@Cess", objGTaxRate.Cess, System.Data.DbType.Decimal));       
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertGSTTaxRateDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    //throw ex;
                }
            }
            return isSaved;
        }
        //Get Total List Of GST Details
        public List<TaxCategoryModel> GetAllGSTCategories()
        {
            List<TaxCategoryModel> lstGSTCategories = new List<TaxCategoryModel>();
            TaxCategoryModel objGST;

            string Query = "SELECT DISTINCT GST_ID,GSTName FROM gstdetails";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objGST = new TaxCategoryModel();

                objGST.GST_ID = DataFormat.GetInteger(dr["GST_ID"]);
                objGST.GSTName = dr["GSTName"].ToString();

                lstGSTCategories.Add(objGST);
            }
            return lstGSTCategories;
        }

        //Get Toatl GST Details With Tax Rates By Id
        public List<TaxCategoryModel> GetGSTCategoryRatesbyId(long id)
        {
            List<TaxCategoryModel> lstgstcate = new List<TaxCategoryModel>();
            TaxCategoryModel objTax;

            string Query = "SELECT * FROM gstdetails WHERE GST_ID=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objTax = new TaxCategoryModel();

                objTax.GST_ID = DataFormat.GetInteger(dr["GST_ID"]);

                objTax.GSTName = dr["GSTName"].ToString();
                objTax.TaxCat_Type = dr["TaxCat_Type"].ToString();
                objTax.CGST_Tax = Convert.ToDecimal(dr["CGST_Tax"].ToString() == string.Empty ? "0.00" : dr["CGST_Tax"]);
                objTax.SGST_Tax = Convert.ToDecimal(dr["SGST_Tax"].ToString() == string.Empty ? "0.00" : dr["SGST_Tax"]);
                objTax.IGST_Tax = Convert.ToDecimal(dr["IGST_Tax"].ToString() == string.Empty ? "0.00" : dr["IGST_Tax"]);
                objTax.TaxonMRP = Convert.ToBoolean(dr["TaxonMRP"]);
                objTax.CalculatedTaxon = Convert.ToDecimal(dr["CalculatedTaxon"].ToString() == string.Empty ? "0.00" : dr["CalculatedTaxon"]);
                objTax.TaxonMRPMode = dr["TaxonMRPMode"].ToString()== null ? string.Empty:dr["TaxonMRPMode"].ToString();
                //SELECT GST Tax Rates

                string itemQuery = "SELECT * FROM gsttaxratedetails WHERE GST_ID=" + id;
                System.Data.IDataReader drTax = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objTax.TaxRates = new List<TaxRatesModel>();
                TaxRatesModel objRate;
                while (drTax.Read())
                {
                    objRate = new TaxRatesModel();

                    objRate.GSTID = DataFormat.GetInteger(drTax["GST_ID"]);
                    objRate.TaxRate_Id = DataFormat.GetInteger(drTax["TaxRate_Id"]);
                    objRate.wef = Convert.ToDateTime(drTax["wef"].ToString());
                    objRate.CGST_Tax = Convert.ToDecimal(drTax["CGST_Tax"].ToString() == string.Empty ? "0.00" : drTax["CGST_Tax"]);
                    objRate.SGST_Tax = Convert.ToDecimal(drTax["SGST_Tax"].ToString() == string.Empty ? "0.00" : drTax["SGST_Tax"]);
                    objRate.IGST_Tax = Convert.ToDecimal(drTax["IGST_Tax"].ToString() == string.Empty ? "0.00" : drTax["IGST_Tax"]);
                    objRate.Cess = Convert.ToDecimal(drTax["Cess"].ToString() == string.Empty ? "0.00" : drTax["Cess"]);
                    objRate.Tax_Type = drTax["Tax_Type"].ToString();

                    objTax.TaxRates.Add(objRate);
                }

                lstgstcate.Add(objTax);

            }
            return lstgstcate;
        }

        //Update GST Details
        public bool UpdateGSTDetails(eSunSpeedDomain.TaxCategoryModel objTaxCat)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@GSTID", objTaxCat.GST_ID));
                paramCollection.Add(new DBParameter("@GSTName", objTaxCat.GSTName));
                paramCollection.Add(new DBParameter("@TaxCat_Type", objTaxCat.TaxCat_Type));
                paramCollection.Add(new DBParameter("@CGST_Tax", objTaxCat.CGST_Tax, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@SGST_Tax", objTaxCat.SGST_Tax, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@IGST_Tax", objTaxCat.IGST_Tax, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TaxonMRP", objTaxCat.TaxonMRP, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CalculatedTaxon", objTaxCat.CalculatedTaxon, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TaxonMRPMode", objTaxCat.TaxonMRPMode));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spUpdateGSTDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                //Update GST Rate Details
                foreach (TaxRatesModel objGTaxRate in objTaxCat.GSTTaxRates)
                {
                    objGTaxRate.GSTID = objTaxCat.GST_ID;
                    if(objGTaxRate.TaxRate_Id>0)
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@GSTID", objGTaxRate.GSTID));
                        paramCollection.Add(new DBParameter("@TaxRateId", objGTaxRate.TaxRate_Id));
                        paramCollection.Add(new DBParameter("@wef", objGTaxRate.wef, System.Data.DbType.DateTime));
                        paramCollection.Add(new DBParameter("@CGST_Tax", objGTaxRate.CGST_Tax, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@SGST_Tax", objGTaxRate.SGST_Tax, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@Tax_Type", objGTaxRate.Tax_Type));
                        paramCollection.Add(new DBParameter("@IGST_Tax", objGTaxRate.IGST_Tax, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@Cess", objGTaxRate.Cess, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                        paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                        paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                        paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                        System.Data.IDataReader drGT =
                        _dbHelper.ExecuteDataReader("spUpdateGSTTaxRateDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }
                   else
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@GSTID", objGTaxRate.GSTID));
                        paramCollection.Add(new DBParameter("@wef", objGTaxRate.wef, System.Data.DbType.DateTime));
                        paramCollection.Add(new DBParameter("@CGST_Tax", objGTaxRate.CGST_Tax, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@SGST_Tax", objGTaxRate.SGST_Tax, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@Tax_Type", objGTaxRate.Tax_Type));
                        paramCollection.Add(new DBParameter("@IGST_Tax", objGTaxRate.IGST_Tax, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@Cess", objGTaxRate.Cess, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                        paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                        paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                        paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                        System.Data.IDataReader drGT =
                        _dbHelper.ExecuteDataReader("spInsertGSTTaxRateDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }

                       
                }
            }
            catch (Exception ex)
            {
                isSaved = false;
                //throw ex;
            }

            return isSaved;
        }

        //Delete Single Tax Category
        public bool DeleteGSTCategorById(long id)
        {
            bool isDelete = false;
            try
            {
                if (DeleteGSTRates(id))
                {
                    string Query = "DELETE  FROM gstdetails WHERE GST_ID=" + id;
                    int rowes = _dbHelper.ExecuteNonQuery(Query);
                    if (rowes > 0)
                        isDelete = true;
                }

            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }
        //Delete GST Tax Rate Details
        public bool DeleteGSTRates(long id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE  FROM gsttaxratedetails WHERE GST_ID=" + id;
                int rowes = _dbHelper.ExecuteNonQuery(Query);
                if (rowes > 0)
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
            }
            return isDelete;
        }
    }
}
