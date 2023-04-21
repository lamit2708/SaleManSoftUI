using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;
using VSoft.Company.UI.UCU.UserCustomer.Data.DVO.Data;

namespace VSoft.Company.UI.UCU.UserCustomer.View.Main.Cpn.Code.Pages
{
    public interface IPageCreateServices : IPageBase
    {
        Task CreateUserCustomers(UserCustomerDvo dealDvo);
    }
}
