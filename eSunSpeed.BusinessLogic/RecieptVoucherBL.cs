using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeed.BusinessLogic
{
    public class RecieptVoucherBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region SAVE RECIEPT VOUCHER
        public int SaveRecieptVoucher(RecieptVoucherModel objReciept)
        {
            string Query = string.Empty;
            int recid = 0;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Series", objReciept.Voucher_Series));             
                paramCollection.Add(new DBParameter("@Date", objReciept.RV_Date));
                paramCollection.Add(new DBParameter("@Voucher_Number", objReciept.Voucher_Number));
                paramCollection.Add(new DBParameter("@Type", objReciept.Type));
                paramCollection.Add(new DBParameter("@PDDate", objReciept.PDCDate));
                //paramCollection.Add(new DBParameter("@Long", objReciept.LongNarration));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                Query = "INSERT INTO Reciept_Voucher([Series],[Reciept_Date],[VoucherNo],[Type],[PDC_Date]," +
                "[CreatedBy],[CreatedDate]) VALUES " +
                "(@Series,@Date,@Voucher_Number,@Type,@PDDate, " +
                " @CreatedBy,@CreatedDate)";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    SaveRecieptAccounts(objReciept.RecieptAccountModel);
                    recid = GetRecieptId();                   
                }
            }
            catch (Exception ex)
            {
                recid = 0;
                throw ex;
            }

            return recid;
        }

        public bool SaveRecieptAccounts(List<AccountModel> lstAcc)
        {
            string Query = string.Empty;
            bool isSaved = true;

            int ParentId = GetRecieptId();

            foreach (AccountModel Acc in lstAcc)
            {
                Acc.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@RV_ID", (Acc.ParentId)));
                    paramCollection.Add(new DBParameter("@DC", (Acc.DC)));
                    paramCollection.Add(new DBParameter("@Account", Acc.Account));
                    paramCollection.Add(new DBParameter("@Debit", Acc.Debit));
                    paramCollection.Add(new DBParameter("@Credit", Acc.Credit));
                    paramCollection.Add(new DBParameter("@Narration", Acc.Narration));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));


                    Query = "INSERT INTO Reciept_Voucher_Accounts([Reciept_Id],[DC],[Account],[Debit]," +
                    "[Credit],[Narration],[CreatedBy],[CreatedDate]) VALUES " +
                    "(@RV_ID,@DC,@Account,@Debit,@Credit,@Narration,@CreatedBy,@CreatedDate)";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                        isSaved = true;
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

      

        public int GetRecieptId()
        {
            string Query = "SELECT MAX(Reciept_Id) FROM Reciept_Voucher";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }


        #endregion

        //Udate Reciept Voucher
        public bool UpdateRecieptVoucher(RecieptVoucherModel objRecipt)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                //UPDATE CREDIT NOTE TABLE - PARENT TABLE

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Series", objRecipt.Voucher_Series));
                paramCollection.Add(new DBParameter("@Date", objRecipt.RV_Date));
                paramCollection.Add(new DBParameter("@Voucher_Number", objRecipt.Voucher_Number));
                paramCollection.Add(new DBParameter("@Type", objRecipt.Type));
                paramCollection.Add(new DBParameter("@PDDate", objRecipt.PDCDate));
                //paramCollection.Add(new DBParameter("@TotalCreditAmt", "0"));
                //paramCollection.Add(new DBParameter("@TotalDebitAmt", "0"));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                paramCollection.Add(new DBParameter("@id", objRecipt.RV_Id));

                Query = "UPDATE Reciept_Voucher SET [Series]=@Series,[Reciept_Date]=@Date,[VoucherNo]=@Voucher_Number," +
                         "[Type]=@Type,[PDC_Date]=@PDDate,[ModifiedBy]=@ModifiedBy," +
                        "[ModifiedDate]=@ModifiedDate " +
                        "WHERE Reciept_Id=@id";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    List<AccountModel> lstAcct = new List<AccountModel>();

                    //UPDATE CREDIT NOTE ACCOUNT -CHILD TABLE UPDATES
                    foreach (AccountModel act in objRecipt.RecieptAccountModel)
                    {
                        if (act.AC_Id > 0)
                        {

                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@DC", (act.DC)));
                            paramCollection.Add(new DBParameter("@Account", act.Account));
                            paramCollection.Add(new DBParameter("@Debit", act.Debit));
                            paramCollection.Add(new DBParameter("@Credit", act.Credit));
                            paramCollection.Add(new DBParameter("@Narration", act.Narration));

                            paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                            paramCollection.Add(new DBParameter("@ACT_ID", act.AC_Id));

                            Query = "UPDATE Reciept_Voucher_Accounts SET [DC]=@DC," +
                            "[Account]=@Account,[Debit]=@Debit,[Credit]=@Credit,[Narration]=@Narration,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                            "WHERE [AC_Id]=@ACT_ID";

                            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                            {
                                isUpdated = true;
                            }
                        }
                        else
                        {
                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@DN_ID", (act.ParentId)));
                            paramCollection.Add(new DBParameter("@DC", (act.DC)));
                            paramCollection.Add(new DBParameter("@Account", act.Account));
                            paramCollection.Add(new DBParameter("@Debit", act.Debit));
                            paramCollection.Add(new DBParameter("@Credit", act.Credit));
                            paramCollection.Add(new DBParameter("@Narration", act.Narration));

                            paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                            Query = "INSERT INTO Reciept_Voucher_Accounts([Reciept_Id],[DC],[Account],[Debit]," +
                                               "[Credit],[Narration],[CreatedBy],[CreatedDate]) VALUES " +
                                               "(@RV_ID,@DC,@Account,@Debit,@Credit,@Narration,@CreatedBy,@CreatedDate)";

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

        public List<ListModel> GetAllRecieptVoucher()
        {
            List<ListModel> lstModel = new List<ListModel>();
            ListModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT C.RECIEPT_ID, C.RECIEPT_DATE, C.VOUCHERNO, A.ACCOUNT,A.DEBIT, A.CREDIT,A.NARRATION FROM RECIEPT_VOUCHER C ");
            sbQuery.Append("INNER JOIN RECIEPT_VOUCHER_ACCOUNTS A ");
            sbQuery.Append("ON A.RECIEPT_ID = C.RECIEPT_ID WHERE DC='C';");

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new ListModel();

                objList.Id = Convert.ToInt32(dr["RECIEPT_ID"]);

                objList.Date = Convert.ToDateTime(dr["RECIEPT_Date"]);
                objList.VoucherNo = Convert.ToInt32(dr["VOUCHERNO"]);
                objList.Account = Convert.ToString(dr["ACCOUNT"]);
                objList.Debit = Convert.ToInt32(dr["DEBIT"]);
                objList.Credit = Convert.ToInt32(dr["CREDIT"]);
                objList.Narration = Convert.ToString(dr["NARRATION"]);
                lstModel.Add(objList);

            }
            return lstModel;
        }

        public List<RecieptVoucherModel> GetRecieptbyId(int id)
        {
            List<RecieptVoucherModel> lstReciept = new List<RecieptVoucherModel>();
            RecieptVoucherModel objReciept;

            string Query = "SELECT * FROM Reciept_Voucher WHERE Reciept_Id=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objReciept = new RecieptVoucherModel();

                objReciept.RV_Id = DataFormat.GetInteger(dr["Reciept_ID"]);
                objReciept.Voucher_Series = dr["Series"].ToString();
                objReciept.RV_Date = DataFormat.GetDateTime(dr["Reciept_Date"]);
                objReciept.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objReciept.Type = dr["Type"].ToString();
                if (dr["PDC_Date"].ToString() != "")
                    objReciept.PDCDate = Convert.ToDateTime(dr["PDC_Date"]);

                //SELECT Payment Voucher Accounts

                string itemQuery = "SELECT * FROM Reciept_Voucher_Accounts WHERE Reciept_Id=" + objReciept.RV_Id;
                System.Data.IDataReader drAcc = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objReciept.RecieptAccountModel = new List<AccountModel>();
                AccountModel objAcc;

                while (drAcc.Read())
                {
                    objAcc = new AccountModel();

                    objAcc.AC_Id = DataFormat.GetInteger(drAcc["AC_Id"]);
                    objAcc.ParentId = DataFormat.GetInteger(drAcc["Reciept_Id"]);
                    objAcc.DC = drAcc["DC"].ToString();
                    objAcc.Account = drAcc["Account"].ToString();
                    objAcc.Debit = Convert.ToDecimal(drAcc["Debit"]);
                    objAcc.Credit = Convert.ToDecimal(drAcc["Credit"]);
                    objAcc.Narration = drAcc["Narration"].ToString();

                    objReciept.RecieptAccountModel.Add(objAcc);

                }

                lstReciept.Add(objReciept);

            }
            return lstReciept;
        }

    }
}
