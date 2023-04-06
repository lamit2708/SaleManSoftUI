using System.Collections.Generic;
using System.Threading.Tasks;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;

namespace VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Code.Pages
{
    public interface IPageTableServices : IPageTableBase
    {
        List<DealDvo> Deals { get; }

        Task OnInitializedAsync();

        Task OnSearch(string keySearch);

        Task OnDeleteTask(long deleteId);

        Task OnPageSelect(int page);
    }
}
