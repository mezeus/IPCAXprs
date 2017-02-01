using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;

namespace eSunSpeed.BusinessLogic
{
    public class FinancialYeaBL
    {
        private DBHelper _dbHelper = new DBHelper();

        /// <summary>
        /// Function to get particular values from FinancialYear  table based on the parameter
        /// </summary>
        /// <param name="financialYearId"></param>
        /// <returns></returns>
        public FinancialYearModel FinancialYearViewForAccountLedger(decimal financialYearId)
        {
            FinancialYearModel financialyearinfo = new FinancialYearModel();
            
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@S_financialYearId", financialYearId));

                IDataReader sdrreader = _dbHelper.ExecuteDataReader("spFinancialYearViewForAccountLedger",_dbHelper.GetConnObject(),CommandType.StoredProcedure);
                while (sdrreader.Read())
                {
                    financialyearinfo.FinancialYearId = decimal.Parse(sdrreader[0].ToString());
                    financialyearinfo.FromDate = DateTime.Parse(sdrreader[1].ToString());
                }
            }
            catch (Exception ex)
            {
            
            }
            finally
            {
            
            
            }
            return financialyearinfo;
        }
        
        
    }
}
