using System.Collections.Generic;
using System.Threading.Tasks;
using VegunSoft.Framework.Base.Entity.Model;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.UI.PRO.Product.Data.DVO.Data;

namespace VSoft.Company.UI.PRO.Product.View.Main.Code.Pages
{
    public interface IPageTableServices
    {
        List<MMessage> Messages { get; }
        string? KeySearch { get; }
        PagingParameters PageParam { get; }
        MetaData MetaData { get; }
        List<ProductDvo> Products { get; }

        Task OnInitializedAsync();

        Task OnSearch(string keySearch);

        Task OnDeleteTask(int deleteId);

        Task OnPageSelect(int page);
    }
}
