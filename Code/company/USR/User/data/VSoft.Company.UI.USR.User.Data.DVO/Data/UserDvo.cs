namespace VSoft.Company.UI.USR.User.Data.DVO.Data
{
    public class UserDvo
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Email { get; set; }

        public int? TeamId { get; set; }

        public override string ToString()
        {
            return $"{Id} / {Name}";
        }
    }
}
