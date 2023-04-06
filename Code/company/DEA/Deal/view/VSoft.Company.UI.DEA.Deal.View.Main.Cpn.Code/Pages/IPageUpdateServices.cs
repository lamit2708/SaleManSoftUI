using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;

namespace VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Code.Pages
{
    public interface IPageUpdateServices : IPageBase
    {
        DealDvo Deal { get; }
        Task OnInitializedAsync(string teamId);
        Task OnUpdateDeal(string teamId, string name, string description);
    }
}
