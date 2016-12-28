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
    public partial class SchememasterList : Form
    {
        public SchememasterList()
        {
            InitializeComponent();
        }

        private void SchememasterList_Load(object sender, EventArgs e)
        {
            //List<eSunSpeedDomain.s> lstGroups = objaccbl.GetListofAccountsGroups();
            //dvgAccList.DataSource = lstGroups;
        }

        private void dvgSchemList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
