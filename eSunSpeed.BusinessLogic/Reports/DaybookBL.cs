using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain.Reports;

namespace eSunSpeed.BusinessLogic.Reports
{
    public class DaybookBL
    {
        public List<DayBookModel> GetAllDayBooks()
        {
            //TODO: DB Call to get day books

            List<DayBookModel> lstDayBooks = new List<DayBookModel>
            {

                new DayBookModel {Date =Convert.ToDateTime("12/12/2016"),Account="Test Account",Type="test type", Narration="Test Narration", VchNumber="12345" },
                new DayBookModel {Date =Convert.ToDateTime("12/12/2016"),Account="Test Account",Type="test type", Narration="Test Narration", VchNumber="12345" },
                new DayBookModel {Date =Convert.ToDateTime("12/12/2016"),Account="Test Account",Type="test type", Narration="Test Narration", VchNumber="12345" }
            };

            return lstDayBooks;
        }
    }
}


