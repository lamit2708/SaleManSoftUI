namespace VSoft.Company.UI.PRO.Product.Data.DVO.Data
{
    public class ProductDvo
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double Price { get; set; }

        public int Quantity { get; set; } = 0!;

        public int CategoryId { get; set; }

        public string Description { get; set; } = null!;

        public string Keyword { get; set; }

        public override string ToString()
        {
            return $"{Id} / {Name}";
        }
    }
}
