namespace SIPCS.Common.Models
{
    public class EmployeeCommission
    {
        public int CommissionID { get; set; }
        public int InvoiceID { get; set; }
        public int UserID { get; set; }
        public decimal CommissionAmount { get; set; }
        public bool IsPaid { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public DateTime? InvoiceDate { get; set; }
    }
}
