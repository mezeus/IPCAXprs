namespace eSunSpeedDomain
{
    public class EmployeeGroupModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string AliasName { get; set; }
        public bool Primary { get; set; }
        public string UnderGroup { get; set; }
        public string NatureGroup { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool CanDelete { get; set; }
    }
}
