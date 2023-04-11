using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;
using VSoft.Company.UI.ACT.Activity.Data.DVO.Data;

namespace VSoft.Company.UI.ACT.Activity.View.Main.Cpn.Code.Pages
{
    public interface IPageUpdateServices : IPageBase
    {
        ActivityDvo Activity { get; }
        Task OnInitializedAsync(string teamId);
        Task OnUpdateActivity(ActivityDvo activityDvo);
    }
}
