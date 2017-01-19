using DemoLicense;
using QLicense;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IPCAUI.License;
using IPCAUI.Models;

namespace IPCAUI.License
{
   public  class CheckLicense
    {
        byte[] _certPubicKeyData;
        
        public bool IsLicenseExists()
        {
            if (File.Exists("license.lic"))
                return true;
            else
                return false;
        }

        public DemoLicense.MyLicense GetLicense(byte[] certpublickeydata)
        {
            MyLicense _lic = null;
            string _msg = string.Empty;
            LicenseStatus _status = LicenseStatus.UNDEFINED;

            if (File.Exists("license.lic"))
            {
                _lic = (MyLicense)LicenseHandler.ParseLicenseFromBASE64String(
                    typeof(MyLicense),
                    File.ReadAllText("license.lic"),
                    certpublickeydata,
                    out _status,
                    out _msg);
            }

            return _lic;
        }

        public void SetLicensetoApplication()
        {
            //Read public key from assembly
            Assembly _assembly = Assembly.GetExecutingAssembly();
            using (MemoryStream _mem = new MemoryStream())
            {
                _assembly.GetManifestResourceStream("IPCAUI.License.LicenseVerify.cer").CopyTo(_mem);

                _certPubicKeyData = _mem.ToArray();
            }

            DemoLicense.MyLicense _lic = GetLicense(_certPubicKeyData);    
            
            if(_lic.BasicLicense)
            {
                //Testing only, this will change
                LicenseBehaviour.EnableTransaction = true;
                LicenseBehaviour.EnableMaster.EnableItemMaster_BatchWiseDetails = true;
                LicenseBehaviour.EnableMaster.EnableItemMaster_MultipleMRP = false; 
            }     
                        
        }

        public byte[] ActivateLicense()
        {
            //Read public key from assembly
            Assembly _assembly = Assembly.GetExecutingAssembly();
            using (MemoryStream _mem = new MemoryStream())
            {
                _assembly.GetManifestResourceStream("IPCAUI.License.LicenseVerify.cer").CopyTo(_mem);

                _certPubicKeyData = _mem.ToArray();
            }

            return _certPubicKeyData;

        }
    }
}
