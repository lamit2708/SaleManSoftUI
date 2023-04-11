﻿using Microsoft.AspNetCore.Components;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.Web;
using VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Code.Pages;
using VegunSoft.Framework.Base.Entity.Enum;

namespace VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Pages
{
    public partial class PageCreate
    {
        [Inject] protected IPageCreateServices PageServices { get; set; }
        [Inject] IToastService ToastService { get; set; }
        protected string? Name;
        protected string? Description;
        protected DateTime? DateFor = DateTime.Now;
        protected double? PredictPrice = 0;
        protected double? PricePossible = 0;

        protected async Task OnSubmit(MouseEventArgs e)
        {
            await PageServices.CreateDeals(Name, Description);
            SyncUI();
        }

        protected void SyncUI()
        {
            var messages = PageServices.Messages;
            if (messages != null && messages.Count > 0)
            {
                foreach (var message in messages)
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