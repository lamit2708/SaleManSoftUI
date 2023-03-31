using Microsoft.AspNetCore.Components;
using VSoft.Company.UI.TEA.Team.View.Main.Code.Pages;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.Web;

namespace VSoft.Company.UI.TEA.Team.View.Main.Pages
{
    public partial class PageCreate
    {
        [Inject] protected IPageCreateServices PageServices { get; set; }
        [Inject] IToastService ToastService { get; set; }
        protected string? Name;
        protected string? Description;

        protected async Task OnSubmit(MouseEventArgs e)
        {
            await PageServices.CreateTeams(Name, Description);
            SyncUI();
        }

        protected void SyncUI()
        {
            var message = PageServices.PageMessage.FirstOrDefault();
            if (PageServices.IsSuccess)
                ToastService.ShowSuccess(message ?? string.Empty);
            else
                ToastService.ShowError(message ?? string.Empty);
        }
    }
}
