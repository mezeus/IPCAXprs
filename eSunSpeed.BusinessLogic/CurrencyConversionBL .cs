using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;

namespace eSunSpeed.BusinessLogic
{
   public class CurrencyConversionBL
    {
        CurrencyConversionModel objccmod = new CurrencyConversionModel();
        private DBHelper _dbHelper = new DBHelper();

        //Save

        public bool SaveCurrencyconversion(CurrencyConversionModel objCurcov)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@CurrencyDate", objCurcov.Date,System.Data.DbType.Date));
                paramCollection.Add(new DBParameter("@CreatedBy","Admin"));

                System.Data.IDataReader dr =
                   _dbHelper.ExecuteDataReader("spInsertCurrencyConversion", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);
                SaveCurrencyConDetails(objCurcov.CurrenyDetails, id);
                    isSaved = true;
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        //Save Currency Conversion Details
        public bool SaveCurrencyConDetails(List<CurrencyConversionDetailsModel> lstCurrency, int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (CurrencyConversionDetailsModel objCurrency in lstCurrency)
            {
                objCurrency.ParentId = ParentId;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();
                    paramCollection.Add(new DBParameter("@ParentId", (objCurrency.ParentId)));
                    paramCollection.Add(new DBParameter("@Currency", (objCurrency.Currency)));
                    paramCollection.Add(new DBParameter("@TandardRate", objCurrency.StandardRate,System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@SellingRate", objCurrency.SellingRate, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@BuyingRate", objCurrency.BuyingRate, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                    System.Data.IDataReader dr =
                   _dbHelper.ExecuteDataReader("spInsertCurrencyConversionDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }
        //UPDATE Currency Convresion
        public bool UpdateCurrencyconversion(CurrencyConversionModel objCurcov)
        {
            string Query = string.Empty;
            bool isUpdate = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@CurrencyDate", objCurcov.Date, System.Data.DbType.Date));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ParentId",objCurcov.CcID));

                System.Data.IDataReader dr =
                   _dbHelper.ExecuteDataReader("spUpdateCurrencyConversion", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                List<CurrencyConversionDetailsModel> lstConn = new List<CurrencyConversionDetailsModel>();

                //UPDATE Currency Conversion Grid
                foreach (CurrencyConversionDetailsModel conver in objCurcov.CurrenyDetails)
                {
                    if (conver.id > 0)
                    {

                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@ParentId", (conver.ParentId)));
                        paramCollection.Add(new DBParameter("@Currency", (conver.Currency)));
                        paramCollection.Add(new DBParameter("@TandardRate", conver.StandardRate, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@SellingRate", conver.SellingRate, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@BuyingRate", conver.BuyingRate, System.Data.DbType.Decimal));                       
                        paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                        paramCollection.Add(new DBParameter("@CurrencyId", conver.id));

                        System.Data.IDataReader drcurr =
                   _dbHelper.ExecuteDataReader("spUpdateCurrencyConversionDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }
                    else
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@ParentId", (objCurcov.CcID)));
                        paramCollection.Add(new DBParameter("@Currency", (conver.Currency)));
                        paramCollection.Add(new DBParameter("@TandardRate", conver.StandardRate, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@SellingRate", conver.SellingRate, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@BuyingRate", conver.BuyingRate, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                        //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                        System.Data.IDataReader drcurr =
                       _dbHelper.ExecuteDataReader("spInsertCurrencyConversionDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }
                }
                isUpdate = true;
            }
            catch (Exception ex)
            {
                isUpdate = false;
                throw ex;
            }

            return isUpdate;
        }
        //Delete Currency Conversion
        public bool DeleteCurrencyConversion(int id)
        {
            bool isDelete = false;
            try
            {
                if (DeleteCurrencyConversionDetails(id))
                {
                    string Query = "DELETE FROM `currencyconversion` WHERE `CC_Id`=" + id;

                    if (_dbHelper.ExecuteNonQuery(Query) > 0)

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
        //Delete Currency Conversion Details
        public bool DeleteCurrencyConversionDetails(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE  FROM `currencyconversiondetails` WHERE `CC_Id`=" + id;
                if (_dbHelper.ExecuteNonQuery(Query) > 0)
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }

        //List All Currencys
        public List<CurrencyConversionDetailsModel> GetAllCurrencyConversions()
        {
            List<CurrencyConversionDetailsModel> lstCurr = new List<CurrencyConversionDetailsModel>();
            CurrencyConversionDetailsModel objCurr;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT C.Date,C.CC_Id,A.Currency,A.TandardRate, A.SellingRate,A.BuyingRate FROM currencyconversion C ");
            sbQuery.Append("INNER JOIN currencyconversiondetails A ");
            sbQuery.Append("ON A.CC_Id = C.CC_Id ");

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());


            while (dr.Read())
            {
                objCurr = new CurrencyConversionDetailsModel();
                objCurr.Date = Convert.ToDateTime(dr["Date"]);
                objCurr.id = Convert.ToInt32(dr["CC_Id"]);
                objCurr.Currency = dr["Currency"].ToString();
                objCurr.StandardRate = Convert.ToDecimal(dr["TandardRate"].ToString());
                objCurr.SellingRate =Convert.ToDecimal(dr["SellingRate"].ToString());
                objCurr.BuyingRate =Convert.ToDecimal(dr["BuyingRate"].ToString());

               lstCurr.Add(objCurr);                
            }

            return lstCurr;
        }

        //Get List of Currency Conversions
        public List<CurrencyConversionModel> GetCurrencyConversionbyId(int id)
        {
            List<CurrencyConversionModel> lstCurrCon = new List<CurrencyConversionModel>();
            CurrencyConversionModel objCurrCon;
            string Query = "SELECT * FROM `currencyconversion` WHERE `CC_Id`=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objCurrCon = new CurrencyConversionModel();

                objCurrCon.CcID = Convert.ToInt32(dr["CC_Id"]);
                objCurrCon.Date =Convert.ToDateTime(dr["Date"].ToString());         
                
                //SELECT Currency Conversion Details
                string CurrQuery = "SELECT * FROM `currencyconversiondetails` WHERE `CC_Id`=" +id;
                System.Data.IDataReader drConn = _dbHelper.ExecuteDataReader(CurrQuery, _dbHelper.GetConnObject());

                objCurrCon.CurrenyDetails = new List<CurrencyConversionDetailsModel>();
                CurrencyConversionDetailsModel objCurrency;

                while (drConn.Read())
                {
                    objCurrency = new CurrencyConversionDetailsModel();

                    objCurrency.id = Convert.ToInt32(drConn["Currency_Id"]);
                    objCurrency.ParentId = Convert.ToInt32(drConn["CC_Id"]);
                    objCurrency.StandardRate = Convert.ToDecimal(drConn["TandardRate"]);
                    objCurrency.SellingRate = Convert.ToDecimal(drConn["SellingRate"]);
                    objCurrency.BuyingRate = Convert.ToDecimal(drConn["BuyingRate"]);
                    objCurrency.Currency = drConn["Currency"].ToString();
                    objCurrCon.CurrenyDetails.Add(objCurrency);

                }

                lstCurrCon.Add(objCurrCon);

            }
            return lstCurrCon;
        }
    }
}
