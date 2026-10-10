using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPCS.Common.Models
{
    public class QuotationDetail
    {
        public QuotationDetail() { }
        public QuotationDetail(int quotationDetailID, int quotationID, int productID, int quantity, decimal unitPrice, string? productName)
        {
            QuotationDetailID = quotationDetailID;
            QuotationID = quotationID;
            ProductID = productID;
            Quantity = quantity;
            UnitPrice = unitPrice;
            ProductName = productName;
        }

        public int QuotationDetailID { get; set; }
        public int QuotationID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        // للعرض فقط
        public string? ProductName { get; set; }
        public decimal TotalLine => Quantity * UnitPrice;
    }
}
