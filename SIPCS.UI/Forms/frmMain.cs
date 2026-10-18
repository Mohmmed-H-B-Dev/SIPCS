using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIPCS.UI.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("🚧 Inventory module is under construction.", "SIPCS");

        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            الان 
                نبني نظام الكاشير (POS) الخاص بنا باستخدام Windows Forms في C#.

                نقوم بتصميم واجهة المستخدم الخاصة بنظام نقاط البيع (POS) باستخدام Windows Forms في C#.
                سنقوم بإنشاء نموذج رئيسي يحتوي على أزرار للوصول إلى مختلف
                وحدات النظام مثل المخزون، 
                المبيعات، التقارير، الإعدادات، والعمولات.
                عند النقر على أي زر، سيتم عرض رسالة تفيد بأن الوحدة قيد الإنشاء.

            MessageBox.Show("🚧 POS module is under construction.", "SIPCS");

        }

        private void btnCommissions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("🚧 Commissions module is under construction.", "SIPCS");

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("🚧 Reports module is under construction.", "SIPCS");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("🚧 Settings module is under construction.", "SIPCS");
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                new Login().ShowDialog();
                this.Close();
                Login loginForm = new Login();
                loginForm.Show();
            }
        }
    }
}
