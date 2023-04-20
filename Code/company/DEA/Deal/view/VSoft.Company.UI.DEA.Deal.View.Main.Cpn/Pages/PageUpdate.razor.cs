using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Xml.Linq;
using VegunSoft.Framework.Base.Entity.Enum;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;
using VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Pages
{
    public partial class PageUpdate
    {
        [Inject] protected IPageUpdateServices PageServices { get; set; }
        [Inject] IToastService ToastService { get; set; }

        public int CusId { get; set; }

        [Parameter]
        public string? DealId { set; get; }

        protected DealDvo Deal { get; set; } = new DealDvo();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await PageServices.OnInitializedAsync(DealId);

            SyncUI();
        }

        protected async Task OnSubmit(MouseEventArgs e)
        {
            var dvo = new DealDvo()
            {
                Id = Deal.Id,
                Name = Deal.Name,
                Description = Deal.Description,
                DateFor = Deal.DateFor,
                CreatedDate = Deal.CreatedDate,
                DealStepId = Deal.DealStepId,
                PricePossible = Deal.PricePossible,
                CustomerId = CusId,
                UserId = Deal.UserId,
                OrderId = Deal.OrderId,
                PridictPrice = Deal.PridictPrice
            };
            await PageServices.OnUpdateDeal(dvo);
            SyncUI();
        }

        protected void SyncUI()
        {
            var sv = PageServices;
            Deal = sv.Deal;
            CusId = (int)Deal.CustomerId;
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
