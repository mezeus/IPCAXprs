using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeed.BusinessLogic
{
    public class ReceviedVoucherModelBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region SAVE FormRecevied VOUCHER
        public bool SaveReceviedVoucher(ReceviedVoucherModel objRecevied)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Date", objRecevied.Date, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Form", objRecevied.form));
                paramCollection.Add(new DBParameter("@Series", objRecevied.Series));
                paramCollection.Add(new DBParameter("@Issuingoffice", objRecevied.issuingoffice));
                paramCollection.Add(new DBParameter("@Formnumber", objRecevied.fromNo));
                paramCollection.Add(new DBParameter("@DateofIssue", objRecevied.issuedDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Stateofissue", objRecevied.stateofissue));
                paramCollection.Add(new DBParameter("@Party", objRecevied.party));
                paramCollection.Add(new DBParameter("@Narration", objRecevied.Narration));
                paramCollection.Add(new DBParameter("@TotalAmount", "0"));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertFormRcvdMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);
                SaveReceviedDetails(objRecevied.ReceviedModel, id);
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        public bool SaveReceviedDetails(List<ReceviedModel> lstRec,int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;

            foreach (ReceviedModel Rec in lstRec)
            {
                Rec.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@RcvdId", (Rec.ParentId)));
                    paramCollection.Add(new DBParameter("@Voucherno", (Rec.VoucherNo)));
                    paramCollection.Add(new DBParameter("@Dated", Rec.Dated));
                    paramCollection.Add(new DBParameter("@Amount", Rec.Amount));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                    System.Data.IDataReader dr =
                     _dbHelper.ExecuteDataReader("spInsertFormRcvdDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

      

        public int GetReceviedtId()
        {
            string Query = "SELECT MAX(Recevied_Id) FROM Recevied_Voucher";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }


        #endregion

        //Udate Recevied Voucher
        public bool UpdateReceviedVoucher(ReceviedVoucherModel objRecevied)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                //UPDATE Recevied TABLE - PARENT TABLE

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Date", objRecevied.Date, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Series", objRecevied.Series));
                paramCollection.Add(new DBParameter("@IssuingOffice", objRecevied.issuingoffice));
                paramCollection.Add(new DBParameter("@FromNo", objRecevied.fromNo));
                paramCollection.Add(new DBParameter("@Party", objRecevied.party));
                paramCollection.Add(new DBParameter("@DateOfIssue", objRecevied.issuedDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@StateOfIssue", objRecevied.stateofissue));
                paramCollection.Add(new DBParameter("@Narration", objRecevied.Narration));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@id", objRecevied.RV_Id));
                //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                Query = "UPDATE Recevied_Voucher SET [Recevied_Date]=@Date,[Series]=@Series,[Issuing Office]=@IssuingOffice," +
                         "[FromNo]=@FromNo,[Party]=@Party,[DateOfIssue]=@DateOfIssue,[StateOfIssue]=StateOfIssue,[Narration]=@Narration," +
                        "[ModifiedBy]=@ModifiedBy " +
                        " WHERE Recevied_Id=@id";

                //Query = "UPDATE Recevied_Voucher SET [Recevied_Date]=@Date,[Series]=@Series,[Issuing Office]=@IssuingOffice," +
                //         "[FromNo]=@FromNo,[Party]=@Party,[DateOfIssue]=@DateOfIssue,[StateOfIssue]=StateOfIssue,[Narration]=@Narration," +
                //        "[ModifiedBy]=@ModifiedBy " +
                //        "WHERE Recevied_Id=@id";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    List<ReceviedModel> lstAcct = new List<ReceviedModel>();

                    //UPDATE CREDIT NOTE ACCOUNT -CHILD TABLE UPDATES
                    foreach (ReceviedModel act in objRecevied.ReceviedModel)
                    {
                        if (act.id > 0)
                        {

                            paramCollection = new DBParameterCollection();

                            
                            paramCollection.Add(new DBParameter("@VoucherNo", (act.VoucherNo)));
                            paramCollection.Add(new DBParameter("@Dated", act.Dated));
                            paramCollection.Add(new DBParameter("@amount", act.Amount));

                            paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@ID", (act.id)));
                            //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                            Query = "UPDATE Recevied_Amount_Voucher SET [VoucherNo]=@VoucherNo," +
                            "[Dated]=@Dated,[Amount]=@amount,[ModifiedBy]=@ModifiedBy " +
                            "WHERE [SNo]=@ID";

                            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                            {
                                isUpdated = true;
                            }
                        }
                        else
                        {
                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@ID", (objRecevied.RV_Id)));
                            paramCollection.Add(new DBParameter("@VoucherNo", (act.VoucherNo)));
                            paramCollection.Add(new DBParameter("@Dated", act.Dated));
                            paramCollection.Add(new DBParameter("@amount", act.Amount));

                            paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                            //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));


                            Query = "INSERT INTO Recevied_Amount_Voucher ([Recevied_Id],[VoucherNo],[Dated],[Amount]," +
                            "[CreatedBy]) VALUES " +
                            "(@ID,@VoucherNo,@Dated,@amount,@CreatedBy)";

                            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)

                                isUpdated = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                isUpdated = false;
                throw ex;
            }

            return isUpdated;
        }

        //public List<RecieptVoucherModel> GetAllRecieptVoucher()
        //{
        //    List<RecieptVoucherModel> lstReciept = new List<RecieptVoucherModel>();
        //    RecieptVoucherModel objRVoucher;

        //    string Query = "SELECT * FROM Reciept_Voucher";
        //    System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

        //    while (dr.Read())
        //    {
        //        objRVoucher = new RecieptVoucherModel();

        //        objRVoucher.RV_Id = DataFormat.GetInteger(dr["Reciept_Id"]);
        //        objRVoucher.Voucher_Series = dr["Series"].ToString();
        //        objRVoucher.RV_Date = DataFormat.GetDateTime(dr["Reciept_Date"]);
        //        objRVoucher.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
        //        objRVoucher.Type = dr["Type"].ToString();
        //        objRVoucher.PDCDate = Convert.ToDateTime(dr["PDCDate"].ToString());

        //        //SELECT Reciept Voucher Accounts

        //        string itemQuery = "SELECT * FROM Reciept_Voucher_Accounts WHERE Reciept_Id=" + objRVoucher.RV_Id;
        //        System.Data.IDataReader drAcc = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

        //        objRVoucher.RecieptAccountModel = new List<AccountModel>();
        //        AccountModel objAcc;

        //        while (drAcc.Read())
        //        {
        //            objAcc = new AccountModel();

        //            objAcc.ParentId = DataFormat.GetInteger(drAcc["Reciept_Id"]);
        //            objAcc.AC_Id = DataFormat.GetInteger(drAcc["AC_Id"]);
        //            objAcc.DC = drAcc["DC"].ToString();
        //            objAcc.Account = drAcc["Account"].ToString();
        //            objAcc.Debit = Convert.ToDecimal(drAcc["Debit"]);
        //            objAcc.Credit = Convert.ToDecimal(drAcc["Credit"]);
        //            objAcc.Narration = drAcc["Narration"].ToString();


        //            objRVoucher.RecieptAccountModel.Add(objAcc);

        //        }

        //        lstReciept.Add(objRVoucher);

        //    }
        //    return lstReciept;
        //}

        //Delete RecieptVoucherModel
        public bool DeleteRecieptVoucher(int id)
        {
            bool isDelete = true;
            try
            {
                DeleteRecieptAccounts(id);
                string Query = "DELETE * FROM Reciept_Voucher WHERE Reciept_Id=" + id;

                if (_dbHelper.ExecuteNonQuery(Query) > 0)
                                  
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }

        public bool DeleteRecieptAccounts(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE * FROM Reciept_Voucher_Accounts WHERE Reciept_Id=" + id;

                if (_dbHelper.ExecuteNonQuery(Query) > 0)
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }

        public List<ListVoucherModel> GetAllReceviedVoucher()
        {
            List<ListVoucherModel> lstModel = new List<ListVoucherModel>();
            ListVoucherModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT C.Recevied_Id, C.Recevied_Date, C.Party, A.VoucherNo, A.Amount FROM Recevied_Voucher C ");
            sbQuery.Append("INNER JOIN Recevied_Amount_Voucher A ");
            sbQuery.Append("ON A.Recevied_Id = C.Recevied_Id;");

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new ListVoucherModel();

                objList.Recevied_Id = Convert.ToInt32(dr["RECEVIED_ID"]);
                objList.Date = Convert.ToDateTime(dr["Recevied_Date"]);
                objList.Party = Convert.ToString(dr["Party"]);
                objList.VoucherNo = Convert.ToInt32(dr["VoucherNo"]);             
                objList.Amount = Convert.ToDecimal(dr["Amount"]);
                lstModel.Add(objList);

            }
            return lstModel;
        }

        public List<ReceviedVoucherModel> GetReceviedVoucherbyId(int id)
        {
            List<ReceviedVoucherModel> lstRecevied = new List<ReceviedVoucherModel>();
            ReceviedVoucherModel objRecevied;

            string Query = "SELECT * FROM Recevied_Voucher WHERE Recevied_Id=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objRecevied = new ReceviedVoucherModel();

                objRecevied.RV_Id = DataFormat.GetInteger(dr["Recevied_ID"]);
                objRecevied.Date = DataFormat.GetDateTime(dr["Recevied_Date"]);
                objRecevied.Series =dr["Series"].ToString();
                objRecevied.issuingoffice = dr["Issuing Office"].ToString();
                objRecevied.fromNo = DataFormat.GetInteger(dr["FromNo"]);
                objRecevied.party = dr["Party"].ToString();
                objRecevied.issuedDate = DataFormat.GetDateTime(dr["DateOfIssue"]);
                objRecevied.stateofissue = dr["StateOfIssue"].ToString();
                objRecevied.Narration = dr["Narration"].ToString();


                //SELECT Recevied Amount Voucher 

                string itemQuery = "SELECT * FROM Recevied_Amount_Voucher WHERE Recevied_Id=" + id;
                System.Data.IDataReader drRec = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objRecevied.ReceviedModel = new List<ReceviedModel>();
                ReceviedModel objrec;

                while (drRec.Read())
                {
                    objrec = new ReceviedModel();

                    objrec.id = DataFormat.GetInteger(drRec["SNo"]);
                    objrec.ParentId = DataFormat.GetInteger(drRec["Recevied_ID"]);
                    objrec.VoucherNo = DataFormat.GetInteger(drRec["VoucherNo"]);
                    objrec.Dated = drRec["Dated"].ToString();
                    objrec.Amount = Convert.ToDecimal(drRec["Amount"]);


                    objRecevied.ReceviedModel.Add(objrec);

                }

                lstRecevied.Add(objRecevied);
            }
            return lstRecevied;
        }

    }
}
