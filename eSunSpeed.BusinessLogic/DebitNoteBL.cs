using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeed.BusinessLogic
{
    public class DebitNoteBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region SAVE DEBIT NOTE
        public bool SaveDebitNote(DebitNoteModel objdebit)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@VoucherNumber", objdebit.Voucher_Number));
                paramCollection.Add(new DBParameter("@Series", objdebit.Voucher_Series));
                paramCollection.Add(new DBParameter("@DNDate", objdebit.DN_Date, System.Data.DbType.DateTime));

                paramCollection.Add(new DBParameter("@DNType", objdebit.Type));
                
                paramCollection.Add(new DBParameter("@LongNarration", objdebit.LongNarration));
                paramCollection.Add(new DBParameter("@TotalCreditAmount", objdebit.TotalCreditAmount));
                paramCollection.Add(new DBParameter("@TotalDebitAmount", objdebit.TotalDebitAmount));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                System.Data.IDataReader dr =
                   _dbHelper.ExecuteDataReader("spInsertDebitNoteMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                int id = 0;
                dr.Read();

                id = Convert.ToInt32(dr[0]);
                SaveDebitAccounts(objdebit.DebitAccountModel, id);
                
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        public bool SaveDebitAccounts(List<AccountModel> lstAcc,int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;

            //int ParentId = GetDebitId();

            foreach (AccountModel Acc in lstAcc)
            {
                Acc.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@DebitId", (Acc.ParentId)));
                    paramCollection.Add(new DBParameter("@DC", (Acc.DC)));
                    paramCollection.Add(new DBParameter("@Account", Acc.Account));
                    paramCollection.Add(new DBParameter("@DebitAmount", Acc.Debit));
                    paramCollection.Add(new DBParameter("@CreditAmount", Acc.Credit));
                    paramCollection.Add(new DBParameter("@Narration", Acc.Narration));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                    System.Data.IDataReader dr =
                   _dbHelper.ExecuteDataReader("spInsertDebitDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                                    
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        
        public int GetDebitId()
        {
            string Query = "SELECT MAX(Debit_Id) FROM Debit_Note";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }


        #endregion

        //UPDATE Debit NOTE
        public bool UpdateDebitNote(DebitNoteModel objDebit)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                //UPDATE Debit NOTE TABLE - PARENT TABLE

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Series", objDebit.Voucher_Series));
                paramCollection.Add(new DBParameter("@Date", objDebit.DN_Date, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Voucher_Number", objDebit.Voucher_Number));
                paramCollection.Add(new DBParameter("@Type", objDebit.Type));

                paramCollection.Add(new DBParameter("@TotalCreditAmt", objDebit.TotalCreditAmount));
                paramCollection.Add(new DBParameter("@TotalDebitAmt", objDebit.TotalDebitAmount));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@id", objDebit.DN_Id));

                Query = "UPDATE Debit_Note_Master SET Series=@Series,DN_Date=@Date,VoucherNo=@Voucher_Number," +
                         "Type=@Type,TotalCreditAmount=@TotalCreditAmt,TotalDebitAmount=@TotalDebitAmt,ModifiedBy=@ModifiedBy," +
                        "ModifiedDate=@ModifiedDate " +
                        "WHERE Debit_Id=@id";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    List<AccountModel> lstAcct = new List<AccountModel>();

                    //UPDATE CREDIT NOTE ACCOUNT -CHILD TABLE UPDATES
                    foreach (AccountModel act in objDebit.DebitAccountModel)
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
                            paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                            paramCollection.Add(new DBParameter("@ACT_ID", act.AC_Id));

                            Query = "UPDATE Debit_Note_Details SET DC=@DC," +
                            "Account=@Account,Debit=@Debit,Credit=@Credit,Narration=@Narration,ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate " +
                            "WHERE AC_Id=@ACT_ID";

                            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                            {
                                isUpdated = true;
                            }
                        }
                        else
                        {
                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@DN_ID", (objDebit.DN_Id)));
                            paramCollection.Add(new DBParameter("@DC", (act.DC)));
                            paramCollection.Add(new DBParameter("@Account", act.Account));
                            paramCollection.Add(new DBParameter("@Debit", act.Debit));
                            paramCollection.Add(new DBParameter("@Credit", act.Credit));
                            paramCollection.Add(new DBParameter("@Narration", act.Narration));

                            paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));


                            Query = "INSERT INTO Debit_Note_Details(Debit_Id,DC,Account,Debit,Credit," +
                            "Narration,CreatedBy,CreatedDate) VALUES " +
                            "(@DN_ID,@DC,@Account,@Debit,@Credit,@Narration,@CreatedBy,@CreatedDate)";

                            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0) { };
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




        public List<DebitNoteModel> GetAllDebitsNote_old()
        {
            List<DebitNoteModel> lstDebit = new List<DebitNoteModel>();
            DebitNoteModel objDebit;

            string Query = "SELECT * FROM Debit_Note";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objDebit = new DebitNoteModel();

                objDebit.DN_Id = DataFormat.GetInteger(dr["CN_Id"]);
                objDebit.Voucher_Series = dr["Series"].ToString();
                objDebit.DN_Date = DataFormat.GetDateTime(dr["CN_Date"]);
                objDebit.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objDebit.Type = dr["Type"].ToString();
                

                //SELECT Debit Note Accounts

                string itemQuery = "SELECT * FROM Debit_Note_Accounts WHERE Debit_Id=" + objDebit.DN_Id;
                System.Data.IDataReader drAcc = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objDebit.DebitAccountModel = new List<AccountModel>();
                AccountModel objAcc;

                while (drAcc.Read())
                {
                    objAcc = new AccountModel();

                    objAcc.AC_Id = DataFormat.GetInteger(drAcc["AC_Id"]);
                    objAcc.ParentId = DataFormat.GetInteger(drAcc["Debit_Id"]);
                    objAcc.DC = drAcc["DC"].ToString();
                    objAcc.Account = drAcc["Account"].ToString();
                    objAcc.Debit = Convert.ToDecimal(drAcc["Debit"]);
                    objAcc.Credit = Convert.ToDecimal(drAcc["Credit"]);
                    objAcc.Narration = drAcc["Narration"].ToString();


                    objDebit.DebitAccountModel.Add(objAcc);

                }

                lstDebit.Add(objDebit);

            }
            return lstDebit;
        }

        public bool DeletDebitNote(int id)
        {
            bool isDelete = false;
            try
            {
                if (DeleteDebitAccounts(id))
                {
                    string Query = "DELETE * FROM Debit_Note WHERE Debit_Id=" + id;
                    int rows = _dbHelper.ExecuteNonQuery(Query);
                    if (rows > 0)
                        isDelete = true;
                }
            }

            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
       
        }

        public bool DeleteDebitAccounts(int id)
        {
            bool isDeleted = false;     
            try
            {
                string Query = "DELETE * FROM Debit_Note_Accounts WHERE Debit_Id=" + id;                
               int rows= _dbHelper.ExecuteNonQuery(Query);
                if (rows > 0)
                    isDeleted = true;
                
            }
            catch (Exception ex)
            {
                isDeleted = false;                
            }

            return isDeleted;
        }

        public List<ListModel> GetAllDebitNote()
        {
            List<ListModel> lstModel = new List<ListModel>();
            ListModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT C.DEBIT_ID, C.DN_DATE, C.VOUCHERNO, C.TYPE, A.ACCOUNT, C.TOTALCREDITAMOUNT,C.TOTALDEBITAMOUNT FROM DEBIT_NOTE_MASTER C ");
            sbQuery.Append("INNER JOIN DEBIT_NOTE_DETAILS A ");
            sbQuery.Append("ON A.DEBIT_ID = C.DEBIT_ID ");

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new ListModel();

                objList.Id = Convert.ToInt32(dr["DEBIT_ID"]);

                objList.Date = Convert.ToDateTime(dr["DN_Date"]);
                objList.VoucherNo = Convert.ToInt32(dr["VOUCHERNO"]);
                objList.Type = Convert.ToString(dr["Type"]);
                objList.Account = Convert.ToString(dr["ACCOUNT"]);
                objList.TotalAmt = Convert.ToInt32(dr["TOTALCREDITAMOUNT"])>0? Convert.ToInt32(dr["TOTALCREDITAMOUNT"]): Convert.ToInt32(dr["TOTALDEBITAMOUNT"]);
                lstModel.Add(objList);

            }
            return lstModel;
        }

        public List<DebitNoteModel> GetDebitNotebyId(int id)
        {
            List<DebitNoteModel> lstDebit = new List<DebitNoteModel>();
            DebitNoteModel objDebit;

            string Query = "SELECT * FROM Debit_Note_Master WHERE Debit_Id=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objDebit = new DebitNoteModel();

                objDebit.DN_Id = DataFormat.GetInteger(dr["Debit_ID"]);
                objDebit.Voucher_Series = dr["Series"].ToString();
                objDebit.DN_Date = DataFormat.GetDateTime(dr["DN_Date"]);
                objDebit.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objDebit.Type = dr["Type"].ToString();
                
                //SELECT Contra Voucher Accounts

                string itemQuery = "SELECT * FROM Debit_Note_Details WHERE Debit_Id=" + objDebit.DN_Id;
                System.Data.IDataReader drAcc = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objDebit.DebitAccountModel = new List<AccountModel>();
                AccountModel objAcc;

                while (drAcc.Read())
                {
                    objAcc = new AccountModel();

                    objAcc.AC_Id = DataFormat.GetInteger(drAcc["AC_Id"]);
                    objAcc.ParentId = DataFormat.GetInteger(drAcc["Debit_Id"]);
                    objAcc.DC = drAcc["DC"].ToString();
                    objAcc.Account = drAcc["Account"].ToString();
                    objAcc.Debit = Convert.ToDecimal(drAcc["Debit"]);
                    objAcc.Credit = Convert.ToDecimal(drAcc["Credit"]);
                    objAcc.Narration = drAcc["Narration"].ToString();

                    objDebit.DebitAccountModel.Add(objAcc);

                }

                lstDebit.Add(objDebit);

            }
            return lstDebit;
        }

    }
}
