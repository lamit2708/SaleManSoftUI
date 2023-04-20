using Microsoft.AspNetCore.Components;
using Radzen;

namespace VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Pages
{
    public partial class PageDetail
    {
        [Parameter]
        public string? DealId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected void OnChange(int index)
        {

        }
    }
}
