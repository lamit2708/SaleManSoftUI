using System.Linq;
using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dto.Response;
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

        public async Task<MDtoResult<string>> CreateAsync(TeamDvo teamDvo)
        {
            var apiRs = await ClientService.CreateAsync(new TeamInsertDtoRequest()
            {
                Data = teamDvo.GetDto(),
            });
            if (apiRs == null)
            {
                if (apiRs.IsSuccess)
                    return new MDtoResultSuccess<string>(apiRs.Data.Name);
                else
                    return new MDtoResultError<string>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDtoResult<PagedList<TeamDvo>>> GetTableTeam(string keyWord, PagingParameters pageParameter)
        {
            //Client làm hàm trả về MDtoResponse<PagedList<TeamDto>>
            var apiRs = await ClientService.GetTableByKeyword(keyWord, pageParameter);
            
            if (apiRs == null)
            {
                if (apiRs.IsSuccess)
                {
                    var teamDvos = apiRs.Data.Items.ToArray().GetDvo().ToList();
                    var rs = new PagedList<TeamDvo>()
                    {
                        MetaData = apiRs.Data.MetaData,
                        Items = teamDvos
                    };
                    return new MDtoResultSuccess<PagedList<TeamDvo>>(rs);
                }
                else
                    return new MDtoResultError<PagedList<TeamDvo>>(apiRs.Message);
            }
            return null;
        }

        public async Task<MDtoResult<string>> DeleteTeam(int id)
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
                    return new MDtoResultSuccess<string>(teamDelete.Name);
                }
                else
                    return new MDtoResultError<string>(apiRs.Message);
            }
            return null;

        }
    }
}
