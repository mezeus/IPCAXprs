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
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                Query = "INSERT INTO StdNarrationMaster(`Vouchertype`,`Narration`,`CreatedBy`) " +
                    "VALUES(@Vouchertype,@Narration,@CreatedBy)";

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
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate",DateTime.Now));
                paramCollection.Add(new DBParameter("@SN_Id", objSNM.SN_Id));

                Query = "UPDATE StdNarrationMaster SET [Vouchertype]=@Vouchertype,[Narration]=@Narration,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
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

        #region Delete Standard Narration
      
        public bool DeleteNarration(List<int> lstIds)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int id in lstIds)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@SN_id", id));
                    Query = "Delete from stdnarrationmaster WHERE [SN_id]=@SN_id";

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
    }
}
