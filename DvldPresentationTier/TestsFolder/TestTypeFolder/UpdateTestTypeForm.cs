using DvldBusinessTier;
using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class UpdateTestTypeForm : Form
    {
        private TestType.enTestType ID;

        TestType test_type;
        public UpdateTestTypeForm(TestType.enTestType ID)
        {
            InitializeComponent();
            this.ID = ID;
            StartPosition = FormStartPosition.CenterParent; 
        }

        private void BTNclose_Click(object sender, System.EventArgs e)
        {
            this.Close(); 
        }

        private void BTNsave_Click(object sender, System.EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Operation failed !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            test_type.TestTypeTitle = textTitle.Text;
            test_type.TestTypeDescription = textDescription.Text;
            test_type.TestTypeFees = Convert.ToDecimal(textCoins.Text); 

            if (test_type.Save())
            {
                MessageBox.Show("Operation had been done successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BTNsave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Operation failed !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textCoins_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void UpdateTestTypeForm_Load(object sender, System.EventArgs e)
        {
            test_type = TestType.Find(ID);
            if(test_type != null)
            {
                textTitle.Text = test_type.TestTypeTitle;
                textDescription.Text = test_type.TestTypeDescription;
                textCoins.Text = test_type.TestTypeFees.ToString("0.00");
                labelID.Text = ((int)ID).ToString();
            }
            else
            {
                MessageBox.Show("Operation failed !! test type not found ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(String.IsNullOrEmpty(textTitle.Text))
            {
                errorProvider1.SetError(textTitle, "this field is required");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(textTitle, "");
        }

        private void textDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textDescription.Text))
            {
                errorProvider1.SetError(textDescription, "this field is required");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(textDescription, "");
        }

        private void textCoins_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textCoins.Text))
            {
                errorProvider1.SetError(textCoins, "this field is required");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(textCoins, "");
        }
    }
}
