using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.UI.PRC.ProductCategory.Data.DVO.Data;

namespace VSoft.Company.UI.PRC.ProductCategory.Business.Service.Services
{
    public interface IProductCategoryBusiness
    {
        Task<MDvoResult<string>> CreateAsync(ProductCategoryDvo teamDvo);

        Task<MDvoResult<List<ProductCategoryDvo>>> GetAll();

        Task<MDvoResult<PagedList<ProductCategoryDvo>>> GetTableProductCategory(string keyWord, PagingParameters pageParameter);

        Task<MDvoResult<string>> DeleteProductCategory(int id);

        Task<MDvoResult<ProductCategoryDvo>> GetProductCategory(string id);

        Task<MDvoResult<string>> UpdateProductCategory(ProductCategoryDvo team);  
    }
}
