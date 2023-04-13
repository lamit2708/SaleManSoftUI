using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dto.Request;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.PRC.ProductCategory.Business.Dto.Request;
using VSoft.Company.PRC.ProductCategory.Client.Services;
using VSoft.Company.UI.PRC.ProductCategory.Business.Service.Services;
using VSoft.Company.UI.PRC.ProductCategory.Data.DVO.Data;
using VSoft.Company.UI.PRC.ProductCategory.Data.DVO.Extension.DataMethods;

namespace VSoft.Company.UI.PRC.ProductCategory.Business.Service.Provider.Services
{
    public class ProductCategoryBusiness : IProductCategoryBusiness
    {
        private IProductCategoryClient ClientService;
        public ProductCategoryBusiness(IProductCategoryClient clientService)
        {
            ClientService = clientService;
        }

        public async Task<MDvoResult<string>> CreateAsync(ProductCategoryDvo teamDvo)
        {
            var apiRs = await ClientService.CreateAsync(new ProductCategoryInsertDtoRequest()
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

        public async Task<MDvoResult<List<ProductCategoryDvo>>> GetAll()
        {
            var apiRs = await ClientService.GetAll();
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var rs = apiRs.Data;
                    var dat = rs.GetDvo().ToList();
                    return new MDvoResultSuccess<List<ProductCategoryDvo>>(dat);
                }
                else
                    return new MDvoResultError<List<ProductCategoryDvo>>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<PagedList<ProductCategoryDvo>>> GetTableProductCategory(string keyWord, PagingParameters pageParameter)
        {
            //Client làm hàm trả về MDtoResponse<PagedList<ProductCategoryDto>>
            var request = new ProductCategoryTableKeySearchDtoRequest()
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
                    var rs = new PagedList<ProductCategoryDvo>()
                    {
                        MetaData = apiRs.MetaData,
                        Items = teamDvos
                    };
                    return new MDvoResultSuccess<PagedList<ProductCategoryDvo>>(rs);
                }
                else
                    return new MDvoResultError<PagedList<ProductCategoryDvo>>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<string>> DeleteProductCategory(int id)
        {
            var apiRs = await ClientService.DeleteAsync(new ProductCategoryDeleteDtoRequest()
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

        public async Task<MDvoResult<ProductCategoryDvo>> GetProductCategory(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var apiRs = await ClientService.FindAsync(new MDtoRequestFindByString() { Id = id });
                if (apiRs != null)
                {
                    if (apiRs.IsSuccess)
                    {
                        var teamDvo = apiRs.Data.GetDvo();
                        return new MDvoResultSuccess<ProductCategoryDvo>(teamDvo);
                    }
                    else
                        return new MDvoResultError<ProductCategoryDvo>(apiRs.Message);
                }
            }
            return null;
        }

        public async Task<MDvoResult<string>> UpdateProductCategory(ProductCategoryDvo teamDvo)
        {
            var teamDto = teamDvo.GetDto();
            var apiRs = await ClientService.UpdateAsync(new ProductCategoryUpdateDtoRequest() { Data = teamDto });
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
    }
}
