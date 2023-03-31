using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dto.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;

namespace VSoft.Company.UI.TEA.Team.Business.Service.Services
{
    public interface ITeamBusiness
    {
        Task<MDtoResult<string>> CreateAsync(TeamDvo teamDvo);

        Task<MDtoResult<PagedList<TeamDvo>>> GetTableTeam(string keyWord, PagingParameters pageParameter);
    }
}
