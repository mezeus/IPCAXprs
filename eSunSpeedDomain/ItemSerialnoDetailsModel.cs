using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class ItemSerialnoDetailsModel
    {
        public int SL_ID { get; set; }
        public int parent_Id { get; set; }
        public bool ManualNuber { get; set; }
        public bool AutoNumber { get; set; }
        public int StaringAutoNo { get; set; }
        public string NumberingFreq { get; set; }
        public string StructureName { get; set; }
        public bool RegenarateAutoNo { get; set; }
        public bool TrackPurcWaranty { get; set; }
        public bool TrackSaleWaranty { get; set; }
        public bool TrackInstallationWaranty { get; set; }
    }
}
