using System.Collections.Generic;
using System.Threading.Tasks;

namespace VSoft.Company.UI.PRO.Team.View.Main.Code.Pages
{
    public interface IPageCreateServices
    {
        List<string> PageMessage { get; }
        bool IsSuccess { get; }
        Task CreateTeams(string name, string description);
    }
}
