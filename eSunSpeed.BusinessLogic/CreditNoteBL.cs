using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeed.BusinessLogic
{
    public class CreditNoteBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region SAVE CREDIT NOTE
        public int SaveCreditNote(CreditNoteModel objCredit)
        {
            string Query = string.Empty;
            int creditid = 0;          

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();


                paramCollection.Add(new DBParameter("@Series", objCredit.Voucher_Series));             
                paramCollection.Add(new DBParameter("@Date", objCredit.CN_Date));
                paramCollection.Add(new DBParameter("@Voucher_Number", objCredit.Voucher_Number));
                paramCollection.Add(new DBParameter("@Type", objCredit.Type));
                paramCollection.Add(new DBParameter("@PDDate", objCredit.PDCDate));
                //paramCollection.Add(new DBParameter("@LongNarrtion",objCredit.l))
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                Query = "INSERT INTO Credit_Note([Series],[CN_Date],[VoucherNo],[Type],[PDC_Date]," +
                "[CreatedBy]) VALUES " +
                "(@Series,@Date,@Voucher_Number,@Type,@PDDate, " +
                " @CreatedBy)";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    SaveCreditAccounts(objCredit.CreditAccountModel);
                    creditid = GetCreditId();                   
                }
            }
            catch (Exception ex)
            {
                creditid = 0;
                throw ex;
            }

            return creditid;
        }

        public bool SaveCreditAccounts(List<AccountModel> lstAcc)
        {
            string Query = string.Empty;
            bool isSaved = true;

            int ParentId = GetCreditId();

            foreach (AccountModel Acc in lstAcc)
            {
                Acc.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@CN_ID", (Acc.ParentId)));
                    paramCollection.Add(new DBParameter("@DC", (Acc.DC)));
                    paramCollection.Add(new DBParameter("@Account", Acc.Account));
                    paramCollection.Add(new DBParameter("@Debit", Acc.Debit));
                    paramCollection.Add(new DBParameter("@Credit", Acc.Credit));
                    paramCollection.Add(new DBParameter("@Narration", Acc.Narration));
                    
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));


                    Query = "INSERT INTO Credit_Note_Accounts([Credit_Id],[DC],[Account],[Debit],[Credit]," +
                    "[Narration],[CreatedBy],[CreatedDate]) VALUES " +
                    "(@CN_ID,@DC,@Account,@Debit,@Credit,@Narration,@CreatedBy,@CreatedDate)";

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

        public List<int> GetAccountId(int creditId)
        {
            List<int> lstAccIds = new List<int>();

            string Query = "SELECT AC_ID FROM Credit_Note_Accounts WHERE CREDIT_ID="+creditId;

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                lstAccIds.Add(Convert.ToInt32(dr["AC_ID"]));                
            }
                return lstAccIds;
        }


        public int GetCreditId()
        {
            string Query = "SELECT MAX(Credit_Id) FROM Credit_Note";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }


        #endregion
        
        //UPDATE CREDIT NOTE
        public bool UpdateCreditNote(CreditNoteModel objCredit)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                //UPDATE CREDIT NOTE TABLE - PARENT TABLE

                DBParameterCollection paramCollection = new DBParameterCollection();
                
                paramCollection.Add(new DBParameter("@Series", objCredit.Voucher_Series));
                paramCollection.Add(new DBParameter("@Date", objCredit.CN_Date));
                paramCollection.Add(new DBParameter("@Voucher_Number", objCredit.Voucher_Number));
                paramCollection.Add(new DBParameter("@Type", objCredit.Type));
                paramCollection.Add(new DBParameter("@PDDate", objCredit.PDCDate));
                paramCollection.Add(new DBParameter("@TotalCreditAmt", "0"));
                paramCollection.Add(new DBParameter("@TotalDebitAmt", "0"));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                paramCollection.Add(new DBParameter("@id", objCredit.CN_Id));
               
                Query = "UPDATE Credit_Note SET [Series]=@Series,[CN_Date]=@Date,[VoucherNo]=@Voucher_Number," +
                         "[Type]=@Type,[PDC_Date]=@PDDate,[TotalCreditAmt]=@TotalCreditAmt,[TotalDebitAmt]=@TotalDebitAmt,[ModifiedBy]=@ModifiedBy," +
                        "[ModifiedDate]=@ModifiedDate " +
                        "WHERE Credit_Id=@id";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    List<AccountModel> lstAcct = new List<AccountModel>();                                           

                    //UPDATE CREDIT NOTE ACCOUNT -CHILD TABLE UPDATES
                    foreach (AccountModel act in objCredit.CreditAccountModel)
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

                            Query = "UPDATE Credit_Note_Accounts SET [DC]=@DC," +
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

                            paramCollection.Add(new DBParameter("@CN_ID", (act.ParentId)));
                            paramCollection.Add(new DBParameter("@DC", (act.DC)));
                            paramCollection.Add(new DBParameter("@Account", act.Account));
                            paramCollection.Add(new DBParameter("@Debit", act.Debit));
                            paramCollection.Add(new DBParameter("@Credit", act.Credit));
                            paramCollection.Add(new DBParameter("@Narration", act.Narration));

                            paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));


                            Query = "INSERT INTO Credit_Note_Accounts([Credit_Id],[DC],[Account],[Debit],[Credit]," +
                            "[Narration],[CreatedBy],[CreatedDate]) VALUES " +
                            "(@CN_ID,@DC,@Account,@Debit,@Credit,@Narration,@CreatedBy,@CreatedDate)";

                            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0) { };                                
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

        //public bool UpdateCreditAccounts(List<Accoun)
        //{

        //    string Query = string.Empty;
        //    bool isUpdate = true;
        //    int ParentId;
        //    foreach (AccountModel Acc in lstacc)
        //    {
        //         Acc.ParentId=  
        //        try
        //        {
        //            DBParameterCollection paramCollection = new DBParameterCollection();

        //            paramCollection.Add(new DBParameter("@AC_ID", (objacc.AC_Id)));
        //            paramCollection.Add(new DBParameter("@CN_ID", (objacc.ParentId)));
        //            paramCollection.Add(new DBParameter("@DC", (objacc.DC)));
        //            paramCollection.Add(new DBParameter("@Account", objacc.Account));
        //            paramCollection.Add(new DBParameter("@Debit", objacc.Debit));
        //            paramCollection.Add(new DBParameter("@Credit", objacc.Credit));
        //            paramCollection.Add(new DBParameter("@Narration", objacc.Narration));

        //            paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
        //            paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));



        //            Query = "UPDATE Credit_Note_Accounts SET [DC]=@DC," +
        //            "[Account]=@Account,[Debit]=@Debit,[Credit]=@Credit,[Narration]=@Narration,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
        //            "WHERE [AC_Id]=@AC_ID AND [Credit_Id]=@CN_ID";

        //            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
        //                isUpdate = true;
        //        }

        //        catch (Exception ex)
        //        {
        //            isUpdate = false;
        //            throw ex;
        //        }
        //    }
        //    return isUpdate;
        //}

        public List<ListModel> GetAllCreditNote()
        {
            List<ListModel> lstModel = new List<ListModel>();
            ListModel objList;

            StringBuilder sbQuery = new StringBuilder();
            string whereClause = string.Empty;

            sbQuery.Append("SELECT C.CREDIT_ID, C.CN_DATE, C.VOUCHERNO, C.TYPE, A.ACCOUNT, A.CREDIT FROM CREDIT_NOTE C ");
            sbQuery.Append("INNER JOIN CREDIT_NOTE_ACCOUNTS A ");
            sbQuery.Append("ON A.CREDIT_ID = C.CREDIT_ID");
            
                                    
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new ListModel();

                objList.Id = Convert.ToInt32(dr["CREDIT_ID"]);

                objList.Date = Convert.ToDateTime( dr["CN_Date"]);
                objList.VoucherNo = Convert.ToInt32(dr["VOUCHERNO"]);
                objList.Type = Convert.ToString(dr["Type"]);
                objList.Account = Convert.ToString(dr["Account"]);
                objList.TotalAmt = Convert.ToInt32(dr["CREDIT"]);
                lstModel.Add(objList);

            }
            return lstModel;
        }

        public List<CreditNoteModel> GetCreditNotebyId(int id)
        {
            List<CreditNoteModel> lstCredit = new List<CreditNoteModel>();
            CreditNoteModel objcredit;

            string Query = "SELECT * FROM Credit_Note WHERE Credit_Id=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objcredit = new CreditNoteModel();

                objcredit.CN_Id = DataFormat.GetInteger(dr["CREDIT_ID"]);
                objcredit.Voucher_Series = dr["Series"].ToString();
                objcredit.CN_Date = DataFormat.GetDateTime(dr["CN_Date"]);
                objcredit.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objcredit.Type = dr["Type"].ToString();
                if (dr["PDC_Date"].ToString() != "")
                    objcredit.PDCDate = Convert.ToDateTime(dr["PDC_Date"]);

                //SELECT Credit Note Accounts

                string itemQuery = "SELECT * FROM Credit_Note_Accounts WHERE Credit_Id=" + objcredit.CN_Id;
                System.Data.IDataReader drAcc = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objcredit.CreditAccountModel = new List<AccountModel>();
                AccountModel objAcc;

                while (drAcc.Read())
                {
                    objAcc = new AccountModel();

                    objAcc.AC_Id = Convert.ToInt32(drAcc["AC_Id"]);
                    objAcc.ParentId = DataFormat.GetInteger(drAcc["Credit_Id"]);
                    objAcc.DC = drAcc["DC"].ToString();
                    objAcc.Account = drAcc["Account"].ToString();
                    objAcc.Debit = Convert.ToDecimal(drAcc["Debit"]);
                    objAcc.Credit = Convert.ToDecimal(drAcc["Credit"]);
                    objAcc.Narration = drAcc["Narration"].ToString();

                    objcredit.CreditAccountModel.Add(objAcc);

                }

                lstCredit.Add(objcredit);

            }
            return lstCredit;
        }


        /*
        public List<CreditNoteModel> GetAllCreditNote()
        {
            List<CreditNoteModel> lstCredit = new List<CreditNoteModel>();
            CreditNoteModel objcredit;

            string Query = "SELECT * FROM Credit_Note";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objcredit = new CreditNoteModel();

                objcredit.CN_Id = DataFormat.GetInteger(dr["CN_Id"]);
                objcredit.Voucher_Series = dr["Series"].ToString();
                objcredit.CN_Date = DataFormat.GetDateTime(dr["CN_Date"]);
                objcredit.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objcredit.Type = dr["Type"].ToString();
                objcredit.PDCDate = Convert.ToDateTime(dr["PDCDate"].ToString());

                //SELECT Contra Voucher Accounts

                string itemQuery = "SELECT * FROM Credit_Note_Accounts WHERE Debit_Id=" + objcredit.CN_Id;
                System.Data.IDataReader drAcc = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objcredit.CreditAccountModel = new List<AccountModel>();
                AccountModel objAcc;

                while (drAcc.Read())
                {
                    objAcc = new AccountModel();

                    objAcc.AC_Id = DataFormat.GetInteger(drAcc["AC_Id"]);
                    objAcc.ParentId = DataFormat.GetInteger(drAcc["Credit_Id"]);
                    objAcc.DC = drAcc["DC"].ToString();
                    objAcc.Account = drAcc["Account"].ToString();
                    objAcc.Debit = Convert.ToDecimal(drAcc["Debit"]);
                    objAcc.Credit = Convert.ToDecimal(drAcc["Credit"]);
                    objAcc.Narration = drAcc["Narration"].ToString();


                    objcredit.CreditAccountModel.Add(objAcc);

                }

                lstCredit.Add(objcredit);

            }
            return lstCredit;
        }

        //        SELECT C.CN_DATE, C.VOUCHERNO, C.TYPE, A.ACCOUNT, A.CREDIT FROM CREDIT_NOTE C
        //INNER JOIN CREDIT_NOTE_ACCOUNTS A
        //ON A.CREDIT_ID= C.CREDIT_ID WHERE A.DC= 'C';
        */

        public bool DeleteCreditNote(int id)
        {            
            bool isDelete = false;
            try
            {
                if(DeleteCreditNoteAccounts(id))
                { 
                     string Query = "DELETE * FROM Credit_Note WHERE Credit_Id=" + id;
                    int rowes = _dbHelper.ExecuteNonQuery(Query);
                     if(rowes>0)
                    isDelete= true;                  
                }
            }
            catch(Exception ex)
            {
                isDelete = false;             
            }
            return isDelete;
        }

        public bool DeleteCreditNoteAccounts(int id)
        {
            bool isDelete =false;
            try
            {
                string Query = "DELETE * FROM Credit_Note_Accounts WHERE Credit_Id=" + id;
                int rowes = _dbHelper.ExecuteNonQuery(Query);
                if(rowes>0)
                    isDelete = true;                
            }
            catch (Exception ex)
            {
                isDelete = false;           
            }
            return isDelete;
        }

       
    }
}
