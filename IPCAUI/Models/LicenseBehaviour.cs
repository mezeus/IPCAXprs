using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCAUI.Models
{
    public static class LicenseBehaviour
    {
        public static ItemLicense EnableMaster { get; set; }
        public static bool LockEntries { get; set; }

        //Basic License Configuration
        
        public static bool EnableTransaction { get; set; }
        public static bool EnableBalanceSheet { get; set; }
        public static bool EnableProftandLoss { get; set; }
    }
}
