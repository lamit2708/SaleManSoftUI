using VSoft.Company.UI.DEA.Deal.Data.DVO.Data;
using VegunSoft.Framework.Ui.Component.Popups;
using VegunSoft.Framework.Paging.Provider.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using VegunSoft.Framework.Base.Entity.Enum;
using VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.DEA.Deal.View.Main.Cpn.Pages
{
    public partial class PageTable
    {
        [Inject] protected IPageTableServices PageServices { get; set; }
        [Inject] IToastService ToastService { get; set; }
        protected List<DealDvo>? Deals;
        protected Confirmation? DeleteConfirmation { set; get; }
        public MetaData MetaData { get; set; } = new MetaData();
        protected string? KeySearch { get; set; }
        protected long DeleteId { get; set; }
        protected PagingParameters PageParams { get; set; } = new PagingParameters();
        [Parameter]
        public string? UpdatePath { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await PageServices.OnInitializedAsync();
            SyncUI();
        }

        protected async Task OnSearch(string keySearch)
        {
            await PageServices.OnSearch(keySearch);
            SyncUI();
        }

        protected async Task OnDeleteTask(long deletedId)
        {
            DeleteId = deletedId;
            DeleteConfirmation.Show();
        }

        public async Task OnConfirmDeleteTask(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await PageServices.OnDeleteTask(DeleteId);
                SyncUI();
            }
        }

        protected async Task OnPageSelect(int selectedPage)
        {
            await PageServices.OnPageSelect(selectedPage);
            SyncUI();
        }

        protected void SyncUI()
        {
            var sv = PageServices;
            Deals = sv.Deals;
            MetaData = sv.MetaData;
            KeySearch = sv.KeySearch;
            PageParams = sv.PageParam;
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

        protected string GetUpdatePath(string id)
        {
            return $"/{UpdatePath}/{id}";
        }
    }
}
