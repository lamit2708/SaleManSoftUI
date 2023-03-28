using System.Threading.Tasks;
using VSoft.Company.TEA.Team.Client.Services;
using VSoft.Company.UI.TEA.Team.Business.Service.Services;
using VSoft.Company.UI.TEA.Team.Data.DVO.Request;
using VSoft.Company.UI.TEA.Team.Data.DVO.Response;

namespace VSoft.Company.UI.TEA.Team.Business.Service.Provider.Services
{
    public class TeamBusiness : ITeamBusiness
    {
        private ITeamClient ClientService;
        public TeamBusiness(ITeamClient clientService)
        {
            ClientService = clientService;
        }

        public Task<TeamFindDvoResponse> FindAsync(string request)
        {

            var rs = ClientService.FindRangeAsync(request).Result;
        }

        public Task<TeamFindRangeDvoResponse> FindRangeAsync(string request)
        {

        }

        public Task<TeamInsertDvoResponse> CreateAsync(TeamInsertDvoRequest request)
        {

        }

        public Task<TeamInsertRangeDvoResponse> CreateRangeAsync(TeamInsertRangeDvoRequest request)
        {

        }

        public Task<TeamUpdateDvoResponse> UpdateAsync(TeamUpdateDvoRequest request)
        {

        }

        public Task<TeamUpdateRangeDvoResponse> UpdateRangeAsync(TeamUpdateRangeDvoRequest request)
        {

        }

        public Task<TeamDeleteDvoResponse> DeleteAsync(TeamDeleteDvoRequest request)
        {

        }

        public Task<TeamDeleteRangeDvoResponse> DeleteRangeAsync(TeamDeleteRangeDvoRequest request)
        {

        }

        public Task<TeamSaveRangeDvoResponse> SaveRangeAsync(TeamSaveRangeDvoRequest request)
        {

        }
    }
}
