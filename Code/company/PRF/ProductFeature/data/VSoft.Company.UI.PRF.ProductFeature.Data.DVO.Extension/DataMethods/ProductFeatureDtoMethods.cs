using System.Collections.Generic;
using VSoft.Company.PRF.ProductFeature.Business.Dto.Data;
using VSoft.Company.UI.PRF.ProductFeature.Data.DVO.Data;

namespace VSoft.Company.UI.PRF.ProductFeature.Data.DVO.Extension.DataMethods
{
    public static class ProductFeatureDtoMethods
    {
        public static ProductFeatureDvo GetDvo(this ProductFeatureDto src)
        {
            return new ProductFeatureDvo()
            {
                Id = src.Id,
                Name = src.Name,
                Description = src.Description,
                Price = src.Price,
                ProductId = src.ProductId
            };
        }

        public static ProductFeatureDvo[]? GetDvo(this ProductFeatureDto[]? src)
        {
            if (src == null)
                return null;
            var rs = new List<ProductFeatureDvo>();
            foreach (var item in src)
            {
                rs.Add(GetDvo(item));
            }
            return rs.ToArray();
        }
    }
}
