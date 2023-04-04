using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.UI.PRO.Product.Data.DVO.Data;

namespace VSoft.Company.UI.PRO.Product.Business.Service.Services
{
    public interface IProductBusiness
    {
        Task<MDvoResult<string>> CreateAsync(ProductDvo teamDvo);

        Task<MDvoResult<PagedList<ProductDvo>>> GetTableProduct(string keyWord, PagingParameters pageParameter);

        Task<MDvoResult<string>> DeleteProduct(int id);

        Task<MDvoResult<ProductDvo>> GetProduct(string id);

        Task<MDvoResult<string>> UpdateProduct(ProductDvo team);  
    }
}
