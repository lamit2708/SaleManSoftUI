using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VegunSoft.Framework.Paging.Provider.Request;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.DEA.Deal.Business.Service.Services;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;
using VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.DEA.Deal.View.Main.Code.Provider.Pages
{
    public class PageTableServices : PageTableBase, IPageTableServices
    {
        protected IDealBusiness BusinessService { get; set; }
        public List<DealDvo>? Deals { get; private set; }

        public PageTableServices(IDealBusiness service)
        {
            BusinessService = service;
        }

        public async Task OnInitializedAsync()
        {
            await GetDeals();
        }

        public async Task OnSearch(string keySearch)
        {
            ClearAllMessage();
            KeySearch = keySearch;
            PageParam = new PagingParameters();
            await GetDeals();
        }

        public async Task OnDeleteTask(long deleteId)
        {
            ClearAllMessage();
            var rs = await BusinessService.DeleteDeal(deleteId);
            if (rs.IsSuccessed) 
                Messages.Add(new MMessage() { Type = EMessageType.Success, Message = $"Xóa hợp đồng \"{rs.ResultObj}\" thành công!" });
            else
                Messages.Add(new MMessage() { Type = EMessageType.Error, Message = $"Xóa hợp đồng \"{rs.ResultObj}\" thất bại!" });
            await GetDeals();
        }

        public async Task OnPageSelect(int page)
        {
            ClearAllMessage();
            PageParam.PageNumber = page;
            await GetDeals();
        }

        protected async Task GetDeals()
        {
            var pagingRs = await BusinessService.GetTableDeal(string.IsNullOrEmpty(KeySearch) ? string.Empty : KeySearch, PageParam);
            if (pagingRs.IsSuccessed) 
            {
                var data = pagingRs.ResultObj;
                Deals = data.Items;
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
