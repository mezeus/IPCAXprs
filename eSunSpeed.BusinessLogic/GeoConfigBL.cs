using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;

namespace eSunSpeed.BusinessLogic
{
   public class GeoConfigBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region State Info
        public List<StateModel> GetStateInfo()
        {
            List<StateModel> lstStates = new List<StateModel>();
            StateModel objModel;

            string Query = "SELECT * FROM StateMaster";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objModel = new StateModel();

                objModel.State_Id = Convert.ToInt32(dr["State_Id"]);
                objModel.State_Name = dr["State_Name"].ToString();
             
                lstStates.Add(objModel);

            }
            return lstStates;
        }
        #endregion

        #region City Info
        public List<CityModel> GetCityInfoByState(int StateId)
        {
            List<CityModel> lstCities = new List<CityModel>();
            CityModel objModel;

            string Query = "SELECT * FROM CityMaster where state_id="+StateId;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objModel = new CityModel();

                objModel.State_Id = Convert.ToInt32(dr["State_Id"]);
                objModel.City_Id = Convert.ToInt32(dr["City_Id"]);
                objModel.City_Name = dr["City_Name"].ToString();
                                
                lstCities.Add(objModel);
            }
            return lstCities;
        }
        #endregion
    }
}
