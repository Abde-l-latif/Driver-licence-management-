using DvldBusinessTier;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class Form13 : Form
    {
        private int ID;
        public Form13(int ID, string title, string description, string fee)
        {
            InitializeComponent();
            this.ID = ID;
            textTitle.Text = title;
            textDescription.Text = description;
            textCoins.Text = fee;
            StartPosition = FormStartPosition.CenterParent;
            labelID.Text = ID.ToString(); 
        }

        private void BTNclose_Click(object sender, System.EventArgs e)
        {
            this.Close(); 
        }

        private void BTNsave_Click(object sender, System.EventArgs e)
        {
            if (Tests.UpdateTestType(ID, textTitle.Text, textDescription.Text , textCoins.Text))
            {
                MessageBox.Show("Operation had been done successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (Form fm in Application.OpenForms)
                {
                    if (fm is Form12 appTypes)
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
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
