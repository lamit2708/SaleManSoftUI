using System.Threading.Tasks;
using VegunSoft.Framework.Business.Dto.Response;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;

namespace VSoft.Company.UI.TEA.Team.Business.Service.Services
{
    public interface ITeamBusiness
    {
        Task<MDtoResult<string>> CreateAsync(TeamDvo teamDvo);
    }
}
