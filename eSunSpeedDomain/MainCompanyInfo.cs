using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class MainCompanyInfo
    {
        #region Variables
        /// <summary>
        /// Public variable declaration part
        /// </summary>
        private decimal _companyId;
        private string _companyName;
        private bool _IsDefault;
        #endregion
        #region properties
        /// <summary>
        /// Property to get and set CompanyId
        /// </summary>
        public decimal CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }
        /// <summary>
        /// Property to get and set CompanyName
        /// </summary>
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        /// <summary>
        /// Property to get and set IsDefault
        /// </summary>
        public bool IsDefault
        {
            get { return _IsDefault; }
            set { _IsDefault = value; }
        }
        #endregion
    }
}
