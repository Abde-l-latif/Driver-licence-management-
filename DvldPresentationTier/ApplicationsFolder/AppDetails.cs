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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DvldProject
{
    public partial class AppDetails : UserControl
    {
        application App;
        public AppDetails()
        {
            InitializeComponent();
        }

        public void LoadApplicationById(int id)
        {
            App = application.FindBaseApplication(id);

            if (App != null)
            {
                labelID.Text = App.ApplicationID.ToString();
                labelFullName.Text = App.Person.FirstName + " " + App.Person.SecondName + " " + App.Person.ThirdName + " " + App.Person.LastName;
                labelStatus.Text = App.ApplicationStatus == application.enAppStatus.New ? "New" :
                    App.ApplicationStatus == application.enAppStatus.Cancelled ? "Cancelled" :
                    "Completed" ;

                labelType.Text = App.AppType.ApplicationTypeTitle;
                labelUserName.Text = Users.getUserByUserID(App.CreatedByUserID).UserName;
                labelFees.Text = App.PaidFees.ToString("0.00");
                labelDate.Text = Convert.ToString(App.ApplicationDate);
                labelStatusDate.Text = Convert.ToString(App.LastStatusDate);
            }
            else
            {
                MessageBox.Show("wrong id try again", "not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersonDetailsForm fm = new PersonDetailsForm(App.Person.PersonID);
            fm.ShowDialog();
        }
    }
}
