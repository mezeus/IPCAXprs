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
        public bool UpdateIGM(ItemGroupMasterModel objIGM)
        {
            string Query = string.Empty;
            bool isUpdate = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ItemGroup", objIGM.ItemGroup));
                paramCollection.Add(new DBParameter("@Alias", objIGM.Alias));
                paramCollection.Add(new DBParameter("@PrimaryGroup", objIGM.PrimaryGroup, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@UnderGroup", objIGM.UnderGroup));
                paramCollection.Add(new DBParameter("@StockAccount", objIGM.StockAccount));
                paramCollection.Add(new DBParameter("@SalesAccount", objIGM.SalesAccount));
                paramCollection.Add(new DBParameter("@PurchaseAccount", objIGM.PurchaseAccount));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                paramCollection.Add(new DBParameter("@IGM_Id",objIGM.IGM_id));

                Query = "UPDATE ItemGroupMaster SET [ItemGroup]=@ItemGroup,[Alias]=@Alias,[PrimaryGroup]=@PrimaryGroup,[UnderGroup]=@UnderGroup,[StockAccount]=@StockAccount,[SalesAccount]=@SalesAccount," +
                   "[PurchaseAccount]=@PurchaseAccount,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                   "WHERE IGM_Id=@IGM_Id";
                
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
    }
}
