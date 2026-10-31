using SIPCS.BLL.Services.UserModule;

namespace SIPCS.UI.Forms
{
    public partial class Login : SIPCS.UI.Forms.SIPCSStyles
    {
        UserService _user;
        public Login()
        {
            InitializeComponent();
            _user = new UserService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text)|| string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_user.Login(txtUserName.Text, txtPassword.Text))
            {
                this.Hide();
                new frmMain().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();    
        }
    }
}
