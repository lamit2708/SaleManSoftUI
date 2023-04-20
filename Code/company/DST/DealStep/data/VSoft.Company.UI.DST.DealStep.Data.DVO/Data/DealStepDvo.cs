namespace VSoft.Company.UI.DST.DealStep.Data.DVO.Data
{
    public class DealStepDvo
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public override string ToString()
        {
            return $"{Id} / {Name}";
        }
    }
}
