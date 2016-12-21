using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
   public class DataRestorationModel
    {
        public int id { get; set; }
        public bool Normal_Backup { get; set; }
        public string Path { get; set; }
        public bool FTP_Backup { get; set; }
        public string Servername { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Folder { get; set; }
    }
}
