using System;

namespace VSoft.Company.UI.CTM.Customer.Data.DVO.Data
{
	public class CustomerDvo
	{
		public long Id { get; set; }

		public string Name { get; set; } = null!;

		public string Phone { get; set; } = null!;

		public string Email { get; set; } = null!;

		public string? Address { get; set; }

		/// <summary>
		/// True: Male, False: Female
		/// </summary>
		public bool? Gender { get; set; }

		public int? PriorityId { get; set; }

		// public long? CustomerInfoId { get; set; }

		public bool IsBought { get; set; }

		public string? Keyword { get; set; }

		public int? CustomerSourceId { get; set; }

		public string? Hobby { get; set; }

		public string? Job { get; set; }

		public DateTime? BirthDate { get; set; }

		public bool? IsMarrage { get; set; }
		public override string ToString()
		{
			return $"{Id} / {Name}";
		}
	}
}
