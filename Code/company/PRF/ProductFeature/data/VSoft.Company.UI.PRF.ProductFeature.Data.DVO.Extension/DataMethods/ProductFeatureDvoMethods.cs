using VSoft.Company.PRF.ProductFeature.Business.Dto.Data;
using VSoft.Company.UI.PRF.ProductFeature.Data.DVO.Data;

namespace VSoft.Company.UI.PRF.ProductFeature.Data.DVO.Extension.DataMethods
{
    public static class ProductFeatureDvoMethods
    {
        public static ProductFeatureDto GetDto(this ProductFeatureDvo src)
        {
            return new ProductFeatureDto()
            {
                Id = src.Id,
                Name = src.Name,
                Description = src.Description,
                ProductId = src.ProductId,
                Price = src.Price

            };
        }
    }
}
