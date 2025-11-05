using System;
using System.Windows.Forms;

namespace DvldProject
{
    public partial class FilterUser : UserControl
    {
        public FilterUser()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        public delegate void filterDelegateUser(string text);

        public event filterDelegateUser textChangedFilter;

        public event filterDelegateUser comboBoxText;

        private void EnableText()
        {
            textFilter.Visible = false;
            textFilter.Enabled = false;
            textFilter.Text = ""; 
        }

        private void EnableCombo()
        {
            comboBox2.Enabled = false;
            comboBox2.Visible = false;
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBoxText?.Invoke(comboBox1.SelectedItem.ToString());

            textFilter.KeyPress -= textFilter_KeyPress;


            if (comboBox1.SelectedItem.ToString() == "user ID" || comboBox1.SelectedItem.ToString() == "person ID")
            {
                textFilter.KeyPress += textFilter_KeyPress;
                textFilter.Text = "";
                textFilter.Visible = true;
                textFilter.Enabled = true;
                EnableCombo();
                return;
            }

            if (comboBox1.SelectedItem.ToString() == "is Active")
            {
                EnableText();
                comboBox2.Enabled = true;
                comboBox2.Visible = true;
                return;
            }

            if (comboBox1.SelectedItem.ToString() == "none")
            {
                EnableText();
                EnableCombo();
            }
            else
            {
                textFilter.Text = ""; 
                textFilter.Visible = true;
                textFilter.Enabled = true;
                EnableCombo();
            }
        }

        private void textFilter_TextChanged(object sender, EventArgs e)
        {
            if (textFilter.Text == "")
                return; 
            textChangedFilter?.Invoke(textFilter.Text); 
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ComboText = "";
            if (comboBox2.SelectedItem.ToString() == "Yes")
                ComboText = "1";
            else if (comboBox2.SelectedItem.ToString() == "No")
                ComboText = "0";
            else if (comboBox2.SelectedItem.ToString() == "All")
            {
                comboBoxText?.Invoke("none");
                return; 
            }
            textChangedFilter?.Invoke(ComboText);
        }

        private void textFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
              e.Handled = true;

        }
    }
}
