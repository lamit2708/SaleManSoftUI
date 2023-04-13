using VSoft.Company.PRC.ProductCategory.Business.Dto.Data;
using VSoft.Company.UI.PRC.ProductCategory.Data.DVO.Data;

namespace VSoft.Company.UI.PRC.ProductCategory.Data.DVO.Extension.DataMethods
{
    public static class ProductCategoryDvoMethods
    {
        public static ProductCategoryDto GetDto(this ProductCategoryDvo src)
        {
            return new ProductCategoryDto()
            {
                Id = src.Id,
                Name = src.Name,
            };
        }
    }
}
