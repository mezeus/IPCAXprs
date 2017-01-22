using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeed.DataAccess;
using eSunSpeedDomain;

namespace eSunSpeed.BusinessLogic
{
    public class StdNarrationMasterBL
    {
        private DBHelper _dbHelper = new DBHelper();
        //Save
        public bool SaveStdNarration(eSunSpeedDomain.StdNarrationMasterModel objSNM)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Vouchertype", objSNM.Vouchertype));
                paramCollection.Add(new DBParameter("@Narration", objSNM.Narration));
                paramCollection.Add(new DBParameter("@Narration2", objSNM.Narration2));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                Query = "INSERT INTO StdNarrationMaster(`Vouchertype`,`Narration`,`Narration2`,`CreatedBy`) " +
                    "VALUES(@Vouchertype,@Narration,@Narration2,@CreatedBy)";

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
        public bool UpdateStdNarration(eSunSpeedDomain.StdNarrationMasterModel objSNM)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Vouchertype", objSNM.Vouchertype));
                paramCollection.Add(new DBParameter("@Narration", objSNM.Narration));
                paramCollection.Add(new DBParameter("@Narration2", objSNM.Narration2));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate",DateTime.Now));
                paramCollection.Add(new DBParameter("@SN_Id", objSNM.SN_Id));

                Query = "UPDATE StdNarrationMaster SET Vouchertype=@Vouchertype,Narration=@Narration,Narration2=@Narration2,ModifiedBy=@ModifiedBy " +
                        "WHERE SN_Id=@SN_Id;";
                    
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
        //List
        public List<eSunSpeedDomain.StdNarrationMasterModel> GetAllStdNarration()
        {
            List<eSunSpeedDomain.StdNarrationMasterModel> lstNarration = new List<StdNarrationMasterModel>();
            eSunSpeedDomain.StdNarrationMasterModel objNarr;

            string Query = "SELECT DISTINCT SN_ID,Narration,Vouchertype FROM `StdNarrationMaster`";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objNarr = new StdNarrationMasterModel();

                objNarr.SN_Id = Convert.ToInt32(dr["SN_ID"]);
                objNarr.Vouchertype = dr["Vouchertype"].ToString();
                objNarr.Narration = dr["Narration"].ToString();             
                //objNarr.CreatedBy = dr["CreatedBy"].ToString();

                lstNarration.Add(objNarr);

            }
            return lstNarration;
        }
        //Get All Stdnarrations By ID
        public StdNarrationMasterModel GetAllStdNarrationById(int id)
        {
            StdNarrationMasterModel objNarr = new StdNarrationMasterModel();

            string Query = "SELECT * FROM StdNarrationMaster WHERE SN_ID="+id+"";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objNarr.SN_Id = Convert.ToInt32(dr["SN_ID"]);
                objNarr.Vouchertype = dr["Vouchertype"].ToString();
                objNarr.Narration = dr["Narration"].ToString();
                objNarr.Narration2 = dr["Narration2"].ToString();
            }
            return objNarr;
        }

        //Delete Standed Narration
        public bool DeletStdNarration(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE FROM stdnarrationmaster WHERE SN_Id=" + id;
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
    }
}
