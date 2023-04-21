using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VegunSoft.Framework.Paging.Provider.Request;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.UCU.UserCustomer.Business.Service.Services;
using VSoft.Company.UI.UCU.UserCustomer.Data.DVO.Data;
using VSoft.Company.UI.UCU.UserCustomer.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.UCU.UserCustomer.View.Main.Code.Provider.Pages
{
    public class PageTableServices : PageTableBase, IPageTableServices
    {
        protected IUserCustomerBusiness BusinessService { get; set; }
        public List<UserCustomerDvo>? UserCustomers { get; private set; }

        public PageTableServices(IUserCustomerBusiness service)
        {
            BusinessService = service;
        }

        public async Task OnInitializedAsync()
        {
            await GetUserCustomers();
        }

        public async Task OnSearch(string keySearch)
        {
            ClearAllMessage();
            KeySearch = keySearch;
            PageParam = new PagingParameters();
            await GetUserCustomers();
        }

        public async Task OnDeleteTask(int deleteId)
        {
            ClearAllMessage();
            var rs = await BusinessService.DeleteUserCustomer(deleteId);
            if (rs.IsSuccessed)
                Messages.Add(new MMessage() { Type = EMessageType.Success, Message = $"Xóa gán khách hàng \"{rs.ResultObj}\" thành công!" });
            else
                Messages.Add(new MMessage() { Type = EMessageType.Error, Message = $"Xóa gán khách hàng \"{rs.ResultObj}\" thất bại!" });
            await GetUserCustomers();
        }

        public async Task OnPageSelect(int page)
        {
            ClearAllMessage();
            PageParam.PageNumber = page;
            await GetUserCustomers();
        }

        protected async Task GetUserCustomers()
        {
            var pagingRs = await BusinessService.GetTableUserCustomer(string.IsNullOrEmpty(KeySearch) ? string.Empty : KeySearch, PageParam);
            if (pagingRs.IsSuccessed)
            {
                var data = pagingRs.ResultObj;
                UserCustomers = data.Items;
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
