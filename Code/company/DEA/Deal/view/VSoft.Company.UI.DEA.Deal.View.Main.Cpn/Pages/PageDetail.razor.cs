using Microsoft.AspNetCore.Components;
using Radzen;

namespace VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Pages
{
    public partial class PageDetail
    {
        [Parameter]
        public string? DealId { get; set; }

        public Dictionary<int, string> DealStepDict { get; set; }


        protected DateTime Date { get; set; } = DateTime.Now;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Date = DateTime.Now;
        }

        protected void OnChange(int index)
        {

        }
    }
}
