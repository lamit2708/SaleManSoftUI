using System;

namespace VSoft.Company.UI.DEA.Deal.Data.DVO.Data
{
    public class DealDvo
    {
        public long Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public long CustomerId { get; set; }

        public int DealStepId { get; set; }

        public int UserId { get; set; }

        public int? OrderId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double PridictPrice { get; set; }

        public DateTime? DateFor { get; set; }

        public double? PricePossible { get; set; }

        public override string ToString()
        {
            return $"{Id} / {Name}";
        }
    }
}
