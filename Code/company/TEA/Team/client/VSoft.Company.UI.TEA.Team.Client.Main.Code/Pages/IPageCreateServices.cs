using System.Threading.Tasks;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;

namespace VSoft.Company.UI.TEA.Team.Client.Main.Code.Pages
{
    public interface IPageCreateServices
    {
        Task<bool> CreateTeams(TeamDvo dvo);
    }
}
