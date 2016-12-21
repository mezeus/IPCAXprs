using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using eSunSpeed.DataAccess;

namespace eSunSpeed.BusinessLogic
{
    public class Analytics
    {
        private Arch arch = new Arch();
        private DBHelper _dbHelper = new DBHelper();
        private ReportArchitecture reportArch = new ReportArchitecture();
        private CommonArch commonReportArch = new CommonArch();
        private ItemWiseAnalytics itemAnalytics = new ItemWiseAnalytics();

        public DataTable AnalyticReport(string month, string year, AnalyticReportType reportType)
        {
            if (reportType.ToString().Equals("Individual"))
                return MonthlyTrendReport(month, year);
            else
                return itemAnalytics.ItemWiseTrendReport(month, year);
        }

      
        public DataTable MonthlyTrendReport(string month, string year)
        {
            DataTable data = new DataTable();

            //Checks that Data exist for present month or not?
            string presentMMYYYY = arch.DecodeMonthYear(month, year);
            bool dataExistForPresntMonth = commonReportArch.DataExistForMonth(month, year);

            //Checks that Data exist for prev month or not?            
            string previousMonth = arch.GetPreviousMonth(month);
            string previousMonthYear = arch.GetPrevMonthsYear(month, year);
            string prevMMYYYY = arch.DecodeMonthYear(previousMonth, previousMonthYear);
            bool dataExistForPrevMonth = commonReportArch.DataExistForMonth(previousMonth, previousMonthYear);

            //Checks that Data exist for next month or not?
            string nextMonth = arch.GetNextMonth(month);
            string nextMonthYear = arch.GetNextMonthsYear(month, year);
            string nextMMYYYY = arch.DecodeMonthYear(nextMonth, nextMonthYear);
            bool dataExistForNextMonth = commonReportArch.DataExistForMonth(nextMonth, nextMonthYear);

            string[,] reportData = null;

            string[] columnName = null ;

            if (dataExistForPresntMonth && dataExistForPrevMonth && dataExistForNextMonth)
            {
                columnName = new string[] { "Expensed By", previousMonth + " (Prev.)", "Trend1", month + " (Pres.)", "Trend2", nextMonth + " (Nxt.)" };
                reportData = new string[reportArch.GetAllUsers().Length, 6];
                reportData = GetReportData1(prevMMYYYY, presentMMYYYY, nextMMYYYY);
                data = arch.GetDataTableFrom2DArray(columnName, reportData);
            }
            else if (dataExistForPresntMonth && dataExistForPrevMonth && !dataExistForNextMonth)
            {
                columnName = new string[] { "Expensed By", previousMonth + " (Prev.)", "Trend", month + " (Pres.)" };
                reportData = new string[reportArch.GetAllUsers().Length, 4];
                reportData = GetReportData2(prevMMYYYY, presentMMYYYY);
                data = arch.GetDataTableFrom2DArray(columnName, reportData);
            }
            else if (dataExistForPresntMonth && !dataExistForPrevMonth && !dataExistForNextMonth)
            {
                columnName = new string[] { "Expensed By", month + " (Pres.)" };
                data = reportArch.MonthlyReportData(month, year);
            }
            else if (dataExistForPresntMonth && !dataExistForPrevMonth && dataExistForNextMonth)
            {
                columnName = new string[] { "Expensed By", month + " (Pres.)", "Trend", nextMonth + " (Nxt.)" };
                reportData = new string[reportArch.GetAllUsers().Length, 4];
                reportData = GetReportData2(presentMMYYYY, nextMMYYYY);
                data = arch.GetDataTableFrom2DArray(columnName, reportData);
            }

            return data;
        }

        private string[,] GetReportData1(string previousMonthYear, string presentMonthYear,  string nextMonthYear)
        {
            int numOfUsers = reportArch.GetAllUsers().Length;
            string[,] reportData = new string[numOfUsers + 1, 6];
            string[] expBy = reportArch.GetAllUsers();
            string[] prevMontExpense = reportArch.GetExpenseByUsers(previousMonthYear);
            string[] trndPreviousPresent = new string[prevMontExpense.Length];
            string[] presentMontExpense = reportArch.GetExpenseByUsers(presentMonthYear);
            string[] trendPresentVsNextMonth = new string[presentMontExpense.Length];
            string[] nextMontExpense = reportArch.GetExpenseByUsers(nextMonthYear);

            double sumPrevMonthExp = GetTotalExpense(prevMontExpense);
            double sumPresentMonthExp = GetTotalExpense(presentMontExpense);
            double sumNextMonthExp = GetTotalExpense(nextMontExpense);

            for (int row = 0; row <= numOfUsers; row++)
            {
                if (row == numOfUsers)
                {
                    reportData[row, 0] = "T O T A L :";
                    reportData[row, 1] = sumPrevMonthExp.ToString();
                    reportData[row, 2] = GetTrendSymbol(sumPrevMonthExp.ToString(), sumPresentMonthExp.ToString());
                    reportData[row, 3] = sumPresentMonthExp.ToString();
                    reportData[row, 4] = GetTrendSymbol(sumPresentMonthExp.ToString(), sumNextMonthExp.ToString());
                    reportData[row, 5] = sumNextMonthExp.ToString();
                }
                else
                {
                    reportData[row, 0] = expBy[row];
                    reportData[row, 1] = prevMontExpense[row];
                    reportData[row, 2] = GetTrendSymbol(prevMontExpense[row], presentMontExpense[row]);
                    reportData[row, 3] = presentMontExpense[row];
                    reportData[row, 4] = GetTrendSymbol(presentMontExpense[row], nextMontExpense[row]);
                    reportData[row, 5] = nextMontExpense[row];
                }
            }

            return reportData;
        }

        private double GetTotalExpense(string[] expenses)
        {
            double totalExpense = 0.0;
            for (int i = 0; i < expenses.Length; i++)
            {
                totalExpense = totalExpense + Convert.ToDouble(expenses[i]);
            }

            return totalExpense;
        }

        private string[,] GetReportData2(string previousMonthYear, string presentMonthYear)
        {
            int numOfUsers = reportArch.GetAllUsers().Length;
            string[,] reportData = new string[numOfUsers + 1, 4];
            string[] expBy = reportArch.GetAllUsers();
            string[] prevMontExpense = reportArch.GetExpenseByUsers(previousMonthYear);
            string[] trndPreviousPresent = new string[prevMontExpense.Length];
            string[] presentMontExpense = reportArch.GetExpenseByUsers(presentMonthYear);

            double sumPrevMonthExp = GetTotalExpense(prevMontExpense);
            double sumPresentMonthExp = GetTotalExpense(presentMontExpense);
            
            for (int row = 0; row <= reportArch.GetAllUsers().Length; row++)
            {
                if (row == numOfUsers)
                {
                    reportData[row, 0] = "T O T A L :";
                    reportData[row, 1] = sumPrevMonthExp.ToString();
                    reportData[row, 2] = GetTrendSymbol(sumPrevMonthExp.ToString(), sumPresentMonthExp.ToString());
                    reportData[row, 3] = sumPresentMonthExp.ToString();
                }
                else
                {
                    reportData[row, 0] = expBy[row];
                    reportData[row, 1] = prevMontExpense[row];
                    reportData[row, 2] = GetTrendSymbol(prevMontExpense[row], presentMontExpense[row]);
                    reportData[row, 3] = presentMontExpense[row];
                }
            }
            return reportData;
        }

        private string GetTrendSymbol(string month1, string month2)
        {
            double firstMonth = Convert.ToDouble(month1);
            double secMonth = Convert.ToDouble(month2);

            if (firstMonth > secMonth)
                return " > ";
            else if (firstMonth < secMonth)
                return " < ";
            else
                return " - ";
        }      

        public enum AnalyticReportType
        {
            Individual,ItemWise,OverAll
        }              
    }
}
