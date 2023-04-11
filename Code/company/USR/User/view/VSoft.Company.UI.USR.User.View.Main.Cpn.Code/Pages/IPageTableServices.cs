using System.Collections.Generic;
using System.Threading.Tasks;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;
using VSoft.Company.UI.USR.User.Data.DVO.Data;

namespace VSoft.Company.UI.USR.User.View.Main.Cpn.Code.Pages
{
    public interface IPageTableServices : IPageTableBase
    {
        List<UserDvo> Users { get; }

        Task OnInitializedAsync();

        Task OnSearch(string keySearch);

        Task OnDeleteTask(int deleteId);

        Task OnPageSelect(int page);
    }
}
