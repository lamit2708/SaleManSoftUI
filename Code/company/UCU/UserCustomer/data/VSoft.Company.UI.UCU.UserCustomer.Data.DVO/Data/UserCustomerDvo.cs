using System;

namespace VSoft.Company.UI.UCU.UserCustomer.Data.DVO.Data
{
    public class UserCustomerDvo
    {
        public int Id { get; set; }
        public long CustomerId { get; set; }
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public DateTime? CreatedDateUser { get; set; }
		public DateTime? CreatedDateTeam { get; set; }
		public string? UserFullName { get; set; }
        public string? CustomerFullName { get; set; }
        public string? TeamName { get; set; }

		

		public override string ToString()
        {
            return $"{Id} / {CustomerFullName}";
        }
    }
}
