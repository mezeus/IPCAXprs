using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
   public class FinancialYearModel
    {
        #region Variables
        /// <summary>
        /// Public variable declaration part
        /// </summary>
        private decimal _financialYearId;
        private DateTime _fromDate;
        private DateTime _toDate;
        private DateTime _extraDate;
        private string _extra1;
        private string _extra2;
        #endregion
        #region properties
        /// <summary>
        /// Property to get and set FinancialYearId
        /// </summary>
        public decimal FinancialYearId
        {
            get { return _financialYearId; }
            set { _financialYearId = value; }
        }
        /// <summary>
        /// Property to get and set FromDate
        /// </summary>
        public DateTime FromDate
        {
            get { return _fromDate; }
            set { _fromDate = value; }
        }
        /// <summary>
        /// Property to get and set ToDate
        /// </summary>
        public DateTime ToDate
        {
            get { return _toDate; }
            set { _toDate = value; }
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
