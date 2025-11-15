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
    public partial class AppDetails : UserControl
    {
        int ApplicationID = -1;
        int PersonID = -1; 
        public AppDetails()
        {
            InitializeComponent();
        }


        public void setAppID(int ID)
        {
            ApplicationID = ID;
        }

        public void setPersonID(int ID)
        {
            PersonID = ID;
        }

        public void reload()
        {
            string status = "" , type = "" , applicant = "" , createdBy = "";
            decimal fees = 0;
            DateTime date = new DateTime(), statusDate = new DateTime();

            application.getApplicationDetails(ApplicationID , ref status , ref type , ref applicant , ref createdBy , 
                ref fees, ref date , ref statusDate);
            
            labelID.Text = ApplicationID.ToString();
            labelFullName.Text = applicant; 
            labelStatus.Text = status;
            labelType.Text = type;
            labelUserName.Text = createdBy;
            labelFees.Text = fees.ToString();
            labelDate.Text = Convert.ToString(date);
            labelStatusDate.Text = Convert.ToString(statusDate);
        }

        private void AppDetails_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form5 fm = new Form5(PersonID);
            fm.ShowDialog();
        }
    }
}
