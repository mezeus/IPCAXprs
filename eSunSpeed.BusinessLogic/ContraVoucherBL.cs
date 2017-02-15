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
        //Save Contara Voucher main
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
                paramCollection.Add(new DBParameter("@Type", objCon.Type));
                paramCollection.Add(new DBParameter("@PDCDate", objCon.PDCDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@LongNarration", objCon.LongNarration));
                paramCollection.Add(new DBParameter("@TotalCreditAmount",objCon.TotalCreditAmount,System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalDebitAmount",objCon.TotalDebitAmount, System.Data.DbType.Decimal));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                System.Data.IDataReader dr =
                   _dbHelper.ExecuteDataReader("spInsertContraMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                long id = 0;
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
        
        //Save Contra Voucher Accounts
        public bool SaveContraAcconuts(List<AccountModel> lstAcc,long ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (AccountModel Acc in lstAcc)
            {
                Acc.ParentId =Convert.ToInt32(ParentId);
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@ContraID",Acc.ParentId));
                    paramCollection.Add(new DBParameter("@DC", (Acc.DC)));
                    paramCollection.Add(new DBParameter("@Account", Acc.Account));
                    paramCollection.Add(new DBParameter("@LegderId", Acc.LedgerId));
                    paramCollection.Add(new DBParameter("@DebitAmount", Acc.Debit, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@CreditAmount", Acc.Credit, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@Narration", Acc.Narration));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now,System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                    paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

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
        #endregion
        //Update Contra Voucher
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
                paramCollection.Add(new DBParameter("@VoucherNumber", objContra.Voucher_Number));
                paramCollection.Add(new DBParameter("@Type", objContra.Type));
                paramCollection.Add(new DBParameter("@CVDate", objContra.CV_Date, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@PDCDate", objContra.PDCDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@TotalCreditAmount", objContra.TotalCreditAmount,System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalDebitAmount", objContra.TotalDebitAmount,System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@LongNarration", objContra.LongNarration));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedDate",DateTime.Now, System.Data.DbType.DateTime));

                paramCollection.Add(new DBParameter("@ContraId", objContra.CV_Id));

                System.Data.IDataReader dr =
                   _dbHelper.ExecuteDataReader("spUpdateContraMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    List<AccountModel> lstAcct = new List<AccountModel>();
                    //UPDATE Contra Voucher details
                    foreach (AccountModel act in objContra.ContraAccountModel)
                    {
                    act.ParentId =Convert.ToInt32(objContra.CV_Id);
                        if (act.AC_Id > 0)
                        {

                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@DC", (act.DC)));
                            paramCollection.Add(new DBParameter("@Account", act.Account));
                            paramCollection.Add(new DBParameter("@LegderId", act.LedgerId));
                            paramCollection.Add(new DBParameter("@DebitAmount", act.Debit, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@CreditAmount", act.Credit, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Narration", act.Narration));
                            paramCollection.Add(new DBParameter("@CreatedBy", ""));
                            paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));

                            paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now,System.Data.DbType.DateTime));
                            paramCollection.Add(new DBParameter("@AccId", act.AC_Id));
                            paramCollection.Add(new DBParameter("@ContraId", act.ParentId));


                        System.Data.IDataReader acdr =
                                        _dbHelper.ExecuteDataReader("spUpdateContraDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                         }
                        else
                        {
                          paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@ContraID", act.ParentId));
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

                        System.Data.IDataReader acdr =
                       _dbHelper.ExecuteDataReader("spInsertContraDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }
                    }
                

            }
            catch (Exception ex)
            {
                isUpdated = false;
                //throw ex;
            }

            return isUpdated;
        }
        //Delete Contra Voucher
        public bool DeleteContraVoucher(long id)
        {
            bool isDelete = false;
            try
            {
                if (DeleteContraVoucherAccounts(id))
                {
                    string Query = "DELETE FROM contra_vouchermaster WHERE Contra_Id=" + id;
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

        public bool DeleteContraVoucherAccounts(long id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM contra_voucherdetails WHERE Contra_Id=" + id;
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

        //Get All List Of Contra Vouchers
        public List<ListModel> GetAllContraVoucher()
        {
            List<ListModel> lstModel = new List<ListModel>();
            ListModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT C.Contra_ID, C.CV_DATE, C.VoucherNo, A.ACCOUNT,A.DEBIT, A.CREDIT,A.NARRATION FROM contra_vouchermaster C ");
            sbQuery.Append("INNER JOIN contra_voucherdetails A ");
            sbQuery.Append("ON A.Contra_ID = C.Contra_ID WHERE DC='C';");

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new ListModel();

                objList.Id = Convert.ToInt32(dr["Contra_ID"]);
                objList.Date = Convert.ToDateTime(dr["CV_Date"]);
                objList.VoucherNo = Convert.ToInt32(dr["VOUCHERNO"]);
                objList.Account = Convert.ToString(dr["ACCOUNT"]);
                objList.Debit = Convert.ToDecimal(dr["DEBIT"]);
                objList.Credit = Convert.ToDecimal(dr["CREDIT"]);
                objList.Narration = Convert.ToString(dr["NARRATION"]);
                lstModel.Add(objList);

            }
            return lstModel;
        }

        public List<ContraVoucherModel> GetContraVoucherbyId(long id)
        {
            List<ContraVoucherModel> lstCredit = new List<ContraVoucherModel>();
            ContraVoucherModel objcontra;

            string Query = "SELECT * FROM contra_vouchermaster WHERE Contra_Id=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objcontra = new ContraVoucherModel();
                objcontra.CV_Id = DataFormat.GetInteger(dr["Contra_ID"]);
                objcontra.Voucher_Series = dr["Series"].ToString();
                objcontra.CV_Date = DataFormat.GetDateTime(dr["CV_Date"]);
                objcontra.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objcontra.Type = dr["Type"].ToString();
                objcontra.PDCDate = Convert.ToDateTime(dr["PDC_Date"]);
                objcontra.LongNarration = dr["LongNarration"].ToString();

                //SELECT Contara Account Details
                string itemQuery = "SELECT * FROM contra_voucherdetails WHERE Contra_Id=" +id;
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
