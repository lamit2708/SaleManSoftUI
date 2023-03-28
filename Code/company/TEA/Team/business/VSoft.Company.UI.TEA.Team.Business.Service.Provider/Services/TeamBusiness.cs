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

        public Task<TeamInsertDvoResponse> CreateAsync(TeamInsertDvoRequest request)
        {
            //var rs = ClientService.FindRangeAsync(request).Result;
            throw new System.NotImplementedException();
        }

        public Task<TeamInsertRangeDvoResponse> CreateRangeAsync(TeamInsertRangeDvoRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<TeamDeleteDvoResponse> DeleteAsync(TeamDeleteDvoRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<TeamDeleteRangeDvoResponse> DeleteRangeAsync(TeamDeleteRangeDvoRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<TeamFindDvoResponse> FindAsync(string request)
        {
            throw new System.NotImplementedException();
        }

        public Task<TeamFindRangeDvoResponse> FindRangeAsync(string request)
        {
            throw new System.NotImplementedException();
        }

        public Task<TeamSaveRangeDvoResponse> SaveRangeAsync(TeamSaveRangeDvoRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<TeamUpdateDvoResponse> UpdateAsync(TeamUpdateDvoRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<TeamUpdateRangeDvoResponse> UpdateRangeAsync(TeamUpdateRangeDvoRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
