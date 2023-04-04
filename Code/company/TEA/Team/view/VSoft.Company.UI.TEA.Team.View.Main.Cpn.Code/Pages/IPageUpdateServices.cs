using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;

namespace VSoft.Company.UI.TEA.Team.View.Main.Cpn.Code.Pages
{
    public interface IPageUpdateServices : IPageBase
    {
        TeamDvo Team { get; }
        Task OnInitializedAsync(string teamId);
        Task OnUpdateTeam(string teamId, string name, string description);
    }
}
