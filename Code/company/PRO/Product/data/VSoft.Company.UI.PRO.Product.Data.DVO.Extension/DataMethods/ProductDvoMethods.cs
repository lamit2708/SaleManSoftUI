using VSoft.Company.PRO.Product.Business.Dto.Data;
using VSoft.Company.UI.PRO.Product.Data.DVO.Data;

namespace VSoft.Company.UI.PRO.Product.Data.DVO.Extension.DataMethods
{
    public static class ProductDvoMethods
    {
        public static ProductDto GetDto(this ProductDvo src)
        {
            return new ProductDto()
            {
                Id = src.Id,
                Name = src.Name,
                Description = src.Description,
                Quantity = src.Quantity,
                CategoryId = src.CategoryId,
                Keyword = src.Keyword,
                Price  = src.Price,
            };
        }
    }
}
