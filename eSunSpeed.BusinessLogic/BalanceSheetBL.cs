using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace eSunSpeed.BusinessLogic
{

    public class BalanceSheetBL
    {
        string connString = ConfigurationManager.ConnectionStrings["mySqlConTest"].ToString();
     

        public DataSet BalanceSheet(DateTime fromDate, DateTime toDate)
        {
            DataSet dset = new DataSet();
            MySqlConnection sqlcon = new MySqlConnection(connString);

            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                MySqlDataAdapter sdaadapter = new MySqlDataAdapter("BalanceSheet", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                MySqlParameter prm = new MySqlParameter();
                prm = sdaadapter.SelectCommand.Parameters.Add("?S_fromDate", MySqlDbType.DateTime);
                prm.Value = fromDate;
                prm = sdaadapter.SelectCommand.Parameters.Add("?S_toDate", MySqlDbType.DateTime);
                prm.Value = toDate;
                sdaadapter.Fill(dset);
            }
            catch (Exception ex)
            {
                //formMDI.infoError.ErrorString = ex.ToString();
            }
            finally
            {
                sqlcon.Close();
            }
            return dset;
        }
       public class CurrencyInfo
        {
            #region Variables
            /// <summary>
            /// Public variable declaration part
            /// </summary>
            private decimal _currencyId;
            private string _currencySymbol;
            private string _currencyName;
            private string _subunitName;
            private int _noOfDecimalPlaces;
            private string _narration;
            private bool _isDefault;
            private DateTime _extraDate;
            private string _extra1;
            private string _extra2;
            #endregion
            #region properties
            /// <summary>
            /// Property to get and set CurrencyId
            /// </summary>
            public decimal CurrencyId
            {
                get { return _currencyId; }
                set { _currencyId = value; }
            }
            /// <summary>
            /// Property to get and set CurrencySymbol
            /// </summary>
            public string CurrencySymbol
            {
                get { return _currencySymbol; }
                set { _currencySymbol = value; }
            }
            /// <summary>
            /// Property to get and set CurrencyName
            /// </summary>
            public string CurrencyName
            {
                get { return _currencyName; }
                set { _currencyName = value; }
            }
            /// <summary>
            /// Property to get and set SubunitName
            /// </summary>
            public string SubunitName
            {
                get { return _subunitName; }
                set { _subunitName = value; }
            }
            /// <summary>
            /// Property to get and set NoOfDecimalPlaces
            /// </summary>
            public int NoOfDecimalPlaces
            {
                get { return _noOfDecimalPlaces; }
                set { _noOfDecimalPlaces = value; }
            }
            /// <summary>
            /// Property to get and set Narration
            /// </summary>
            public string Narration
            {
                get { return _narration; }
                set { _narration = value; }
            }
            /// <summary>
            /// Property to get and set IsDefault
            /// </summary>
            public bool IsDefault
            {
                get { return _isDefault; }
                set { _isDefault = value; }
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
        
        /// <summary>
        /// Function to get Stock Value get On Date
        /// </summary>
        /// <param name="date"></param>
        /// <param name="calculationMethod"></param>
        /// <param name="isOpeningStock"></param>
        /// <param name="isFromBalanceSheet"></param>
        /// <returns></returns>
        public decimal StockValueGetOnDate(DateTime date, string calculationMethod, bool isOpeningStock, bool isFromBalanceSheet)
        {
            decimal dcstockValue = 0;
            MySqlConnection sqlcon = new MySqlConnection(connString);
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                object obj = null;
                MySqlParameter prm = new MySqlParameter();
                MySqlCommand sccmd = new MySqlCommand();
                if (calculationMethod == "FIFO")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByFIFOForOpeningStock", sqlcon);
                            prm = sccmd.Parameters.Add("?S_fromDate", MySqlDbType.DateTime);
                            prm.Value = "01-01-2016";
                        }
                        else
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByFIFOForOpeningStockForBalancesheet", sqlcon);
                            prm = sccmd.Parameters.Add("?S_fromDate", MySqlDbType.DateTime);
                            //prm = sccmd.Parameters.Add("?S_date", MySqlDbType.DateTime);
                            prm.Value = "12-12-2016";
                        }
                    }
                    else
                    {
                        sccmd = new MySqlCommand("StockValueOnDateByFIFO", sqlcon);
                    }
                }
                else if (calculationMethod == "Average Cost")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByAVCOForOpeningStock", sqlcon);
                        }
                        else
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByAVCOForOpeningStockForBalanceSheet", sqlcon);
                        }
                        prm = sccmd.Parameters.Add("?S_fromDate", MySqlDbType.DateTime);
                        prm.Value = "12-12-2016";
                    }
                    else
                    {
                        sccmd = new MySqlCommand("StockValueOnDateByAVCO", sqlcon);
                    }
                }
                else if (calculationMethod == "High Cost")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByHighCostForOpeningStock", sqlcon);
                        }
                        else
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByHighCostForOpeningStockBlncSheet", sqlcon);
                        }
                        prm = sccmd.Parameters.Add("?S_fromDate", MySqlDbType.DateTime);
                        prm.Value = "01-01-2016";
                    }
                    else
                    {
                        sccmd = new MySqlCommand("StockValueOnDateByHighCost", sqlcon);
                    }
                }
                else if (calculationMethod == "Low Cost")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByLowCostForOpeningStock", sqlcon);
                        }
                        else
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByLowCostForOpeningStockForBlncSheet", sqlcon);
                        }
                        prm = sccmd.Parameters.Add("?S_fromDate", MySqlDbType.DateTime);
                        prm.Value = "01-01-2016";
                    }
                    else
                    {
                        sccmd = new MySqlCommand("StockValueOnDateByLowCost", sqlcon);
                    }
                }
                else if (calculationMethod == "Last Purchase Rate")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByLastPurchaseRateForOpeningStock", sqlcon);
                        }
                        else
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByLastPurchaseRateForOpeningStockBlncSheet", sqlcon);
                        }
                        prm = sccmd.Parameters.Add("?S_fromDate", MySqlDbType.DateTime);
                        prm.Value = "01-01-2016";
                    }
                    else
                    {
                        sccmd = new MySqlCommand("StockValueOnDateByLastPurchaseRate", sqlcon);
                    }
                }
                sccmd.CommandType = CommandType.StoredProcedure;
                prm = sccmd.Parameters.Add("?S_date", MySqlDbType.DateTime);
                prm.Value = date;
                obj = sccmd.ExecuteScalar();
                if (obj != null)
                {
                    decimal.TryParse(obj.ToString(), out dcstockValue);
                }
            }
            catch (Exception ex)
            {
                //formMDI.infoError.ErrorString = ex.ToString();
            }
            finally
            {
                sqlcon.Close();
            }
            return dcstockValue;
        }
        /// <summary>
        /// Function to get Stock value on date for Profit and loss account
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dtToDate"></param>
        /// <param name="calculationMethod"></param>
        /// <param name="isOpeningStock"></param>
        /// <param name="isFromBalanceSheet"></param>
        /// <returns></returns>
        public decimal StockValueGetOnDate(DateTime date, DateTime dtToDate, string calculationMethod, bool isOpeningStock, bool isFromBalanceSheet)
        {
            MySqlConnection sqlcon = new MySqlConnection(connString);
            decimal dcstockValue = 0;
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                object obj = null;
                MySqlParameter prm = new MySqlParameter();
                MySqlCommand sccmd = new MySqlCommand();
                if (calculationMethod == "FIFO")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByFIFOForOpeningStock", sqlcon);
                            prm = sccmd.Parameters.Add("?S_fromDate", MySqlDbType.DateTime);
                            prm.Value = "01-01-2016";
                        }
                        else
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByFIFOForOpeningStockForBalancesheet", sqlcon);
                            prm = sccmd.Parameters.Add("?S_date", MySqlDbType.DateTime);
                            prm.Value = "12-12-2016";
                        }
                    }
                    else
                    {
                        sccmd = new MySqlCommand("StockValueOnDateByFIFO", sqlcon);
                    }
                }
                else if (calculationMethod == "Average Cost")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByAVCOForOpeningStock", sqlcon);
                        }
                        else
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByAVCOForOpeningStockForBalanceSheet", sqlcon);
                        }
                        prm = sccmd.Parameters.Add("?S_fromDate", MySqlDbType.DateTime);
                        prm.Value = dtToDate;
                    }
                    else
                    {
                        sccmd = new MySqlCommand("StockValueOnDateByAVCO", sqlcon);
                    }
                }
                else if (calculationMethod == "High Cost")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByHighCostForOpeningStock", sqlcon);
                        }
                        else
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByHighCostForOpeningStockBlncSheet", sqlcon);
                        }
                        prm = sccmd.Parameters.Add("?S_fromDate", MySqlDbType.DateTime);
                        prm.Value = "01-01-2017";
                    }
                    else
                    {
                        sccmd = new MySqlCommand("StockValueOnDateByHighCost", sqlcon);
                    }
                }
                else if (calculationMethod == "Low Cost")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByLowCostForOpeningStock", sqlcon);
                        }
                        else
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByLowCostForOpeningStockForBlncSheet", sqlcon);
                        }
                        prm = sccmd.Parameters.Add("?S_fromDate", MySqlDbType.DateTime);
                        prm.Value = "01-01-2016";
                    }
                    else
                    {
                        sccmd = new MySqlCommand("StockValueOnDateByLowCost", sqlcon);
                    }
                }
                else if (calculationMethod == "Last Purchase Rate")
                {
                    if (isOpeningStock)
                    {
                        if (!isFromBalanceSheet)
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByLastPurchaseRateForOpeningStock", sqlcon);
                        }
                        else
                        {
                            sccmd = new MySqlCommand("StockValueOnDateByLastPurchaseRateForOpeningStockBlncSheet", sqlcon);
                        }
                        prm = sccmd.Parameters.Add("?S_fromDate", MySqlDbType.DateTime);
                        prm.Value = dtToDate;
                    }
                    else
                    {
                        sccmd = new MySqlCommand("StockValueOnDateByLastPurchaseRate", sqlcon);
                    }
                }
                sccmd.CommandType = CommandType.StoredProcedure;
                prm = sccmd.Parameters.Add("?S_date", MySqlDbType.DateTime);
                prm.Value = date;
                obj = sccmd.ExecuteScalar();
                if (obj != null)
                {
                    decimal.TryParse(obj.ToString(), out dcstockValue);
                }
            }
            catch (Exception ex)
            {
                // formMDI.infoError.ErrorString = ex.ToString();
            }
            finally
            {
                sqlcon.Close();
            }
            return dcstockValue;
        }

        public DataSet ProfitAndLossAnalysisUpToaDateForPreviousYears(DateTime toDate)
        {
            DataSet dset = new DataSet();
            MySqlConnection sqlcon = new MySqlConnection(connString);
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                MySqlDataAdapter sdaadapter = new MySqlDataAdapter("ProfitAndLossAnalysisUpToaDateForPreviousYears", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                MySqlParameter prm = new MySqlParameter();
                prm = sdaadapter.SelectCommand.Parameters.Add("?S_fromDate", MySqlDbType.DateTime);
                prm.Value = toDate;
                sdaadapter.Fill(dset);
            }
            catch (Exception ex)
            {
                //       formMDI.infoError.ErrorString = ex.ToString();
            }
            finally
            {
                sqlcon.Close();
            }
            return dset;
        }


        public DataSet ProfitAndLossAnalysisUpToaDateForBalansheet(DateTime fromDate, DateTime toDate)
        {
            DataSet dset = new DataSet();
            MySqlConnection sqlcon = new MySqlConnection(connString);
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                MySqlDataAdapter sdaadapter = new MySqlDataAdapter("ProfitAndLossAnalysisUpToaDateForBalansheet", sqlcon);
                sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                MySqlParameter prm = new MySqlParameter();
                prm = sdaadapter.SelectCommand.Parameters.Add("?S_fromDate", MySqlDbType.DateTime);
                prm.Value = fromDate;
                prm = sdaadapter.SelectCommand.Parameters.Add("?S_toDate", MySqlDbType.DateTime);
                prm.Value = toDate;
                sdaadapter.Fill(dset);
            }
            catch (Exception ex)
            {
                //formMDI.infoError.ErrorString = ex.ToString();
            }
            finally
            {
                sqlcon.Close();
            }
            return dset;
        }
    }
}
