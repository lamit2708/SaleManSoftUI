<<<<<<< HEAD:Code/company/TEA/Team/view/VSoft.Company.UI.TEA.Team.View.Main.Cpn.Code.Provider/Pages/PageTableServices.cs
﻿using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
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
                Messages.Add(new MMessage() { Type = EMessageType.Success, Message = $"Xóa Team \"{rs.ResultObj}\" thành công!" });
            else
                Messages.Add(new MMessage() { Type = EMessageType.Error, Message = $"Xóa Team \"{rs.ResultObj}\" thất bại!" });
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
=======
﻿using VegunSoft.Framework.Base.Entity.Enum;
using VegunSoft.Framework.Base.Entity.Model;
using VegunSoft.Framework.Paging.Provider.Request;
using VegunSoft.Framework.Paging.Provider.Response;
using VSoft.Company.UI.TEA.Team.Business.Service.Services;
using VSoft.Company.UI.TEA.Team.Data.DVO.Data;
using VSoft.Company.UI.TEA.Team.View.Main.Code.Pages;

namespace VSoft.Company.UI.TEA.Team.View.Main.Code.Provider.Pages
{
    public class PageTableServices : IPageTableServices
    {
        protected ITeamBusiness BusinessService { get; set; }
        public List<MMessage> Messages { get; private set; } = new List<MMessage>();
        public string? KeySearch { get; private set; }
        public PagingParameters PageParam { get; private set; } = new PagingParameters();
        public MetaData MetaData { get; private set; } = new MetaData();
        public List<TeamDvo> Teams { get; private set; }

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
            await BusinessService.DeleteTeam(deleteId);
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
>>>>>>> 17258665a6c2edd448073b898dd965c0e0b88037:Code/company/TEA/Team/view/VSoft.Company.UI.TEA.Team.View.Main.Code.Provider/Pages/PageTableServices.cs
