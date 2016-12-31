
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using System.Data;
using eSunSpeedDomain;
using eSunSpeed.BusinessLogic;

namespace eSunSpeed.BusinessLogic
{
    public class TdsModelBL
    {
        TdsModel objtds = new TdsModel();

        
        private DBHelper _dbHelper = new DBHelper();       
        
        public bool SaveTdsModel(TdsModel objtds)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@TdsCategoryName", objtds.TdsCategoryName));
                paramCollection.Add(new DBParameter("@SelectCode", objtds.Selectcode));                           

                Query = "INSERT INTO tdscategory(`TdsCategoryName`,`SelectCode`) " +
                    "VALUES(@TdsCategoryName,@SelectCode)";

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

        //Update Tds category
        public bool UpdateTdsModel(TdsModel objtds)
        {
            string Query = string.Empty;
            bool isSaved = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@TdsCategoryName", objtds.TdsCategoryName));
                paramCollection.Add(new DBParameter("@SelectCode", objtds.Selectcode));
                paramCollection.Add(new DBParameter("@Tds_ID", objtds.Tds_Id));

                Query = "UPDATE tdscategory SET TdsCategoryName=@TdsCategoryName,SelectCode=@SelectCode " +
                       "WHERE Tds_ID=@Tds_ID";

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

        public List<TdsModel> GetListofTDS()
        {
            List<TdsModel> lstTdsCategory = new List<TdsModel>();
            TdsModel objTds;

            string Query = "SELECT * FROM `tdscategory`";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objTds = new TdsModel();

                objTds.Tds_Id = Convert.ToInt32(dr["Tds_Id"]);
                objTds.TdsCategoryName = dr["TdsCategoryName"].ToString();
                objTds.Selectcode = dr["SelectCode"].ToString();

                lstTdsCategory.Add(objTds);
            }
            return lstTdsCategory;
        }
        //Get List Of Details By Id
        public TdsModel GetListofTDSById(int id)
        {
            TdsModel objTds = new TdsModel();

            string Query = "SELECT * FROM `tdscategory` WHERE Tds_Id="+id+"";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objTds.Tds_Id = Convert.ToInt32(dr["Tds_Id"]);
                objTds.TdsCategoryName = dr["TdsCategoryName"].ToString();
                objTds.Selectcode = dr["SelectCode"].ToString();
            }
            return objTds;
        }

    }
}
    
        




    