using VegunSoft.Framework.Base.Entity.Model;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;

namespace VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages
{
    public class PageBase : IPageBase
    {
        public List<MMessage> Messages { get; protected set; } = new List<MMessage>();
    }
}
