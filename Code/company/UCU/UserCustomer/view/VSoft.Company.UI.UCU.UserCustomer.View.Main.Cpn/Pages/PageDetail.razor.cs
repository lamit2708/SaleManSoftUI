using Microsoft.AspNetCore.Components;
using Radzen;

namespace VSoft.Company.UI.UCU.UserCustomer.View.Main.Cpn.Pages
{
    public partial class PageDetail
    {
        [Parameter]
        public string? UserCustomerId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected void OnChange(int index)
        {

        }
    }
}
