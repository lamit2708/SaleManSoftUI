using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;

namespace VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Code.Pages
{
    public interface IPageDealTagServices
    {
        int? UserId { get; }
        int? TeamId { get; }
        DateTime? Date { get; }
        string? Keyword { get; }
        Dictionary<int, string> UserList { get; }
        Dictionary<int, string> TeamList { get; }
        List<DealTagDvo>? ListDealTag { get; }
        Dictionary<int, string> DealStepDict { get; }

        Task Init();

        Task OnSearch(int? userId, int? teamId, DateTime? date, string? keyword);
    }
}
