using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages;

namespace VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages
{
    public class PageTableBase : PageBase, IPageTableBase
    {
        public string? KeySearch { get; protected set; }
        public PagingParameters PageParam { get; protected set; } = new PagingParameters();
        public MetaData MetaData { get; protected set; } = new MetaData();
    }
}
