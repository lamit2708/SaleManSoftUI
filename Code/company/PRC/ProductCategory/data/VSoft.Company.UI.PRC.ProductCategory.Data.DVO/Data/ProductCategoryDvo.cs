namespace VSoft.Company.UI.PRC.ProductCategory.Data.DVO.Data
{
    public class ProductCategoryDvo
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public override string ToString()
        {
            return $"{Id} / {Name}";
        }
    }
}
