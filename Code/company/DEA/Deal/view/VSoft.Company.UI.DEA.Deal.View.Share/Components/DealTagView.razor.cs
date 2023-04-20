using Microsoft.AspNetCore.Components;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;

namespace VSoft.Company.UI.DEA.Deal.View.Share.Components
{
    public partial class DealTagView
    {
        [Parameter]
        public DealTagDvo DealTag { get; set; }

        protected string? Color { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if (DealTag.DealStepId == 2)
                Color = "background-color: #A0D4CD";
            else if (DealTag.DealStepId == 3)
                Color = "background-color: #075B6F; color: white";
            else if (DealTag.DealStepId == 4)
                Color = "background-color: #F79B83";
            else if (DealTag.DealStepId == 5)
                Color = "background-color: #339900; color: white";
            else
                Color = "background-color: #dedede";

        }
    }
}
