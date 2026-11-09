namespace SIPCS.UI.Forms.POS
{
    partial class POS_Payments
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
            label7 = new Label();
            txtWallet = new TextBox();
            label6 = new Label();
            txtBankTransfer = new TextBox();
            label5 = new Label();
            txtCash = new TextBox();
            label3 = new Label();
            txtCard = new TextBox();
            label2 = new Label();
            txtCredit = new TextBox();
            panel2 = new Panel();
            label1 = new Label();
            txtTotal = new TextBox();
            listViewCart = new ListView();
            label4 = new Label();
            lblTitleApp = new Label();
            btnClose = new Button();
            btnPayed = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtWallet);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtBankTransfer);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtCash);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtCard);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtCredit);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnPayed);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(682, 426);
            panel1.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(347, 214);
            label7.Name = "label7";
            label7.Size = new Size(69, 25);
            label7.TabIndex = 21;
            label7.Text = "Wallet :";
            // 
            // txtWallet
            // 
            txtWallet.Font = new Font("Segoe UI", 12F);
            txtWallet.ForeColor = Color.Black;
            txtWallet.Location = new Point(474, 212);
            txtWallet.Name = "txtWallet";
            txtWallet.Size = new Size(159, 29);
            txtWallet.TabIndex = 20;
            txtWallet.Tag = "Wallet";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(343, 166);
            label6.Name = "label6";
            label6.Size = new Size(125, 25);
            label6.TabIndex = 19;
            label6.Tag = "";
            label6.Text = "Bank Transfer :";
            // 
            // txtBankTransfer
            // 
            txtBankTransfer.Font = new Font("Segoe UI", 12F);
            txtBankTransfer.ForeColor = Color.Black;
            txtBankTransfer.Location = new Point(474, 166);
            txtBankTransfer.Name = "txtBankTransfer";
            txtBankTransfer.Size = new Size(159, 29);
            txtBankTransfer.TabIndex = 18;
            txtBankTransfer.Tag = "Bank Transfer";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(343, 27);
            label5.Name = "label5";
            label5.Size = new Size(59, 25);
            label5.TabIndex = 17;
            label5.Text = "Cash :";
            // 
            // txtCash
            // 
            txtCash.Font = new Font("Segoe UI", 12F);
            txtCash.ForeColor = Color.Black;
            txtCash.Location = new Point(474, 27);
            txtCash.Name = "txtCash";
            txtCash.Size = new Size(159, 29);
            txtCash.TabIndex = 16;
            txtCash.Tag = "Cash";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(347, 74);
            label3.Name = "label3";
            label3.Size = new Size(58, 25);
            label3.TabIndex = 15;
            label3.Text = "Card :";
            // 
            // txtCard
            // 
            txtCard.Font = new Font("Segoe UI", 12F);
            txtCard.ForeColor = Color.Black;
            txtCard.Location = new Point(474, 74);
            txtCard.Name = "txtCard";
            txtCard.Size = new Size(159, 29);
            txtCard.TabIndex = 14;
            txtCard.Tag = "Card";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(347, 120);
            label2.Name = "label2";
            label2.Size = new Size(68, 25);
            label2.TabIndex = 13;
            label2.Text = "Credit :";
            // 
            // txtCredit
            // 
            txtCredit.Font = new Font("Segoe UI", 12F);
            txtCredit.ForeColor = Color.Black;
            txtCredit.Location = new Point(474, 120);
            txtCredit.Name = "txtCredit";
            txtCredit.Size = new Size(159, 29);
            txtCredit.TabIndex = 12;
            txtCredit.Tag = "Credit";
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtTotal);
            panel2.Controls.Add(listViewCart);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(lblTitleApp);
            panel2.Controls.Add(btnClose);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(334, 420);
            panel2.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(10, 329);
            label1.Name = "label1";
            label1.Size = new Size(58, 25);
            label1.TabIndex = 11;
            label1.Text = "Total :";
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 12F);
            txtTotal.ForeColor = Color.Black;
            txtTotal.Location = new Point(90, 329);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(159, 29);
            txtTotal.TabIndex = 10;
            // 
            // listViewCart
            // 
            listViewCart.Location = new Point(6, 81);
            listViewCart.Name = "listViewCart";
            listViewCart.Size = new Size(308, 233);
            listViewCart.TabIndex = 9;
            listViewCart.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(72, 39);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 8;
            label4.Text = "POS System v1.0";
            // 
            // lblTitleApp
            // 
            lblTitleApp.AutoSize = true;
            lblTitleApp.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitleApp.ForeColor = Color.White;
            lblTitleApp.Location = new Point(72, 4);
            lblTitleApp.Name = "lblTitleApp";
            lblTitleApp.Size = new Size(103, 30);
            lblTitleApp.TabIndex = 7;
            lblTitleApp.Text = "\U0001f6d2 SIPCS";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Thistle;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(52, 65, 35);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 15F);
            btnClose.ForeColor = Color.Red;
            btnClose.Location = new Point(3, 368);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(276, 49);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnPayed
            // 
            btnPayed.BackColor = Color.Thistle;
            btnPayed.FlatAppearance.BorderColor = Color.FromArgb(52, 65, 35);
            btnPayed.FlatStyle = FlatStyle.Flat;
            btnPayed.Font = new Font("Segoe UI", 15F);
            btnPayed.ForeColor = Color.Red;
            btnPayed.Location = new Point(291, 371);
            btnPayed.Name = "btnPayed";
            btnPayed.Size = new Size(388, 49);
            btnPayed.TabIndex = 5;
            btnPayed.Text = "Done";
            btnPayed.UseVisualStyleBackColor = false;
            btnPayed.Click += btnPayed_Click;
            // 
            // POS_Payments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(706, 450);
            Controls.Add(panel1);
            Name = "POS_Payments";
            Text = "POS_Payments";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btnClose;
        private Button btnPayed;
        private Label label4;
        private Label lblTitleApp;
        private ListView listViewCart;
        private Label label1;
        private TextBox txtTotal;
        private Label label7;
        private TextBox txtWallet;
        private Label label6;
        private TextBox txtBankTransfer;
        private Label label5;
        private TextBox txtCash;
        private Label label3;
        private TextBox txtCard;
        private Label label2;
        private TextBox txtCredit;
    }
}