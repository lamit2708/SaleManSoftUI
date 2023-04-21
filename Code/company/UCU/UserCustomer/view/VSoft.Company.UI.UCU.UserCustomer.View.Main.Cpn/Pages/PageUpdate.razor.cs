using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Xml.Linq;
using VegunSoft.Framework.Base.Entity.Enum;
using VSoft.Company.UI.UCU.UserCustomer.Data.DVO.Data;
using VSoft.Company.UI.UCU.UserCustomer.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.UCU.UserCustomer.View.Main.Cpn.Pages
{
    public partial class PageUpdate
    {
        [Inject] protected IPageUpdateServices PageServices { get; set; }
        [Inject] IToastService ToastService { get; set; }

        public int CusId { get; set; }

        [Parameter]
        public string? UserCustomerId { set; get; }

        protected UserCustomerDvo UserCustomer { get; set; } = new UserCustomerDvo();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await PageServices.OnInitializedAsync(UserCustomerId);

            SyncUI();
        }

        protected async Task OnSubmit(MouseEventArgs e)
        {
            var dvo = new UserCustomerDvo()
            {
                Id = UserCustomer.Id,
                //Name = UserCustomer.Name,
                //Description = UserCustomer.Description,
                //DateFor = UserCustomer.DateFor,
                //CreatedDate = UserCustomer.CreatedDate,
                //UserCustomerStepId = UserCustomer.UserCustomerStepId,
                //PricePossible = UserCustomer.PricePossible,
                CustomerId = CusId,
                UserId = UserCustomer.UserId,
                //OrderId = UserCustomer.OrderId,
                //PridictPrice = UserCustomer.PridictPrice
            };
            await PageServices.OnUpdateUserCustomer(dvo);
            SyncUI();
        }

        protected void SyncUI()
        {
            var sv = PageServices;
            UserCustomer = sv.UserCustomer;
            CusId = (int)UserCustomer.CustomerId;
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
