using System;
using System.Data;
using System.Windows.Forms;
using DvldBusinessTier;

namespace DvldProject
{
    public partial class LicenseHistory : Form
    {
       
        private int PersonID = -1;

        public LicenseHistory()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        public LicenseHistory(int personID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            PersonID = personID;
        }

        private void initializeDataGrid(DataGridView dataGridView)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AllowUserToAddRows = false;
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


        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void ClearDataGrid()
        {
            dataGridLocal.Rows.Clear();
            dataGridInternational.Rows.Clear();
        }

        private void LicenseHistory_Load(object sender, EventArgs e)
        {
            if(PersonID == -1)
            {
                personDetailsFilter1.FilterPerson = true;
                personDetailsFilter1.FocusFilter();
                ClearDataGrid();
            } 
            else
            {
                personDetailsFilter1.FilterPerson = false;
                personDetailsFilter1.LoadPersonInfo(PersonID);
                initializeDataGridLocal(PersonID);
                initializeDataGridInternational(PersonID);
            }
        }

        private void personDetailsFilter1_OnPersonSelected(int obj)
        {
            PersonID = obj;

            if (Driver.isDriverExists(PersonID))
            {
                initializeDataGrid(dataGridLocal);
                dataGridLocal.DataSource = Licenses.getLocalLicenseHistory(PersonID);
                LbRecord.Text = dataGridLocal.Rows.Count.ToString() + " Records";
                initializeDataGrid(dataGridInternational);
                dataGridInternational.DataSource = Licenses.getInterLicenseHistory(PersonID);
                LbRecord.Text = dataGridInternational.Rows.Count.ToString() + " Records";
            }
            else
            {
                MessageBox.Show("This Person is not a driver !" , "information" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
