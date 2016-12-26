using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeed.BusinessLogic
{
    public class JournalVoucherModelBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region SAVE JOURNAL VOUCHER
        public bool SaveJournalVoucher(JournalVoucherModel objjvmodel)
        {
            string Query = string.Empty;
            bool isSaved = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@VoucherNumber", objjvmodel.Voucher_Number));
                paramCollection.Add(new DBParameter("@Series", objjvmodel.Voucher_Series));
                paramCollection.Add(new DBParameter("@JVDate", objjvmodel.JV_Date, System.Data.DbType.DateTime));

                paramCollection.Add(new DBParameter("@Type", objjvmodel.Type));
                paramCollection.Add(new DBParameter("@PDCDate", objjvmodel.PDCDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@LongNarration", objjvmodel.LongNarration));
                paramCollection.Add(new DBParameter("@TotalCreditAmount", "0"));
                paramCollection.Add(new DBParameter("@TotalDebitAmount", "0"));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                System.Data.IDataReader dr =
                   _dbHelper.ExecuteDataReader("spInsertJournalMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);
                SaveJVAccounts(objjvmodel.JournalAccountModel, id);
               
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        public bool SaveJVAccounts(List<AccountModel> lstAcc,int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (AccountModel Acc in lstAcc)
            {
                Acc.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@JournalId", (Acc.ParentId)));
                    paramCollection.Add(new DBParameter("@DC", (Acc.DC)));
                    paramCollection.Add(new DBParameter("@Account", Acc.Account));
                    paramCollection.Add(new DBParameter("@DebitAmount", Acc.Debit));
                    paramCollection.Add(new DBParameter("@CreditAmount", Acc.Credit));
                    paramCollection.Add(new DBParameter("@Narration", Acc.Narration));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                    System.Data.IDataReader dr =
                   _dbHelper.ExecuteDataReader("spInsertJournalDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }    


        #endregion
        //Update Journal Voucher
        public bool UpdateJournalVoucher(JournalVoucherModel objJV)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                //UPDATE CREDIT NOTE TABLE - PARENT TABLE

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Series", objJV.Voucher_Series));
                paramCollection.Add(new DBParameter("@Date", objJV.JV_Date));
                paramCollection.Add(new DBParameter("@Voucher_Number", objJV.Voucher_Number));
                paramCollection.Add(new DBParameter("@Type", objJV.Type));
                paramCollection.Add(new DBParameter("@PDDate", objJV.PDCDate));
                //paramCollection.Add(new DBParameter("@TotalCreditAmt", "0"));
                //paramCollection.Add(new DBParameter("@TotalDebitAmt", "0"));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                paramCollection.Add(new DBParameter("@id", objJV.JV_Id));

                Query = "UPDATE Journal_Voucher SET [Series]=@Series,[JV_Date]=@Date,[VoucherNo]=@Voucher_Number," +
                         "[Type]=@Type,[PDC_Date]=@PDDate,[ModifiedBy]=@ModifiedBy," +
                        "[ModifiedDate]=@ModifiedDate " +
                        "WHERE JV_Id=@id";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    List<AccountModel> lstAcct = new List<AccountModel>();

                    //UPDATE CREDIT NOTE ACCOUNT -CHILD TABLE UPDATES
                    foreach (AccountModel act in objJV.JournalAccountModel)
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

                            Query = "UPDATE Journal_Voucher_Accounts SET [DC]=@DC," +
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


                            Query = "INSERT INTO Journal_Voucher_Accounts([JV_Id],[DC],[Account],[Debit]," +
                    "[Credit],[Narration],[CreatedBy],[CreatedDate]) VALUES " +
                    "(@JV_ID,@DC,@Account,@Debit,@Credit,@Narration,@CreatedBy,@CreatedDate)";

                            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                                isUpdated= true;
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



        public List<JournalVoucherModel> GetAllJournalVouchers()
        {
            List<JournalVoucherModel> lstJournal = new List<JournalVoucherModel>();
            JournalVoucherModel objjournal;

            string Query = "SELECT * FROM Journal_Voucher";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objjournal = new JournalVoucherModel();

                objjournal.JV_Id = DataFormat.GetInteger(dr["JV_Id"]);
                objjournal.Voucher_Series = dr["Series"].ToString();
                objjournal.JV_Date = DataFormat.GetDateTime(dr["JV_Date"]);
                objjournal.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objjournal.Type = dr["Type"].ToString();
                objjournal.PDCDate = Convert.ToDateTime(dr["PDCDate"].ToString());

                //SELECT Journal Voucher Accounts

                string itemQuery = "SELECT * FROM Journal_Voucher_Accounts WHERE Journal_Id=" + objjournal.JV_Id;
                System.Data.IDataReader drAcc = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objjournal.JournalAccountModel = new List<AccountModel>();
                AccountModel objAcc;

                while (drAcc.Read())
                {
                    objAcc = new AccountModel();

                    objAcc.AC_Id = DataFormat.GetInteger(drAcc["AC_Id"]);
                    objAcc.ParentId = DataFormat.GetInteger(drAcc["Journal_Id"]);
                    objAcc.DC = drAcc["DC"].ToString();
                    objAcc.Account = drAcc["Account"].ToString();
                    objAcc.Debit = Convert.ToDecimal(drAcc["Debit"]);
                    objAcc.Credit = Convert.ToDecimal(drAcc["Credit"]);
                    objAcc.Narration = drAcc["Narration"].ToString();


                    objjournal.JournalAccountModel.Add(objAcc);

                }

                lstJournal.Add(objjournal);

            }
            return lstJournal;
        }

        public bool DeletJournalVoucher(int id)
        {
            bool isDelete = false;
            try
            {
                DeleteJVAccounts(id);
                string Query = "DELETE * FROM Journal_Voucher WHERE JV_Id=" + id;
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

        public bool DeleteJVAccounts(int id)
        {

            bool isDelete = false;
            try
            {
                string Query = "DELETE * FROM Journal_Voucher_Accounts WHERE JV_Id=" + id;             
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

        public List<ListModel> GetAllJournalVoucher()
        {
            List<ListModel> lstModel = new List<ListModel>();
            ListModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT C.JV_ID, C.JV_DATE, C.VOUCHERNO, A.ACCOUNT,A.DEBIT, A.CREDIT,A.NARRATION FROM JOURNAL_VOUCHER C ");
            sbQuery.Append("INNER JOIN JOURNAL_VOUCHER_ACCOUNTS A ");
            sbQuery.Append("ON A.JV_ID = C.JV_ID WHERE DC='C';");

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new ListModel();

                objList.Id = Convert.ToInt32(dr["JV_ID"]);

                objList.Date = Convert.ToDateTime(dr["JV_Date"]);
                objList.VoucherNo = Convert.ToInt32(dr["VOUCHERNO"]);                
                objList.Account = Convert.ToString(dr["Account"]);
                objList.Debit= Convert.ToInt32(dr["DEBIT"]);
                objList.Credit = Convert.ToInt32(dr["CREDIT"]);
                objList.Narration = Convert.ToString(dr["NARRATION"]);
                lstModel.Add(objList);

            }
            return lstModel;
        }

        public List<JournalVoucherModel> GetJournalbyId(int id)
        {
            List<JournalVoucherModel> lstJournal = new List<JournalVoucherModel>();
            JournalVoucherModel objjvm;

            string Query = "SELECT * FROM Journal_Voucher WHERE JV_Id=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objjvm = new JournalVoucherModel();

                objjvm.JV_Id = DataFormat.GetInteger(dr["JV_ID"]);
                objjvm.Voucher_Series = dr["Series"].ToString();
                objjvm.JV_Date= DataFormat.GetDateTime(dr["JV_Date"]);
                objjvm.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objjvm.Type = dr["Type"].ToString();
                if (dr["PDC_Date"].ToString() != "")
                    objjvm.PDCDate = Convert.ToDateTime(dr["PDC_Date"]);

                //SELECT Credit Note Accounts

                string itemQuery = "SELECT * FROM Journal_Voucher_Accounts WHERE JV_Id=" + objjvm.JV_Id;
                System.Data.IDataReader drAcc = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objjvm.JournalAccountModel = new List<AccountModel>();
                AccountModel objAcc;

                while (drAcc.Read())
                {
                    objAcc = new AccountModel();

                    objAcc.AC_Id = DataFormat.GetInteger(drAcc["AC_Id"]);
                    objAcc.ParentId = DataFormat.GetInteger(drAcc["JV_Id"]);
                    objAcc.DC = drAcc["DC"].ToString();
                    objAcc.Account = drAcc["Account"].ToString();
                    objAcc.Debit = Convert.ToDecimal(drAcc["Debit"]);
                    objAcc.Credit = Convert.ToDecimal(drAcc["Credit"]);
                    objAcc.Narration = drAcc["Narration"].ToString();

                    objjvm.JournalAccountModel.Add(objAcc);

                }

                lstJournal.Add(objjvm);

            }
            return lstJournal;
        }
    }

}
