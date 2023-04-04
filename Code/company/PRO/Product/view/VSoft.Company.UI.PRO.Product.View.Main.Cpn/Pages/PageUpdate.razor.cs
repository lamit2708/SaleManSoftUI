using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using VegunSoft.Framework.Base.Entity.Enum;
using VSoft.Company.UI.PRO.Product.Data.DVO.Data;
using VSoft.Company.UI.PRO.Product.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.PRO.Product.View.Main.Cpn.Pages
{
    public partial class PageUpdate
    {
        [Inject] protected IPageUpdateServices PageServices { get; set; }
        [Inject] IToastService ToastService { get; set; }

        [Parameter]
        public string? ProductId { set; get; }


        protected ProductDvo Product { get; set; } = new ProductDvo();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await PageServices.OnInitializedAsync(ProductId);
            SyncUI();
        }

        protected async Task OnSubmit(MouseEventArgs e)
        {
            await PageServices.OnUpdateProduct(ProductId, Product.Name, Product.Description);
            SyncUI();
        }

        protected void SyncUI()
        {
            var sv = PageServices;
            Product = sv.Product;
            if (sv.Messages != null && sv.Messages.Count > 0)
            {
                foreach (var message in sv.Messages)
                {
                    if (message != null)
                    {
                        if (message.Type == EMessageType.Success && !string.IsNullOrEmpty(message.Message))
                            ToastService.ShowSuccess(message.Message);
                        else if (message.Type == EMessageType.Error && !string.IsNullOrEmpty(message.Message))
                            ToastService.ShowError(message.Message);
                    }
                }
            }
        }
    }
}
