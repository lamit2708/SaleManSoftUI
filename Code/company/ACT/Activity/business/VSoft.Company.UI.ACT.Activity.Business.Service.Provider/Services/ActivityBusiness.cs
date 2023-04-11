using System;
using System.Linq;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dto.Request;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.ACT.Activity.Business.Dto.Request;
using VSoft.Company.ACT.Activity.Client.Services;
using VSoft.Company.UI.ACT.Activity.Business.Service.Services;
using VSoft.Company.UI.ACT.Activity.Data.DVO.Data;
using VSoft.Company.UI.ACT.Activity.Data.DVO.Extension.DataMethods;

namespace VSoft.Company.UI.ACT.Activity.Business.Service.Provider.Services
{
    public class ActivityBusiness : IActivityBusiness
    {
        private IActivityClient ClientService;
        public ActivityBusiness(IActivityClient clientService)
        {
            ClientService = clientService;
        }

        public async Task<MDvoResult<string>> CreateAsync(ActivityDvo teamDvo)
        {
            var apiRs = await ClientService.CreateAsync(new ActivityInsertDtoRequest()
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

        public async Task<MDvoResult<PagedList<ActivityDvo>>> GetTableActivity(string keyWord, PagingParameters pageParameter)
        {
            //Client làm hàm trả về MDtoResponse<PagedList<ActivityDto>>
            var request = new ActivityTableKeySearchDtoRequest()
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
                    var rs = new PagedList<ActivityDvo>()
                    {
                        MetaData = apiRs.MetaData,
                        Items = teamDvos
                    };
                    return new MDvoResultSuccess<PagedList<ActivityDvo>>(rs);
                }
                else
                    return new MDvoResultError<PagedList<ActivityDvo>>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<string>> DeleteActivity(int id)
        {
            var apiRs = await ClientService.DeleteAsync(new ActivityDeleteDtoRequest()
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

        public async Task<MDvoResult<ActivityDvo>> GetActivity(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var apiRs = await ClientService.FindAsync(new MDtoRequestFindByString() { Id = id });
                if (apiRs != null)
                {
                    if (apiRs.IsSuccess)
                    {
                        var teamDvo = apiRs.Data.GetDvo();
                        return new MDvoResultSuccess<ActivityDvo>(teamDvo);
                    }
                    else
                        return new MDvoResultError<ActivityDvo>(apiRs.Message);
                }
            }
            return null;
        }

        public async Task<MDvoResult<string>> UpdateActivity(ActivityDvo teamDvo)
        {
            var teamDto = teamDvo.GetDto();
            var apiRs = await ClientService.UpdateAsync(new ActivityUpdateDtoRequest() { Data = teamDto });
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
