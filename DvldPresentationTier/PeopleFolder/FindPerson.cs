using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvldProject.PeopleFolder
{
    public partial class FindPerson : Form
    {
        public FindPerson()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            personDetailsFilter1.OnPersonSelected += GetPersonID;
            personDetailsFilter1.ShowAddPerson = false; 
        }

        private void GetPersonID(int PersonID)
        {
            MessageBox.Show("person Found with ID = " + PersonID + " Successfully.", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personDetailsFilter1.FilterPerson = false; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
