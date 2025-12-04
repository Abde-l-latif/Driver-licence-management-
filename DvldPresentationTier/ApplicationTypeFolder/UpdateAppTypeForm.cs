using DvldBusinessTier;
using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class UpdateAppTypeForm : Form
    {
        private int ID;

        private ApplicationType AppType;
        public UpdateAppTypeForm(int id)
        {
            InitializeComponent();
            ID = id;
            StartPosition = FormStartPosition.CenterParent;
        }

        private void BTNclose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void _Find()
        {
            AppType = ApplicationType.Find(ID);
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {

            AppType.ApplicationFees = Convert.ToDecimal(textCoins.Text);
            AppType.ApplicationTypeTitle = textTitle.Text;

            if (AppType.Save())
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
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void UpdateAppTypeForm_Load(object sender, EventArgs e)
        {
            _Find();

            if (AppType != null)
            {
                labelID.Text = AppType.ApplicationID.ToString();
                textTitle.Text = AppType.ApplicationTypeTitle;
                textCoins.Text = AppType.ApplicationFees.ToString("0.00");
            }
        }
    }
}
