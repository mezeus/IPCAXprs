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

namespace IPCAUI.Administration.List
{
    public partial class StformList : Form
    {
        STFormMasterBL objStbl = new STFormMasterBL();
        public StformList()
        {
            InitializeComponent();
        }

        private void StformList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.STFormMasterModel> lstStforms = objStbl.GetAllSTF();
            dvgStformList.DataSource = lstStforms;
        }

        

        private void dvgStformList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
