using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.UI.PRF.ProductFeature.Data.DVO.Data;

namespace VSoft.Company.UI.PRF.ProductFeature.Business.Service.Services
{
    public interface IProductFeatureBusiness
    {
        Task<MDvoResult<string>> CreateAsync(ProductFeatureDvo teamDvo);

        Task<MDvoResult<PagedList<ProductFeatureDvo>>> GetTableProductFeature(string keyWord, PagingParameters pageParameter);

        Task<MDvoResult<string>> DeleteProductFeature(int id);

        Task<MDvoResult<ProductFeatureDvo>> GetProductFeature(int id);

        Task<MDvoResult<string>> UpdateProductFeature(ProductFeatureDvo team);
        Task<MDvoResult<List<ProductFeatureDvo>>> GetAll();
    }
}
