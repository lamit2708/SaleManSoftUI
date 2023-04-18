using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VegunSoft.Framework.Paging.Provider.Request;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.PRO.Product.Business.Service.Services;
using VSoft.Company.UI.PRO.Product.Data.DVO.Data;
using VSoft.Company.UI.PRO.Product.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.PRO.Product.View.Main.Code.Provider.Pages
{
    public class PageTableServices : PageTableBase, IPageTableServices
    {
        protected IProductBusiness BusinessService { get; set; }
        public List<ProductDvo>? Products { get; private set; }

        public PageTableServices(IProductBusiness service)
        {
            BusinessService = service;
        }

        public async Task OnInitializedAsync()
        {
            await GetProducts();
        }

        public async Task OnSearch(string keySearch)
        {
            ClearAllMessage();
            KeySearch = keySearch;
            PageParam = new PagingParameters();
            await GetProducts();
        }

        public async Task OnDeleteTask(int deleteId)
        {
            ClearAllMessage();
            var rs = await BusinessService.DeleteProduct(deleteId);
            if (rs.IsSuccessed) 
                Messages.Add(new MMessage() { Type = EMessageType.Success, Message = $"Xóa sản phẩm \"{rs.ResultObj}\" thành công!" });
            else
                Messages.Add(new MMessage() { Type = EMessageType.Error, Message = $"Xóa sản phẩm \"{rs.ResultObj}\" thất bại!" });
            await GetProducts();
        }

        public async Task OnPageSelect(int page)
        {
            ClearAllMessage();
            PageParam.PageNumber = page;
            await GetProducts();
        }

        protected async Task GetProducts()
        {
            var pagingRs = await BusinessService.GetTableProduct(string.IsNullOrEmpty(KeySearch) ? string.Empty : KeySearch, PageParam);
            if (pagingRs.IsSuccessed) 
            {
                var data = pagingRs.ResultObj;
                Products = data.Items;
                MetaData = data.MetaData;
            }
            else
                Messages.Add(new MMessage() { Type = EMessageType.Error, Message = $"Không thể load trang \"{PageParam.PageNumber}\" với từ khóa \"{KeySearch}\"" });
        }

        protected void ClearAllMessage()
        {
            Messages?.Clear();
        }
    }
}
