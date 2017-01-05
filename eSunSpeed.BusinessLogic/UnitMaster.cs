using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;


namespace eSunSpeed.BusinessLogic
{
    public class UnitMaster
    {
        private DBHelper _dbHelper = new DBHelper();
        public bool SaveUM(eSunSpeedDomain.UnitMasterModel objUM)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@UnitName", objUM.UnitName));
                paramCollection.Add(new DBParameter("@PrintName", objUM.PrintName));
                paramCollection.Add(new DBParameter("@UnitNameforexciseEreturn", objUM.ExciseReturn));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));


                Query = "INSERT INTO UnitMaster(`UnitName`,`PrintName`,`ExciseReturn`,`CreatedBy`) " +
                    "VALUES(@UnitName,@PrintName,@UnitNameforexciseEreturn,@CreatedBy)";

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
        public bool UpdateUM(eSunSpeedDomain.UnitMasterModel objUM)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@UnitName", objUM.UnitName));
                paramCollection.Add(new DBParameter("@PrintName", objUM.PrintName));
                paramCollection.Add(new DBParameter("@ExciseReturn", objUM.ExciseReturn));
                paramCollection.Add(new DBParameter("@ModifiedBy", objUM.ModifiedBy));
                paramCollection.Add(new DBParameter("@UM_ID", objUM.UM_ID));


                Query = "UPDATE UnitMaster SET UnitName=@UnitName,PrintName=@PrintName,ExciseReturn=@ExciseReturn,ModifiedBy=@ModifiedBy " +
                  "WHERE UM_Id=@UM_Id";

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

        #region Delete Unit
        /// <summary>
        /// Modified UNIT
        /// </summary>
        /// <param name="UNITIDS"></param>
        /// <returns>True/False</returns>
        public bool DeletUnit(List<int> unitids)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int uid in unitids)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@UM_id", uid));
                    Query = "Delete from unitmaster WHERE [UM_id]=@UM_id";

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
        #endregion
        //Delete Unitmaster By Id
        public bool DeleteUnitMasterById(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE FROM UnitMaster WHERE UM_ID=" + id;
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

        #region Get List of Units
        public List<UnitMasterModel> GetListofUnits()
        {
            List<UnitMasterModel> lsObj = new List<UnitMasterModel>();
            UnitMasterModel obj;

            try
            {
                string Query = "SELECT DISTINCT UM_ID,UnitName,PrintName FROM `UnitMaster`";
                System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

                while (dr.Read())
                {
                    //Initialize/reset account master object
                    obj = new UnitMasterModel();

                    obj.UM_ID = Convert.ToInt32(dr["UM_ID"]);
                    obj.UnitName = dr["UnitName"].ToString();
                    obj.PrintName = dr["PrintName"].ToString();
                  
                    lsObj.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lsObj;
        }
        #endregion

        public UnitMasterModel GetListofUnitsById(int id)
        {
            UnitMasterModel obj = new UnitMasterModel();

            try
            {
                string Query = "SELECT * FROM `UnitMaster` WHERE UM_ID="+id+"";
                System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

                while (dr.Read())
                {

                    obj.UM_ID = Convert.ToInt32(dr["UM_ID"]);
                    obj.UnitName = dr["UnitName"].ToString();
                    obj.PrintName = dr["PrintName"].ToString();
                    obj.ExciseReturn = dr["ExciseReturn"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }
    }
}
