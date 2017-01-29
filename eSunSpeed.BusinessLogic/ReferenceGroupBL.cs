using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using System.Data;

namespace eSunSpeed.BusinessLogic
{
    public class ReferenceGroupBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region Save Reference Group
        /// <summary>
        /// Save Reference Group
        /// </summary>
        /// <param name="objReferenceGroup"></param>
        /// <returns>True/False</returns>
        public bool SaveReferenceGroup(eSunSpeedDomain.ReferenceGroupModel objrefGrp)
        {
            string Query = string.Empty;
            bool IsSaved = false;          

            DBParameterCollection paramCollection = new DBParameterCollection();
            try
            {
                paramCollection.Add(new DBParameter("@Name", objrefGrp.Name));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", string.Empty));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                Query = "INSERT INTO Referencegroup(`Name`,`CreatedBy`,`CreatedDate`,`ModifiedBy`,`ModifiedDate`) VALUES (@Name,@CreatedBy,@CreatedDate,@ModifiedBy,@ModifiedDate)";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    IsSaved = true;
            }
             catch(Exception ex)
            {
                IsSaved = false;
                throw ex;
            }
            return IsSaved;            
        }
        #endregion 
        //Update Reference Group
        public bool UpdateReferenceGroup(eSunSpeedDomain.ReferenceGroupModel objrefGrp)
        {
            string Query = string.Empty;
            bool IsUpdate = false;

            DBParameterCollection paramCollection = new DBParameterCollection();
            try
            {
                paramCollection.Add(new DBParameter("@Name", objrefGrp.Name));
                paramCollection.Add(new DBParameter("@CreatedBy",string.Empty));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy","Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@ReferenceId",objrefGrp.ReferenceId));
                Query = "UPDATE Referencegroup SET Name=@Name,CreatedBy=@CreatedBy,CreatedDate=@CreatedDate,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate "+
                    "WHERE RG_ID=@ReferenceId";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    IsUpdate = true;
            }
            catch (Exception ex)
            {
                IsUpdate = false;
                throw ex;
            }
            return IsUpdate;
        }
        //Get Lis Of All Reference Group
        public List<ReferenceGroupModel> GetAllReferenceGroups()
        {
            List<ReferenceGroupModel> lstRefGrp = new List<ReferenceGroupModel>();
            eSunSpeedDomain.ReferenceGroupModel referencegroup;

            string Query = "SELECT DISTINCT RG_ID,Name FROM `referencegroup`";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                referencegroup = new ReferenceGroupModel();

                referencegroup.ReferenceId = Convert.ToInt32(dr["RG_ID"]);
                referencegroup.Name = dr["Name"].ToString();

                lstRefGrp.Add(referencegroup);
            }

            return lstRefGrp;
        }
        //Get Reference Group Details By Id
        public ReferenceGroupModel GetReferenceDetailsById(int id)
        {
            ReferenceGroupModel objReference = new ReferenceGroupModel();

            string Query = "SELECT * FROM referencegroup WHERE RG_ID=" + id + "";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objReference.ReferenceId = Convert.ToInt32(dr["RG_ID"]);
                objReference.Name = dr["Name"].ToString();
            }

            return objReference;

        }
        //Delete Referenc Group Details
        public bool DeleteReferenceGroup(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE FROM referencegroup WHERE RG_ID=" + id;
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
        //Reference Group Is Exists Or Not
        public bool IsReferenceExists(string groupName)
        {
            StringBuilder _sbQuery = new StringBuilder();
            _sbQuery.AppendFormat("SELECT COUNT(*) FROM referencegroup WHERE Name='{0}'", groupName);

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(_sbQuery.ToString(), _dbHelper.GetConnObject());
            dr.Read();
            if (Convert.ToInt32(dr[0]) > 0)
                return true;
            else
                return false;

        }
    }
}
