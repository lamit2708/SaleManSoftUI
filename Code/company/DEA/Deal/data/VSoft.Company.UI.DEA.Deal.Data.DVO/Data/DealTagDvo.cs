using System;

namespace VSoft.Company.UI.DEA.Deal.Data.DVO.Data
{
    public class DealTagDvo
    {
        public long Id { get; set; }

        public string? DealName { get; set; }

        public long CustomerId { get; set; }

        public string? CustomerName { get; set; }

        public string? CustomerPhone { get; set; }

        public int UserId { get; set; }

        public string? UserName { get; set; }

        public double PridictPrice { get; set; }

        public int DealStepId { get; set; }

        public int? TeamId { get; set; }

        public DateTime? DateFor { get; set; }
    }
}
