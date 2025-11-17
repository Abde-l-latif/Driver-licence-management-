using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class ShowAppDetails : Form
    {
        public ShowAppDetails(int AppID , int PersonID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            appDetails1.setAppID(AppID);
            appDetails1.setPersonID(PersonID);
            appDetails1.reload();
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
