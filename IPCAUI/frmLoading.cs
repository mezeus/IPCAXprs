using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IPCAUI
{
    public partial class frmLoading : Form
    {
        #region Function
        public frmLoading()
        {
            InitializeComponent();
        }
        public void ShowFromSendMail()
        {
            label1.Text = "Sending...";
            ShowDialog();
        }
        #endregion
        #region Events
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //lblTableName.Text = frmCopyData.strTable;
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Loading:1" + ex.Message, "Open Miracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
