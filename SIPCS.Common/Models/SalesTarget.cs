using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPCS.Common.Models
{
    public class SalesTarget
    {

        public int TargetID { get; set; }
        public int UserID { get; set; }
        public decimal TargetAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsAchieved { get; set; }
        public string? FullName { get; set; }
    }
}
