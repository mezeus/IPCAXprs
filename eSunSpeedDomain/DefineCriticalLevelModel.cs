using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class DefineCriticalLevelModel
    {
        public int DC_Id { get; set; }
        public int ParentId { get; set; }
        public decimal MinimumLevelQty { get; set; }
        public decimal RecordLevelQty { get; set; }
        public decimal MaximumLevelQty { get; set; }
        public decimal MinimumLevelDays { get; set; }
        public decimal RecordLevelDays { get; set; }
        public decimal MaximumLevelDays { get; set; }
    }
}
