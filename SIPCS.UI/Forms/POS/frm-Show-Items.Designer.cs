namespace SIPCS.UI.Forms.POS
{
    partial class frm_Show_Items
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
            panel2 = new Panel();
            btnClose = new Button();
            btnAdd = new Button();
            dgvCartMenuItems = new DataGridView();
            clmSKU = new DataGridViewTextBoxColumn();
            clmProductName = new DataGridViewTextBoxColumn();
            clmCategoryName = new DataGridViewTextBoxColumn();
            cmlQuantity = new DataGridViewTextBoxColumn();
            clmUnitPrice = new DataGridViewTextBoxColumn();
            label2 = new Label();
            label3 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCartMenuItems).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(btnClose);
            panel2.Controls.Add(btnAdd);
            panel2.Controls.Add(dgvCartMenuItems);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(828, 450);
            panel2.TabIndex = 7;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.White;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(52, 65, 35);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 15F);
            btnClose.ForeColor = Color.Red;
            btnClose.Location = new Point(12, 389);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(151, 49);
            btnClose.TabIndex = 5;
            btnClose.Text = "❌ Close";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.White;
            btnAdd.FlatAppearance.BorderColor = Color.FromArgb(52, 65, 35);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 15F);
            btnAdd.ForeColor = Color.Red;
            btnAdd.Location = new Point(646, 389);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(174, 49);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "📥 Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvCartMenuItems
            // 
            dgvCartMenuItems.AllowUserToAddRows = false;
            dgvCartMenuItems.AllowUserToDeleteRows = false;
            dgvCartMenuItems.BackgroundColor = Color.FromArgb(30, 41, 53);
            dgvCartMenuItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCartMenuItems.Columns.AddRange(new DataGridViewColumn[] { clmSKU, clmProductName, clmCategoryName, cmlQuantity, clmUnitPrice });
            dgvCartMenuItems.Location = new Point(3, 3);
            dgvCartMenuItems.Name = "dgvCartMenuItems";
            dgvCartMenuItems.ReadOnly = true;
            dgvCartMenuItems.Size = new Size(817, 380);
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
            clmProductName.HeaderText = "Product Name";
            clmProductName.Name = "clmProductName";
            clmProductName.ReadOnly = true;
            clmProductName.Width = 170;
            // 
            // clmCategoryName
            // 
            clmCategoryName.HeaderText = "Category Name";
            clmCategoryName.Name = "clmCategoryName";
            clmCategoryName.ReadOnly = true;
            clmCategoryName.Width = 150;
            // 
            // cmlQuantity
            // 
            cmlQuantity.HeaderText = "Quantity";
            cmlQuantity.Name = "cmlQuantity";
            cmlQuantity.ReadOnly = true;
            cmlQuantity.Width = 150;
            // 
            // clmUnitPrice
            // 
            clmUnitPrice.HeaderText = "Unit Price";
            clmUnitPrice.Name = "clmUnitPrice";
            clmUnitPrice.ReadOnly = true;
            clmUnitPrice.Width = 150;
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
            // frm_Show_Items
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 450);
            Controls.Add(panel2);
            Name = "frm_Show_Items";
            Text = "Show Items";
            Load += frm_Show_Items_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCartMenuItems).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridView dgvCartMenuItems;
        private DataGridViewTextBoxColumn clmSKU;
        private DataGridViewTextBoxColumn clmProductName;
        private DataGridViewTextBoxColumn clmCategoryName;
        private DataGridViewTextBoxColumn cmlQuantity;
        private DataGridViewTextBoxColumn clmUnitPrice;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button btnAdd;
        private Button btnClose;
    }
}