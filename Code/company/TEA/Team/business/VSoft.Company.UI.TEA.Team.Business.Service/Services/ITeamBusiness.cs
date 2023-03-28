using System.Threading.Tasks;
using VSoft.Company.UI.TEA.Team.Data.DVO.Request;
using VSoft.Company.UI.TEA.Team.Data.DVO.Response;

namespace VSoft.Company.UI.TEA.Team.Business.Service.Services
{
    public interface ITeamBusiness
    {
        Task<TeamFindDvoResponse> FindAsync(string request);

        Task<TeamFindRangeDvoResponse> FindRangeAsync(string request);

        Task<TeamInsertDvoResponse> CreateAsync(TeamInsertDvoRequest request);

        Task<TeamInsertRangeDvoResponse> CreateRangeAsync(TeamInsertRangeDvoRequest request);

        Task<TeamUpdateDvoResponse> UpdateAsync(TeamUpdateDvoRequest request);

        Task<TeamUpdateRangeDvoResponse> UpdateRangeAsync(TeamUpdateRangeDvoRequest request);

        Task<TeamDeleteDvoResponse> DeleteAsync(TeamDeleteDvoRequest request);

        Task<TeamDeleteRangeDvoResponse> DeleteRangeAsync(TeamDeleteRangeDvoRequest request);

        Task<TeamSaveRangeDvoResponse> SaveRangeAsync(TeamSaveRangeDvoRequest request);
    }
}
