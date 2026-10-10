using SIPCS.Common.Enums;
using System.Dynamic;

namespace SIPCS.Common.Models
{
    public class CommissionRule
    {
        public int RuleID { get; set; }
        public int RoleID { get; set; }
        public CommissionTargetType TargetType { get; set; }
        public decimal CommissionValue { get; set; }  // نسبة % أو مبلغ ثابت

         public decimal MinimumTargetAmount { get; set; }  // الحد الأدنى للهدف
        public TargetPeriodType TargetPeriod { get; set; }  // فترة الهدف (مثلاً:  
  //      شهري، ربع سنوي، سنوي)
        public string CommissionType { get; set; }  //Sales , Product.that means the commission is based on sales or Specific product
        public string? RoleName { get; set; }

        public string GetNameCommissionTargetType(CommissionTargetType commissionTargetType)
        {
           return commissionTargetType switch
            {
                CommissionTargetType.Daily => "Daily",
                CommissionTargetType.Monthly => "Monthly",
                CommissionTargetType.Quarterly => "Quarterly",
                CommissionTargetType.Yearly => "Yearly",
                _ => "Unknown"
            };
        }
        public CommissionTargetType CheckCommissionTargetType(string commissionTargetType)
        {
            return commissionTargetType.ToLower() switch
            {
                "daily" => CommissionTargetType.Daily,
                "monthly" => CommissionTargetType.Monthly,
                "quarterly" => CommissionTargetType.Quarterly,
                "yearly" => CommissionTargetType.Yearly,
                _ => throw new ArgumentException("Invalid commission target type")
            };
        }


        public string GetNameTargetPeriodType(TargetPeriodType TargetType)
        {
            return TargetType switch
            {
                TargetPeriodType.Percentage => "Percentage",
                TargetPeriodType.Fixed => "Fixed",
                _ => "Unknown"
            };
        }

        public TargetPeriodType CheckTargetPeriodType(string TargetType)
        {
            return TargetType.ToLower() switch
            {
                "percentage" => TargetPeriodType.Percentage,
                "fixed" => TargetPeriodType.Fixed,
                _ => throw new ArgumentException("Invalid target period type")
            };
        }
    }
}
