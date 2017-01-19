using System;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using QLicense;
using DemoLicense;

namespace IPCAUI.License
{
    public partial class frmMain : Form
    {

        byte[] _certPubicKeyData;
        public frmMain()
        {
            InitializeComponent();
        }


        private void frmMain_Shown(object sender, EventArgs e)
        {
            CheckLicense c = new CheckLicense();

            _certPubicKeyData = c.ActivateLicense();
            if (!c.IsLicenseExists())
            {
                //_certPubicKeyData = c.ActivateLicense();
                
                using (frmActivation frm = new frmActivation())
                {
                    frm.CertificatePublicKeyData = _certPubicKeyData;
                    frm.ShowDialog();

                    //Exit the application after activation to reload the license file 
                    //Actually it is not nessessary, you may just call the API to reload the license file
                    //Here just simplied the demo process

                }
            }
            else
            {
                MyLicense _lic = c.GetLicense(_certPubicKeyData);
                licInfo.ShowLicenseInfo(_lic);
            }            
        }
    }
}
