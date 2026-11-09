using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPCS.Common.Models.TVP
{
    public class PaymentMethodTableType
    {


        public string PaymentProvider { get; set; }
        public string Notes { get; set; }
        public string TransactionReference { get; set; }
        public string CardLast4 { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public decimal Amount { get; set; }



        public DateTime PaymentDate { get; set; }
        public int ProcessedByUserID { get; set; }
    }
}
