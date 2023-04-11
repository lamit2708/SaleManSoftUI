using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;
using VSoft.Company.UI.USR.User.Data.DVO.Data;

namespace VSoft.Company.UI.USR.User.View.Main.Cpn.Code.Pages
{
    public interface IPageUpdateServices : IPageBase
    {
        UserDvo User { get; }
        Task OnInitializedAsync(string teamId);
        Task OnUpdateUser(string teamId, string name, string description);
    }
}
