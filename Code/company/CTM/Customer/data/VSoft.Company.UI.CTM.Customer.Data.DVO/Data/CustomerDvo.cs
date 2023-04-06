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

        public long? CustomerInfoId { get; set; }

        public bool IsBought { get; set; }

        public override string ToString()
        {
            return $"{Id} / {Name}";
        }
    }
}
