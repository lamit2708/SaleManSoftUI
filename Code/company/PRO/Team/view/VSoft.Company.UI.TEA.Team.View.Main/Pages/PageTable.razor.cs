using VSoft.Company.UI.PRO.Team.Data.DVO.Data;
using VegunSoft.Framework.Ui.Component.Popups;
using VegunSoft.Framework.Paging.Provider.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using VSoft.Company.UI.PRO.Team.View.Main.Code.Pages;
using VegunSoft.Framework.Ui.Component.Searchs;
using VegunSoft.Framework.Base.Entity.Enum;

namespace VSoft.Company.UI.PRO.Team.View.Main.Pages
{
    public partial class PageTable
    {
        [Inject] protected IPageTableServices PageServices { get; set; }
        [Inject] IToastService ToastService { get; set; }
        protected List<TeamDvo>? Teams;
        protected Confirmation? DeleteConfirmation { set; get; }
        public MetaData MetaData { get; set; } = new MetaData();
        protected string? KeySearch { get; set; }
        protected int DeleteId { get; set; }
        protected PagingParameters PageParams { get; set; } = new PagingParameters();

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

        protected async Task OnDeleteTask(int deletedId)
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
            Teams = sv.Teams;
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
    }
}
