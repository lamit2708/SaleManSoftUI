using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.DQU.DealQuotation.View.Main.Cpn.Code.Pages
{
    public interface IPageCreateServices : IPageBase
    {
        Task CreateDealQuotations(string name, string description);
    }
}
