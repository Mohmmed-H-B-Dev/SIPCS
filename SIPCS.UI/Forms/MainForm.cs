using SIPCS.BLL.Services.UserModule;

namespace SIPCS.UI.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lblWelcome.Text = $"مرحباً، {UserService.CurrentUser?.FullName} 👋";
            lblRole.Text    = UserService.CurrentUser?.RoleName;
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            // TODO: افتح شاشة المخزون
            MessageBox.Show("🚧 شاشة المخزون - قيد التطوير", "SIPCS");
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            // TODO: افتح شاشة البيع
            MessageBox.Show("🚧 شاشة نقطة البيع - قيد التطوير", "SIPCS");
        }

        private void btnCommissions_Click(object sender, EventArgs e)
        {
            // TODO: افتح شاشة العمولات
            MessageBox.Show("🚧 شاشة العمولات - قيد التطوير", "SIPCS");
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            // TODO: افتح شاشة التقارير
            MessageBox.Show("🚧 شاشة التقارير - قيد التطوير", "SIPCS");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد تسجيل الخروج؟", "تأكيد",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new UserService().Logout();
                this.Close();
            }
        }
    }
}
