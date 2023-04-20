using Microsoft.AspNetCore.Components;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.Web;
using VSoft.Company.UI.DST.DealStep.View.Main.Cpn.Code.Pages;
using VegunSoft.Framework.Base.Entity.Enum;
using VSoft.Company.UI.DST.DealStep.Data.DVO.Data;
using System.Text;
using VegunSoft.Framework.Value.Password.Methods;

namespace VSoft.Company.UI.DST.DealStep.View.Main.Cpn.Pages
{
    public partial class PageCreate
    {
        //[Inject] protected IPageCreateServices PageServices { get; set; }
        //[Inject] IToastService ToastService { get; set; }
        //protected string? Name;
        //protected string? Description;
        //protected DealStepDvo DealStep { get; set; } = new DealStepDvo();


        //protected async Task OnSubmit(MouseEventArgs e)
        //{
        //    DealStep.TeamId = null;
        //    DealStep.Password = DealStep.Password?.ToMD5();
        //    await PageServices.CreateDealSteps(DealStep);
        //    SyncUI();
        //}
        

        //protected void SyncUI()
        //{
        //    var messages = PageServices.Messages;
        //    if (messages != null && messages.Count > 0)
        //    {
        //        foreach (var message in messages)
        //        {
        //            if (message != null)
        //            {
        //                if (message.Type == EMessageType.Success && !string.IsNullOrEmpty(message.Message))
        //                    ToastService.ShowSuccess(message.Message);
        //                else if (message.Type == EMessageType.Error && !string.IsNullOrEmpty(message.Message))
        //                    ToastService.ShowError(message.Message);
        //            }
        //        }
        //    }
        //}
    }
}
