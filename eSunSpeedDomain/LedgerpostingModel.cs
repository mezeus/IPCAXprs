using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
  public  class LedgerPostingModel
    {
        #region Variables
        /// <summary>
        /// Public variable declaration part
        /// </summary>
        private decimal _ledgerPostingId;
        private DateTime _date;
        private decimal _voucherTypeId;
        private string _voucherNo;
        private decimal _ledgerId;
        private decimal _debit;
        private decimal _credit;

        private decimal _detailsId;
        private decimal _yearId;
        private string _invoiceNo;
        private string _chequeNo;
        private DateTime _chequeDate;
        private DateTime _extraDate;
        private string _extra1;
        private string _extra2;
        #endregion
        #region properties
        /// <summary>
        /// Property to get and set LedgerPostingId
        /// </summary>

        public decimal LedgerPostingId
        {
            get { return _ledgerPostingId; }
            set { _ledgerPostingId = value; }
        }
        /// <summary>
        /// Property to get and set Date
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        /// <summary>
        /// Property to get and set VoucherTypeId
        /// </summary>
        public decimal VoucherTypeId
        {
            get { return _voucherTypeId; }
            set { _voucherTypeId = value; }
        }
        /// <summary>
        /// Property to get and set VoucherNo
        /// </summary>
        public string VoucherNo
        {
            get { return _voucherNo; }
            set { _voucherNo = value; }
        }
        /// <summary>
        /// Property to get and set LedgerId
        /// </summary>
        public decimal LedgerId
        {
            get { return _ledgerId; }
            set { _ledgerId = value; }
        }
        /// <summary>
        /// Property to get and set Debit
        /// </summary>
        public decimal Debit
        {
            get { return _debit; }
            set { _debit = value; }
        }
        /// <summary>
        /// Property to get and set Credit
        /// </summary>
        public decimal Credit
        {
            get { return _credit; }
            set { _credit = value; }
        }
        /// <summary>
        /// Property to get and set DetailsId
        /// </summary>
        public decimal DetailsId
        {
            get { return _detailsId; }
            set { _detailsId = value; }
        }
        /// <summary>
        /// Property to get and set YearId
        /// </summary>
        public decimal YearId
        {
            get { return _yearId; }
            set { _yearId = value; }
        }
        /// <summary>
        /// Property to get and set InvoiceNo
        /// </summary>
        public string InvoiceNo
        {
            get { return _invoiceNo; }
            set { _invoiceNo = value; }
        }
        /// <summary>
        /// Property to get and set ChequeNo
        /// </summary>
        public string ChequeNo
        {
            get { return _chequeNo; }
            set { _chequeNo = value; }
        }
        /// <summary>
        /// Property to get and set HolidayId
        /// </summary>
        public DateTime ChequeDate
        {
            get { return _chequeDate; }
            set { _chequeDate = value; }
        }
        /// <summary>
        /// Property to get and set ExtraDate
        /// </summary>
        public DateTime ExtraDate
        {
            get { return _extraDate; }
            set { _extraDate = value; }
        }
        /// <summary>
        /// Property to get and set Extra1
        /// </summary>   
        public string Extra1
        {
            get { return _extra1; }
            set { _extra1 = value; }
        }
        /// <summary>
        /// Property to get and set Extra2
        /// </summary>  
        public string Extra2
        {
            get { return _extra2; }
            set { _extra2 = value; }
        }
        #endregion
    }
}
