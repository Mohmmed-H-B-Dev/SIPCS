using SIPCS.BLL.Services.UserModule;

namespace SIPCS.UI.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService = new();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("يرجى إدخال اسم المستخدم وكلمة المرور", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_userService.Login(username, password))
            {
                this.Hide();
                new Main().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("❌ اسم المستخدم أو كلمة المرور غير صحيحة", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnLogin_Click(sender, e);
        }
    }
}
