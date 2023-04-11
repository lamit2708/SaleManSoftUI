using Microsoft.AspNetCore.Components;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;

namespace VSoft.Company.UI.DEA.Deal.View.Share.Components
{
    public partial class DealTagTableView
    {
        [Parameter]
        public Dictionary<string, string>? DealStepDict { get; set; }
        [Parameter]
        public List<DealTagDvo>? ListDealTag { get; set; }
    }
}
