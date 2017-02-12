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
        public bool SaveCreditNote(CreditNoteModel objCredit)
        {
            string Query = string.Empty;     
            bool isSaved = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@VoucherNumber", objCredit.Voucher_Number));
                paramCollection.Add(new DBParameter("@Series", objCredit.Voucher_Series));             
                paramCollection.Add(new DBParameter("@CNDate", objCredit.CN_Date,System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@CNType", objCredit.Type));
                paramCollection.Add(new DBParameter("@PDCDate", objCredit.PDCDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@LongNarration", objCredit.Narration));
                paramCollection.Add(new DBParameter("@TotalCreditAmount", objCredit.TotalCreditAmt, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalDebitAmount", objCredit.TotalDebitAmt, System.Data.DbType.Decimal));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                System.Data.IDataReader dr =
                   _dbHelper.ExecuteDataReader("spInsertCreditNoteMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);
                SaveCreditAccounts(objCredit.CreditAccountModel, id);
                
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        public bool SaveCreditAccounts(List<AccountModel> lstAcc,int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (AccountModel Acc in lstAcc)
            {
                Acc.ParentId = ParentId;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@CreditId", (Acc.ParentId)));
                    paramCollection.Add(new DBParameter("@DC", (Acc.DC)));
                    paramCollection.Add(new DBParameter("@Account", Acc.Account));
                    paramCollection.Add(new DBParameter("@LegderId", Acc.LedgerId));
                    paramCollection.Add(new DBParameter("@DebitAmount", Acc.Debit, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@CreditAmount", Acc.Credit, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@Narration", Acc.Narration));
                    
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                    paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                    System.Data.IDataReader dr =
                   _dbHelper.ExecuteDataReader("spInsertCreditDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
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
                paramCollection.Add(new DBParameter("@Date", objCredit.CN_Date, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@VoucherNumber", objCredit.Voucher_Number));
                paramCollection.Add(new DBParameter("@Type", objCredit.Type));
                paramCollection.Add(new DBParameter("@PCDate", objCredit.PDCDate,System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Narration", objCredit.Narration));

                paramCollection.Add(new DBParameter("@TotalCreditAmt", objCredit.TotalCreditAmt));
                paramCollection.Add(new DBParameter("@TotalDebitAmt", objCredit.TotalDebitAmt));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@id", objCredit.CN_Id));

                Query = "UPDATE Credit_Note_Master SET Series=@Series,CN_Date=@Date,VoucherNo=@VoucherNumber," +
                         "Type=@Type,PDC_Date=@PDDate,LongNarration=@Narration,TotalCreditAmt=@TotalCreditAmt,TotalDebitAmt=@TotalDebitAmt,ModifiedBy=@ModifiedBy," +
                        "ModifiedDate=@ModifiedDate " +
                        "WHERE Credit_Id=@id";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    List<AccountModel> lstAcct = new List<AccountModel>();                                           

                    //UPDATE CREDIT NOTE ACCOUNT -CHILD TABLE UPDATES
                    foreach (AccountModel act in objCredit.CreditAccountModel)
                    {
                        act.ParentId = objCredit.CN_Id;
                        if (act.AC_Id > 0)
                        {

                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@DC", (act.DC)));
                            paramCollection.Add(new DBParameter("@Account", act.Account));
                            paramCollection.Add(new DBParameter("@Debit", act.Debit));
                            paramCollection.Add(new DBParameter("@Credit", act.Credit));
                            paramCollection.Add(new DBParameter("@Narration", act.Narration));

                            paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now,System.Data.DbType.DateTime));
                            paramCollection.Add(new DBParameter("@ACT_ID", act.AC_Id));
                            paramCollection.Add(new DBParameter("@ParentId", act.ParentId));

                            Query = "UPDATE Credit_Note_Details SET DC=@DC," +
                            "Account=@Account,Debit=@Debit,Credit=@Credit,Narration=@Narration,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate " +
                            "WHERE AC_Id=@ACT_ID AND Credit_Id=@ParentId";
                            
                            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                            {
                                isUpdated = true;
                            }
                        }
                        else
                        {
                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@CreditId", (act.ParentId)));
                            paramCollection.Add(new DBParameter("@DC", (act.DC)));
                            paramCollection.Add(new DBParameter("@Account", act.Account));
                            paramCollection.Add(new DBParameter("@LegderId", act.LedgerId));
                            paramCollection.Add(new DBParameter("@DebitAmount", act.Debit, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@CreditAmount", act.Credit, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Narration", act.Narration));

                            paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                            paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                            paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                            System.Data.IDataReader dr =
                           _dbHelper.ExecuteDataReader("spInsertCreditDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                        }
                    }                                        
                }

            }
            catch (Exception ex)
            {
                isUpdated = false;
               //  throw ex;
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

            sbQuery.Append("SELECT C.CREDIT_ID, C.CN_DATE, C.VOUCHERNO, C.TYPE, A.ACCOUNT, A.CREDIT FROM CREDIT_NOTE_MASTER C ");
            sbQuery.Append("INNER JOIN CREDIT_NOTE_DETAILS A ");
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

        public List<CreditNoteModel> GetCreditNotebyId(long id)
        {
            List<CreditNoteModel> lstCredit = new List<CreditNoteModel>();
            CreditNoteModel objcredit;

            string Query = "SELECT * FROM Credit_Note_Master WHERE Credit_Id=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objcredit = new CreditNoteModel();

                objcredit.CN_Id = DataFormat.GetInteger(dr["CREDIT_ID"]);
                objcredit.Voucher_Series = dr["Series"].ToString();
                objcredit.CN_Date = DataFormat.GetDateTime(dr["CN_Date"]);
                objcredit.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objcredit.Narration = dr["LongNarration"].ToString();
                objcredit.Type = dr["Type"].ToString();
                if (dr["PDC_Date"].ToString() != "")
                    objcredit.PDCDate = Convert.ToDateTime(dr["PDC_Date"]);

                //SELECT Credit Note Accounts

                string itemQuery = "SELECT * FROM Credit_Note_Details WHERE Credit_Id=" + objcredit.CN_Id;
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
                    objAcc.LedgerId = Convert.ToInt64(drAcc["LegderId"].ToString());
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

        public bool DeleteCreditNote(long id)
        {            
            bool isDelete = false;
            try
            {
                if(DeleteCreditNoteAccounts(id))
                { 
                     string Query = "DELETE FROM credit_note_master WHERE Credit_Id=" + id;
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

        public bool DeleteCreditNoteAccounts(long id)
        {
            bool isDelete =true;
            try
            {
                string Query = "DELETE FROM credit_note_details WHERE Credit_Id=" + id;
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
