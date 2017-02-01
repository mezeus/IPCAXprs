using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using System.Data;

namespace eSunSpeed.BusinessLogic
{
    public class LedgerPostingBL
    {
        private DBHelper _dbHelper = new DBHelper();

        public void LedgerPostingAdd(LedgerPostingModel ledgerpostinginfo)
        {
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@S_date", ledgerpostinginfo.Date, DbType.DateTime));
                paramCollection.Add(new DBParameter("@S_voucherTypeId", ledgerpostinginfo.VoucherTypeId));
                paramCollection.Add(new DBParameter("@S_voucherNo", ledgerpostinginfo.VoucherNo));
                paramCollection.Add(new DBParameter("@S_ledgerId", ledgerpostinginfo.LedgerId));
                paramCollection.Add(new DBParameter("@S_debit", ledgerpostinginfo.Debit,DbType.Decimal));
                paramCollection.Add(new DBParameter("@S_credit", ledgerpostinginfo.Credit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@S_detailsId", ledgerpostinginfo.DetailsId));
                paramCollection.Add(new DBParameter("@S_yearId", ledgerpostinginfo.YearId));
                paramCollection.Add(new DBParameter("@S_invoiceNo", ledgerpostinginfo.InvoiceNo));
                paramCollection.Add(new DBParameter("@S_chequeNo", ledgerpostinginfo.ChequeNo));
                paramCollection.Add(new DBParameter("@S_chequeDate", ledgerpostinginfo.ChequeDate,DbType.DateTime));
                paramCollection.Add(new DBParameter("@S_extra1", ledgerpostinginfo.Extra1));
                paramCollection.Add(new DBParameter("@S_extra2", ledgerpostinginfo.Extra2));

                IDataReader dr = _dbHelper.ExecuteDataReader("spLedgerPostingAdd", _dbHelper.GetConnObject(), paramCollection, CommandType.StoredProcedure);
               
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                
            }
        }

        //Ledger Posting Edit
        public void LedgerPostingEdit(LedgerPostingModel ledgerpostinginfo)
        {
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@S_parentId", ledgerpostinginfo.ParentId));
                paramCollection.Add(new DBParameter("@S_date", ledgerpostinginfo.Date, DbType.DateTime));
                paramCollection.Add(new DBParameter("@S_voucherTypeId", ledgerpostinginfo.VoucherTypeId));
                paramCollection.Add(new DBParameter("@S_voucherNo", ledgerpostinginfo.VoucherNo));
                paramCollection.Add(new DBParameter("@S_ledgerId", ledgerpostinginfo.LedgerId));
                paramCollection.Add(new DBParameter("@S_debit", ledgerpostinginfo.Debit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@S_credit", ledgerpostinginfo.Credit, DbType.Decimal));
                paramCollection.Add(new DBParameter("@S_detailsId", ledgerpostinginfo.DetailsId));
                paramCollection.Add(new DBParameter("@S_yearId", ledgerpostinginfo.YearId));
                paramCollection.Add(new DBParameter("@S_invoiceNo", ledgerpostinginfo.InvoiceNo));
                paramCollection.Add(new DBParameter("@S_chequeNo", ledgerpostinginfo.ChequeNo));
                paramCollection.Add(new DBParameter("@S_chequeDate", ledgerpostinginfo.ChequeDate, DbType.DateTime));
                paramCollection.Add(new DBParameter("@S_extra1", ledgerpostinginfo.Extra1));
                paramCollection.Add(new DBParameter("@S_extra2", ledgerpostinginfo.Extra2));

                IDataReader dr = _dbHelper.ExecuteDataReader("spLedgerPostingUpdate", _dbHelper.GetConnObject(), paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

        }
        //Delete Ledger Posting Details
        public bool LedgerPostingDelete(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `tbl_ledgerposting` WHERE ledgerId=" + id;
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
    }
}
