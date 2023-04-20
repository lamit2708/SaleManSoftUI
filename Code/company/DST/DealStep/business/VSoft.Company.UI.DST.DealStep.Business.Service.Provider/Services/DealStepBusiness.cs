using System;
using System.Linq;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dto.Request;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.DST.DealStep.Business.Dto.Request;
using VSoft.Company.DST.DealStep.Client.Services;
using VSoft.Company.UI.DST.DealStep.Business.Service.Services;
using VSoft.Company.UI.DST.DealStep.Data.DVO.Data;
using VSoft.Company.UI.DST.DealStep.Data.DVO.Extension.DataMethods;
using System.Collections.Generic;
using VSoft.Company.DST.DealStep.Business.Dto.Response;

namespace VSoft.Company.UI.DST.DealStep.Business.Service.Provider.Services
{
    public class DealStepBusiness : IDealStepBusiness
    {
        private IDealStepClient ClientService;
        public DealStepBusiness(IDealStepClient clientService)
        {
            ClientService = clientService;
        }

        public async Task<MDvoResult<string>> CreateAsync(DealStepDvo teamDvo)
        {
            var apiRs = await ClientService.CreateAsync(new DealStepInsertDtoRequest()
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

        //public async Task<MDvoResult<PagedList<DealStepDvo>>> GetTableDealStep(string keyWord, PagingParameters pageParameter)
        //{
        //    //Client làm hàm trả về MDtoResponse<PagedList<DealStepDto>>
        //    var request = new DealStepTableKeySearchDtoRequest()
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
        //            var rs = new PagedList<DealStepDvo>()
        //            {
        //                MetaData = apiRs.MetaData,
        //                Items = teamDvos
        //            };
        //            return new MDvoResultSuccess<PagedList<DealStepDvo>>(rs);
        //        }
        //        else
        //            return new MDvoResultError<PagedList<DealStepDvo>>(apiRs.Message);
        //    }
        //    return null;
        //}

        public async Task<MDvoResult<string>> DeleteDealStep(int id)
        {
            var apiRs = await ClientService.DeleteAsync(new DealStepDeleteDtoRequest()
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

        public async Task<MDvoResult<DealStepDvo>> GetDealStep(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var apiRs = await ClientService.FindAsync(new MDtoRequestFindByString() { Id = id });
                if (apiRs != null)
                {
                    if (apiRs.IsSuccess)
                    {
                        var teamDvo = apiRs.Data.GetDvo();
                        return new MDvoResultSuccess<DealStepDvo>(teamDvo);
                    }
                    else
                        return new MDvoResultError<DealStepDvo>(apiRs.Message);
                }
            }
            return null;
        }

        public async Task<MDvoResult<string>> UpdateDealStep(DealStepDvo teamDvo)
        {
            var teamDto = teamDvo.GetDto();
            var apiRs = await ClientService.UpdateAsync(new DealStepUpdateDtoRequest() { Data = teamDto });
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
		public async Task<MDvoResult<List<KeyValuePair<int,string>>>> GetAll()
		{
			var apiRs = await ClientService.GetAll();
			//if (apiRs != null)
			//{
			//	if (apiRs.IsSuccess)
			//	{
			//		var rs = apiRs.Data;
			//		var dat = rs.ToList();
			//		return new MDvoResultSuccess<List<KeyValuePair<int, string>>>(dat);
			//	}
			//	else
			//		return new MDvoResultError<List<KeyValuePair<int, string>>>(apiRs.Message);
			//}
			return null;
		}
	}
}
