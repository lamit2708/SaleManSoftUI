using System.Collections.Generic;
using VSoft.Company.PRO.Product.Business.Dto.Data;
using VSoft.Company.UI.PRO.Product.Data.DVO.Data;

namespace VSoft.Company.UI.PRO.Product.Data.DVO.Extension.DataMethods
{
    public static class ProductDtoMethods
    {
        public static ProductDvo GetDvo(this ProductDto src)
        {
            return new ProductDvo()
            {
                Id = src.Id,
                Name = src.Name,
                Description = src.Description,
            };
        }

        public static ProductDvo[]? GetDvo(this ProductDto[]? src)
        {
            if (src == null)
                return null;
            var rs = new List<ProductDvo>();
            foreach(var item in src )
            {
                rs.Add(GetDvo(item));
            }
            return rs.ToArray();
        }
    }
}
