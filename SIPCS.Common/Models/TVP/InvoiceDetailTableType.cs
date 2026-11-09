using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPCS.Common.Models.TVP
{


    
        public class InvoiceDetailTableType
        {
            public int ProductId { get; set; }
            public string SKU { get; set; }
            public string ProductName { get; set; }
            public decimal Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal DiscountAmount { get; set; }
            public decimal TaxRate { get; set; }
            public decimal TaxAmount { get; set; }
            public decimal UnitCost { get; set; }

             


           
        
           
        }

        /// <summary>
        /// يمثل جدول تفاصيل طرق الدفع والمدفوعات (الكلاس الشامل لكل متغيرات الدفع)
        /// </summary>

    }
