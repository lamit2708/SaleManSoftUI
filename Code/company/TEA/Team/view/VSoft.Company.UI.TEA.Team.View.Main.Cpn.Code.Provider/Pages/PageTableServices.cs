using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VegunSoft.Framework.Paging.Provider.Request;
using VSoft.Common.UI.APP.Base.View.Main.Cpn.Code.Provider.Pages;
using VSoft.Company.UI.TEA.Team.Business.Service.Services;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;
using VSoft.Company.UI.TEA.Team.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.TEA.Team.View.Main.Code.Provider.Pages
{
    public class PageTableServices : PageTableBase, IPageTableServices
    {
        protected ITeamBusiness BusinessService { get; set; }
        public List<TeamDvo>? Teams { get; private set; }

        public PageTableServices(ITeamBusiness service)
        {
            BusinessService = service;
        }

        public async Task OnInitializedAsync()
        {
            await GetTeams();
        }

        public async Task OnSearch(string keySearch)
        {
            ClearAllMessage();
            KeySearch = keySearch;
            PageParam = new PagingParameters();
            await GetTeams();
        }

        public async Task OnDeleteTask(int deleteId)
        {
            ClearAllMessage();
            var rs = await BusinessService.DeleteTeam(deleteId);
            if (rs.IsSuccessed) 
                Messages.Add(new MMessage() { Type = EMessageType.Success, Message = $"Xóa nhóm \"{rs.ResultObj}\" thành công!" });
            else
                Messages.Add(new MMessage() { Type = EMessageType.Error, Message = $"Xóa nhóm \"{rs.ResultObj}\" thất bại!" });
            await GetTeams();
        }

        public async Task OnPageSelect(int page)
        {
            ClearAllMessage();
            PageParam.PageNumber = page;
            await GetTeams();
        }

        protected async Task GetTeams()
        {
            var pagingRs = await BusinessService.GetTableTeam(string.IsNullOrEmpty(KeySearch) ? string.Empty : KeySearch, PageParam);
            if (pagingRs.IsSuccessed) 
            {
                var data = pagingRs.ResultObj;
                Teams = data.Items;
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
