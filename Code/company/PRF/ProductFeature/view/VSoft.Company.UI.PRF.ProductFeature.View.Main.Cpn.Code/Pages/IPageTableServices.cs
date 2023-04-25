using System.Collections.Generic;
using System.Threading.Tasks;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;
using VSoft.Company.UI.PRF.ProductFeature.Data.DVO.Data;

namespace VSoft.Company.UI.PRF.ProductFeature.View.Main.Cpn.Code.Pages
{
    public interface IPageTableServices : IPageTableBase
    {
        List<ProductFeatureDvo> ProductFeatures { get; }

        Task OnInitializedAsync();

        Task OnSearch(string keySearch);

        Task OnDeleteTask(int deleteId);

        Task OnPageSelect(int page);
    }
}
