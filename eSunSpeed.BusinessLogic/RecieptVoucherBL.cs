﻿using eSunSpeed.DataAccess;
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
        public bool SaveRecieptVoucher(RecieptVoucherModel objReciept)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@VoucherNumber", objReciept.Voucher_Number));
                paramCollection.Add(new DBParameter("@Series", objReciept.Voucher_Series));
                paramCollection.Add(new DBParameter("@RecieptDate", objReciept.RV_Date, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Type", objReciept.Type));
                paramCollection.Add(new DBParameter("@PDCDate", objReciept.PDCDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@LongNarration", objReciept.LongNarration));
                paramCollection.Add(new DBParameter("@TotalCreditAmount", objReciept.TotalCreditAmt,System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalDebitAmount",objReciept.TotalDebitAmt, System.Data.DbType.Decimal));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now,System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                System.Data.IDataReader dr =
                   _dbHelper.ExecuteDataReader("spInsertRecieptMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);
                SaveRecieptAccounts(objReciept.RecieptAccountModel, id);
            }
            catch (Exception ex)
            {
                isSaved = false;
                //throw ex;
            }

            return isSaved;
        }

        public bool SaveRecieptAccounts(List<AccountModel> lstAcc,int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;
            //int ParentId = GetRecieptId();

            foreach (AccountModel Acc in lstAcc)
            {
                Acc.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();
                    paramCollection.Add(new DBParameter("@RecieptId", (Acc.ParentId)));
                    paramCollection.Add(new DBParameter("@DC", (Acc.DC)));
                    paramCollection.Add(new DBParameter("@Account", Acc.Account));
                    paramCollection.Add(new DBParameter("@LegderId", Acc.LegderId));
                    paramCollection.Add(new DBParameter("@DebitAmount", Acc.Debit,System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@CreditAmount", Acc.Credit, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@Narration", Acc.Narration));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now,System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                    paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                    System.Data.IDataReader dr =
                   _dbHelper.ExecuteDataReader("spInsertRecieptDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
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

        //Udate Reciept Voucher
        public bool UpdateRecieptVoucher(RecieptVoucherModel objRecipt)
        {
            string Query = string.Empty;
            bool isUpdated = true;
            try
            {
        
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Series", objRecipt.Voucher_Series));
                paramCollection.Add(new DBParameter("@Date", objRecipt.RV_Date,System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Voucher_Number", objRecipt.Voucher_Number));
                paramCollection.Add(new DBParameter("@Type", objRecipt.Type));
                paramCollection.Add(new DBParameter("@PDDate", objRecipt.PDCDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@LongNarration", objRecipt.LongNarration));
                paramCollection.Add(new DBParameter("@TotalCreditAmt",objRecipt.TotalCreditAmt, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalDebitAmt",objRecipt.TotalDebitAmt, System.Data.DbType.Decimal));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@id", objRecipt.RV_Id));

                Query = "UPDATE Reciept_Voucher_Master SET `Series`=@Series,`Reciept_Date`=@Date,`VoucherNo`=@Voucher_Number," +
                         "`Type`=@Type,`PDC_Date`=@PDDate,`LongNarration`=@LongNarration,`TotalCreditAmt`=@TotalCreditAmt,`TotalDebitAmt`=@TotalDebitAmt,`CreatedBy`=CreatedBy,`CreatedDate`=CreatedDate,`ModifiedBy`=@ModifiedBy," +
                        "`ModifiedDate`=@ModifiedDate " +
                        "WHERE `Reciept_Id`=@id";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    List<AccountModel> lstAcct = new List<AccountModel>();

                    //UPDATE CREDIT NOTE ACCOUNT -CHILD TABLE UPDATES
                    foreach (AccountModel act in objRecipt.RecieptAccountModel)
                    {
                        act.ParentId = Convert.ToInt32( objRecipt.RV_Id);
                        if (act.AC_Id > 0)
                        {

                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@DC", (act.DC)));
                            paramCollection.Add(new DBParameter("@Account", act.Account));
                            paramCollection.Add(new DBParameter("@LegderId", act.LegderId));
                            paramCollection.Add(new DBParameter("@Debit", act.Debit, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Credit", act.Credit, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Narration", act.Narration));

                            paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                            paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                            paramCollection.Add(new DBParameter("@ACT_ID", act.AC_Id));
                            paramCollection.Add(new DBParameter("@ParentId", act.ParentId));

                            Query = "UPDATE Reciept_Voucher_Details SET `DC`=@DC," +
                            "`Account`=@Account,`Debit`=@Debit,`Credit`=@Credit,`Narration`=@Narration,`CreatedBy`=CreatedBy,`CreatedDate`=CreatedDate,`ModifiedBy`=@ModifiedBy,`ModifiedDate`=@ModifiedDate,`LegderId`=@LegderId " +
                            "WHERE `AC_Id`=@ACT_ID AND `Reciept_Id`=@ParentId";

                            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                            {
                                isUpdated = true;
                            }
                        }
                        else
                        {
                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@RecieptId", (objRecipt.RV_Id)));
                            paramCollection.Add(new DBParameter("@DC", (act.DC)));
                            paramCollection.Add(new DBParameter("@Account", act.Account));
                            paramCollection.Add(new DBParameter("@LegderId", act.LegderId));
                            paramCollection.Add(new DBParameter("@DebitAmount", act.Debit, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@CreditAmount", act.Credit, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Narration", act.Narration));

                            paramCollection.Add(new DBParameter("@CreatedBy", ""));
                            paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                            paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                            System.Data.IDataReader dr =
                                             _dbHelper.ExecuteDataReader("spInsertRecieptDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                        }
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
        public bool DeleteRecieptVoucher(long id)
        {
            bool isDelete = false;
            try
            {
                if(DeleteRecieptAccounts(id));
                {
                    string Query = "DELETE FROM `Reciept_Voucher_Master` WHERE `Reciept_Id`=" + id;

                    if (_dbHelper.ExecuteNonQuery(Query) > 0)

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

        public bool DeleteRecieptAccounts(long id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE  FROM `Reciept_Voucher_Details` WHERE `Reciept_Id`=" + id;

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

            sbQuery.Append("SELECT C.RECIEPT_ID, C.RECIEPT_DATE, C.VOUCHERNO, A.ACCOUNT,A.DEBIT, A.CREDIT,A.NARRATION FROM RECIEPT_VOUCHER_MASTER C ");
            sbQuery.Append("INNER JOIN RECIEPT_VOUCHER_DETAILS A ");
            sbQuery.Append("ON A.Reciept_Id = C.Reciept_Id WHERE DC='D';");

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

        public List<RecieptVoucherModel> GetRecieptbyId(long id)
        {
            List<RecieptVoucherModel> lstReciept = new List<RecieptVoucherModel>();
            RecieptVoucherModel objReciept;

            string Query = "SELECT * FROM `Reciept_Voucher_Master` WHERE `Reciept_Id`=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objReciept = new RecieptVoucherModel();

                objReciept.RV_Id = DataFormat.GetInteger(dr["Reciept_ID"]);
                objReciept.Voucher_Series = dr["Series"].ToString();
                objReciept.RV_Date = DataFormat.GetDateTime(dr["Reciept_Date"]);
                objReciept.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objReciept.Type = dr["Type"].ToString();
                objReciept.PDCDate = Convert.ToDateTime(dr["PDC_Date"]);
                objReciept.LongNarration = dr["LongNarration"].ToString();
                objReciept.TotalCreditAmt = Convert.ToDecimal(dr["TotalCreditAmt"]);
                objReciept.TotalDebitAmt = Convert.ToDecimal(dr["TotalDebitAmt"]);
                
                //SELECT Payment Voucher Details

                string itemQuery = "SELECT * FROM `Reciept_Voucher_Details` WHERE `Reciept_Id`=" + objReciept.RV_Id;
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
