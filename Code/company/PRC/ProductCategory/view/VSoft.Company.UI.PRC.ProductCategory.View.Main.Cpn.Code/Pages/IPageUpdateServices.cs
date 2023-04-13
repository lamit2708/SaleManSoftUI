using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;
using VSoft.Company.UI.PRC.ProductCategory.Data.DVO.Data;

namespace VSoft.Company.UI.PRC.ProductCategory.View.Main.Cpn.Code.Pages
{
    public interface IPageUpdateServices : IPageBase
    {
        ProductCategoryDvo ProductCategory { get; }
        Task OnInitializedAsync(string teamId);
        Task OnUpdateProductCategory(string teamId, string name);
    }
}
