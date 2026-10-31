namespace SIPCS.UI.Forms.POS
{
    partial class POS_Main
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
            label4 = new Label();
            button2 = new Button();
            btnReports = new Button();
            btnCommissions = new Button();
            btnPOS = new Button();
            btnShowItems = new Button();
            lblWelcom = new Label();
            lblRole = new Label();
            lblTitleApp = new Label();
            label1 = new Label();
            panel2 = new Panel();
            dgvCartMenuItems = new DataGridView();
            clmSKU = new DataGridViewTextBoxColumn();
            clmProductName = new DataGridViewTextBoxColumn();
            cmlQuantity = new DataGridViewTextBoxColumn();
            clmUnitPrice = new DataGridViewTextBoxColumn();
            clmDelete = new DataGridViewButtonColumn();
            label2 = new Label();
            label3 = new Label();
            panel3 = new Panel();
            label7 = new Label();
            label5 = new Label();
            label6 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCartMenuItems).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(btnReports);
            panel1.Controls.Add(btnCommissions);
            panel1.Controls.Add(btnPOS);
            panel1.Controls.Add(btnShowItems);
            panel1.Controls.Add(lblWelcom);
            panel1.Controls.Add(lblRole);
            panel1.Controls.Add(lblTitleApp);
            panel1.Location = new Point(711, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(285, 471);
            panel1.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(56, 45);
            label4.Name = "label4";
            label4.Size = new Size(177, 15);
            label4.TabIndex = 5;
            label4.Text = "To start choise from side menu *";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(30, 41, 53);
            button2.FlatAppearance.BorderColor = Color.FromArgb(52, 65, 35);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 15F);
            button2.Location = new Point(0, 371);
            button2.Name = "button2";
            button2.Size = new Size(285, 49);
            button2.TabIndex = 4;
            button2.Text = "👩‍💼💼 Admin-Op";
            button2.UseVisualStyleBackColor = false;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.FromArgb(30, 41, 53);
            btnReports.FlatAppearance.BorderColor = Color.FromArgb(52, 65, 35);
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 15F);
            btnReports.Location = new Point(3, 316);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(279, 49);
            btnReports.TabIndex = 3;
            btnReports.Text = "📊 Reports";
            btnReports.UseVisualStyleBackColor = false;
            // 
            // btnCommissions
            // 
            btnCommissions.BackColor = Color.FromArgb(30, 41, 53);
            btnCommissions.FlatAppearance.BorderColor = Color.FromArgb(52, 65, 35);
            btnCommissions.FlatStyle = FlatStyle.Flat;
            btnCommissions.Font = new Font("Segoe UI", 15F);
            btnCommissions.Location = new Point(3, 261);
            btnCommissions.Name = "btnCommissions";
            btnCommissions.Size = new Size(279, 49);
            btnCommissions.TabIndex = 2;
            btnCommissions.Text = "💰  Commissions";
            btnCommissions.UseVisualStyleBackColor = false;
            // 
            // btnPOS
            // 
            btnPOS.BackColor = Color.FromArgb(30, 41, 53);
            btnPOS.FlatAppearance.BorderColor = Color.FromArgb(52, 65, 35);
            btnPOS.FlatStyle = FlatStyle.Flat;
            btnPOS.Font = new Font("Segoe UI", 15F);
            btnPOS.Location = new Point(3, 206);
            btnPOS.Name = "btnPOS";
            btnPOS.Size = new Size(279, 49);
            btnPOS.TabIndex = 1;
            btnPOS.Text = "\U0001f6d2 POS";
            btnPOS.UseVisualStyleBackColor = false;
            // 
            // btnShowItems
            // 
            btnShowItems.BackColor = Color.FromArgb(30, 41, 53);
            btnShowItems.FlatAppearance.BorderColor = Color.FromArgb(52, 65, 35);
            btnShowItems.FlatStyle = FlatStyle.Flat;
            btnShowItems.Font = new Font("Segoe UI", 15F);
            btnShowItems.Location = new Point(0, 151);
            btnShowItems.Name = "btnShowItems";
            btnShowItems.Size = new Size(285, 49);
            btnShowItems.TabIndex = 0;
            btnShowItems.Text = "📦  Show Items";
            btnShowItems.UseVisualStyleBackColor = false;
            btnShowItems.Click += btnShowItems_Click;
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
            lblTitleApp.Location = new Point(82, 15);
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
            label1.Location = new Point(231, 9);
            label1.Name = "label1";
            label1.Size = new Size(210, 30);
            label1.TabIndex = 3;
            label1.Text = "Main Control Screen.";
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvCartMenuItems);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(12, 42);
            panel2.Name = "panel2";
            panel2.Size = new Size(693, 244);
            panel2.TabIndex = 6;
            // 
            // dgvCartMenuItems
            // 
            dgvCartMenuItems.AllowUserToAddRows = false;
            dgvCartMenuItems.AllowUserToDeleteRows = false;
            dgvCartMenuItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCartMenuItems.Columns.AddRange(new DataGridViewColumn[] { clmSKU, clmProductName, cmlQuantity, clmUnitPrice, clmDelete });
            dgvCartMenuItems.Location = new Point(3, 3);
            dgvCartMenuItems.Name = "dgvCartMenuItems";
            dgvCartMenuItems.ReadOnly = true;
            dgvCartMenuItems.Size = new Size(683, 197);
            dgvCartMenuItems.TabIndex = 3;
            // 
            // clmSKU
            // 
            clmSKU.HeaderText = "SKU";
            clmSKU.Name = "clmSKU";
            clmSKU.ReadOnly = true;
            clmSKU.Width = 150;
            // 
            // clmProductName
            // 
            clmProductName.HeaderText = "ProductName";
            clmProductName.Name = "clmProductName";
            clmProductName.ReadOnly = true;
            clmProductName.Width = 170;
            // 
            // cmlQuantity
            // 
            cmlQuantity.HeaderText = "Quantity";
            cmlQuantity.Name = "cmlQuantity";
            cmlQuantity.ReadOnly = true;
            cmlQuantity.Width = 110;
            // 
            // clmUnitPrice
            // 
            clmUnitPrice.HeaderText = "UnitPrice";
            clmUnitPrice.Name = "clmUnitPrice";
            clmUnitPrice.ReadOnly = true;
            clmUnitPrice.Width = 110;
            // 
            // clmDelete
            // 
            clmDelete.HeaderText = "Delete";
            clmDelete.Name = "clmDelete";
            clmDelete.ReadOnly = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(293, 72);
            label2.Name = "label2";
            label2.Size = new Size(0, 30);
            label2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(233, 104);
            label3.Name = "label3";
            label3.Size = new Size(0, 30);
            label3.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label6);
            panel3.Location = new Point(12, 303);
            panel3.Name = "panel3";
            panel3.Size = new Size(693, 211);
            panel3.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 16F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(169, 64);
            label7.Name = "label7";
            label7.Size = new Size(261, 30);
            label7.TabIndex = 6;
            label7.Text = "This is not Emplement yet";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(293, 72);
            label5.Name = "label5";
            label5.Size = new Size(0, 30);
            label5.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(233, 104);
            label6.Name = "label6";
            label6.Size = new Size(0, 30);
            label6.TabIndex = 1;
            // 
            // POS_Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 525);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "POS_Main";
            Text = "POS_Main";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCartMenuItems).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button2;
        private Button btnReports;
        private Button btnCommissions;
        private Button btnPOS;
        private Button btnShowItems;
        private Label lblWelcom;
        private Label lblRole;
        private Label lblTitleApp;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dgvCartMenuItems;
        private DataGridViewTextBoxColumn clmSKU;
        private DataGridViewTextBoxColumn clmProductName;
        private DataGridViewTextBoxColumn cmlQuantity;
        private DataGridViewTextBoxColumn clmUnitPrice;
        private DataGridViewButtonColumn clmDelete;
        private Panel panel3;
        private Label label7;
        private Label label5;
        private Label label6;
    }
}