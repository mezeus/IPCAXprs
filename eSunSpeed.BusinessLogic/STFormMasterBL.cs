using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeed.DataAccess;
using eSunSpeedDomain;

namespace eSunSpeed.BusinessLogic
{
    public class STFormMasterBL
    {
        private DBHelper _dbHelper = new DBHelper();
        public bool SaveSTF(STFormMasterModel objSTF)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Name", objSTF.Name));
                paramCollection.Add(new DBParameter("@PrintName", objSTF.PrintName));
                paramCollection.Add(new DBParameter("@STRegType", objSTF.STRegType));
                paramCollection.Add(new DBParameter("@CreatedBy", objSTF.CreatedBy));

                Query = "INSERT INTO STFormMaster(`Name`,`PrintName`,`STRegType`,`CreatedBy`) " +
                         "VALUES(@Name,@PrintName,@STRegType,@CreatedBy)";

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

        //update
        public bool UpdateSTF(STFormMasterModel objSTF)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Name", objSTF.Name));
                paramCollection.Add(new DBParameter("@PrintName", objSTF.PrintName));
                paramCollection.Add(new DBParameter("@STRegType", objSTF.STRegType));
                paramCollection.Add(new DBParameter("@ModifiedBy", objSTF.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now,System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@STF_ID", objSTF.STF_Id));


                Query = "UPDATE STFormMaster SET `Name`=@Name,`PrintName`=@PrintName,`STRegType`=@STRegType,`ModifiedBy`=@ModifiedBy,`ModifiedDate`=@ModifiedDate " +                  
                        "WHERE `STF_Id`=@STF_Id";

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

        public List<STFormMasterModel> GetAllSTF()
        {
            List<STFormMasterModel> lstSTF = new List<STFormMasterModel>();
            STFormMasterModel objModel;

            string Query = "SELECT DISTINCT STF_Id,Name,PrintName FROM STFormMaster";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objModel = new STFormMasterModel();

                objModel.STF_Id = Convert.ToInt32(dr["STF_Id"]);
                objModel.Name = dr["Name"].ToString();
                objModel.PrintName= dr["PrintName"].ToString();
                
                lstSTF.Add(objModel);
            }

            return lstSTF;
        }

        //Get List Of ST Form Details By Id
        public STFormMasterModel GetAllSTFById(int id)
        {
            STFormMasterModel objModel = new STFormMasterModel();

            string Query = "SELECT * FROM `STFormMaster` WHERE STF_Id="+id+"";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objModel.STF_Id = Convert.ToInt32(dr["STF_Id"]);
                objModel.Name = dr["Name"].ToString();
                objModel.PrintName = dr["PrintName"].ToString();
                objModel.STRegType = dr["STRegType"].ToString();
            }

            return objModel;
        }

        //Delete
        public bool DeleteST(List<int> lstIds)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int id in lstIds)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@STF_Id", id));
                    Query = "Delete from STFormMaster WHERE [STF_Id]=@STF_ID";

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
        //Delete ST Form Master By Id
        public bool DeleteSTById(int id)
        {
            string Query = string.Empty;
            bool isUpdated = true;
            try
            {
              Query = "Delete from `STFormMaster` WHERE `STF_Id`="+id+"";
              if (_dbHelper.ExecuteNonQuery(Query) > 0)
              isUpdated = true;
            }
            catch (Exception ex)
            {
                isUpdated = false;
                throw ex;
            }

            return isUpdated;
        }
        //Is ST Form Name Is Exist or Not
        public bool IsSTNameExists(string STName)
        {
            StringBuilder _sbQuery = new StringBuilder();
            _sbQuery.AppendFormat("SELECT COUNT(*) FROM STFormMaster WHERE Name='{0}'", STName);

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(_sbQuery.ToString(), _dbHelper.GetConnObject());
            dr.Read();
            if (Convert.ToInt32(dr[0]) > 0)
                return true;
            else
                return false;

        }
    }
}
