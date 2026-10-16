namespace SIPCS.UI.Forms
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnClose = new Button();
            btnLogin = new Button();
            label2 = new Label();
            txtPassword = new TextBox();
            label1 = new Label();
            txtUserName = new TextBox();
            lblTitleApp = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtUserName);
            panel1.Location = new Point(29, 83);
            panel1.Name = "panel1";
            panel1.Size = new Size(471, 203);
            panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(30, 41, 53);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 13F);
            btnClose.ForeColor = Color.FromArgb(119, 139, 253);
            btnClose.Location = new Point(344, 158);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(124, 42);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(30, 41, 53);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 13F);
            btnLogin.ForeColor = Color.FromArgb(119, 139, 253);
            btnLogin.Location = new Point(3, 158);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(124, 42);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(21, 88);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 3;
            label2.Text = "Enter Password";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(119, 139, 253);
            txtPassword.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(0, 106);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(252, 28);
            txtPassword.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(21, 15);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 1;
            label1.Text = "Enter User Name";
            // 
            // txtUserName
            // 
            txtUserName.BackColor = Color.FromArgb(119, 139, 253);
            txtUserName.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            txtUserName.Location = new Point(3, 33);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(252, 28);
            txtUserName.TabIndex = 0;
            // 
            // lblTitleApp
            // 
            lblTitleApp.AutoSize = true;
            lblTitleApp.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitleApp.ForeColor = Color.Black;
            lblTitleApp.Location = new Point(212, 9);
            lblTitleApp.Name = "lblTitleApp";
            lblTitleApp.Size = new Size(103, 30);
            lblTitleApp.TabIndex = 4;
            lblTitleApp.Text = "\U0001f6d2 SIPCS";
            // 
            // Login
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 99, 253);
            ClientSize = new Size(538, 333);
            Controls.Add(lblTitleApp);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "Login";
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txtUserName;
        private Label label1;
        private Label label2;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnClose;
        private Label lblTitleApp;
    }
}