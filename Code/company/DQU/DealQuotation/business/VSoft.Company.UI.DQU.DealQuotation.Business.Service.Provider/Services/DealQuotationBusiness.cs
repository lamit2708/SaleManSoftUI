using System;
using System.Linq;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dto.Request;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.DQU.DealQuotation.Business.Dto.Request;
using VSoft.Company.DQU.DealQuotation.Client.Services;
using VSoft.Company.UI.DQU.DealQuotation.Business.Service.Services;
using VSoft.Company.UI.DQU.DealQuotation.Data.DVO.Data;
using VSoft.Company.UI.DQU.DealQuotation.Data.DVO.Extension.DataMethods;

namespace VSoft.Company.UI.DQU.DealQuotation.Business.Service.Provider.Services
{
    public class DealQuotationBusiness : IDealQuotationBusiness
    {
        private IDealQuotationClient ClientService;
        public DealQuotationBusiness(IDealQuotationClient clientService)
        {
            ClientService = clientService;
        }

        public async Task<MDvoResult<string>> CreateAsync(DealQuotationDvo teamDvo)
        {
            var apiRs = await ClientService.CreateAsync(new DealQuotationInsertDtoRequest()
            {
                Data = teamDvo.GetDto(),
            });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                    return new MDvoResultSuccess<string>(apiRs.Data.DealId.ToString());
                else
                    return new MDvoResultError<string>(apiRs.Message);
            }
            return null;
        }

        //public async Task<MDvoResult<PagedList<DealQuotationDvo>>> GetTableDealQuotation(string keyWord, PagingParameters pageParameter)
        //{
        //    //Client làm hàm trả về MDtoResponse<PagedList<DealQuotationDto>>
        //    var request = new DealQuotationTableKeySearchDtoRequest()
        //    {
        //        Data = keyWord,
        //        PagingParams = pageParameter,
        //    };
        //    var apiRs = await ClientService.GetTableByKeyword(request);
            
        //    if (apiRs != null)
        //    {
        //        if (apiRs.IsSuccess)
        //        {
        //            var teamDvos = apiRs.Data.GetDvo().ToList();
        //            var rs = new PagedList<DealQuotationDvo>()
        //            {
        //                MetaData = apiRs.MetaData,
        //                Items = teamDvos
        //            };
        //            return new MDvoResultSuccess<PagedList<DealQuotationDvo>>(rs);
        //        }
        //        else
        //            return new MDvoResultError<PagedList<DealQuotationDvo>>(apiRs.Message);
        //    }
        //    return null;
        //}

        public async Task<MDvoResult<string>> DeleteDealQuotation(int id)
        {
            var apiRs = await ClientService.DeleteAsync(new DealQuotationDeleteDtoRequest()
            {
                Id = id,
            });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamDelete = apiRs.Data;
                    return new MDvoResultSuccess<string>(teamDelete.DealId.ToString());
                }
                else
                    return new MDvoResultError<string>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<DealQuotationDvo>> GetDealQuotation(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var apiRs = await ClientService.FindAsync(new MDtoRequestFindByString() { Id = id });
                if (apiRs != null)
                {
                    if (apiRs.IsSuccess)
                    {
                        var teamDvo = apiRs.Data.GetDvo();
                        return new MDvoResultSuccess<DealQuotationDvo>(teamDvo);
                    }
                    else
                        return new MDvoResultError<DealQuotationDvo>(apiRs.Message);
                }
            }
            return null;
        }

        public async Task<MDvoResult<string>> UpdateDealQuotation(DealQuotationDvo teamDvo)
        {
            var teamDto = teamDvo.GetDto();
            var apiRs = await ClientService.UpdateAsync(new DealQuotationUpdateDtoRequest() { Data = teamDto });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamUpdate = apiRs.Data;
                    return new MDvoResultSuccess<string>(teamUpdate.DealId.ToString());
                }
                else
                    return new MDvoResultError<string>(apiRs.Message);
            }
            return null;
        }
    }
}
