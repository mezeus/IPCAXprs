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
    public partial class AuthorList : Form
    {
        eSunSpeed.BusinessLogic.AuthorMaster objautbl = new AuthorMaster();
        public AuthorList()
        {
            InitializeComponent();
        }

        private void AuthorList_Load(object sender, EventArgs e)
        {
            Author.AuthorId = 0;
            List<eSunSpeedDomain.AuthorModel> lstAuthor = objautbl.GetAllAuthors();
            dvgAuthorList.DataSource = lstAuthor;
        }

        private void dvgAutorDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void dvgAutorDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == '\r')
            {
                AuthorModel lstAuthors;

                lstAuthors = (AuthorModel)dvgAutorDetails.GetRow(dvgAutorDetails.FocusedRowHandle);
                Author.AuthorId = lstAuthors.Author_Id;

                this.Close();
            }
            return;
        }

        private void dvgAutorDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            AuthorModel lstAuthors;

            lstAuthors = (AuthorModel)dvgAutorDetails.GetRow(dvgAutorDetails.FocusedRowHandle);
            Author.AuthorId = lstAuthors.Author_Id;

            this.Close();
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
