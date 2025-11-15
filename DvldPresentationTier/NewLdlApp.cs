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
    public partial class NewLdlApp : Form
    {

        /*LocalDrivingLicenseid & application type witch is LocalDrivingLicense */
        private int L_D_Lid = -1; 
        private int applicationTypeID = 1;


        /* Filter people */
        private string text;
        private string Filter;



        private application App; 


        public NewLdlApp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            filterPeople1.OnTextChangedInside += textChanged;
            filterPeople1.OnSelectChange += ComboChanged;
            BTNNext.Enabled = false; 
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textChanged(string text)
        {
            this.text = text;
        }

        private void ComboChanged(string text)
        {
            Filter = text; 
        }

        private void BTNfilterSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = people.filterPeople(text, Filter);
            if (dt.Rows.Count > 0)
            {
                int personID = (int)dt.Rows[0][0];
                personDetails1.setPersonId(personID);
                personDetails1.reload();
                BTNNext.Enabled = true;
            }
            else
            {
                MessageBox.Show("Person Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void BTNAddPerson_Click(object sender, EventArgs e)
        {
            Form4 fm = new Form4(-1);
            fm.personIDAdded += OnPersonIDAdded;
            fm.ShowDialog();
        }

        private void OnPersonIDAdded(int personID)
        {
            personDetails1.setPersonId(personID);
            personDetails1.reload();
            BTNNext.Enabled = true;
        }

        private void AddApplication()
        {
            LbDate.Text = DateTime.Now.ToString();
            LBCreatedBy.Text = Global.USER.UserName.ToString();
            comboBox1.DataSource = application.getAllLicenseClasses();
            comboBox1.DisplayMember = "ClassName";
            comboBox1.ValueMember = "LicenseClassID";
            LBCoins.Text = application.getApplicationFee(applicationTypeID).ToString("0.00");
        }

        private void BTNNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            AddApplication();
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {
                if (BTNNext.Enabled == false)
                {
                    tabControl1.SelectedIndex = 0;
                    MessageBox.Show("You have to fill person info !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AddApplication(); 
                }
            }

        }

        private void FillApp(application App)
        {
            App.ApplicationStatus = 1;
            App.ApplicationDate = Convert.ToDateTime(LbDate.Text);
            App.ApplicationTypeID = applicationTypeID;
            App.ApplicantPersonID = personDetails1.getPersonID();
            App.CreatedByUserID = Global.USER.UserID;
            App.LastStatusDate = Convert.ToDateTime(LbDate.Text);
            App.PaidFees = Convert.ToDecimal(LBCoins.Text);
        }

        private void Fill_LDL_App(int appID , int type , ref int L_D_Lid)
        {
            if (application.insert_LDL_Application(appID, type, ref L_D_Lid))
                return; 
            else
                MessageBox.Show("Failed to fill LDL_app  !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {

            App = new application();
  
            FillApp(App);

            if(!application.isPersonAppalreadyExists(comboBox1.Text , personDetails1.getNationalNo()))
            {

                if (App.Save())
                {

                    LBdlID.Text = App.ApplicationID.ToString();
                    Fill_LDL_App(App.ApplicationID, Convert.ToInt32(comboBox1.SelectedValue), ref L_D_Lid);

                    MessageBox.Show("Application Added Successfully ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Operation Failed  !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                BTNsave.Enabled = false;
            }
            else
                MessageBox.Show("This person has already registered in this license class  !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
