using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;

namespace IPCAUI.Administration.List
{
    public partial class CurrencyconversionList : Form
    {
        CurrencyConversionBL objccbl = new CurrencyConversionBL();
        public CurrencyconversionList()
        {
            InitializeComponent();
        }

        private void CurrencyconversionList_Load(object sender, EventArgs e)
        {
            
        }
        private void dvgCurrencyconversionList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
