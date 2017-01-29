using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class AuthorModel
    {
        public int Author_Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string PrintName { get; set; }
        public bool ConnectAcc { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Street { get; set; }
        public long MobileNo { get; set; }
        public long Telephone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
