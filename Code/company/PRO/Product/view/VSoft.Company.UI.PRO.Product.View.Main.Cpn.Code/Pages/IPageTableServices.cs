using System.Collections.Generic;
using System.Threading.Tasks;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;
using VSoft.Company.UI.PRO.Product.Data.DVO.Data;

namespace VSoft.Company.UI.PRO.Product.View.Main.Cpn.Code.Pages
{
    public interface IPageTableServices : IPageTableBase
    {
        List<ProductDvo> Products { get; }

        Task OnInitializedAsync();

        Task OnSearch(string keySearch);

        Task OnDeleteTask(int deleteId);

        Task OnPageSelect(int page);
    }
}
