using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;
using VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Pages
{
    public partial class PageDealTag
    {
        [Inject] protected IPageDealTagServices PageServices { get; set; }
        public int? UserId { get; set; }
        public int? TeamId { get; set; }
        public DateTime? Date { get; set; }
        public string? Keyword { get; set; }
        public Dictionary<int, string> UserList { get; set; }
        public Dictionary<int, string> TeamList { get; set; }
        public List<DealTagDvo>? ListDealTag { get; set; }
        public Dictionary<int, string> DealStepDict { get; set; }

        [Parameter]
        public string? DetailPath { get; set; }
        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await PageServices.Init();
            SyncUI();
        }

        protected async Task OnSearch(MouseEventArgs e)
        {
            await PageServices.OnSearch(UserId, TeamId, Date, Keyword);
            SyncUI();
        }

        protected void SyncUI()
        {
            UserId = PageServices.UserId;
            TeamId = PageServices.TeamId;
            Date = PageServices.Date;
            Keyword = PageServices.Keyword;
            UserList = PageServices.UserList;
            TeamList = PageServices.TeamList;
            ListDealTag = PageServices.ListDealTag;
            DealStepDict = PageServices.DealStepDict;
        }

        
    }
}
