namespace SIPCS.Common.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        
        public string? TaxNumber { get; set; }  // الرقم الضريبي
    }
}
