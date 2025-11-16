using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public LicenseHistory(string NationalNo)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            initializeFilterControl(NationalNo);
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

        private void initializeFilterControl(string NationalNo)
        {
            filterPeople1.OnTextChangedInside += textFilter;
            filterPeople1.OnSelectChange += selectText;
            PersonID = people.getPersonIDbyNationalNo(NationalNo);
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
    }
}
