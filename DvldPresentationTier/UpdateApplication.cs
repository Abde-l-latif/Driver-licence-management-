using DvldBusinessTier;
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
    public partial class UpdateApplication : Form
    {
        private int AppID; 
        public UpdateApplication(int appID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent; 
            AppID = appID;
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateApplication_Load(object sender, EventArgs e)
        {
            labelID.Text = AppID.ToString(); 
        }

        private void reloadDatGrid()
        {
            foreach(Form fm in Application.OpenForms)
            {
                if (fm is localDrivingLicenseApp Ldl)
                {
                    Ldl.reload();
                    return; 
                }
            }
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            //if(application.UpdateApplicationDate(AppID , dateTimePicker1.Value))
            //{
            //    MessageBox.Show("the application Date has been Updated", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    BTNsave.Enabled = false;
            //    reloadDatGrid();
            //}
            //else
            //{
            //    MessageBox.Show("Operation Failed !!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
