using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class PersonDetailsForm : Form
    {
 
        public PersonDetailsForm(int PersonID)
        {
            InitializeComponent();
            personDetails1.setPersonId(PersonID);
            StartPosition =  FormStartPosition.CenterParent;
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
