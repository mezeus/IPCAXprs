using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;

namespace eSunSpeed.BusinessLogic
{
  public  class MasterseriesBL
    {
        MasterseriesModel objmasmod = new MasterseriesModel();
        private DBHelper _dbHelper = new DBHelper();

        //Save
        public bool SaveMasterSeries(MasterseriesModel objmasmod)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@MasterName", objmasmod.MasterName));
                paramCollection.Add(new DBParameter("@CreatedBy","Admin"));
                
                Query = "INSERT INTO masterseriesgroup (`Name`) " +
                    "VALUES(@MasterName)";

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

        //Update
        public bool UpdateMasterSeries(MasterseriesModel objmasmod)
        {
            string Query = string.Empty;
            bool isUpdate = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@MasterName", objmasmod.MasterName));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@SN_Id", objmasmod.MasterId));

                Query = "UPDATE masterseriesgroup SET Name=@MasterName " +
                        "WHERE masid=@SN_Id;";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    isUpdate = true;
            }
            catch (Exception ex)
            {
                isUpdate = false;
                throw ex;
            }

            return isUpdate;
        }

        //Is Material Series Exists
        public bool IsMaterialSeriesExists(string SeriesName)
        {
            StringBuilder _sbQuery = new StringBuilder();
            _sbQuery.AppendFormat("SELECT COUNT(*) FROM masterseriesgroup WHERE Name='{0}'", SeriesName);

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(_sbQuery.ToString(), _dbHelper.GetConnObject());
            dr.Read();
            if (Convert.ToInt32(dr[0]) > 0)
                return true;
            else
                return false;

        }

        public bool DeletITG(List<int> lstIds)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int id in lstIds)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@IGM_ID", id));
                    Query = "Delete from ItemGroupMaster WHERE [IGM_ID]=@IGM_ID";

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
        
        //Delete MasterSeries Group
        public bool DeleteMasterSeriesGroup(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE FROM masterseriesgroup WHERE masid=" + id;
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
        public List<eSunSpeedDomain.MasterseriesModel> GetListofMasterSeries()
        {
            List<eSunSpeedDomain.MasterseriesModel> lstmasterseries = new List<eSunSpeedDomain.MasterseriesModel>();
            eSunSpeedDomain.MasterseriesModel masterseries;

            string Query = "SELECT DISTINCT masid,Name FROM `masterseriesgroup`";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                masterseries = new eSunSpeedDomain.MasterseriesModel();

                masterseries.MasterId = Convert.ToInt32(dr["masid"]);
                masterseries.MasterName = dr["Name"].ToString();

                lstmasterseries.Add(masterseries);

            }

            return lstmasterseries;
        }

        public MasterseriesModel GetListofMasterSeriesById(int id)
        {
            MasterseriesModel masterseries = new MasterseriesModel();

            string Query = "SELECT * FROM masterseriesgroup WHERE masid="+id+"";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                masterseries.MasterId = Convert.ToInt32(dr["masid"]);
                masterseries.MasterName = dr["Name"].ToString();
            }

            return masterseries;

        }
    }
}
