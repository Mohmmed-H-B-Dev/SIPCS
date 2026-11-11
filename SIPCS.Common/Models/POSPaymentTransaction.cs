
using SIPCS.Common.Enums;

namespace SIPCS.Common.Models
{
    // عمليات الدفع والتحصيل لفواتير نقاط البيع
    public class POSPaymentTransaction
    {
        // =====================================================
        // PAYMENT METHOD CONVERSION
        // =====================================================

        // تحويل طريقة الدفع من Enum إلى نص
        public static string GetNameOfPaymentMethod(POSPaymentMethod method)
        {
            return method switch
            {
                POSPaymentMethod.Cash => "Cash",
                POSPaymentMethod.Card => "Card",
                POSPaymentMethod.Credit => "Credit",
                POSPaymentMethod.BankTransfer => "Bank Transfer",
                POSPaymentMethod.Wallet => "Wallet",
                _ => "Unknown"
            };
        }

        // تحويل طريقة الدفع من نص إلى Enum
        public static POSPaymentMethod GetTypeOfPaymentMethod(string str)
        {
            return str switch
            {
                "Cash" => POSPaymentMethod.Cash,
                "Card" => POSPaymentMethod.Card,
                "Credit" => POSPaymentMethod.Credit,
                "Bank Transfer" => POSPaymentMethod.BankTransfer,
                "Wallet" => POSPaymentMethod.Wallet,
                _ => POSPaymentMethod.Unknown
            };
        }

        // =====================================================
        // PAYMENT STATUS CONVERSION
        // =====================================================

        // تحويل حالة الدفع من Enum إلى نص
        public static string GetNameOfPaymentStatus(POSPaymentStatus status)
        {
            return status switch
            {
                POSPaymentStatus.Pending => "Pending",
                POSPaymentStatus.Processing => "Processing",
                POSPaymentStatus.Completed => "Completed",
                POSPaymentStatus.Failed => "Failed",
                POSPaymentStatus.Refunded => "Refunded",
                POSPaymentStatus.Voided => "Voided",
                _ => "Unknown"
            };
        }

        // تحويل حالة الدفع من نص إلى Enum
        public static POSPaymentStatus GetTypeOfPaymentStatus(string str)
        {
            return str switch
            {
                "Pending" => POSPaymentStatus.Pending,
                "Processing" => POSPaymentStatus.Processing,
                "Completed" => POSPaymentStatus.Completed,
                "Failed" => POSPaymentStatus.Failed,
                "Refunded" => POSPaymentStatus.Refunded,
                "Voided" => POSPaymentStatus.Voided,
                _ => POSPaymentStatus.Unknown
            };
        }

        // =====================================================
        // PROPERTIES
        // =====================================================

        // المعرف الفريد لعملية الدفع
        public int PaymentTransactionID { get; set; }

        // الفاتورة المرتبطة بعملية الدفع
        public int InvoiceID { get; set; }

        // طريقة الدفع
        public POSPaymentMethod PaymentMethod { get; set; }

        // المبلغ المدفوع
        public decimal Amount { get; set; }

        // حالة عملية الدفع
        public POSPaymentStatus PaymentStatus { get; set; } = POSPaymentStatus.Pending;

        // رقم مرجع العملية
        public string? TransactionReference { get; set; }

        // اسم البنك أو مزود خدمة الدفع
        public string? PaymentProvider { get; set; }

        // آخر أربعة أرقام من البطاقة
        public string? CardLast4 { get; set; }

        // تاريخ تنفيذ عملية الدفع
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        // الموظف الذي نفذ العملية
        public int? ProcessedByUserID { get; set; }

        // ملاحظات إضافية
        public string? Notes { get; set; }

        // تاريخ إنشاء السجل
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // خصائص للعرض فقط
        public string? UserName { get; set; }
        public string? InvoiceNumber { get; set; }
    }
}
