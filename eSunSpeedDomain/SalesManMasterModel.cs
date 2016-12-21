using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
 public class SalesManMasterModel
    {
        public string SMName { get; set; }
        public string Alias { get; set; }
        public string PrintName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public int TelNO { get; set; }
        public int MNO { get; set; }
        public string EMail { get; set; }
        public bool SDCD { get; set; } //Specify Defalut Commission Details
        public string CommMode { get; set; }
        public decimal Commission { get; set; }
        public bool FrzComm { get; set; }
        public string SMACr { get; set; } // Salesman A/c Credited
        public string isSaleCommDr { get; set; }
        public string isSaleCommAccDr { get; set; }
        public string isPurCommDr { get; set; }
        public string ispurCommAccDr { get; set; }




    }
}
