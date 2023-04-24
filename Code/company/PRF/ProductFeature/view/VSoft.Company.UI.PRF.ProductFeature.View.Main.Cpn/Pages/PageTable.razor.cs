using VSoft.Company.UI.PRF.ProductFeature.Data.DVO.Data;
using VegunSoft.Framework.Ui.Component.Popups;
using VegunSoft.Framework.Paging.Provider.Response;
using VegunSoft.Framework.Paging.Provider.Request;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using VegunSoft.Framework.Base.Entity.Enum;
using VSoft.Company.UI.PRF.ProductFeature.View.Main.Cpn.Code.Pages;

namespace VSoft.Company.UI.PRF.ProductFeature.View.Main.Cpn.Pages
{
    public partial class PageTable
    {
        [Inject] protected IPageTableServices PageServices { get; set; }
        [Inject] IToastService ToastService { get; set; }
        protected List<ProductFeatureDvo>? ProductFeatures;
        protected Confirmation? DeleteConfirmation { set; get; }
        public MetaData MetaData { get; set; } = new MetaData();
        protected string? KeySearch { get; set; }
        protected int DeleteId { get; set; }
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
            ProductFeatures = sv.ProductFeatures;
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
        //createDeal
        protected string GetCreateDealPath(string id)
        {
            return $"/createDeal/{id}";
        }
        protected string GetUpdatePath(string id)
        {
            return $"/{UpdatePath}/{id}";
        }
        protected string GetModulePath(string name, string productfeatureId)
        {
            return $"/{name}/{productfeatureId}";
        }
        protected string GetDisplayGender(bool? isMale)
        {
            return isMale == true ? " Nam " : " Nữ ";
        }
    }
}
