using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Xml.Linq;
using System;
using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;
using VSoft.Company.UI.DEA.Deal.Business.Service.Services;

namespace VSoft.Company.UI.DEA.Deal.View.Share.Components
{
    public partial class DealTagView
    {
        [Inject] protected IDealBusiness BusinessService { get; set; }

        [Parameter]
        public DealTagDvo DealTag { get; set; }

        protected string? Color { get; set; }

        [Parameter]
        public bool IsNextDisable { get; set; }

        [Parameter]
        public bool IsPreviouseDisable { get; set; }

        [Parameter]
        public Action<string>? OnStepChange { get; set; }


        [Parameter]
        public string? DetailPath { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if (DealTag.DealStepId == 2)
                Color = "background-color: #A0D4CD";
            else if (DealTag.DealStepId == 3)
                Color = "background-color: #075B6F; color: white";
            else if (DealTag.DealStepId == 4)
                Color = "background-color: #F79B83";
            else if (DealTag.DealStepId == 5)
                Color = "background-color: #339900; color: white";
            else
                Color = "background-color: #dedede";
        }

        protected async Task OnNext(MouseEventArgs e)
        {
            var rs = await BusinessService.UpdateStepDeal(DealTag.Id, DealTag.DealStepId + 1, DealTag.DealName);
            var message = rs.Message;
            if (rs.IsSuccessed)
            {
                DealTag.DealStepId = DealTag.DealStepId + 1;
                OnStepChange?.Invoke(message);
            }
        }

        protected async Task OnPrevious(MouseEventArgs e)
        {
            var rs = await BusinessService.UpdateStepDeal(DealTag.Id, DealTag.DealStepId - 1, DealTag.DealName);
            var message = rs.Message;
            if (rs.IsSuccessed)
            {
                DealTag.DealStepId = DealTag.DealStepId - 1;
                OnStepChange?.Invoke(message);
            }
        }


        protected string GetDetailPath(long id)
        {
            return $"{DetailPath}/{id}";
        }
    }
}
