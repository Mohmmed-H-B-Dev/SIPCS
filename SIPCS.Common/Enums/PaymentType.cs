namespace SIPCS.Common.Enums
{
    /// <summary>
    /// طريقة الدفع في نقطة البيع
    /// </summary>
    public enum PaymentType
    {
        Cash = 1,    // نقدي
        Card = 2,    // بطاقة شبكة
        Credit = 3 ,  // آجل (على حساب العميل)
        Unknown = 4   // غير معروف
    }
}
