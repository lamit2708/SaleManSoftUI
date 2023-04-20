using VSoft.Company.UI.DEA.Deal.Business.Service.Services;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;
using VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Code.Provider.Pages
{
    public class PageDealTagServices : IPageDealTagServices
    {
        public IDealBusiness BusinessService { get; set; }
        public int? UserId { get; protected set; }
        public int? TeamId { get; protected set; }
        public DateTime? Date { get; protected set; }
        public string? Keyword { get; protected set; }
        public Dictionary<int, string> UserList { get; protected set; }
        public Dictionary<int, string> TeamList { get; protected set; }
        public List<DealTagDvo>? ListDealTag { get; protected set; }
        public Dictionary<int, string> DealStepDict { get; set; }

        public PageDealTagServices(IDealBusiness service)
        {
            BusinessService = service;
        }

        public async Task Init()
        {
            UserList = new Dictionary<int, string>();
            TeamList = new Dictionary<int, string>();
            var dsrs = await BusinessService.GetDealStep();
            if (dsrs != null)
            {
                DealStepDict = dsrs.ResultObj;
            }
            var rs = await BusinessService.GetDealTagDvo(null, null, null, null);
            if (rs != null && rs.IsSuccessed)
            {
                ListDealTag = rs.ResultObj;
            }
        }

        public async Task OnSearch(int? userId,  int? teamId, DateTime? date, string? keyword)
        {
            UserId = userId;
            TeamId = teamId;
            Date = date;
            Keyword = keyword;
            var rs = await BusinessService.GetDealTagDvo(UserId, TeamId, Date, Keyword);
            if (rs != null && rs.IsSuccessed)
            {
                ListDealTag = rs.ResultObj;
            }
        }
    }
}
