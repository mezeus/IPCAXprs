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
            List<ReferenceGroupModel> lstGroups = objrefbl.GetAllReferenceGroups();
            dvgReferencegroupList.DataSource = lstGroups;
        }

        private void dvgReferencegroupList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == '\r')
            {
                ReferenceGroupModel lstReference;

                lstReference = (ReferenceGroupModel)dvgRefgrpDetails.GetRow(dvgRefgrpDetails.FocusedRowHandle);
                Referencegroup.RefId = lstReference.ReferenceId;

                this.Close();
            }
        }

        private void dvgRefgrpDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //ReferenceGroupModel lstReference;

            //lstReference = (ReferenceGroupModel)dvgRefgrpDetails.GetRow(dvgRefgrpDetails.FocusedRowHandle);
            //Referencegroup.RefId = lstReference.ReferenceId;

            //this.Close();
        }

        private void dvgRefgrpDetails_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
