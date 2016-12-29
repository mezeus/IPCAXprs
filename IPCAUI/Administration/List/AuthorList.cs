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
            List<eSunSpeedDomain.AuthorModel> lstAuthor = objautbl.GetAllAuthors();
            dvgAuthorList.DataSource = lstAuthor;
        }

        private void dvgAutorDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            AuthorModel lstAuthors;

            lstAuthors = (AuthorModel)dvgAutorDetails.GetRow(dvgAutorDetails.FocusedRowHandle);
            Author.AuthorId = lstAuthors.Author_Id;

            this.Close();
        }
    }
}
