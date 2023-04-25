using Microsoft.AspNetCore.Components;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;

namespace VSoft.Company.UI.DEA.Deal.View.Share.Components
{
    public partial class DealTagTableView
    {
        [Parameter]
        public Dictionary<int, string> DealStepDict { get; set; }
        [Parameter]
        public List<DealTagDvo>? ListDealTag { get; set; }
        [Parameter]
        public string? DetailPath { get; set; }


        protected void OnStepChange(string message)
        {
            StateHasChanged();
        }
        //public Action<string>? OnStepChange { get; set; }
    }
}
