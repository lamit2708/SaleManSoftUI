using System.Linq;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.PRO.Product.Business.Dto.Request;
using VSoft.Company.PRO.Product.Client.Services;
using VSoft.Company.UI.PRO.Product.Business.Service.Services;
using VSoft.Company.UI.PRO.Product.Data.DVO.Data;
using VSoft.Company.UI.PRO.Product.Data.DVO.Extension.DataMethods;

namespace VSoft.Company.UI.PRO.Product.Business.Service.Provider.Services
{
    public class ProductBusiness : IProductBusiness
    {
        private IProductClient ClientService;
        public ProductBusiness(IProductClient clientService)
        {
            ClientService = clientService;
        }

        public async Task<MDvoResult<string>> CreateAsync(ProductDvo teamDvo)
        {
            var apiRs = await ClientService.CreateAsync(new ProductInsertDtoRequest()
            {
                Data = teamDvo.GetDto(),
            });
            if (apiRs == null)
            {
                if (apiRs.IsSuccess)
                    return new MDvoResultSuccess<string>(apiRs.Data.Name);
                else
                    return new MDvoResultError<string>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<PagedList<ProductDvo>>> GetTableProduct(string keyWord, PagingParameters pageParameter)
        {
            //Client làm hàm trả về MDtoResponse<PagedList<ProductDto>>
            var request = new ProductTableKeySearchDtoRequest()
            {
                Data = keyWord,
                PagingParams = pageParameter,
            };
            var apiRs = await ClientService.GetTableByKeyword(request);
            
            if (apiRs == null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamDvos = apiRs.Data.GetDvo().ToList();
                    var rs = new PagedList<ProductDvo>()
                    {
                        MetaData = apiRs.MetaData,
                        Items = teamDvos
                    };
                    return new MDvoResultSuccess<PagedList<ProductDvo>>(rs);
                }
                else
                    return new MDvoResultError<PagedList<ProductDvo>>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<string>> DeleteProduct(int id)
        {
            var apiRs = await ClientService.DeleteAsync(new ProductDeleteDtoRequest()
            {
                Id = id,
            });
            if (apiRs == null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamDelete = apiRs.Data;
                    return new MDvoResultSuccess<string>(teamDelete.Name);
                }
                else
                    return new MDvoResultError<string>(apiRs.Message);
            }
            return null;

        }
    }
}
