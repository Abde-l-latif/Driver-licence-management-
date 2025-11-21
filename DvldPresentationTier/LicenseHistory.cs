using System;
using System.Data;
using System.Windows.Forms;
using DvldBusinessTier;

namespace DvldProject
{
    public partial class LicenseHistory : Form
    {
        /* Filter Variables */
        private string textBox = "";
        private string comboBox = "";
        private int PersonID = -1; 
        public LicenseHistory(int personID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            initializeFilterControl(personID);
            initializePersonDetails(PersonID);
            groupBox1.Enabled = false;
            initializeDataGridLocal(PersonID);
        }

        private void initializeDataGrid(DataGridView dataGridView)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AllowUserToAddRows = false;
        }

        private void initializeFilterControl(int personID)
        {
            filterPeople1.OnTextChangedInside += textFilter;
            filterPeople1.OnSelectChange += selectText;
            PersonID = personID;
            filterPeople1.customFilter(PersonID.ToString(), "person ID");
        }

        private void initializePersonDetails(int PersonID)
        {
            personDetails1.setPersonId(PersonID);
            personDetails1.reload();
        }

        private void initializeDataGridLocal(int PersonID)
        {
            if(Driver.isDriverExists(PersonID))
            {
                initializeDataGrid(dataGridLocal);
                dataGridLocal.DataSource = Licenses.getLocalLicenseHistory(PersonID);
                LbRecord.Text = dataGridLocal.Rows.Count.ToString() + " Records"; 
            }
        }

        private void initializeDataGridInternational(int PersonID)
        {
            if (Driver.isDriverExists(PersonID))
            {
                initializeDataGrid(dataGridInternational);
                dataGridInternational.DataSource = Licenses.getInterLicenseHistory(PersonID);
                LbRecord.Text = dataGridInternational.Rows.Count.ToString() + " Records";
            }
        }

        private void textFilter(string text)
        {
            textBox = text; 
        }

        private void selectText(string text)
        {
            comboBox = text;
        }

        private int getPersonIdFromFilter()
        {
            DataTable dt = people.filterPeople(textBox, comboBox);
            int personID = (int)dt.Rows[0][0];
            return personID;
        }

        private void BTNfilterSearch_Click(object sender, EventArgs e)
        {
            int PersonID = getPersonIdFromFilter();
            initializePersonDetails(PersonID);
        }

        private void OnPersonIDAdded(int personID)
        {
            initializePersonDetails(personID);
        }
        private void BTNAddPerson_Click(object sender, EventArgs e)
        {
            addNewPerson fm = new addNewPerson(-1);
            fm.personIDAdded += OnPersonIDAdded;
            fm.ShowDialog();
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
                initializeDataGridInternational(PersonID);
            else if (tabControl1.SelectedIndex == 0)
                initializeDataGridLocal(PersonID);
        }
    }
}
