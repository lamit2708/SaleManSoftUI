using System.Collections.Generic;
using VSoft.Company.PRC.ProductCategory.Business.Dto.Data;
using VSoft.Company.UI.PRC.ProductCategory.Data.DVO.Data;

namespace VSoft.Company.UI.PRC.ProductCategory.Data.DVO.Extension.DataMethods
{
    public static class ProductCategoryDtoMethods
    {
        public static ProductCategoryDvo GetDvo(this ProductCategoryDto src)
        {
            return new ProductCategoryDvo()
            {
                Id = src.Id,
                Name = src.Name,
            };
        }

        public static ProductCategoryDvo[]? GetDvo(this ProductCategoryDto[]? src)
        {
            if (src == null)
                return null;
            var rs = new List<ProductCategoryDvo>();
            foreach(var item in src )
            {
                rs.Add(GetDvo(item));
            }
            return rs.ToArray();
        }
    }
}
