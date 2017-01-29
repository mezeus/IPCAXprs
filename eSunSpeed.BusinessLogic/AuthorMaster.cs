using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;

namespace eSunSpeed.BusinessLogic
{
    public class AuthorMaster
    {

        private DBHelper _dbHelper = new DBHelper();

        //Save Author Master
        public bool SaveAuthorMaster(AuthorModel objAuthor)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Author_Name", objAuthor.Name));
                paramCollection.Add(new DBParameter("@Author_Alias", objAuthor.Alias));
                paramCollection.Add(new DBParameter("@Author_PrintName", objAuthor.PrintName));
                paramCollection.Add(new DBParameter("@Author_ConnectAcc", objAuthor.ConnectAcc, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Author_Address", objAuthor.Address));
                paramCollection.Add(new DBParameter("@Author_Address1", objAuthor.Address1));
                paramCollection.Add(new DBParameter("@Author_Address2", objAuthor.Address2));
                paramCollection.Add(new DBParameter("@Author_Address3", objAuthor.Address3));
                paramCollection.Add(new DBParameter("@Author_State", objAuthor.State));
                paramCollection.Add(new DBParameter("@Author_Telnumber", objAuthor.Telephone));
                paramCollection.Add(new DBParameter("@Author_MobileNo", objAuthor.MobileNo));
                paramCollection.Add(new DBParameter("@Author_email", objAuthor.Email));               

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));


                Query = "INSERT INTO AuthorMaster (`Author_Name`,`Author_Alias`,`Author_PName`,`Author_Connect`,`Author_Address`,`Author_Address1`,`Author_Address2`,`Author_Address3`," +
                        "`Author_State`,`Author_Telenumber`,`Author_Mobile`,`Author_Email`,`CreatedBy`) VALUES " +
                        "(@Author_Name,@Author_Alias,@Author_PrintName,@Author_ConnectAcc,@Author_Address,@Author_Address1,@Author_Address2,@Author_Address3," +
                        "@Author_State,@Author_Telnumber,@Author_MobileNo,@Author_email,@CreatedBy)";
                
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
        public bool UpdateAuthorMaster(eSunSpeedDomain.AuthorModel objAuthor)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Author_Name", objAuthor.Name));
                paramCollection.Add(new DBParameter("@Author_Alias", objAuthor.Alias));
                paramCollection.Add(new DBParameter("@Author_PrintName", objAuthor.PrintName));
                paramCollection.Add(new DBParameter("@Author_ConnectAcc", objAuthor.ConnectAcc, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Author_Address", objAuthor.Address));
                paramCollection.Add(new DBParameter("@Author_Address1", objAuthor.Address1));
                paramCollection.Add(new DBParameter("@Author_Address2", objAuthor.Address2));
                paramCollection.Add(new DBParameter("@Author_Address3", objAuthor.Address3));
                paramCollection.Add(new DBParameter("@Author_State", objAuthor.State));
                paramCollection.Add(new DBParameter("@Author_Telnumber", objAuthor.Telephone));
                paramCollection.Add(new DBParameter("@Author_MobileNo", objAuthor.MobileNo));
                paramCollection.Add(new DBParameter("@Author_email", objAuthor.Email));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                paramCollection.Add(new DBParameter("@Author_Id", objAuthor.Author_Id));
                
                Query = "UPDATE AuthorMaster SET Author_Name=@Author_Name,Author_Alias=@Author_Alias,Author_PName=@Author_PrintName,`Author_Connect`=@Author_ConnectAcc," +
                        "Author_Address=@Author_Address,`Author_Address1`=@Author_Address1,`Author_Address2`=Author_Address2,`Author_Address3`=@Author_Address3,Author_State=@Author_State," +
                        "Author_TeleNumber=@Author_Telnumber,Author_Mobile=@Author_MobileNo,Author_Email=@Author_Email,ModifiedBy=@ModifiedBy" +
                        " WHERE Author_Id=@Author_Id;";

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
        public List<eSunSpeedDomain.AuthorModel> GetAllAuthors()
        {
            List<eSunSpeedDomain.AuthorModel> lstAuthors = new List<eSunSpeedDomain.AuthorModel>();
            eSunSpeedDomain.AuthorModel objModel;

            string Query = "SELECT DISTINCT Author_Id,Author_Name,Author_Alias,Author_PName FROM AuthorMaster";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objModel = new eSunSpeedDomain.AuthorModel();

                objModel.Author_Id = DataFormat.GetInteger(dr["Author_Id"]);
                
                objModel.Name = dr["Author_Name"].ToString();
                objModel.Alias = dr["Author_Alias"].ToString();
                objModel.PrintName = dr["Author_PName"].ToString();
                //objModel.ConnectAcc = Convert.ToBoolean(dr["Author_Connect"]);
                //objModel.MobileNo = dr["Author_Mobile"].ToString();
                //objModel.Address = dr["Author_Address"].ToString();
                //objModel.Street = dr["Author_Street"].ToString();
                //objModel.City = dr["Author_City"].ToString();
                //objModel.Country = dr["Author_Country"].ToString();
                //objModel.State = dr["Author_State"].ToString();
                //objModel.PinCode = dr["Author_PinCode"].ToString();

                lstAuthors.Add(objModel);

            }
            return lstAuthors;
        }
        public bool DeletAuthour(List<int> lstIds)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int AM_ID in lstIds)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Author_Id", AM_ID));
                    Query = "Delete from AuthorMaster WHERE [Author_Id]=@Author_Id";

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

        //Delete Author Master
        public bool DeleteAuthorMasterDetails(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE FROM authormaster WHERE Author_Id=" + id;
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
        public AuthorModel GetAllAuthorsById(int id)
        {
            AuthorModel objModel = new AuthorModel();

            string Query = "SELECT * FROM AuthorMaster WHERE Author_Id="+id+"";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
           
                objModel.Author_Id = DataFormat.GetInteger(dr["Author_Id"]);                
                objModel.Name = dr["Author_Name"].ToString();
                objModel.Alias = dr["Author_Alias"].ToString();
                objModel.PrintName = dr["Author_PName"].ToString();
                objModel.ConnectAcc = Convert.ToBoolean(dr["Author_Connect"]);
                objModel.Address = dr["Author_Address"].ToString();
                objModel.Address1 = dr["Author_Address1"].ToString();
                objModel.Address2 = dr["Author_Address2"].ToString();
                objModel.Address3 = dr["Author_Address3"].ToString();
                objModel.State = dr["Author_State"].ToString();
                objModel.MobileNo = Convert.ToInt64(dr["Author_Mobile"].ToString()==string.Empty?"0": dr["Author_Mobile"].ToString());
                objModel.Telephone =Convert.ToInt64(dr["Author_Telenumber"].ToString()==string.Empty?"0": dr["Author_Telenumber"].ToString());                  
                objModel.Email = dr["Author_Email"].ToString();

            }
            return objModel;
        }

        //Is Author Master Exist or Not
        public bool IsAuthorMasterExists(string Name)
        {
            StringBuilder _sbQuery = new StringBuilder();
            _sbQuery.AppendFormat("SELECT COUNT(*) FROM authormaster WHERE Author_Name='{0}'", Name);

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(_sbQuery.ToString(), _dbHelper.GetConnObject());
            dr.Read();
            if (Convert.ToInt32(dr[0]) > 0)
                return true;
            else
                return false;

        }
    }
}
