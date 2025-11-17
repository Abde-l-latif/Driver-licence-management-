using DvldBusinessTier;
using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class UpdateAppTypeForm : Form
    {
        private int ID;
        public UpdateAppTypeForm(int id , string title , string fee)
        {
            InitializeComponent();
            ID = id;
            textTitle.Text = title;
            textCoins.Text = Convert.ToDecimal(fee).ToString("0.00"); 
            labelID.Text = ID.ToString();
            StartPosition = FormStartPosition.CenterParent;
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            if(application.updateApplicationTypes(ID , textTitle.Text , textCoins.Text))
            {
                MessageBox.Show("Operation had been done successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach(Form fm in Application.OpenForms)
                {
                    if(fm is ManageAppTypeForm appTypes)
                    {
                        appTypes.reloadDataGrid();
                    }
                }

                BTNsave.Enabled = false; 
            }
            else
            {
                MessageBox.Show("Operation failed !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textCoins_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
