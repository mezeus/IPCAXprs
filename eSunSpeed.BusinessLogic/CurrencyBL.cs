using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;

namespace eSunSpeed.BusinessLogic
{
   public class CurrencyBL
    {
        private DBHelper _dbHelper = new DBHelper();

        //Save

        public bool SaveCurrency(CurrencyMasterModel objCur)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Symbol", objCur.Symbol));
                paramCollection.Add(new DBParameter("@String", objCur.CString));
                paramCollection.Add(new DBParameter("@SubString", objCur.SubString));
                paramCollection.Add(new DBParameter("@ConversionMode", objCur.ConvertionMode));
                paramCollection.Add(new DBParameter("@CreatedBy", objCur.CreatedBy));                                

                Query = "INSERT INTO CurrencyMaster(`Symbol`,`CString`,`SubString`,`ConversionMode`,`CreatedBy`) " +
                         "VALUES(@Symbol,@String,@SubString,@ConversionMode,@CreatedBy)";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    isSaved = true;
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        //UPDATE
        public bool UpdateCurrency(CurrencyMasterModel objCur)
        {
            string Query = string.Empty;
            bool isUpdated = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Symbol", objCur.Symbol));
                paramCollection.Add(new DBParameter("@String", objCur.CString));
                paramCollection.Add(new DBParameter("@SubString", objCur.SubString));
                paramCollection.Add(new DBParameter("@ConversionMode", objCur.ConvertionMode));
                paramCollection.Add(new DBParameter("@ModifiedBy",objCur.ModifiedBy));
                paramCollection.Add(new DBParameter("@CM_ID", objCur.CM_ID));


                Query = "UPDATE CurrencyMaster SET Symbol=@Symbol,CString=@String,SubString=@SubString,`ConversionMode`=@ConversionMode,ModifiedBy=@ModifiedBy " +
                        "WHERE CM_ID=@CM_ID";


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
        //Delete Single Currency
        public bool DeletCurrency(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE FROM currencymaster WHERE CM_ID=" + id;
                int rowes = _dbHelper.ExecuteNonQuery(Query);
                if (rowes > 0)
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }
        //List
        public List<CurrencyMasterModel> GetAllCurrency()
        {
            List<CurrencyMasterModel> lstCurr = new List<CurrencyMasterModel>();
            CurrencyMasterModel objCurr;
           
            string Query = "SELECT DISTINCT CM_ID,Symbol,CString,SubString,ConversionMode FROM `CurrencyMaster`";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objCurr = new CurrencyMasterModel();
                objCurr.CM_ID = Convert.ToInt32(dr["CM_ID"]);
                objCurr.Symbol = dr["Symbol"].ToString();
                objCurr.CString = dr["CString"].ToString();
                objCurr.SubString = dr["SubString"].ToString();
                objCurr.ConvertionMode = dr["ConversionMode"].ToString();
                //objCurr.ModifiedBy = dr["ModifiedBy"].ToString();

               lstCurr.Add(objCurr);                
            }

            return lstCurr;
        }

        public CurrencyMasterModel GetAllCurrencyById(int id)
        {
            CurrencyMasterModel objCurr = new CurrencyMasterModel();

            string Query = "SELECT * FROM CurrencyMaster WHERE CM_ID="+id+"";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objCurr = new CurrencyMasterModel();
                objCurr.CM_ID = Convert.ToInt32(dr["CM_ID"]);
                objCurr.Symbol = dr["Symbol"].ToString();
                objCurr.CString = dr["CString"].ToString();
                objCurr.SubString = dr["SubString"].ToString();
                objCurr.ConvertionMode = dr["ConversionMode"].ToString();
     
            }

            return objCurr;
        }

        //If is Currency Exists
        public bool IsCurrencyExists(string MasterName)
        {
            StringBuilder _sbQuery = new StringBuilder();
            _sbQuery.AppendFormat("SELECT COUNT(*) FROM currencymaster WHERE Symbol='{0}'", MasterName);

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(_sbQuery.ToString(), _dbHelper.GetConnObject());
            dr.Read();
            if (Convert.ToInt32(dr[0]) > 0)
                return true;
            else
                return false;

        }
    }
}
