namespace SIPCS.UI.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.Size           = new Size(1100, 680);
            this.StartPosition  = FormStartPosition.CenterScreen;
            this.RightToLeft    = RightToLeft.Yes;
            this.Font           = new Font("Segoe UI", 10f);
            this.MinimumSize    = new Size(900, 600);

            // ── Sidebar ──
            pnlSidebar = new Panel
            {
                Dock      = DockStyle.Right,
                Width     = 220,
                BackColor = Color.FromArgb(15, 23, 42)
            };
            this.Controls.Add(pnlSidebar);

            lblAppName = new Label
            {
                Text      = "🛒 SIPCS",
                Font      = new Font("Segoe UI", 15f, FontStyle.Bold),
                ForeColor = Color.FromArgb(56, 139, 253),
                Location  = new Point(0, 30),
                Size      = new Size(220, 35),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlSidebar.Controls.Add(lblAppName);

            lblWelcome = new Label
            {
                Text      = "",
                ForeColor = Color.White,
                Location  = new Point(10, 80),
                Size      = new Size(200, 22),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlSidebar.Controls.Add(lblWelcome);

            lblRole = new Label
            {
                Text      = "",
                ForeColor = Color.FromArgb(56, 139, 253),
                Font      = new Font("Segoe UI", 9f),
                Location  = new Point(10, 102),
                Size      = new Size(200, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlSidebar.Controls.Add(lblRole);

          
           

            pnlSidebar.Controls.AddRange(new Control[]
                { btnInventory, btnPOS, btnCommissions, btnReports });

            btnLogout = new Button
            {
                Text      = "تسجيل الخروج",
                Location  = new Point(15, 560),
                Size      = new Size(190, 38),
                BackColor = Color.FromArgb(127, 29, 29),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += btnLogout_Click;
            pnlSidebar.Controls.Add(btnLogout);

            // ── Content Area ──
            pnlContent = new Panel
            {
                Dock      = DockStyle.Fill,
                BackColor = Color.FromArgb(30, 41, 59)
            };
            this.Controls.Add(pnlContent);

            var lblDashboard = new Label
            {
                Text      = "لوحة التحكم الرئيسية",
                Font      = new Font("Segoe UI", 16f, FontStyle.Bold),
                ForeColor = Color.White,
                Location  = new Point(30, 30),
                Size      = new Size(400, 40)
            };
            pnlContent.Controls.Add(lblDashboard);

            var lblHint = new Label
            {
                Text      = "اختر من القائمة الجانبية للبدء ✨",
                ForeColor = Color.FromArgb(100, 116, 139),
                Location  = new Point(30, 80),
                Size      = new Size(500, 30),
                Font      = new Font("Segoe UI", 12f)
            };
            pnlContent.Controls.Add(lblHint);

            this.ResumeLayout(false);
        }

    
    }
}
