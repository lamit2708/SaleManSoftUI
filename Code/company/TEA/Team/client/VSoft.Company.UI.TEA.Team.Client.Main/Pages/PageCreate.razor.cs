using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using VSoft.Company.UI.TEA.Team.Client.Main.Code.Pages;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.Web;

namespace VSoft.Company.UI.TEA.Team.Client.Main.Pages
{
    public partial class PageCreate
    {
        [Inject] protected IPageCreateServices PageServices { get; set; }
        [Inject] IToastService ToastService { get; set; }
        protected string? Name;
        protected string? Description;

        private async Task OnSubmit(MouseEventArgs e)
        {
            var rs = await PageServices.CreateTeams(Name, Description);
            if (rs.Key)
                ToastService.ShowSuccess(rs.Value);
            else
                ToastService.ShowError(rs.Value);
        }
    }
}
