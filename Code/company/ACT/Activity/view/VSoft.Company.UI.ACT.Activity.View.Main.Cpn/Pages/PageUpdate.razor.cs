using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using VegunSoft.Framework.Base.Entity.Enum;
using VSoft.Company.UI.ACT.Activity.Data.DVO.Data;
using VSoft.Company.UI.ACT.Activity.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.ACT.Activity.View.Main.Cpn.Pages
{
    public partial class PageUpdate
    {
        [Inject] protected IPageUpdateServices PageServices { get; set; }
        [Inject] IToastService ToastService { get; set; }

        [Parameter]
        public string? ActivityId { set; get; }


        protected ActivityDvo Activity { get; set; } = new ActivityDvo();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await PageServices.OnInitializedAsync(ActivityId);
            SyncUI();
        }

        protected async Task OnSubmit(MouseEventArgs e)
        {
            await PageServices.OnUpdateActivity(Activity);
            SyncUI();
        }

        protected void SyncUI()
        {
            var sv = PageServices;
            Activity = sv.Activity;
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
