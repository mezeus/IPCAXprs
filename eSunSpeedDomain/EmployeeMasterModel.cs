using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class EmployeeMasterModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string ShortName { get; set; }

        public string PrintName { get; set; }
        public string Group { get; set; }

        public string Designation { get; set; }
        public string FatherName { get; set; }
        public string SpouseName { get; set; }

        public string Address { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }

        public string DateofBirth { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string email { get; set; }
        public string ITpan { get; set; }

        public string DefaultSaleType { get; set; }
        public string FreezeSaleType { get; set; }
        public bool SpecifyDefaultPurType { get; set; }

        public string DateofJoining { get; set; }     
        public string CurrentStatus { get; set; }     
        public string LastWorkingDate { get; set; }
        public string PFNo { get; set; }
        public string ESIInsurance { get; set; }

        public string BonusApplicable { get; set; }
        public string EmailQuery { get; set; }        
        public string SMSQuery { get; set; }
        public string Contactperson { get; set; }
        public string Ward { get; set; }
        public string LSTNo { get; set; }

        public string CSTNo { get; set; }
        public string TIN { get; set; }

        public string LBTNo { get; set; }
        public string ServiceTaxNo { get; set; }
        public string IECode { get; set; }
        public string DLNo1 { get; set; }
        public string ChequePrintName { get; set; }

        public string CreatedBy { get; set; }        
        public string ModifiedBy { get; set; }
    }
}
