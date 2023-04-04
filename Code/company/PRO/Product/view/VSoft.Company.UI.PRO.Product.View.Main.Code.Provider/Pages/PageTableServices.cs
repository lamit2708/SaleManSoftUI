using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.UI.PRO.Product.Business.Service.Services;
using VSoft.Company.UI.PRO.Product.Data.DVO.Data;
using VSoft.Company.UI.PRO.Product.View.Main.Code.Pages;

namespace VSoft.Company.UI.PRO.Product.View.Main.Code.Provider.Pages
{
    public class PageTableServices : IPageTableServices
    {
        protected IProductBusiness BusinessService { get; set; }
        public List<MMessage> Messages { get; private set; } = new List<MMessage>();
        public string? KeySearch { get; private set; }
        public PagingParameters PageParam { get; private set; } = new PagingParameters();
        public MetaData MetaData { get; private set; } = new MetaData();
        public List<ProductDvo> Products { get; private set; }

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
            await BusinessService.DeleteProduct(deleteId);
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
            var pagingRs = await BusinessService.GetTableProduct(KeySearch, PageParam);
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
