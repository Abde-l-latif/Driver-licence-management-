using System.Windows.Forms;

namespace DvldProject
{
    public partial class UserDetailsForm : Form
    {

        int _UserID;
        public UserDetailsForm(int userID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            _UserID = userID;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void fillInfo()
        {
            userInfo1.LoadUserInfo(_UserID);
        }

        private void UserDetailsForm_Load(object sender, System.EventArgs e)
        {
            fillInfo();
        }
    }
}
