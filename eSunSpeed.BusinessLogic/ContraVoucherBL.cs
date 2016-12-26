using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeed.BusinessLogic
{
    public class ContraVoucherBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region SAVE CONTRA VOUCHER
        public bool SaveContraVoucher(ContraVoucherModel objCon)
        {
            string Query = string.Empty;
            bool isSaved = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@VoucherNumber", objCon.Voucher_Number));
                paramCollection.Add(new DBParameter("@Series", objCon.Voucher_Series));
                paramCollection.Add(new DBParameter("@CVDate", objCon.CV_Date, System.Data.DbType.DateTime));

                //paramCollection.Add(new DBParameter("@Type", objCon.Type));
                //paramCollection.Add(new DBParameter("@PDCDate", objCon.PDCDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@LongNarration", objCon.LongNarration));
                paramCollection.Add(new DBParameter("@TotalCreditAmount", "0"));
                paramCollection.Add(new DBParameter("@TotalDebitAmount", "0"));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                System.Data.IDataReader dr =
                   _dbHelper.ExecuteDataReader("spInsertContraMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);
                SaveContraAcconuts(objCon.ContraAccountModel, id);
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        public bool SaveContraAcconuts(List<AccountModel> lstAcc,int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;
            //int ParentId = GetContraId();
            foreach (AccountModel Acc in lstAcc)
            {
                Acc.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@ContraID", (Acc.ParentId)));
                    paramCollection.Add(new DBParameter("@DC", (Acc.DC)));
                    paramCollection.Add(new DBParameter("@Account", Acc.Account));
                    paramCollection.Add(new DBParameter("@DebitAmount", Acc.Debit));
                    paramCollection.Add(new DBParameter("@CreditAmount", Acc.Credit));
                    paramCollection.Add(new DBParameter("@Narration", Acc.Narration));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                    System.Data.IDataReader dr =
                   _dbHelper.ExecuteDataReader("spInsertContraDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }
     
        public int GetContraId()
        {
            string Query = "SELECT MAX(Contra_Id) FROM Contra_Voucher";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }


        #endregion

        public bool UpdateContraVoucher(ContraVoucherModel objContra)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                //UPDATE CONTRA TABLE - PARENT TABLE

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Series", objContra.Voucher_Series));
                paramCollection.Add(new DBParameter("@Date", objContra.CV_Date));
                paramCollection.Add(new DBParameter("@Voucher_Number", objContra.Voucher_Number));
                paramCollection.Add(new DBParameter("@Type", objContra.Type));
                paramCollection.Add(new DBParameter("@PDDate", objContra.PDCDate));
                //paramCollection.Add(new DBParameter("@TotalCreditAmt", "0"));
                //paramCollection.Add(new DBParameter("@TotalDebitAmt", "0"));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                paramCollection.Add(new DBParameter("@id", objContra.CV_Id));

                Query = "UPDATE Contra_Voucher SET [Series]=@Series,[CV_Date]=@Date,[VoucherNo]=@Voucher_Number," +
                         "[Type]=@Type,[PDC_Date]=@PDDate,[ModifiedBy]=@ModifiedBy," +
                        "[ModifiedDate]=@ModifiedDate " +
                        "WHERE Contra_Id=@id";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    List<AccountModel> lstAcct = new List<AccountModel>();

                    //UPDATE CREDIT NOTE ACCOUNT -CHILD TABLE UPDATES
                    foreach (AccountModel act in objContra.ContraAccountModel)
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

                            Query = "UPDATE Contra_Voucher_Accounts SET [DC]=@DC," +
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


                            Query = "INSERT INTO Contra_Voucher_Accounts([Contra_Id],[DC],[Account],[Debit],[Credit]," +
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

        public bool DeleteContraVoucher(int id)
        {
            bool isDelete = false;
            try
            {
                if (DeleteContraVoucherAccounts(id))
                {
                    string Query = "DELETE * FROM Contra_Voucher WHERE Contra_Id=" + id;
                    int rowes = _dbHelper.ExecuteNonQuery(Query);
                    if (rowes > 0)
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

        public bool DeleteContraVoucherAccounts(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE * FROM Contra_Voucher_Accounts WHERE Contra_Id=" + id;
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


        public List<ListModel> GetAllContraVoucher()
        {
            List<ListModel> lstModel = new List<ListModel>();
            ListModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT C.Contra_ID, C.CV_DATE, C.VOUCHERNO, A.ACCOUNT,A.DEBIT, A.CREDIT,A.NARRATION FROM CONTRA_VOUCHER C ");
            sbQuery.Append("INNER JOIN CONTRA_VOUCHER_ACCOUNTS A ");
            sbQuery.Append("ON A.Contra_ID = C.Contra_ID WHERE DC='C';");

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new ListModel();

                objList.Id = Convert.ToInt32(dr["Contra_ID"]);

                objList.Date = Convert.ToDateTime(dr["CV_Date"]);
                objList.VoucherNo = Convert.ToInt32(dr["VOUCHERNO"]);
                objList.Account = Convert.ToString(dr["ACCOUNT"]);
                objList.Debit = Convert.ToInt32(dr["DEBIT"]);
                objList.Credit = Convert.ToInt32(dr["CREDIT"]);
                objList.Narration = Convert.ToString(dr["NARRATION"]);
                lstModel.Add(objList);

            }
            return lstModel;
        }

        public List<ContraVoucherModel> GetCreditNotebyId(int id)
        {
            List<ContraVoucherModel> lstCredit = new List<ContraVoucherModel>();
            ContraVoucherModel objcontra;

            string Query = "SELECT * FROM Contra_Voucher WHERE Contra_Id=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objcontra = new ContraVoucherModel();

                objcontra.CV_Id = DataFormat.GetInteger(dr["Contra_ID"]);
                objcontra.Voucher_Series = dr["Series"].ToString();
                objcontra.CV_Date = DataFormat.GetDateTime(dr["CV_Date"]);
                objcontra.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objcontra.Type = dr["Type"].ToString();
                if (dr["PDC_Date"].ToString() != "")
                    objcontra.PDCDate = Convert.ToDateTime(dr["PDC_Date"]);

                //SELECT Credit Note Accounts

                string itemQuery = "SELECT * FROM Contra_Voucher_Accounts WHERE Contra_Id=" + objcontra.CV_Id;
                System.Data.IDataReader drAcc = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objcontra.ContraAccountModel = new List<AccountModel>();
                AccountModel objAcc;

                while (drAcc.Read())
                {
                    objAcc = new AccountModel();

                    objAcc.AC_Id = Convert.ToInt32(drAcc["AC_Id"]);
                    objAcc.ParentId = DataFormat.GetInteger(drAcc["Contra_Id"]);
                    objAcc.DC = drAcc["DC"].ToString();
                    objAcc.Account = drAcc["Account"].ToString();
                    objAcc.Debit = Convert.ToDecimal(drAcc["Debit"]);
                    objAcc.Credit = Convert.ToDecimal(drAcc["Credit"]);
                    objAcc.Narration = drAcc["Narration"].ToString();

                    objcontra.ContraAccountModel.Add(objAcc);

                }

                lstCredit.Add(objcontra);

            }
            return lstCredit;
        }
    }
}
