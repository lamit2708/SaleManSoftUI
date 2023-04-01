using System.Linq;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.TEA.Team.Business.Dto.Request;
using VSoft.Company.TEA.Team.Client.Services;
using VSoft.Company.UI.TEA.Team.Business.Service.Services;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;
using VSoft.Company.UI.TEA.Team.Data.DVO.Extension.DataMethods;

namespace VSoft.Company.UI.TEA.Team.Business.Service.Provider.Services
{
    public class TeamBusiness : ITeamBusiness
    {
        private ITeamClient ClientService;
        public TeamBusiness(ITeamClient clientService)
        {
            ClientService = clientService;
        }

        public async Task<MDvoResult<string>> CreateAsync(TeamDvo teamDvo)
        {
            var apiRs = await ClientService.CreateAsync(new TeamInsertDtoRequest()
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

        public async Task<MDvoResult<PagedList<TeamDvo>>> GetTableTeam(string keyWord, PagingParameters pageParameter)
        {
            //Client làm hàm trả về MDtoResponse<PagedList<TeamDto>>
            var request = new TeamTableKeySearchDtoRequest()
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
                    var rs = new PagedList<TeamDvo>()
                    {
                        MetaData = apiRs.MetaData,
                        Items = teamDvos
                    };
                    return new MDvoResultSuccess<PagedList<TeamDvo>>(rs);
                }
                else
                    return new MDvoResultError<PagedList<TeamDvo>>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDvoResult<string>> DeleteTeam(int id)
        {
            var apiRs = await ClientService.DeleteAsync(new TeamDeleteDtoRequest()
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
