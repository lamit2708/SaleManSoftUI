using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dvo.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;

namespace VSoft.Company.UI.TEA.Team.Business.Service.Services
{
    public interface ITeamBusiness
    {
        Task<MDvoResult<string>> CreateAsync(TeamDvo teamDvo);

        Task<MDvoResult<PagedList<TeamDvo>>> GetTableTeam(string keyWord, PagingParameters pageParameter);

        Task<MDvoResult<string>> DeleteTeam(int id);
    }
}
