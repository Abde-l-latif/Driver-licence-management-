using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class Form5 : Form
    {
 
        public Form5(int PersonID)
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
