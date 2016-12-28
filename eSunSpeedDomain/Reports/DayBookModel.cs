using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain.Reports
{
   public class DayBookModel
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string VchNumber { get; set; }
        public string Account { get; set; }
        public string Narration { get; set; }
    }
}
