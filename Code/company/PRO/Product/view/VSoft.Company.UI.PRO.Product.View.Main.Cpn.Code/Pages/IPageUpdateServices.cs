using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;
using VSoft.Company.UI.PRO.Product.Data.DVO.Data;

namespace VSoft.Company.UI.PRO.Product.View.Main.Cpn.Code.Pages
{
    public interface IPageUpdateServices : IPageBase
    {
        ProductDvo Product { get; }
        Task OnInitializedAsync(string teamId);
        Task OnUpdateProduct(string teamId, string name, string description);
    }
}
