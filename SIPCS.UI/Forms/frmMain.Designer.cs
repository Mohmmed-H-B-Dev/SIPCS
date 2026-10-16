namespace SIPCS.UI.Forms
{
    partial class frmMain
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
            button2 = new Button();
            btnLogout = new Button();
            btnReports = new Button();
            btnCommissions = new Button();
            btnPOS = new Button();
            btnInventory = new Button();
            lblWelcom = new Label();
            lblRole = new Label();
            lblTitleApp = new Label();
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(btnReports);
            panel1.Controls.Add(btnCommissions);
            panel1.Controls.Add(btnPOS);
            panel1.Controls.Add(btnInventory);
            panel1.Controls.Add(lblWelcom);
            panel1.Controls.Add(lblRole);
            panel1.Controls.Add(lblTitleApp);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(706, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(326, 551);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(30, 41, 53);
            button2.FlatAppearance.BorderColor = Color.FromArgb(52, 65, 35);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 15F);
            button2.Location = new Point(0, 371);
            button2.Name = "button2";
            button2.Size = new Size(314, 49);
            button2.TabIndex = 4;
            button2.Text = "👩‍💼💼 Admin-Op";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkRed;
            btnLogout.FlatAppearance.BorderColor = Color.FromArgb(52, 65, 35);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 15F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(3, 479);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(320, 49);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Log-out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += Logout_Click;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.FromArgb(30, 41, 53);
            btnReports.FlatAppearance.BorderColor = Color.FromArgb(52, 65, 35);
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 15F);
            btnReports.Location = new Point(3, 316);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(311, 49);
            btnReports.TabIndex = 3;
            btnReports.Text = "📊 Reports";
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
            // 
            // btnCommissions
            // 
            btnCommissions.BackColor = Color.FromArgb(30, 41, 53);
            btnCommissions.FlatAppearance.BorderColor = Color.FromArgb(52, 65, 35);
            btnCommissions.FlatStyle = FlatStyle.Flat;
            btnCommissions.Font = new Font("Segoe UI", 15F);
            btnCommissions.Location = new Point(3, 261);
            btnCommissions.Name = "btnCommissions";
            btnCommissions.Size = new Size(311, 49);
            btnCommissions.TabIndex = 2;
            btnCommissions.Text = "💰  Commissions";
            btnCommissions.UseVisualStyleBackColor = false;
            btnCommissions.Click += btnCommissions_Click;
            // 
            // btnPOS
            // 
            btnPOS.BackColor = Color.FromArgb(30, 41, 53);
            btnPOS.FlatAppearance.BorderColor = Color.FromArgb(52, 65, 35);
            btnPOS.FlatStyle = FlatStyle.Flat;
            btnPOS.Font = new Font("Segoe UI", 15F);
            btnPOS.Location = new Point(3, 206);
            btnPOS.Name = "btnPOS";
            btnPOS.Size = new Size(311, 49);
            btnPOS.TabIndex = 1;
            btnPOS.Text = "\U0001f6d2 POS";
            btnPOS.UseVisualStyleBackColor = false;
            btnPOS.Click += btnPOS_Click;
            // 
            // btnInventory
            // 
            btnInventory.BackColor = Color.FromArgb(30, 41, 53);
            btnInventory.FlatAppearance.BorderColor = Color.FromArgb(52, 65, 35);
            btnInventory.FlatStyle = FlatStyle.Flat;
            btnInventory.Font = new Font("Segoe UI", 15F);
            btnInventory.Location = new Point(3, 150);
            btnInventory.Name = "btnInventory";
            btnInventory.Size = new Size(311, 49);
            btnInventory.TabIndex = 0;
            btnInventory.Text = "📦  Inventory";
            btnInventory.UseVisualStyleBackColor = false;
            btnInventory.Click += btnInventory_Click;
            // 
            // lblWelcom
            // 
            lblWelcom.AutoSize = true;
            lblWelcom.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblWelcom.ForeColor = Color.Black;
            lblWelcom.Location = new Point(293, 72);
            lblWelcom.Name = "lblWelcom";
            lblWelcom.Size = new Size(0, 30);
            lblWelcom.TabIndex = 2;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblRole.ForeColor = Color.Black;
            lblRole.Location = new Point(233, 104);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(0, 30);
            lblRole.TabIndex = 1;
            // 
            // lblTitleApp
            // 
            lblTitleApp.AutoSize = true;
            lblTitleApp.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitleApp.ForeColor = Color.Black;
            lblTitleApp.Location = new Point(130, 19);
            lblTitleApp.Name = "lblTitleApp";
            lblTitleApp.Size = new Size(103, 30);
            lblTitleApp.TabIndex = 0;
            lblTitleApp.Text = "\U0001f6d2 SIPCS";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(242, 9);
            label1.Name = "label1";
            label1.Size = new Size(210, 30);
            label1.TabIndex = 1;
            label1.Text = "Main Control Screen.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(309, 48);
            label2.Name = "label2";
            label2.Size = new Size(177, 15);
            label2.TabIndex = 2;
            label2.Text = "To start choise from side menu *";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(56, 77, 253);
            ClientSize = new Size(1032, 551);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            ForeColor = Color.FromArgb(119, 139, 253);
            Name = "frmMain";
            Text = "Main";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblTitleApp;
        private Button btnInventory;
        private Label lblWelcom;
        private Label lblRole;
        private Button btnCommissions;
        private Button btnPOS;
        private Button btnLogout;
        private Button btnReports;
        private Label label1;
        private Label label2;
        private Button button2;
    }
}