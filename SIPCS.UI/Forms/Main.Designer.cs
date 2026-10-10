namespace SIPCS.UI.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Panel pnlSidebar;
        private Panel pnlContent;
        private Label lblAppName;
        private Label lblWelcome;
        private Label lblRole;
        private Button btnInventory;
        private Button btnPOS;
        private Button btnCommissions;
        private Button btnReports;
        private Button btnLogout;
        private Button CreateSidebarButton(string text, int y)
        {
            var btn = new Button
            {
                Text      = text,
                Location  = new Point(15, y),
                Size      = new Size(1100, 680),
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.FromArgb(203, 213, 225),
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 10f),
                TextAlign = ContentAlignment.MiddleRight,
                Padding   = new Padding(10, 0, 0, 0),
                Cursor    = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize  = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 65, 85);
            return btn;
        }
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
            int btnY = 120;
            btnInventory   = CreateSidebarButton("📦  المخزون", btnY); btnY += 55;
            btnPOS         = CreateSidebarButton("🛒  نقطة البيع", btnY); btnY += 55;
            btnCommissions = CreateSidebarButton("💰  العمولات", btnY); btnY += 55;
            btnReports     = CreateSidebarButton("📊  التقارير", btnY); btnY += 55;

          //  btnInventory.Click   += btnInventory_Click;
           // btnPOS.Click         += btnPOS_Click;
          //  btnCommissions.Click += btnCommissions_Click;
           // btnReports.Click     += btnReports_Click;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(884, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 687);
            panel1.TabIndex = 0;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(1084, 687);
            Controls.Add(panel1);
            MinimumSize = new Size(900, 600);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SIPCS — Smart Inventory · POS · Commission System";
            Load += Main_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
    }
}