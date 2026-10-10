namespace SIPCS.UI.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Panel pnlCard;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form
            this.Text            = "SIPCS — تسجيل الدخول";
            this.Size            = new Size(420, 380);
            this.StartPosition  = FormStartPosition.CenterScreen;
            this.BackColor       = Color.FromArgb(15, 23, 42);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox    = false;
            this.RightToLeft    = RightToLeft.Yes;
            this.Font           = new Font("Segoe UI", 10f);

            // Card Panel
            pnlCard = new Panel
            {
                Size      = new Size(340, 280),
                Location  = new Point(40, 40),
                BackColor = Color.FromArgb(30, 41, 59),
            };
            this.Controls.Add(pnlCard);

            // Title
            lblTitle = new Label
            {
                Text      = "🛒 SIPCS",
                Font      = new Font("Segoe UI", 18f, FontStyle.Bold),
                ForeColor = Color.FromArgb(56, 139, 253),
                Location  = new Point(0, 20),
                Size      = new Size(340, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlCard.Controls.Add(lblTitle);

            // Username Label
            lblUsername = new Label
            {
                Text      = "اسم المستخدم",
                ForeColor = Color.FromArgb(148, 163, 184),
                Location  = new Point(20, 80),
                Size      = new Size(300, 22)
            };
            pnlCard.Controls.Add(lblUsername);

            // Username TextBox
            txtUsername = new TextBox
            {
                Location  = new Point(20, 104),
                Size      = new Size(300, 30),
                BackColor = Color.FromArgb(51, 65, 85),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            pnlCard.Controls.Add(txtUsername);

            // Password Label
            lblPassword = new Label
            {
                Text      = "كلمة المرور",
                ForeColor = Color.FromArgb(148, 163, 184),
                Location  = new Point(20, 148),
                Size      = new Size(300, 22)
            };
            pnlCard.Controls.Add(lblPassword);

            // Password TextBox
            txtPassword = new TextBox
            {
                Location     = new Point(20, 172),
                Size         = new Size(300, 30),
                BackColor    = Color.FromArgb(51, 65, 85),
                ForeColor    = Color.White,
                BorderStyle  = BorderStyle.FixedSingle,
                PasswordChar = '●'
            };
            txtPassword.KeyPress += txtPassword_KeyPress;
            pnlCard.Controls.Add(txtPassword);

            // Login Button
            btnLogin = new Button
            {
                Text      = "تسجيل الدخول",
                Location  = new Point(20, 220),
                Size      = new Size(300, 40),
                BackColor = Color.FromArgb(56, 139, 253),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 11f, FontStyle.Bold),
                Cursor    = Cursors.Hand
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += btnLogin_Click;
            pnlCard.Controls.Add(btnLogin);

            this.ResumeLayout(false);
        }
    }
}
