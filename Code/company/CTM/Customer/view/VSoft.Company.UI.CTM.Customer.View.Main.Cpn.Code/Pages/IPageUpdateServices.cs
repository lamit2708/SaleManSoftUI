using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;
using VSoft.Company.UI.CTM.Customer.Data.DVO.Data;

namespace VSoft.Company.UI.CTM.Customer.View.Main.Cpn.Code.Pages
{
    public interface IPageUpdateServices : IPageBase
    {
        CustomerDvo Customer { get; }
        Task OnInitializedAsync(string teamId);
        Task OnUpdateCustomer(string teamId, string name, string description);
    }
}
