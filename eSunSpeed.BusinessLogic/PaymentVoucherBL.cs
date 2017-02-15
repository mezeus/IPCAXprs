using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace eSunSpeed.BusinessLogic
{
    public class PaymentVoucherBL
    {
        private DBHelper _dbHelper = new DBHelper();
        LedgerPostingBL objLPBL = new LedgerPostingBL();

        #region SAVE PAYMENT VOUCHER
        public bool SavePaymentVoucher(PaymentVoucherModel objpaymod)
        {
            string Query = string.Empty;
            //int payid = 0;
            bool isSaved = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();


                paramCollection.Add(new DBParameter("@VoucherNumber", objpaymod.Voucher_Number));
                paramCollection.Add(new DBParameter("@Series", objpaymod.Voucher_Series));
                paramCollection.Add(new DBParameter("@PayDate", objpaymod.Pay_Date, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Type", objpaymod.Type));
                paramCollection.Add(new DBParameter("@PaymentModeId", objpaymod.PaymentModeId));
                paramCollection.Add(new DBParameter("@PDCDate", objpaymod.PDCDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@LongNarration", objpaymod.LongNarration));
                paramCollection.Add(new DBParameter("@TotalCreditAmount", objpaymod.TotalCreditAmt, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalDebitAmount", objpaymod.TotalDebitAmt, DbType.Decimal));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                System.Data.IDataReader dr =
                  _dbHelper.ExecuteDataReader("spInsertPaymentMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                int id = 0;
                dr.Read(); 
                 id = Convert.ToInt32(dr[0]);
                SavePaymentAccounts(objpaymod.PaymentAccountModel, id);
                objLPBL.LedgerPostingAddByList(objpaymod.PaymentLPDebit);
                objLPBL.LedgerPostingAddByList(objpaymod.PaymentLPCredit);
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }
        //Save Payment Voucher Details
        public bool SavePaymentAccounts(List<AccountModel> lstAcc,int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (AccountModel Acc in lstAcc)
            {
                Acc.ParentId = ParentId;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@PaymentId", (Acc.ParentId)));
                    paramCollection.Add(new DBParameter("@DC", (Acc.DC)));
                    paramCollection.Add(new DBParameter("@Account", Acc.Account));
                    paramCollection.Add(new DBParameter("@LegderId", Acc.LedgerId));
                    paramCollection.Add(new DBParameter("@DebitAmount", Acc.Debit, DbType.Decimal));
                    paramCollection.Add(new DBParameter("@CreditAmount", Acc.Credit, DbType.Decimal));
                    paramCollection.Add(new DBParameter("@Narration", Acc.Narration));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now,DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                    paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                    System.Data.IDataReader dr =
                  _dbHelper.ExecuteDataReader("spInsertPaymentDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                   
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    //throw ex;
                }
            }
            return isSaved;
        }


        #endregion
        //Update Payment Voucher
        public bool UpdatePaymentVoucher(PaymentVoucherModel objPay)
        {
            string Query = string.Empty;
            bool isUpdated = true;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Series", objPay.Voucher_Series));
                paramCollection.Add(new DBParameter("@Date", objPay.Pay_Date,System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Voucher_Number", objPay.Voucher_Number));
                paramCollection.Add(new DBParameter("@Type", objPay.Type));
                paramCollection.Add(new DBParameter("@PaymentModeId", objPay.PaymentModeId));
                paramCollection.Add(new DBParameter("@PDDate", objPay.PDCDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@LongNarration", objPay.LongNarration));
                paramCollection.Add(new DBParameter("@TotalCreditAmt",objPay.TotalCreditAmt, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalDebitAmt",objPay.TotalDebitAmt, System.Data.DbType.Decimal));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now,System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@id", objPay.Pay_Id));

                Query = "UPDATE Payment_Voucher_Master SET `Series`=@Series,`PaymentModeId`=PaymentModeId,`Pay_Date`=@Date,`VoucherNo`=@Voucher_Number," +
                         "`Type`=@Type,`PDC_Date`=@PDDate,`LongNarration`=@LongNarration,`TotalCreditAmt`=@TotalCreditAmt,`TotalDebitAmt`=@TotalDebitAmt,`ModifiedBy`=@ModifiedBy," +
                        "`ModifiedDate`=@ModifiedDate " +
                        "WHERE Payment_Id=@id";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    List<AccountModel> lstAcct = new List<AccountModel>();

                    foreach (AccountModel act in objPay.PaymentAccountModel)
                    {
                        act.ParentId = objPay.Pay_Id;
                        if (act.AC_Id > 0)
                        {

                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@DC", (act.DC)));
                            paramCollection.Add(new DBParameter("@Account", act.Account));
                            paramCollection.Add(new DBParameter("@LegderId", act.LedgerId));
                            paramCollection.Add(new DBParameter("@Debit", act.Debit, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Credit", act.Credit, System.Data.DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Narration", act.Narration));

                            paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                            paramCollection.Add(new DBParameter("@ACT_ID", act.AC_Id));
                            paramCollection.Add(new DBParameter("@ParentId", act.ParentId));

                            Query = "UPDATE Payment_Voucher_Details SET `DC`=@DC," +
                            "`Account`=@Account,`Debit`=@Debit,`LegderId`=@LegderId,`Credit`=@Credit,`Narration`=@Narration,`ModifiedBy`=@ModifiedBy,`ModifiedDate`=@ModifiedDate " +
                            "WHERE `AC_Id`=@ACT_ID AND Payment_Id=@ParentId";

                            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                            {
                                isUpdated = true;
                            }
                        }
                        else
                        {
                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@PaymentId", (act.ParentId)));
                            paramCollection.Add(new DBParameter("@DC", (act.DC)));
                            paramCollection.Add(new DBParameter("@Account", act.Account));
                            paramCollection.Add(new DBParameter("@LegderId", act.LedgerId));
                            paramCollection.Add(new DBParameter("@DebitAmount", act.Debit, DbType.Decimal));
                            paramCollection.Add(new DBParameter("@CreditAmount", act.Credit, DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Amount", act.Amount, DbType.Decimal));
                            paramCollection.Add(new DBParameter("@Narration", act.Narration));

                            paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                            paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                            paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                            System.Data.IDataReader dr =
                          _dbHelper.ExecuteDataReader("spInsertPaymentDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
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

       


        //public List<PaymentVoucherModel> GetAllPaymentVoucher()
        //{
        //    List<PaymentVoucherModel> lstPayment = new List<PaymentVoucherModel>();
        //    PaymentVoucherModel objpay;

        //    string Query = "SELECT * FROM Payment_Voucher";
        //    System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

        //    while (dr.Read())
        //    {
        //        objpay = new PaymentVoucherModel();

        //        objpay.Pay_Id = DataFormat.GetInteger(dr["Pay_Id"]);
        //        objpay.Voucher_Series = dr["Series"].ToString();
        //        objpay.Pay_Date = DataFormat.GetDateTime(dr["Pay_Date"]);
        //        objpay.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
        //        objpay.Type = dr["Type"].ToString();
        //        objpay.PDCDate = Convert.ToDateTime(dr["PDCDate"].ToString());

        //        //SELECT Payment Voucher Accounts

        //        string itemQuery = "SELECT * FROM Payment_Voucher_Accounts WHERE Payment_Id=" + objpay.Pay_Id;
        //        System.Data.IDataReader drAcc = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

        //        objpay.PaymentAccountModel = new List<AccountModel>();
        //        AccountModel objAcc;

        //        while (drAcc.Read())
        //        {
        //            objAcc = new AccountModel();

        //            objAcc.AC_Id = DataFormat.GetInteger(drAcc["AC_Id"]);
        //            objAcc.ParentId = DataFormat.GetInteger(drAcc["Payment_Id"]);
        //            objAcc.DC = drAcc["DC"].ToString();
        //            objAcc.Account = drAcc["Account"].ToString();
        //            objAcc.Debit = Convert.ToDecimal(drAcc["Debit"]);
        //            objAcc.Credit = Convert.ToDecimal(drAcc["Credit"]);
        //            objAcc.Narration = drAcc["Narration"].ToString();


        //            objpay.PaymentAccountModel.Add(objAcc);

        //        }

        //        lstPayment.Add(objpay);

        //    }
        //    return lstPayment;
        //}

        //Delete Payment Voucher

            //Delete Payment Voucher
        public bool DeletPaymentVoucher(long id)
        {

            bool isDelete = false;
            try
            {
                if(DeletePaymentAccounts(id));
                {
                    string Query = "DELETE  FROM `Payment_Voucher_master` WHERE `Payment_Id`=" + id;
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

        public bool DeletePaymentAccounts(long id)
        {

            bool isDelete = true;
            try
            {
                string Query = "DELETE  FROM `Payment_Voucher_Details` WHERE `Payment_Id`=" + id;
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

        public List<ListModel> GetAllPaymentVoucher()
        {
            List<ListModel> lstModel = new List<ListModel>();
            ListModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT C.Payment_ID, C.Pay_DATE, C.VOUCHERNO, C.TYPE, A.DEBIT,A.CREDIT,A.Account,A.NARRATION FROM Payment_voucher_MASTER C   ");
            sbQuery.Append("INNER JOIN PAYMENT_VOUCHER_details A ");
            sbQuery.Append("ON A.PAYMENT_ID = C.PAYMENT_ID");

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new ListModel();

                objList.Id = Convert.ToInt32(dr["PAYMENT_ID"]);

                objList.Date = Convert.ToDateTime(dr["Pay_Date"]);
                objList.VoucherNo = Convert.ToInt32(dr["VOUCHERNO"]);
                objList.Account = Convert.ToString(dr["Account"]);
                objList.Debit = Convert.ToDecimal(dr["DEBIT"]);
                objList.Credit = Convert.ToDecimal(dr["CREDIT"]);
                objList.Narration = Convert.ToString(dr["NARRATION"]);
                lstModel.Add(objList);

            }
            return lstModel;
        }

        public List<PaymentVoucherModel> GetPaymentbyId(long id)
        {
            List<PaymentVoucherModel> lstPayment = new List<PaymentVoucherModel>();
            PaymentVoucherModel objPayment;
            StringBuilder SbQuery = new StringBuilder();
            SbQuery.AppendLine("SELECT p.*,m.ACC_Name FROM Payment_Voucher_Master as p");
            SbQuery.AppendLine("left join accountmaster as m on p.PaymentModeId=m.Ac_Id");
            SbQuery.AppendLine("WHERE `Payment_Id`=" + id);
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(SbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objPayment = new PaymentVoucherModel();

                objPayment.Pay_Id = DataFormat.GetInteger(dr["Payment_ID"]);
                objPayment.Voucher_Series = dr["Series"].ToString();
                objPayment.Pay_Date = DataFormat.GetDateTime(dr["Pay_Date"]);
                objPayment.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objPayment.Type = dr["Type"].ToString();
                objPayment.PaymentModeId = Convert.ToInt64(dr["PaymentModeId"].ToString());
                objPayment.PaymentMode = dr["ACC_Name"].ToString();
                objPayment.PDCDate = Convert.ToDateTime(dr["PDC_Date"]);
                objPayment.LongNarration = dr["LongNarration"].ToString();
                objPayment.TotalDebitAmt = Convert.ToDecimal(dr["TotalDebitAmt"]);
                objPayment.TotalCreditAmt = Convert.ToDecimal(dr["TotalCreditAmt"]);


                //SELECT Payment Voucher Details

                string itemQuery = "SELECT * FROM `Payment_Voucher_Details` WHERE `Payment_Id`=" + objPayment.Pay_Id;
                System.Data.IDataReader drAcc = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objPayment.PaymentAccountModel = new List<AccountModel>();
                AccountModel objAcc;

                while (drAcc.Read())
                {
                    objAcc = new AccountModel();

                    objAcc.AC_Id = DataFormat.GetInteger(drAcc["AC_Id"]);
                    objAcc.ParentId = DataFormat.GetInteger(drAcc["Payment_Id"]);
                    objAcc.DC = drAcc["DC"].ToString();
                    objAcc.Account = drAcc["Account"].ToString();
                    objAcc.LedgerId = Convert.ToInt64(drAcc["LegderId"].ToString());
                    objAcc.Debit = Convert.ToDecimal(drAcc["Debit"]);
                    objAcc.Credit = Convert.ToDecimal(drAcc["Credit"]);
                    objAcc.Amount = Convert.ToDecimal(drAcc["Debit"]);
                    objAcc.Narration = drAcc["Narration"].ToString();

                    objPayment.PaymentAccountModel.Add(objAcc);
                }

                lstPayment.Add(objPayment);

            }
            return lstPayment;
        }
    }
}
