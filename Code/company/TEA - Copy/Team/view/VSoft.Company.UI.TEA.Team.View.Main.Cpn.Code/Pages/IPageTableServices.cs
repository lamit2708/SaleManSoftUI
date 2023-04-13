using System.Collections.Generic;
using System.Threading.Tasks;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;

namespace VSoft.Company.UI.TEA.Team.View.Main.Cpn.Code.Pages
{
    public interface IPageTableServices : IPageTableBase
    {
        List<TeamDvo> Teams { get; }

        Task OnInitializedAsync();

        Task OnSearch(string keySearch);

        Task OnDeleteTask(int deleteId);

        Task OnPageSelect(int page);
    }
}
