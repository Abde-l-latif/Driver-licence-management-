using DvldBusinessTier;
using System;
using System.Windows.Forms;

namespace DvldProject.PeopleFolder.Controls
{
    public partial class PersonDetailsFilter : UserControl
    {
        public PersonDetailsFilter()
        {
            InitializeComponent();
        }

        public event Action<int> OnPersonSelected; 

        protected virtual void PersonSelected(int personId)
        {
            Action<int> handler = OnPersonSelected;

            if(handler != null)
            {
                handler(personId);
            }
        }

        private bool _ShowAddPerson = true ;

        private bool _FilterPerson = true ;

        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value ;
                BtnAdd.Enabled = _ShowAddPerson;
            }
        }

        public bool FilterPerson
        {
            get
            {
                return _FilterPerson;
            }
            set
            {
                _FilterPerson = value;
                 groupFilter.Enabled = _FilterPerson;
            }
        }


        public void LoadPersonInfo(int PersonID)
        {

            comboBox1.SelectedIndex = 0;
            textFilter.Text = PersonID.ToString();
            FindNow();

        }

        private void FindNow()
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "person ID":
                {
                    personDetails1.LoadPersonByID(Convert.ToInt32(textFilter.Text));
                    break;
                }
                case "national No":
                {
                    personDetails1.LoadPersonByNationalNo(textFilter.Text);
                    break;
                }
            }

            if(OnPersonSelected != null && _FilterPerson)
                OnPersonSelected(personDetails1.getPersonID());
        }


        private void BtnFilter_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error","Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if(!people.checkPersonIdExists(textFilter.Text))
            {
                MessageBox.Show("PersonID not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textFilter.Text = "";
                return;
            }

            FindNow(); 
        }

        private void PersonDetailsFilter_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textFilter.Focus();
        }

        private void textFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "person ID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void textFilter_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textFilter.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textFilter, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(textFilter, null);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddEditPerson Fm = new AddEditPerson(-1);
            Fm.ShowDialog();
            Fm.personIDAdded += getPersonID;
        }

        private void getPersonID(int personID)
        {
            LoadPersonInfo(personID);
            FilterPerson = false;
        }

        public void FocusFilter()
        {
            textFilter.Focus();
        }
    }
}
