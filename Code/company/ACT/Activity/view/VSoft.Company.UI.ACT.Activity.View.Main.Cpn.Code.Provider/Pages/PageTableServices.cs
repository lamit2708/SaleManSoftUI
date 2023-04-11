using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VegunSoft.Framework.Paging.Provider.Request;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.ACT.Activity.Business.Service.Services;
using VSoft.Company.UI.ACT.Activity.Data.DVO.Data;
using VSoft.Company.UI.ACT.Activity.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.ACT.Activity.View.Main.Code.Provider.Pages
{
    public class PageTableServices : PageTableBase, IPageTableServices
    {
        protected IActivityBusiness BusinessService { get; set; }
        public List<ActivityDvo>? Activitys { get; private set; }

        public PageTableServices(IActivityBusiness service)
        {
            BusinessService = service;
        }

        public async Task OnInitializedAsync()
        {
            await GetActivitys();
        }

        public async Task OnSearch(string keySearch)
        {
            ClearAllMessage();
            KeySearch = keySearch;
            PageParam = new PagingParameters();
            await GetActivitys();
        }

        public async Task OnDeleteTask(int deleteId)
        {
            ClearAllMessage();
            var rs = await BusinessService.DeleteActivity(deleteId);
            if (rs.IsSuccessed) 
                Messages.Add(new MMessage() { Type = EMessageType.Success, Message = $"Xóa Activity \"{rs.ResultObj}\" thành công!" });
            else
                Messages.Add(new MMessage() { Type = EMessageType.Error, Message = $"Xóa Activity \"{rs.ResultObj}\" thất bại!" });
            await GetActivitys();
        }

        public async Task OnPageSelect(int page)
        {
            ClearAllMessage();
            PageParam.PageNumber = page;
            await GetActivitys();
        }

        protected async Task GetActivitys()
        {
            var pagingRs = await BusinessService.GetTableActivity(string.IsNullOrEmpty(KeySearch) ? string.Empty : KeySearch, PageParam);
            if (pagingRs.IsSuccessed) 
            {
                var data = pagingRs.ResultObj;
                Activitys = data.Items;
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
