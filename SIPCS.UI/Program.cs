

using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;

namespace SIPCS.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // ✅ تحقق من الاتصال بقاعدة البيانات قبل الفتح
            if (DatabaseHelper.TestConnection())
            {
                MessageBox.Show("تم الاتصال بقاعدة البيانات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("فشل الاتصال بقاعدة البيانات. يرجى التحقق من الإعدادات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // إيقاف تشغيل التطبيق إذا فشل الاتصال
            }
            Application.Run(new Forms.LoginForm());
        }
    }
}
