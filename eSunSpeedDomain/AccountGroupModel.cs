using System.Collections.Generic;

namespace eSunSpeedDomain
{
    public class AccountGroupModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string AliasName { get; set; }
        public bool Primary { get; set; }
        public string UnderGroup { get; set; }
        public int UnderGroupId { get; set; }
        public int NatureGroupId { get; set; }
        public string DC { get; set; }
        //Master Series Group Popup Grid
        public List<MasterseriesModel> AGMasterSeries { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool CanDelete { get; set; }
        public string NatureGroup { get; set; }
        public bool IsAffectGrossProfit { get; set; }
    }
}
