using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace IPCAUI.Menu
{
    public partial class ConfigurationMenu : DevExpress.XtraEditors.XtraForm
    {
        XtraForm1 frm;
        public ConfigurationMenu(XtraForm1 frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void ConfigurationMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.Visible = true;
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Settings.Accountsettings frm;
            frm = new Settings.Accountsettings(); //generate new instance 
            //frm.Owner = this;
            //frm.TopLevel = false;

            //spli.Panel2.Controls.Add(frm);
            frm.ShowDialog();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}