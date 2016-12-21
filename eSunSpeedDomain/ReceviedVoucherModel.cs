using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class ReceviedVoucherModel
    {
        public int RV_Id { get; set; }
        public DateTime Date { get; set; }
        public string Series { get; set; }
        public DateTime issuedDate { get; set; }
        public int fromNo { get; set; }
        public string party { get; set; }
        public string issuingoffice { get; set; }
        public string stateofissue { get; set; }
        public string Narration { get; set; }
        public List<ReceviedModel> ReceviedModel { get; set; }
    }
}
