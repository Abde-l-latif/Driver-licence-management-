    using System;
using System.Windows.Forms;


namespace DvldProject
{
    public partial class filterPeople : UserControl
    {
        public filterPeople()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        public delegate void TextChangedHandler(string text);

        public event TextChangedHandler OnTextChangedInside;

        public event TextChangedHandler OnSelectChange;


        public void customFilter(string text , string combo)
        {
            comboBox1.SelectedIndex = comboBox1.FindString(combo); ;
            textFilter.Text = text; 
        }

        private void textFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        } 

        private void comboChange(object sender, EventArgs e)
        {

            textFilter.KeyPress -= textFilter_KeyPress;

            if (comboBox1.SelectedItem.ToString() == "person ID")
            {
                textFilter.Visible = true;
                textFilter.KeyPress += textFilter_KeyPress;
            }

            if(comboBox1.SelectedItem.ToString() != "none")
            {
                textFilter.Text = "";
                textFilter.Visible = true;
            }
            else if (comboBox1.SelectedItem.ToString() == "none")
            {
                textFilter.Visible = false;
                textFilter.Text = "";
            }

            OnSelectChange?.Invoke(comboBox1.SelectedItem.ToString());
        }

        private void textFilter_TextChanged(object sender, EventArgs e)
        {
            OnTextChangedInside?.Invoke(textFilter.Text);
        }

    }
}
