using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using VSoft.Company.UI.PRO.Product.Data.DVO.Data;

namespace VSoft.Company.UI.PRO.Product.View.Main.Pages
{
    public partial class PageUpdate
    {
        [Parameter]
        public string ProductId { set; get; }

        private ProductDvo Product;

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private async Task SubmitTask(EditContext context)
        {

        }
    }
}
