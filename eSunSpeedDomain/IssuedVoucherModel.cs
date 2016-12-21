using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class IssuedVoucherModel
    {
        public int IV_Id { get; set; }
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string Authourity { get; set; }
        public int fromNo { get; set; }
        public string party { get; set; }
        
        public string stateofissue { get; set; }
        public string Narration { get; set; }
        public List<ReceviedModel> ReceviedModel { get; set; }
    }
}
