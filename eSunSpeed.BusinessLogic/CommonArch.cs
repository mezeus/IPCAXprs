using System;
using System.Collections.Generic;
using System.Text;
using eSunSpeed.DataAccess;

namespace eSunSpeed.BusinessLogic
{
    public class CommonArch
    {
        private DBHelper _dbHelper = new DBHelper();
        private Arch arch = new Arch();

        public bool DataExistForMonth(string month, string year)
        {
            string monthYear = arch.DecodeMonthYear(month, year);
            string Query = "SELECT COUNT(*) FROM Expense_Details WHERE " +
                "MonthYear='" + monthYear + "' AND IsDeleted=0";

            if (Convert.ToInt16(_dbHelper.ExecuteScalar(Query).ToString()) > 0)
                return true;
            else
                return false;
        }
    }
}
