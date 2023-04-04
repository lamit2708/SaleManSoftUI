using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;

namespace VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Pages
{
    public interface IPageTableBase : IPageBase
    {
        string? KeySearch { get; }
        PagingParameters PageParam { get; }
        MetaData MetaData { get; }
    }
}
