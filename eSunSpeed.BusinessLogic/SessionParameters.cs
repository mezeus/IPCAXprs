using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace eSunSpeed.BusinessLogic
{    
    public static class SessionParameters
    {        
        public static DataSet GetDataSet { get; set; }
        public static List<string> GetSettingsList { get; set; }

        public static List<int> ListIds { get; set; }
        public static string VoucherNo { get; set; }

        public static Control SettingsControl { get; set; }

        public static Form GridForm { get; set; }

        public static Form ItemForm { get; set; }
        public static Form BSForm { get; set; }

        public static Control CtrlItem { get; set; }

        public static DataSet dsDiscountStruct { get; set; }
        public static DataSet dsSales_Items { get; set; }
        public static DataSet dsSales_BS { get; set; }
        public static DataSet dsTaxRates { get; set; }
        public static DataSet dsBS_MatConsumed { get; set; }
        public static DataSet dsBS_ProdGenerated { get; set; }

        public static Control BS_MatConsumed { get; set; }
        public static Control BS_ProdGenerated { get; set; }

        public static string SalesItemName { get; set; }

        private static int _userId = 0;

        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        public static int UserID
        {
            get 
            {
                return _userId;
            }
            set 
            {
                _userId = value;
            }
        }

        private static Common.UserRole _userRole;

        /// <summary>
        /// Gets or Sets UserRole
        /// </summary>
        public static Common.UserRole UserRole
        {
            get
            {
                return _userRole;
            }
            set
            {
                _userRole = value;
            }
        }


        private static string _userName = String.Empty;

        /// <summary>
        /// Gets or Sets UserName
        /// </summary>
        public static string UserName
        {
            get 
            {
                return _userName;
            }
            set 
            {
                _userName = value;                
            }
        }
    }
}
