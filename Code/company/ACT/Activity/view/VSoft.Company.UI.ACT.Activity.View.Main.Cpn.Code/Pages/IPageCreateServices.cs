using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;
using VSoft.Company.UI.ACT.Activity.Data.DVO.Data;

namespace VSoft.Company.UI.ACT.Activity.View.Main.Cpn.Code.Pages
{
    public interface IPageCreateServices : IPageBase
    {
        Task CreateActivitys(ActivityDvo activityDvo);
    }
}
