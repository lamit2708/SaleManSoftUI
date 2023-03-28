using VSoft.Company.UI.TEA.Team.Client.Main.Code.Pages;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;

namespace VSoft.Company.UI.TEA.Team.Client.Main.Code.Provider.Pages
{
    public class PageCreateServices : IPageCreateServices
    {
        public Task<bool> CreateTeams(TeamDvo dvo)
        {
            return Task.FromResult(true);
        }
    }
}
