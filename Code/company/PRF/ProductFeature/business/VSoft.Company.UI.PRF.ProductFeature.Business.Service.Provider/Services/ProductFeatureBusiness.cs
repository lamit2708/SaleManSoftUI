using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dto.Request;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.PRF.ProductFeature.Business.Dto.Data;
using VSoft.Company.PRF.ProductFeature.Business.Dto.Request;
using VSoft.Company.PRF.ProductFeature.Client.Services;
using VSoft.Company.UI.PRF.ProductFeature.Business.Service.Services;
using VSoft.Company.UI.PRF.ProductFeature.Data.DVO.Data;
using VSoft.Company.UI.PRF.ProductFeature.Data.DVO.Extension.DataMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VSoft.Company.UI.PRF.ProductFeature.Business.Service.Provider.Services
{
    public class ProductFeatureBusiness : IProductFeatureBusiness
    {
        private IProductFeatureClient ClientService;
        public ProductFeatureBusiness(IProductFeatureClient clientService)
        {
            ClientService = clientService;
        }

        public async Task<MDvoResult<string>> CreateAsync(ProductFeatureDvo teamDvo)
        {
            var apiRs = await ClientService.CreateAsync(new ProductFeatureInsertDtoRequest()
            {
                Data = teamDvo.GetDto(),
            });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                    return new MDvoResultSuccess<string>(apiRs.Data.Name);
                else
                    return new MDvoResultError<string>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<PagedList<ProductFeatureDvo>>> GetTableProductFeature(string keyWord, PagingParameters pageParameter)
        {
            //Client làm hàm trả về MDtoResponse<PagedList<ProductFeatureDto>>
            var request = new ProductFeatureTableKeySearchDtoRequest()
            {
                Data = keyWord,
                PagingParams = pageParameter,
            };
            var apiRs = await ClientService.GetTableByKeyword(request);

            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamDvos = apiRs.Data.GetDvo().ToList();
                    var rs = new PagedList<ProductFeatureDvo>()
                    {
                        MetaData = apiRs.MetaData,
                        Items = teamDvos
                    };
                    return new MDvoResultSuccess<PagedList<ProductFeatureDvo>>(rs);
                }
                else
                    return new MDvoResultError<PagedList<ProductFeatureDvo>>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<string>> DeleteProductFeature(int id)
        {
            var apiRs = await ClientService.DeleteAsync(new ProductFeatureDeleteDtoRequest()
            {
                Id = id,
            });
            if (apiRs != null)
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

        public async Task<MDvoResult<ProductFeatureDvo>> GetProductFeature(int id)
        {
            var apiRs = await ClientService.FindAsync(new MDtoRequestFindByInt() { Id = id });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var dvo = apiRs.Data.GetDvo();
                    return new MDvoResultSuccess<ProductFeatureDvo>(dvo);
                }
                else
                    return new MDvoResultError<ProductFeatureDvo>(apiRs.Message);
            }

            return null;
        }

        public async Task<MDvoResult<string>> UpdateProductFeature(ProductFeatureDvo teamDvo)
        {
            var teamDto = teamDvo.GetDto();
            var apiRs = await ClientService.UpdateAsync(new ProductFeatureUpdateDtoRequest() { Data = teamDto });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamUpdate = apiRs.Data;
                    return new MDvoResultSuccess<string>(teamUpdate.Name);
                }
                else
                    return new MDvoResultError<string>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<List<ProductFeatureDvo>>> GetAll()
        {
            var apiRs = await ClientService.GetAll();
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var rs = apiRs.Data;
                    var dat = rs.GetDvo().ToList();
                    return new MDvoResultSuccess<List<ProductFeatureDvo>>(dat);
                }
                else
                    return new MDvoResultError<List<ProductFeatureDvo>>(apiRs.Message);
            }
            return null;
        }
    }
}
