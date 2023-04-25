using System;

namespace VSoft.Company.UI.DQU.DealQuotation.Data.DVO.Data
{
    public class DealQuotationDvo
    {
        public long Id { get; set; }

        public long DealId { get; set; }

        public int ProductId { get; set; }

        public int Quatitty { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public override string ToString()
        {
            return $"{Id} / {DealId}";
        }
    }
}
