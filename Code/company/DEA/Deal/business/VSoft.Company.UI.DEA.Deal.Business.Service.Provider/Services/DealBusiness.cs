using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dto.Request;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.DEA.Deal.Business.Dto.Data;
using VSoft.Company.DEA.Deal.Business.Dto.Request;
using VSoft.Company.DEA.Deal.Client.Services;
using VSoft.Company.DST.DealStep.Client.Services;
using VSoft.Company.TEA.Team.Client.Services;
using VSoft.Company.UI.DEA.Deal.Business.Service.Services;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Extension.DataMethods;
using VSoft.Company.USR.User.Client.Services;
using VSoft.Company.VDT.VDealTag.Business.Dto.Data;
using VSoft.Company.VDT.VDealTag.Business.Dto.Request;
using VSoft.Company.VDT.VDealTag.Client.Services;

namespace VSoft.Company.UI.DEA.Deal.Business.Service.Provider.Services
{
    public class DealBusiness : IDealBusiness
    {
        private IDealClient ClientService;
        private IVDealTagClient ClientVDTService;
        private IDealStepClient ClientDSTService;
        private IUserClient ClientUserService;
        private ITeamClient ClientTeamService;
        public DealBusiness(IDealClient clientService, IVDealTagClient clientVDTService, IDealStepClient clientDST, IUserClient usrClient, ITeamClient teamClient)
        {
            ClientService = clientService;
            ClientVDTService = clientVDTService;
            ClientDSTService = clientDST;
            ClientUserService = usrClient;
            ClientTeamService = teamClient;
        }

        public async Task<MDvoResult<string>> CreateAsync(DealDvo teamDvo)
        {
            var apiRs = await ClientService.CreateAsync(new DealInsertDtoRequest()
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

        public async Task<MDvoResult<PagedList<DealDvo>>> GetTableDeal(string keyWord, PagingParameters pageParameter)
        {
            //Client làm hàm trả về MDtoResponse<PagedList<DealDto>>
            var request = new DealTableKeySearchDtoRequest()
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
                    var rs = new PagedList<DealDvo>()
                    {
                        MetaData = apiRs.MetaData,
                        Items = teamDvos
                    };
                    return new MDvoResultSuccess<PagedList<DealDvo>>(rs);
                }
                else
                    return new MDvoResultError<PagedList<DealDvo>>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<string>> DeleteDeal(long id)
        {
            var apiRs = await ClientService.DeleteAsync(new DealDeleteDtoRequest()
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

        public async Task<MDvoResult<DealDvo>> GetDeal(string id)
        {
            var valId = string.IsNullOrEmpty(id) ? "0" : id;

            var apiRs = await ClientService.FindAsync(new MDtoRequestFindByString() { Id = valId });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamDvo = apiRs.Data.GetDvo();
                    return new MDvoResultSuccess<DealDvo>(teamDvo);
                }
                else
                    return new MDvoResultError<DealDvo>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<string>> UpdateDeal(DealDvo teamDvo)
        {
            var teamDto = teamDvo.GetDto();
            var apiRs = await ClientService.UpdateAsync(new DealUpdateDtoRequest() { Data = teamDto });
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

        public async Task<MDvoResult<string>> UpdateStepDeal(long dealId, int dealStepUpdate, string dealName)
        {
            var dto = new DealDto() { Id = dealId, DealStepId = dealStepUpdate, Name = dealName };
            var apiRs = await ClientService.UpdateStepAsync(new DealChangeStepDtoRequest() { Data = dto });
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

        public async Task<MDvoResult<List<DealTagDvo>>> GetDealTagDvo(int? userId, int? teamId, DateTime? date, string keyword)
        {
            var apiRs = await ClientVDTService.GetByFilter(new VDealTagFilterDtoRequest()
            {
                Filter = new VDealTagFilterDto()
                {
                    UserId = userId == 0 ? null : userId,
                    TeamId = teamId == 0 ? null : teamId,
                    Date = date,
                    Keyword = keyword,
                    Buffer = "a"
                },
            });
            if (apiRs != null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamDvo = apiRs.Data.GetDvo();
                    return new MDvoResultSuccess<List<DealTagDvo>>(teamDvo.ToList());
                }
                else
                    return new MDvoResultError<List<DealTagDvo>>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<Dictionary<int, string>>> GetDealStep()
        {
            var rs = await ClientDSTService.GetAll();
            if (rs != null)
            {
                if (rs.IsSuccess)
                {
                    var dealStep = new Dictionary<int, string>();
                    foreach(var ds in rs.Data)
                        dealStep.Add(ds.Id, ds.Name);
                    return new MDvoResultSuccess<Dictionary<int, string>>(dealStep);
                }
                else
                    return new MDvoResultError<Dictionary<int, string>>(rs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<Dictionary<int, string>>> GetUser()
        {
            var rs = await ClientUserService.GetAll();
            if (rs != null)
            {
                if (rs.IsSuccess)
                {
                    var dealStep = new Dictionary<int, string>();
                    foreach (var ds in rs.Data)
                        dealStep.Add(ds.Key, ds.Value);
                    return new MDvoResultSuccess<Dictionary<int, string>>(dealStep);
                }
                else
                    return new MDvoResultError<Dictionary<int, string>>(rs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<Dictionary<int, string>>> GetTeam()
        {
            var rs = await ClientTeamService.GetAll();
            if (rs != null)
            {
                if (rs.IsSuccess)
                {
                    var dealStep = new Dictionary<int, string>();
                    foreach (var ds in rs.Data)
                        dealStep.Add(ds.Key, ds.Value);
                    return new MDvoResultSuccess<Dictionary<int, string>>(dealStep);
                }
                else
                    return new MDvoResultError<Dictionary<int, string>>(rs.Message);
            }
            return null;
        }
    }
}
