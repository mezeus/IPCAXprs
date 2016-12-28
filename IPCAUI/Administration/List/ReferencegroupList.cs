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
    public partial class ReferencegroupList : Form
    {
        ReferenceGroupBL objrefbl = new ReferenceGroupBL();
        public ReferencegroupList()
        {
            InitializeComponent();
        }

        private void ReferencegroupList_Load(object sender, EventArgs e)
        {
            //List<eSunSpeedDomain.AccountGroupModel> lstGroups = objaccbl.GetListofAccountsGroups();
            //dvgAccList.DataSource = lstGroups;
        }

        private void dvgReferencegroupList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
