using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VegunSoft.Framework.Paging.Provider.Request;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.USR.User.Business.Service.Services;
using VSoft.Company.UI.USR.User.Data.DVO.Data;
using VSoft.Company.UI.USR.User.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.USR.User.View.Main.Code.Provider.Pages
{
    public class PageTableServices : PageTableBase, IPageTableServices
    {
        protected IUserBusiness BusinessService { get; set; }
        public List<UserDvo>? Users { get; private set; }

        public PageTableServices(IUserBusiness service)
        {
            BusinessService = service;
        }

        public async Task OnInitializedAsync()
        {
            await GetUsers();
        }

        public async Task OnSearch(string keySearch)
        {
            ClearAllMessage();
            KeySearch = keySearch;
            PageParam = new PagingParameters();
            await GetUsers();
        }

        public async Task OnDeleteTask(int deleteId)
        {
            ClearAllMessage();
            var rs = await BusinessService.DeleteUser(deleteId);
            if (rs.IsSuccessed) 
                Messages.Add(new MMessage() { Type = EMessageType.Success, Message = $"Xóa User \"{rs.ResultObj}\" thành công!" });
            else
                Messages.Add(new MMessage() { Type = EMessageType.Error, Message = $"Xóa User \"{rs.ResultObj}\" thất bại!" });
            await GetUsers();
        }

        public async Task OnPageSelect(int page)
        {
            ClearAllMessage();
            PageParam.PageNumber = page;
            await GetUsers();
        }

        protected async Task GetUsers()
        {
            var pagingRs = await BusinessService.GetTableUser(string.IsNullOrEmpty(KeySearch) ? string.Empty : KeySearch, PageParam);
            if (pagingRs.IsSuccessed) 
            {
                var data = pagingRs.ResultObj;
                Users = data.Items;
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
