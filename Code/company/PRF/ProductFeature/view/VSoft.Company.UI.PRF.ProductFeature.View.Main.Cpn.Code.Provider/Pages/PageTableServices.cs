using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VegunSoft.Framework.Paging.Provider.Request;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.PRF.ProductFeature.Business.Service.Services;
using VSoft.Company.UI.PRF.ProductFeature.Data.DVO.Data;
using VSoft.Company.UI.PRF.ProductFeature.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.PRF.ProductFeature.View.Main.Code.Provider.Pages
{
    public class PageTableServices : PageTableBase, IPageTableServices
    {
        protected IProductFeatureBusiness BusinessService { get; set; }
        public List<ProductFeatureDvo>? ProductFeatures { get; private set; }

        public PageTableServices(IProductFeatureBusiness service)
        {
            BusinessService = service;
        }

        public async Task OnInitializedAsync()
        {
            await GetProductFeatures();
        }

        public async Task OnSearch(string keySearch)
        {
            ClearAllMessage();
            KeySearch = keySearch;
            PageParam = new PagingParameters();
            await GetProductFeatures();
        }

        public async Task OnDeleteTask(int deleteId)
        {
            ClearAllMessage();
            var rs = await BusinessService.DeleteProductFeature(deleteId);
            if (rs.IsSuccessed)
                Messages.Add(new MMessage() { Type = EMessageType.Success, Message = $"Xóa khách hàng \"{rs.ResultObj}\" thành công!" });
            else
                Messages.Add(new MMessage() { Type = EMessageType.Error, Message = $"Xóa khách hàng \"{rs.ResultObj}\" thất bại!" });
            await GetProductFeatures();
        }

        public async Task OnPageSelect(int page)
        {
            ClearAllMessage();
            PageParam.PageNumber = page;
            await GetProductFeatures();
        }

        protected async Task GetProductFeatures()
        {
            var pagingRs = await BusinessService.GetTableProductFeature(string.IsNullOrEmpty(KeySearch) ? string.Empty : KeySearch, PageParam);
            if (pagingRs.IsSuccessed)
            {
                var data = pagingRs.ResultObj;
                ProductFeatures = data.Items;
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
